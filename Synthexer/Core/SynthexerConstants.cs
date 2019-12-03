using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Synthexer.Core
{
	public static class SynthexerConstants
	{
		[LocalizedName(typeof(Properties.Resources), "Namespace")]
		[Description("Synthexer: namespace")]
		public const string Namespace = ClassificationTypeNames.NamespaceName; //"syntexer namespace name";

		[LocalizedName(typeof(Properties.Resources), "Interface")]
		[Description("Synthexer: interface")]
		public const string Interface = ClassificationTypeNames.InterfaceName;

		[LocalizedName(typeof(Properties.Resources), "Class")]
		[Description("Synthexer: class")]
		public const string Class = ClassificationTypeNames.ClassName;

		[LocalizedName(typeof(Properties.Resources), "Static class")]
		[Description("Synthexer: static class")]
		public const string StaticClass = "syntexer static class name";

		[LocalizedName(typeof(Properties.Resources), "Struct")]
		[Description("Synthexer: struct")]
		public const string Struct = ClassificationTypeNames.StructName;

		[LocalizedName(typeof(Properties.Resources), "Field")]
		[Description("Synthexer: field")]
		public const string Field = ClassificationTypeNames.FieldName; //"syntexer field name";

		[LocalizedName(typeof(Properties.Resources), "Property")]
		[Description("Synthexer: property")]
		public const string Property = ClassificationTypeNames.PropertyName; //"syntexer property name";

		[LocalizedName(typeof(Properties.Resources), "Constant")]
		[Description("Synthexer: constant")]
		public const string Constant = "Synthexer constant name"; //ClassificationTypeNames.ConstantName; //

		[LocalizedName(typeof(Properties.Resources), "Enum")]
		[Description("Synthexer: enum")]
		public const string Enum = ClassificationTypeNames.EnumName;

		[LocalizedName(typeof(Properties.Resources), "Enum value")]
		[Description("Synthexer: enum value")]
		public const string EnumValue = ClassificationTypeNames.EnumMemberName; //"syntexer enum member name";

		[LocalizedName(typeof(Properties.Resources), "Attribute")]
		[Description("Synthexer: attribute")]
		public const string Attribute = "syntexer attribute name";

		[LocalizedName(typeof(Properties.Resources), "Method")]
		[Description("Synthexer: method")]
		public const string Method = ClassificationTypeNames.MethodName; //"syntexer method name";

		[LocalizedName(typeof(Properties.Resources), "Static method")]
		[Description("Synthexer: static method")]
		public const string StaticMethod = "syntexer static method name";

		[LocalizedName(typeof(Properties.Resources), "Extension method")]
		[Description("Synthexer: extension method")]
		public const string ExtensionMethod = ClassificationTypeNames.ExtensionMethodName; //"syntexer extension method name";

		[LocalizedName(typeof(Properties.Resources), "Local function")]
		[Description("Synthexer: local function")]
		public const string LocalFunction = "syntexer local function name";

		[LocalizedName(typeof(Properties.Resources), "Parameter")]
		[Description("Synthexer: parameter")]
		public const string Parameter = ClassificationTypeNames.ParameterName; //"syntexer parameter name";

		[LocalizedName(typeof(Properties.Resources), "Type parameter")]
		[Description("Synthexer: type parameter")]
		public const string TypeParameter = ClassificationTypeNames.TypeParameterName;

		[LocalizedName(typeof(Properties.Resources), "Local variable")]
		[Description("Synthexer: local variable")]
		public const string LocalVariable = ClassificationTypeNames.LocalName; //"syntexer local variable name";

		[LocalizedName(typeof(Properties.Resources), "Delegate")]
		[Description("Synthexer: delegate")]
		public const string Delegate = ClassificationTypeNames.EventName;

		[LocalizedName(typeof(Properties.Resources), "Event")]
		[Description("Synthexer: event")]
		public const string Event = ClassificationTypeNames.DelegateName; //"syntexer event name";

		[LocalizedName(typeof(Properties.Resources), "Preprocessor directive")]
		[Description("Synthexer: preprocessor directive")]
		public const string PreprocessorDirective = ClassificationTypeNames.PreprocessorKeyword;

		private static List<(string classificationId, (string displayName, string description) info)> _all;

		public static IEnumerable<(string classificationId, (string displayName, string description) info)> All
		{
			get
			{
				if (_all != null)
				{
					return _all;
				}

				_all = new List<(string classificationId, (string displayName, string description))>
				{
					(Namespace, GetInfo(nameof(Namespace))),
					(Interface, GetInfo(nameof(Interface))),
					(Class, GetInfo(nameof(Class))),
					(StaticClass, GetInfo(nameof(StaticClass))),
					(Struct, GetInfo(nameof(Struct))),
					(Field, GetInfo(nameof(Field))),
					(Property, GetInfo(nameof(Property))),
					(Constant, GetInfo(nameof(Constant))),
					(Enum, GetInfo(nameof(Enum))),
					(EnumValue, GetInfo(nameof(EnumValue))),
					(Attribute, GetInfo(nameof(Attribute))),
					(Method, GetInfo(nameof(Method))),
					(StaticMethod, GetInfo(nameof(StaticMethod))),
					(ExtensionMethod, GetInfo(nameof(ExtensionMethod))),
					(LocalFunction, GetInfo(nameof(LocalFunction))),
					(Parameter, GetInfo(nameof(Parameter))),
					(TypeParameter, GetInfo(nameof(TypeParameter))),
					(LocalVariable, GetInfo(nameof(LocalVariable))),
					(Delegate, GetInfo(nameof(Delegate))),
					(Event, GetInfo(nameof(Event))),
					(PreprocessorDirective, GetInfo(nameof(PreprocessorDirective)))
				};
				return _all;
			}
		}

		private static (string displayName, string description) GetInfo(string fieldName)
		{
			var field = typeof(SynthexerConstants).GetFields().FirstOrDefault(f => f.Name == fieldName);
			var name = Properties.Resources.ResourceManager.GetString(field?.GetCustomAttribute<LocalizedNameAttribute>().LocalizedName ?? string.Empty);
			var descr = field?.GetCustomAttribute<DescriptionAttribute>().Description;
			return (name, descr);
		}
	}
}