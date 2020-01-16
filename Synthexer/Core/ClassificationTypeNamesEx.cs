using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis.Classification;

namespace Synthexer.Core
{
	public static class ClassificationTypeNamesEx
	{
		private const string Owner = "Synthexer ";

		public const string Comment = Owner + ClassificationTypeNames.Comment;
		// public const string ExcludedCode = Owner + ClassificationTypeNames.ExcludedCode;
		// public const string Identifier = Owner + ClassificationTypeNames.Identifier;
		public const string Keyword = Owner + ClassificationTypeNames.Keyword;
		// public const string ControlKeyword = Owner + ClassificationTypeNames.ControlKeyword;
		public const string NumericLiteral = Owner + ClassificationTypeNames.NumericLiteral;
		public const string Operator = Owner + ClassificationTypeNames.Operator;
		public const string OperatorOverloaded = Owner + ClassificationTypeNames.OperatorOverloaded;
		public const string PreprocessorKeyword = Owner + ClassificationTypeNames.PreprocessorKeyword;
		public const string StringLiteral = Owner + ClassificationTypeNames.StringLiteral;
		// public const string WhiteSpace = Owner + ClassificationTypeNames.WhiteSpace;
		// public const string Text = Owner + ClassificationTypeNames.Text;
		// public const string StaticSymbol = Owner + ClassificationTypeNames.StaticSymbol;
		public const string PreprocessorText = Owner + ClassificationTypeNames.PreprocessorText;
		public const string Punctuation = Owner + ClassificationTypeNames.Punctuation;
		public const string VerbatimStringLiteral = Owner + ClassificationTypeNames.VerbatimStringLiteral;
		public const string StringEscapeCharacter = Owner + ClassificationTypeNames.StringEscapeCharacter;
		public const string ClassName = Owner + ClassificationTypeNames.ClassName;
		public const string DelegateName = Owner + ClassificationTypeNames.DelegateName;
		public const string EnumName = Owner + ClassificationTypeNames.EnumName;
		public const string InterfaceName = Owner + ClassificationTypeNames.InterfaceName;
		// public const string ModuleName = Owner + ClassificationTypeNames.ModuleName;
		public const string StructName = Owner + ClassificationTypeNames.StructName;
		public const string TypeParameterName = Owner + ClassificationTypeNames.TypeParameterName;
		public const string FieldName = Owner + ClassificationTypeNames.FieldName;
		public const string EnumMemberName = Owner + ClassificationTypeNames.EnumMemberName;
		public const string ConstantName = Owner + ClassificationTypeNames.ConstantName;
		public const string LocalName = Owner + ClassificationTypeNames.LocalName;
		public const string ParameterName = Owner + ClassificationTypeNames.ParameterName;
		public const string MethodName = Owner + ClassificationTypeNames.MethodName;
		public const string ExtensionMethodName = Owner + ClassificationTypeNames.ExtensionMethodName;
		public const string PropertyName = Owner + ClassificationTypeNames.PropertyName;
		public const string EventName = Owner + ClassificationTypeNames.EventName;
		public const string NamespaceName = Owner + ClassificationTypeNames.NamespaceName;
		public const string LabelName = Owner + ClassificationTypeNames.LabelName;

		// =====================================================================================================================

		public const string StaticClassName = "static class name";
		public const string AttributeName = "attribute name";
		public const string LocalFunctionName = "local function name";
		public const string StaticMethodName = "static method name";

		internal static string ToDisplayName(string classification)
		{
			var s = Normalize(classification);
			return s.ToUpperInvariant()[0] + s.Substring(1);
		}

		internal static string Normalize(string classification) => classification.Replace(Owner, "").Trim();

		public static IEnumerable<(string classification, string displayName)> All()
		{
			foreach (var field in typeof(ClassificationTypeNamesEx).GetFields(BindingFlags.Public | BindingFlags.Static).Where(f => f.IsLiteral && !f.IsInitOnly))
			{
				string constValue;
				yield return (constValue = Normalize(field.GetValue(null).ToString()), ToDisplayName(constValue));
			}
		}
	}
}