using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Synthexer.Core
{
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.Comment)]
	// [Name(ClassificationTypeNamesEx.Comment)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class CommentFormat : ClassificationFormatDefinition
	// {
	// 	public CommentFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.Comment);
	// 		ForegroundBrush = Brushes.DarkGray;
	// 	}
	// }
	//
	// // [Export(typeof(EditorFormatDefinition))]
	// // [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.ExcludedCode)]
	// // [Name(ClassificationTypeNamesEx.ExcludedCode)]
	// // [UserVisible(false)]
	// // [Order(After = Priority.High)]
	// // internal sealed class ExcludedCodeFormat : ClassificationFormatDefinition
	// // {
	// // 	public ExcludedCodeFormat()
	// // 	{
	// // 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.ExcludedCode);
	// // 		ForegroundBrush = Brushes.DarkGray;
	// // 	}
	// // }
	//
	// // [Export(typeof(EditorFormatDefinition))]
	// // [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.Identifier)]
	// // [Name(ClassificationTypeNamesEx.Identifier)]
	// // [UserVisible(false)]
	// // [Order(After = Priority.High)]
	// // internal sealed class IdentifierFormat : ClassificationFormatDefinition
	// // {
	// // 	public IdentifierFormat()
	// // 	{
	// // 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.Identifier);
	// // 		ForegroundBrush = Brushes.Black;
	// // 	}
	// // }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.Keyword)]
	// [Name(ClassificationTypeNamesEx.Keyword)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class KeywordFormat : ClassificationFormatDefinition
	// {
	// 	public KeywordFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.Keyword);
	// 		ForegroundBrush = Brushes.Blue;
	// 	}
	// }
	//
	// // [Export(typeof(EditorFormatDefinition))]
	// // [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.ControlKeyword)]
	// // [Name(ClassificationTypeNamesEx.ControlKeyword)]
	// // [UserVisible(false)]
	// // [Order(After = Priority.High)]
	// // internal sealed class ControlKeywordFormat : ClassificationFormatDefinition
	// // {
	// // 	public ControlKeywordFormat()
	// // 	{
	// // 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.ControlKeyword);
	// // 		ForegroundBrush = Brushes.Blue;
	// // 	}
	// // }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.NumericLiteral)]
	// [Name(ClassificationTypeNamesEx.NumericLiteral)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class NumericLiteralFormat : ClassificationFormatDefinition
	// {
	// 	public NumericLiteralFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.NumericLiteral);
	// 		ForegroundBrush = Brushes.Red;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.Operator)]
	// [Name(ClassificationTypeNamesEx.Operator)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class OperatorFormat : ClassificationFormatDefinition
	// {
	// 	public OperatorFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.Operator);
	// 		ForegroundBrush = Brushes.DarkOrange;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.OperatorOverloaded)]
	// [Name(ClassificationTypeNamesEx.OperatorOverloaded)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class OperatorOverloadedFormat : ClassificationFormatDefinition
	// {
	// 	public OperatorOverloadedFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.OperatorOverloaded);
	// 		ForegroundBrush = Brushes.DarkOrange;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.PreprocessorKeyword)]
	// [Name(ClassificationTypeNamesEx.PreprocessorKeyword)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class PreprocessorKeywordFormat : ClassificationFormatDefinition
	// {
	// 	public PreprocessorKeywordFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.PreprocessorKeyword);
	// 		ForegroundBrush = Brushes.BurlyWood;
	// 	}
	// }
	//
	// // [Export(typeof(EditorFormatDefinition))]
	// // [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.StringLiteral)]
	// // [Name(ClassificationTypeNamesEx.StringLiteral)]
	// // [UserVisible(false)]
	// // [Order(After = Priority.High)]
	// // internal sealed class StringLiteralFormat : ClassificationFormatDefinition
	// // {
	// // 	public StringLiteralFormat()
	// // 	{
	// // 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.StringLiteral);
	// // 		ForegroundBrush = Brushes.ForestGreen;
	// // 	}
	// // }
	// //
	// // [Export(typeof(EditorFormatDefinition))]
	// // [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.WhiteSpace)]
	// // [Name(ClassificationTypeNamesEx.WhiteSpace)]
	// // [UserVisible(false)]
	// // [Order(After = Priority.High)]
	// // internal sealed class WhiteSpaceFormat : ClassificationFormatDefinition
	// // {
	// // 	public WhiteSpaceFormat()
	// // 	{
	// // 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.WhiteSpace);
	// // 		ForegroundBrush = Brushes.Transparent;
	// // 	}
	// // }
	// //
	// // [Export(typeof(EditorFormatDefinition))]
	// // [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.Text)]
	// // [Name(ClassificationTypeNamesEx.Text)]
	// // [UserVisible(false)]
	// // [Order(After = Priority.High)]
	// // internal sealed class TextFormat : ClassificationFormatDefinition
	// // {
	// // 	public TextFormat()
	// // 	{
	// // 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.Text);
	// // 		ForegroundBrush = Brushes.Black;
	// // 	}
	// // }
	// //
	// // [Export(typeof(EditorFormatDefinition))]
	// // [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.StaticSymbol)]
	// // [Name(ClassificationTypeNamesEx.StaticSymbol)]
	// // [UserVisible(false)]
	// // [Order(After = Priority.High)]
	// // internal sealed class StaticSymbolFormat : ClassificationFormatDefinition
	// // {
	// // 	public StaticSymbolFormat()
	// // 	{
	// // 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.StaticSymbol);
	// // 		ForegroundBrush = Brushes.Black;
	// // 	}
	// // }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.PreprocessorText)]
	// [Name(ClassificationTypeNamesEx.PreprocessorText)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class PreprocessorTextFormat : ClassificationFormatDefinition
	// {
	// 	public PreprocessorTextFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.PreprocessorText);
	// 		ForegroundBrush = Brushes.BurlyWood;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.Punctuation)]
	// [Name(ClassificationTypeNamesEx.Punctuation)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class PunctuationFormat : ClassificationFormatDefinition
	// {
	// 	public PunctuationFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.Punctuation);
	// 		ForegroundBrush = Brushes.DarkOrange;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.VerbatimStringLiteral)]
	// [Name(ClassificationTypeNamesEx.VerbatimStringLiteral)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class VerbatimStringLiteralFormat : ClassificationFormatDefinition
	// {
	// 	public VerbatimStringLiteralFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.VerbatimStringLiteral);
	// 		ForegroundBrush = Brushes.LimeGreen;
	// 	}
	// }
	//
	// // [Export(typeof(EditorFormatDefinition))]
	// // [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.StringEscapeCharacter)]
	// // [Name(ClassificationTypeNamesEx.StringEscapeCharacter)]
	// // [UserVisible(false)]
	// // [Order(After = Priority.High)]
	// // internal sealed class StringEscapeCharacterFormat : ClassificationFormatDefinition
	// // {
	// // 	public StringEscapeCharacterFormat()
	// // 	{
	// // 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.VerbatimStringLiteral);
	// // 		ForegroundBrush = Brushes.Maroon;
	// // 	}
	// // }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.ClassName)]
	// [Name(ClassificationTypeNamesEx.ClassName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class ClassNameFormat : ClassificationFormatDefinition
	// {
	// 	public ClassNameFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.ClassName);
	// 		ForegroundBrush = Brushes.CadetBlue;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.DelegateName)]
	// [Name(ClassificationTypeNamesEx.DelegateName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class DelegateNameFormat : ClassificationFormatDefinition
	// {
	// 	public DelegateNameFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.DelegateName);
	// 		ForegroundBrush = Brushes.Fuchsia;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.EnumName)]
	// [Name(ClassificationTypeNamesEx.EnumName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class EnumNameFormat : ClassificationFormatDefinition
	// {
	// 	public EnumNameFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.EnumName);
	// 		ForegroundBrush = Brushes.Peru;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.InterfaceName)]
	// [Name(ClassificationTypeNamesEx.InterfaceName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class InterfaceFormat : ClassificationFormatDefinition
	// {
	// 	public InterfaceFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.InterfaceName);
	// 		ForegroundBrush = Brushes.DeepSkyBlue;
	// 	}
	// }
	//
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.StructName)]
	// [Name(ClassificationTypeNamesEx.StructName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class StructNameFormat : ClassificationFormatDefinition
	// {
	// 	public StructNameFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.StructName);
	// 		ForegroundBrush = Brushes.BlueViolet;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.TypeParameterName)]
	// [Name(ClassificationTypeNamesEx.TypeParameterName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class TypeParameterNameFormat : ClassificationFormatDefinition
	// {
	// 	public TypeParameterNameFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.TypeParameterName);
	// 		ForegroundBrush = Brushes.BlueViolet;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.FieldName)]
	// [Name(ClassificationTypeNamesEx.FieldName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class FieldFormat : ClassificationFormatDefinition
	// {
	// 	public FieldFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.FieldName);
	// 		ForegroundBrush = Brushes.Black;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.EnumMemberName)]
	// [Name(ClassificationTypeNamesEx.EnumMemberName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class EnumMemberNameFormat : ClassificationFormatDefinition
	// {
	// 	public EnumMemberNameFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.EnumMemberName);
	// 		ForegroundBrush = Brushes.SaddleBrown;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.ConstantName)]
	// [Name(ClassificationTypeNamesEx.ConstantName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class ConstantNameFormat : ClassificationFormatDefinition
	// {
	// 	public ConstantNameFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.ConstantName);
	// 		ForegroundBrush = Brushes.MediumVioletRed;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.LocalName)]
	// [Name(ClassificationTypeNamesEx.LocalName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class LocalNameFormat : ClassificationFormatDefinition
	// {
	// 	public LocalNameFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.LocalName);
	// 		ForegroundBrush = Brushes.Black;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.ParameterName)]
	// [Name(ClassificationTypeNamesEx.ParameterName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class ParameterNameFormat : ClassificationFormatDefinition
	// {
	// 	public ParameterNameFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.ParameterName);
	// 		ForegroundBrush = Brushes.Black;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.MethodName)]
	// [Name(ClassificationTypeNamesEx.MethodName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class MethodFormat : ClassificationFormatDefinition
	// {
	// 	public MethodFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.MethodName);
	// 		ForegroundBrush = Brushes.Firebrick;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.ExtensionMethodName)]
	// [Name(ClassificationTypeNamesEx.ExtensionMethodName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class ExtensionMethodFormat : ClassificationFormatDefinition
	// {
	// 	public ExtensionMethodFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.ExtensionMethodName);//SynthexerConstants.All.Where(i => i.classificationId == SynthexerConstants.ExtensionMethod).Select(i => i.info.description).FirstOrDefault();
	// 		ForegroundBrush = Brushes.Teal;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.PropertyName)]
	// [Name(ClassificationTypeNamesEx.PropertyName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class PropertyFormat : ClassificationFormatDefinition
	// {
	// 	public PropertyFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.PropertyName);
	// 		ForegroundBrush = Brushes.Blue;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.EventName)]
	// [Name(ClassificationTypeNamesEx.EventName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class EventNameFormat : ClassificationFormatDefinition
	// {
	// 	public EventNameFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.EventName);
	// 		ForegroundBrush = Brushes.Fuchsia;
	// 	}
	// }
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.NamespaceName)]
	// [Name(ClassificationTypeNamesEx.NamespaceName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class NamespaceNameFormat : ClassificationFormatDefinition
	// {
	// 	public NamespaceNameFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.NamespaceName);
	// 		ForegroundBrush = Brushes.Goldenrod;
	// 	}
	// }
	//
	//
	// [Export(typeof(EditorFormatDefinition))]
	// [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.LabelName)]
	// [Name(ClassificationTypeNamesEx.LabelName)]
	// [UserVisible(false)]
	// [Order(After = Priority.High)]
	// internal sealed class LabelNameFormat : ClassificationFormatDefinition
	// {
	// 	public LabelNameFormat()
	// 	{
	// 		DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.LabelName);
	// 		ForegroundBrush = Brushes.Plum;
	// 	}
	// }

	// =====================================================================================================================

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.StaticClassName)]
	[Name(ClassificationTypeNamesEx.StaticClassName)]
	[UserVisible(false)]
	[Order(After = Priority.High)]
	internal sealed class StaticClassFormat : ClassificationFormatDefinition
	{
		public StaticClassFormat()
		{
			DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.StaticClassName);
			ForegroundBrush = Brushes.DimGray;
		}
	}

	[Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.AttributeName)]
    [Name(ClassificationTypeNamesEx.AttributeName)]
    [UserVisible(false)]
    [Order(After = Priority.High)]
    internal sealed class AttributeFormat : ClassificationFormatDefinition
    {
        public AttributeFormat()
        {
            DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.AttributeName);
            ForegroundBrush = Brushes.DarkOliveGreen;
		}
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.LocalFunctionName)]
    [Name(ClassificationTypeNamesEx.LocalFunctionName)]
    [UserVisible(false)]
    [Order(After = Priority.High)]
    internal sealed class LocalFunctionFormat : ClassificationFormatDefinition
    {
	    public LocalFunctionFormat()
	    {
		    DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.LocalFunctionName);
		    ForegroundBrush = Brushes.BurlyWood;
	    }
    }

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = ClassificationTypeNamesEx.StaticMethodName)]
	[Name(ClassificationTypeNamesEx.StaticMethodName)]
	[UserVisible(false)]
	[Order(After = Priority.High)]
	internal sealed class StaticMethodFormat : ClassificationFormatDefinition
	{
		public StaticMethodFormat()
		{
			DisplayName = ClassificationTypeNamesEx.ToDisplayName(ClassificationTypeNamesEx.StaticMethodName);
			ForegroundBrush = Brushes.Crimson;
		}
	}
}