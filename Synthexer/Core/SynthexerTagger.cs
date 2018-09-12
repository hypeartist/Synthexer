using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Synthexer.Misc;
using ArgumentSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentSyntax;
using SyntaxKind = Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace Synthexer.Core
{
	internal class SynthexerTagger : ITagger<IClassificationTag>
	{
		private readonly IClassificationType _namespaceType;
		private readonly IClassificationType _interfaceType;
		private readonly IClassificationType _classType;
		private readonly IClassificationType _structType;
		private readonly IClassificationType _fieldType;
		private readonly IClassificationType _propertyType;
		private readonly IClassificationType _constantType;
		private readonly IClassificationType _enumType;
		private readonly IClassificationType _enumFieldType;
        private readonly IClassificationType _attributeType;
        private readonly IClassificationType _methodType;
		private readonly IClassificationType _staticMethodType;
		private readonly IClassificationType _extensionMethodType;
		private readonly IClassificationType _localFunctionType;
		private readonly IClassificationType _parameterType;
		private readonly IClassificationType _typeParameterType;
		private readonly IClassificationType _localVariableType;
		private readonly IClassificationType _delegateType;
		private readonly IClassificationType _eventType;
		private readonly IClassificationType _preprocessorDirectiveType;
		
		private readonly ITextBuffer _theBuffer;
		private Cache _cache;

		internal SynthexerTagger(ITextBuffer buffer, IClassificationTypeRegistryService registry)
		{
			_theBuffer = buffer;
			_namespaceType = registry.GetClassificationType(SynthexerConstants.Namespace);
			_interfaceType = registry.GetClassificationType(SynthexerConstants.Interface);
			_classType = registry.GetClassificationType(SynthexerConstants.Class);
			_structType = registry.GetClassificationType(SynthexerConstants.Struct);
			_fieldType = registry.GetClassificationType(SynthexerConstants.Field);
			_propertyType = registry.GetClassificationType(SynthexerConstants.Property);
			_constantType = registry.GetClassificationType(SynthexerConstants.Constant);
			_enumType = registry.GetClassificationType(SynthexerConstants.Enum);
			_enumFieldType = registry.GetClassificationType(SynthexerConstants.EnumValue);
            _attributeType = registry.GetClassificationType(SynthexerConstants.Attribute);
            _methodType = registry.GetClassificationType(SynthexerConstants.Method);
			_staticMethodType = registry.GetClassificationType(SynthexerConstants.StaticMethod);
			_extensionMethodType = registry.GetClassificationType(SynthexerConstants.ExtensionMethod);
			_localFunctionType = registry.GetClassificationType(SynthexerConstants.LocalFunction);
			_parameterType = registry.GetClassificationType(SynthexerConstants.Parameter);
			_typeParameterType = registry.GetClassificationType(SynthexerConstants.TypeParameter);
			_localVariableType = registry.GetClassificationType(SynthexerConstants.LocalVariable);
			_delegateType = registry.GetClassificationType(SynthexerConstants.Delegate);
			_eventType = registry.GetClassificationType(SynthexerConstants.Event);
			_preprocessorDirectiveType = registry.GetClassificationType(SynthexerConstants.PreprocessorDirective);
		}
#pragma warning disable CS0067
		public event EventHandler<SnapshotSpanEventArgs> TagsChanged;
#pragma warning restore CS0067

		public IEnumerable<ITagSpan<IClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
		{
			if (spans.Count == 0)
			{
				return Enumerable.Empty<ITagSpan<IClassificationTag>>();
			}

			if (_cache != null && _cache.Snapshot == spans[0].Snapshot)
			{
				return GetTagsImpl(_cache, spans);
			}

			// this makes me feel dirty, but otherwise it will not
			// work reliably, as TryGetSemanticModel() often will return false
			// should make this into a completely async process somehow
			var task = Cache.ResolveAsync(_theBuffer, spans[0].Snapshot);
			try
			{
#pragma warning disable VSTHRD002 // Avoid problematic synchronous waits
				task.Wait();

			}
			catch (Exception)
			{
				return Enumerable.Empty<ITagSpan<IClassificationTag>>();
			}

			_cache = task.Result;
#pragma warning restore VSTHRD002 // Avoid problematic synchronous waits
			return _cache == null ? Enumerable.Empty<ITagSpan<IClassificationTag>>() : GetTagsImpl(_cache, spans);
        }

        private class PreprocessorTriviaFinder : CSharpSyntaxRewriter
        {
            public override SyntaxTrivia VisitTrivia(SyntaxTrivia trivia)
            {
                if (trivia.IsDirective)
                {
                    HasPreprocessorDirective = true;
                }

                return trivia;
            }

            public bool HasPreprocessorDirective { get; private set; }
        }

        private IEnumerable<ITagSpan<IClassificationTag>> GetTagsImpl(Cache doc, NormalizedSnapshotSpanCollection spans)
		{			
			var snapshot = spans[0].Snapshot;

			var classifiedSpans = GetClassifiedSpans(doc.Workspace, doc.SemanticModel, spans);
            var isInsidePreprocessorDirective = false;
            foreach (var span in classifiedSpans)
            {
                var node = GetExpression(doc.SyntaxRoot.FindNode(span.TextSpan));
                var symbol = doc.SemanticModel.GetSymbolInfo(node).Symbol ?? doc.SemanticModel.GetDeclaredSymbol(node);
                if (span.ClassificationType == ClassificationTypeNames.PreprocessorKeyword)
                {
                    var triviaFinder = new PreprocessorTriviaFinder();
                    triviaFinder.Visit(node);
                    if (triviaFinder.HasPreprocessorDirective)
                    {
                        isInsidePreprocessorDirective = true;
                        yield return span.TextSpan.ToTagSpan(snapshot, _preprocessorDirectiveType);
                        continue;
                    }
                }
				if (isInsidePreprocessorDirective)
				{
					yield return span.TextSpan.ToTagSpan(snapshot, _preprocessorDirectiveType);
					continue;
				}
				if (symbol == null) continue;

				switch (symbol.Kind)
				{
                    case SymbolKind.Field:
						switch (span.ClassificationType)
						{
                            case SynthexerConstants.Constant:
								yield return span.TextSpan.ToTagSpan(snapshot, _constantType);
								break;
							case SynthexerConstants.Field:
								yield return span.TextSpan.ToTagSpan(snapshot, _fieldType);
								break;
							case SynthexerConstants.EnumValue:
								yield return span.TextSpan.ToTagSpan(snapshot, _enumFieldType);
								break;
						}

						break;
					case SymbolKind.Method:
                        if (span.ClassificationType == ClassificationTypeNames.ClassName)
                        {
                            yield return span.TextSpan.ToTagSpan(snapshot, _attributeType);
                            break;
                        }
						var methodSymbol = (IMethodSymbol) symbol;
                        if (methodSymbol.IsExtensionMethod)
                        {
                            yield return span.TextSpan.ToTagSpan(snapshot, _extensionMethodType);
                            break;
                        }
                        if (methodSymbol.IsStatic)
                        {
                            yield return span.TextSpan.ToTagSpan(snapshot, _staticMethodType);
                            break;
                        }
                        switch (methodSymbol.MethodKind)
						{
							case MethodKind.AnonymousFunction:
								break;
							case MethodKind.Ordinary:
                                yield return span.TextSpan.ToTagSpan(snapshot, _methodType);
								break;
							case MethodKind.Constructor:
							case MethodKind.Destructor:
							case MethodKind.StaticConstructor:
								if (methodSymbol.ContainingType.IsReferenceType)
								{
									yield return span.TextSpan.ToTagSpan(snapshot, _classType);
								}
								else
								{
									yield return span.TextSpan.ToTagSpan(snapshot, _structType);
								}
								break;
							case MethodKind.LocalFunction:
								yield return span.TextSpan.ToTagSpan(snapshot, _localFunctionType);
								break;
							default:
								yield return span.TextSpan.ToTagSpan(snapshot, _methodType);
								break;
						}
						break;
					case SymbolKind.Parameter:
						yield return span.TextSpan.ToTagSpan(snapshot, _parameterType);
						break;
					case SymbolKind.TypeParameter:
						yield return span.TextSpan.ToTagSpan(snapshot, _typeParameterType);
						break;
					case SymbolKind.Namespace:
						yield return span.TextSpan.ToTagSpan(snapshot, _namespaceType);
						break;
					case SymbolKind.Property:
						yield return span.TextSpan.ToTagSpan(snapshot, _propertyType);
						break;
					case SymbolKind.Local:
						yield return span.TextSpan.ToTagSpan(snapshot, _localVariableType);
						break;
					case SymbolKind.Event:
						yield return span.TextSpan.ToTagSpan(snapshot, _eventType);
						break;
					case SymbolKind.NamedType:
						switch (span.ClassificationType)
						{
                            case SynthexerConstants.Class:
								yield return span.TextSpan.ToTagSpan(snapshot, _classType);
								break;
							case SynthexerConstants.Struct:
								yield return span.TextSpan.ToTagSpan(snapshot, _structType);
								break;
							case SynthexerConstants.Enum:
								yield return span.TextSpan.ToTagSpan(snapshot, _enumType);
								break;
							case SynthexerConstants.Interface:
								yield return span.TextSpan.ToTagSpan(snapshot, _interfaceType);
								break;
							case SynthexerConstants.Delegate:
								yield return span.TextSpan.ToTagSpan(snapshot, _delegateType);
								break;
						}
						break;
				}
			}
		}

		private static SyntaxNode GetExpression(SyntaxNode node)
        {
            return node.CSharpKind() == SyntaxKind.Argument ? ((ArgumentSyntax) node).Expression : (node.CSharpKind() == SyntaxKind.AttributeArgument ? ((AttributeArgumentSyntax) node).Expression : node);
        }

		private static IEnumerable<ClassifiedSpan> GetClassifiedSpans(Workspace workspace, SemanticModel model, NormalizedSnapshotSpanCollection spans)
		{
			var comparer = StringComparer.InvariantCultureIgnoreCase;
			var classifiedSpans = spans.SelectMany(span =>
			{
				var textSpan = TextSpan.FromBounds(span.Start, span.End);
				return Classifier.GetClassifiedSpans(model, textSpan, workspace);
			});
            // ReSharper disable once PossibleUnintendedLinearSearchInSet
            return classifiedSpans.Where(span => span.ClassificationType == ClassificationTypeNames.Identifier || SynthexerConstants.All.Select(a => a.classificationId).Contains(span.ClassificationType, comparer));
        }

		private class Cache
		{
			private Cache()
			{
			}

			public Workspace Workspace { get; private set; }
			
			public SemanticModel SemanticModel { get; private set; }
			
			public SyntaxNode SyntaxRoot { get; private set; }

			public ITextSnapshot Snapshot { get; private set; }

			public static async Task<Cache> ResolveAsync(ITextBuffer buffer, ITextSnapshot snapshot)
			{
				var workspace = buffer.GetWorkspace();
				var document = snapshot.GetOpenDocumentInCurrentContextWithChanges();
				if (document == null)
				{
					return null;
				}

				// the ConfigureAwait() calls are important,
				// otherwise we'll deadlock VS
				var semanticModel = await document.GetSemanticModelAsync().ConfigureAwait(false);
				var syntaxRoot = await document.GetSyntaxRootAsync().ConfigureAwait(false);
				return new Cache
				{
					Workspace = workspace,
					SemanticModel = semanticModel,
					SyntaxRoot = syntaxRoot,
					Snapshot = snapshot
				};
			}
		}
	}
}