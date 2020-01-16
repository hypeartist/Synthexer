using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
		private readonly IClassificationType _comment;
		// private readonly IClassificationType _excludedCode;
		// private readonly IClassificationType _identifier;
		private readonly IClassificationType _keyword;
		// private readonly IClassificationType _controlKeyword;
		private readonly IClassificationType _numericLiteral;
		private readonly IClassificationType _operator;
		private readonly IClassificationType _operatorOverloaded;
		private readonly IClassificationType _preprocessorKeyword;
		private readonly IClassificationType _stringLiteral;
		// private readonly IClassificationType _whiteSpace;
		// private readonly IClassificationType _text;
		// private readonly IClassificationType _staticSymbol;
		private readonly IClassificationType _preprocessorText;
		private readonly IClassificationType _punctuation;
		private readonly IClassificationType _verbatimStringLiteral;
		private readonly IClassificationType _stringEscapeCharacter;
		private readonly IClassificationType _className;
		private readonly IClassificationType _delegateName;
		private readonly IClassificationType _enumName;
		private readonly IClassificationType _interfaceName;
		private readonly IClassificationType _structName;
		private readonly IClassificationType _typeParameterName;
		private readonly IClassificationType _fieldName;
		private readonly IClassificationType _enumMemberName;
		private readonly IClassificationType _constantName;
		private readonly IClassificationType _localName;
		private readonly IClassificationType _parameterName;
		private readonly IClassificationType _methodName;
		private readonly IClassificationType _extensionMethodName;
		private readonly IClassificationType _propertyName;
		private readonly IClassificationType _eventName;
		private readonly IClassificationType _namespace;
		private readonly IClassificationType _labelName;

		// =====================================================================================================================

		private readonly IClassificationType _staticClassName;
        private readonly IClassificationType _attributeName;
		private readonly IClassificationType _staticMethodName;
		private readonly IClassificationType _localFunctionName;
		
		private readonly ITextBuffer _theBuffer;
		private Cache _cache;

		internal SynthexerTagger(ITextBuffer buffer, IClassificationTypeRegistryService registry)
		{
			_theBuffer = buffer;

			_comment = registry.GetClassificationType(ClassificationTypeNamesEx.Comment);
			// _excludedCode = registry.GetClassificationType(ClassificationTypeNamesEx.ExcludedCode);
			// _identifier = registry.GetClassificationType(ClassificationTypeNamesEx.Identifier);
			_keyword = registry.GetClassificationType(ClassificationTypeNamesEx.Keyword);
			// _controlKeyword = registry.GetClassificationType(ClassificationTypeNamesEx.ControlKeyword);
			_numericLiteral = registry.GetClassificationType(ClassificationTypeNamesEx.NumericLiteral);
			_operator = registry.GetClassificationType(ClassificationTypeNamesEx.Operator);
			_operatorOverloaded = registry.GetClassificationType(ClassificationTypeNamesEx.OperatorOverloaded);
			_preprocessorKeyword = registry.GetClassificationType(ClassificationTypeNamesEx.PreprocessorKeyword);
			_stringLiteral = registry.GetClassificationType(ClassificationTypeNamesEx.StringLiteral);
			// _whiteSpace = registry.GetClassificationType(ClassificationTypeNamesEx.WhiteSpace);
			// _text = registry.GetClassificationType(ClassificationTypeNamesEx.Text);
			// _staticSymbol = registry.GetClassificationType(ClassificationTypeNamesEx.StaticSymbol);
			_preprocessorText = registry.GetClassificationType(ClassificationTypeNamesEx.PreprocessorText);
			_punctuation = registry.GetClassificationType(ClassificationTypeNamesEx.Punctuation);
			_verbatimStringLiteral = registry.GetClassificationType(ClassificationTypeNamesEx.VerbatimStringLiteral);
			_stringEscapeCharacter = registry.GetClassificationType(ClassificationTypeNamesEx.StringEscapeCharacter);
			_className = registry.GetClassificationType(ClassificationTypeNamesEx.ClassName);
			_delegateName = registry.GetClassificationType(ClassificationTypeNamesEx.DelegateName);
			_enumName = registry.GetClassificationType(ClassificationTypeNamesEx.EnumName);
			_interfaceName = registry.GetClassificationType(ClassificationTypeNamesEx.InterfaceName);
			_structName = registry.GetClassificationType(ClassificationTypeNamesEx.StructName);
			_typeParameterName = registry.GetClassificationType(ClassificationTypeNamesEx.TypeParameterName);
			_fieldName = registry.GetClassificationType(ClassificationTypeNamesEx.FieldName);
			_enumMemberName = registry.GetClassificationType(ClassificationTypeNamesEx.EnumMemberName);
			_constantName = registry.GetClassificationType(ClassificationTypeNamesEx.ConstantName);
			_localName = registry.GetClassificationType(ClassificationTypeNamesEx.LocalName);
			_parameterName = registry.GetClassificationType(ClassificationTypeNamesEx.ParameterName);
			_methodName = registry.GetClassificationType(ClassificationTypeNamesEx.MethodName);
			_extensionMethodName = registry.GetClassificationType(ClassificationTypeNamesEx.ExtensionMethodName);
			_propertyName = registry.GetClassificationType(ClassificationTypeNamesEx.PropertyName);
			_eventName = registry.GetClassificationType(ClassificationTypeNamesEx.EventName);
			_namespace = registry.GetClassificationType(ClassificationTypeNamesEx.NamespaceName);
			_labelName = registry.GetClassificationType(ClassificationTypeNamesEx.LabelName);

			// =====================================================================================================================

			_staticClassName = registry.GetClassificationType(ClassificationTypeNamesEx.StaticClassName);
            _attributeName = registry.GetClassificationType(ClassificationTypeNamesEx.AttributeName);
			_staticMethodName = registry.GetClassificationType(ClassificationTypeNamesEx.StaticMethodName);
			_localFunctionName = registry.GetClassificationType(ClassificationTypeNamesEx.LocalFunctionName);
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
	            if (span.IsOfType(ClassificationTypeNamesEx.Keyword))
	            {
					yield return span.TextSpan.ToTagSpan(snapshot, _keyword);
					continue;
				}
	            if (span.IsOfType(ClassificationTypeNamesEx.NumericLiteral))
	            {
		            yield return span.TextSpan.ToTagSpan(snapshot, _numericLiteral);
		            continue;
	            }
	            if (span.IsOfType(ClassificationTypeNamesEx.StringLiteral))
	            {
		            yield return span.TextSpan.ToTagSpan(snapshot, _stringLiteral);
		            continue;
	            }
	            if (span.IsOfType(ClassificationTypeNamesEx.VerbatimStringLiteral))
	            {
		            yield return span.TextSpan.ToTagSpan(snapshot, _verbatimStringLiteral);
		            continue;
	            }
	            if (span.IsOfType(ClassificationTypeNamesEx.StringEscapeCharacter))
	            {
		            yield return span.TextSpan.ToTagSpan(snapshot, _stringEscapeCharacter);
		            continue;
	            }
	            if (span.IsOfType(ClassificationTypeNamesEx.Operator))
	            {
		            yield return span.TextSpan.ToTagSpan(snapshot, _operator);
		            continue;
	            }
	            if (span.IsOfType(ClassificationTypeNamesEx.StringLiteral))
	            {
		            yield return span.TextSpan.ToTagSpan(snapshot, _operatorOverloaded);
		            continue;
	            }
	            if (span.IsOfType(ClassificationTypeNamesEx.Punctuation))
	            {
		            yield return span.TextSpan.ToTagSpan(snapshot, _punctuation);
		            continue;
	            }
				if (span.IsOfType(ClassificationTypeNamesEx.Comment))
	            {
		            yield return span.TextSpan.ToTagSpan(snapshot, _comment);
		            continue;
	            }

				var node = GetExpression(doc.SyntaxRoot.FindNode(span.TextSpan));
                var symbol = doc.SemanticModel.GetSymbolInfo(node).Symbol ?? doc.SemanticModel.GetDeclaredSymbol(node);
                if (span.IsOfType(ClassificationTypeNamesEx.PreprocessorKeyword))
                {
                    var triviaFinder = new PreprocessorTriviaFinder();
                    triviaFinder.Visit(node);
                    if (triviaFinder.HasPreprocessorDirective)
                    {
                        isInsidePreprocessorDirective = true;
                        yield return span.TextSpan.ToTagSpan(snapshot, _preprocessorKeyword);
                        continue;
                    }
                }
                if (isInsidePreprocessorDirective)
				{
					yield return span.TextSpan.ToTagSpan(snapshot, _preprocessorKeyword);
					continue;
				}

                if (symbol == null)
                {
	                yield return span switch
	                {
		                _ when span.IsOfType(ClassificationTypeNamesEx.ClassName) => span.TextSpan.ToTagSpan(snapshot, _className),
		                _ when span.IsOfType(ClassificationTypeNamesEx.InterfaceName) => span.TextSpan.ToTagSpan(snapshot, _interfaceName),
		                _ => null
	                };
					continue;
				}
				switch (symbol.Kind)
				{
					case SymbolKind.Field:
						yield return span.ClassificationType switch
						{
							_ when span.IsOfType(ClassificationTypeNamesEx.ConstantName) => span.TextSpan.ToTagSpan(snapshot, _constantName),
							_ when span.IsOfType(ClassificationTypeNamesEx.FieldName) => span.TextSpan.ToTagSpan(snapshot, _fieldName),
							_ when span.IsOfType(ClassificationTypeNamesEx.EnumMemberName) => span.TextSpan.ToTagSpan(snapshot, _enumMemberName),
							_ => null
						};
						break;
					case SymbolKind.Method:
						var methodSymbol = (IMethodSymbol) symbol;
                        if (methodSymbol.IsExtensionMethod)
                        {
                            yield return span.TextSpan.ToTagSpan(snapshot, _extensionMethodName);
                            break;
                        }
						if (methodSymbol.IsStatic)
                        {
                            yield return span.TextSpan.ToTagSpan(snapshot, _staticMethodName);
                            break;
                        }
                        switch (methodSymbol.MethodKind)
						{
							case MethodKind.AnonymousFunction:
							case MethodKind.Ordinary:
                                yield return span.TextSpan.ToTagSpan(snapshot, _methodName);
								break;
							case MethodKind.Constructor:
							case MethodKind.Destructor:
							case MethodKind.StaticConstructor:
								if (methodSymbol.ContainingType.IsAttribute())
								{
									yield return span.TextSpan.ToTagSpan(snapshot, _attributeName);
									break;
								}

								if (methodSymbol.ContainingType.IsReferenceType)
								{
									yield return span.TextSpan.ToTagSpan(snapshot, _className);
								}
								else
								{
									yield return span.TextSpan.ToTagSpan(snapshot, _structName);
								}
								break;
							case MethodKind.LocalFunction:
								yield return span.TextSpan.ToTagSpan(snapshot, _localFunctionName);
								break;
							default:
								yield return span.TextSpan.ToTagSpan(snapshot, _methodName);
								break;
						}
						break;
					case SymbolKind.Parameter:
						yield return span.TextSpan.ToTagSpan(snapshot, _parameterName);
						break;
					case SymbolKind.TypeParameter:
						yield return span.TextSpan.ToTagSpan(snapshot, _typeParameterName);
						break;
					case SymbolKind.Namespace:
						yield return span.TextSpan.ToTagSpan(snapshot, _namespace);
						break;
					case SymbolKind.Property:
						yield return span.TextSpan.ToTagSpan(snapshot, _propertyName);
						break;
					case SymbolKind.Local:
						yield return span.TextSpan.ToTagSpan(snapshot, _localName);
						break;
					case SymbolKind.Event:
						yield return span.TextSpan.ToTagSpan(snapshot, _eventName);
						break;
					case SymbolKind.NamedType:
						yield return span.ClassificationType switch
						{
							_ when span.IsOfType(ClassificationTypeNamesEx.ClassName) => span.TextSpan.ToTagSpan(snapshot, ((INamedTypeSymbol)symbol).IsStatic ? _staticClassName : _className),
							_ when span.IsOfType(ClassificationTypeNamesEx.StructName) => span.TextSpan.ToTagSpan(snapshot, _structName),
							_ when span.IsOfType(ClassificationTypeNamesEx.EnumName) => span.TextSpan.ToTagSpan(snapshot, _enumName),
							_ when span.IsOfType(ClassificationTypeNamesEx.InterfaceName) => span.TextSpan.ToTagSpan(snapshot, _interfaceName),
							_ when span.IsOfType(ClassificationTypeNamesEx.DelegateName) => span.TextSpan.ToTagSpan(snapshot, _delegateName),
							_ => null
						};
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
			}).ToList();
            // ReSharper disable once PossibleUnintendedLinearSearchInSet
            var customCls = ClassificationTypeNamesEx.All().Select(a => a.classification).ToList();
			foreach (ClassifiedSpan span in classifiedSpans)
            {
	            var isCustom = false;//SynthexerConstants.All.Select(a => a.classificationId).Contains(span.ClassificationType, comparer);
	            foreach (var cid in customCls)
	            {
		            if (/*!cid.Contains(SynthexerConstants.ScopeName) || */!cid.Contains(span.ClassificationType)) continue;
		            isCustom = true;
		            break;
	            }
				if (span.ClassificationType == ClassificationTypeNames.Identifier || isCustom) yield return span;
            }
			// return classifiedSpans;
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

	public static class ClassifiedSpanEx
	{
		public static bool IsOfType(this ClassifiedSpan span, string classification)
		{
			return string.Equals(span.ClassificationType, ClassificationTypeNamesEx.Normalize(classification), StringComparison.InvariantCultureIgnoreCase);
		}
	}
}