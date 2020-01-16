using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Synthexer.Core
{
	[SuppressMessage("ReSharper", "UnassignedField.Global")]
	internal static class SynthexerClassificationTypes
	{
#pragma warning disable CS0649

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.Comment)]
		internal static ClassificationTypeDefinition Comment;

		// [Export(typeof(ClassificationTypeDefinition))]
		// [Name(ClassificationTypeNamesEx.ExcludedCode)]
		// internal static ClassificationTypeDefinition ExcludedCode;

		// [Export(typeof(ClassificationTypeDefinition))]
		// [Name(ClassificationTypeNamesEx.Identifier)]
		// internal static ClassificationTypeDefinition Identifier;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.Keyword)]
		internal static ClassificationTypeDefinition Keyword;

		// [Export(typeof(ClassificationTypeDefinition))]
		// [Name(ClassificationTypeNamesEx.ControlKeyword)]
		// internal static ClassificationTypeDefinition ControlKeyword;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.NumericLiteral)]
		internal static ClassificationTypeDefinition NumericLiteral;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.Operator)]
		internal static ClassificationTypeDefinition Operator;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.OperatorOverloaded)]
		internal static ClassificationTypeDefinition OperatorOverloaded;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.PreprocessorKeyword)]
		internal static ClassificationTypeDefinition PreprocessorDirectiveType;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.StringLiteral)]
		internal static ClassificationTypeDefinition StringLiteral;
		//
		// [Export(typeof(ClassificationTypeDefinition))]
		// [Name(ClassificationTypeNamesEx.WhiteSpace)]
		// internal static ClassificationTypeDefinition WhiteSpace;
		//
		// [Export(typeof(ClassificationTypeDefinition))]
		// [Name(ClassificationTypeNamesEx.Text)]
		// internal static ClassificationTypeDefinition Text;
		//
		// [Export(typeof(ClassificationTypeDefinition))]
		// [Name(ClassificationTypeNamesEx.StaticSymbol)]
		// internal static ClassificationTypeDefinition StaticSymbol;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.PreprocessorText)]
		internal static ClassificationTypeDefinition PreprocessorText;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.Punctuation)]
		internal static ClassificationTypeDefinition Punctuation;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.VerbatimStringLiteral)]
		internal static ClassificationTypeDefinition VerbatimStringLiteral;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.StringEscapeCharacter)]
		internal static ClassificationTypeDefinition StringEscapeCharacter;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.ClassName)]
		internal static ClassificationTypeDefinition ClassName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.DelegateName)]
		internal static ClassificationTypeDefinition DelegateName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.EnumName)]
		internal static ClassificationTypeDefinition EnumName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.InterfaceName)]
		internal static ClassificationTypeDefinition InterfaceName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.StructName)]
		internal static ClassificationTypeDefinition StructName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.TypeParameterName)]
		internal static ClassificationTypeDefinition TypeParameterName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.FieldName)]
		internal static ClassificationTypeDefinition FieldName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.EnumMemberName)]
		internal static ClassificationTypeDefinition EnumMemberName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.ConstantName)]
		internal static ClassificationTypeDefinition ConstantName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.LocalName)]
		internal static ClassificationTypeDefinition LocalName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.ParameterName)]
		internal static ClassificationTypeDefinition ParameterName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.MethodName)]
		internal static ClassificationTypeDefinition MethodName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.ExtensionMethodName)]
		internal static ClassificationTypeDefinition ExtensionMethodName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.PropertyName)]
		internal static ClassificationTypeDefinition PropertyName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.EventName)]
		internal static ClassificationTypeDefinition EventName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.NamespaceName)]
		internal static ClassificationTypeDefinition NamespaceName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.LabelName)]
		internal static ClassificationTypeDefinition LabelName;

		// =====================================================================================================================

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.StaticClassName)]
		internal static ClassificationTypeDefinition StaticClassName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.AttributeName)]
		internal static ClassificationTypeDefinition AttributeName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.StaticMethodName)]
		internal static ClassificationTypeDefinition StaticMethodName;

		[Export(typeof(ClassificationTypeDefinition))]
		[Name(ClassificationTypeNamesEx.LocalFunctionName)]
		internal static ClassificationTypeDefinition LocalFunctionName;

		
#pragma warning restore CS0649
	}
}