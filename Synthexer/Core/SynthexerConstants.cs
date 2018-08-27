using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis.Classification;

namespace Synthexer.Core
{
	public static class SynthexerConstants
    {
        [Microsoft.VisualStudio.Utilities.DisplayName("Namespace")] [Description("Synthexer: namespace")]
        public const string Namespace = "namespace name";

        [Microsoft.VisualStudio.Utilities.DisplayName("Interface")] [Description("Synthexer: interface")]
        public const string Interface = ClassificationTypeNames.InterfaceName;

		[Microsoft.VisualStudio.Utilities.DisplayName("Class")]
		[Description("Synthexer: class")]
		public const string Class = ClassificationTypeNames.ClassName;

		[Microsoft.VisualStudio.Utilities.DisplayName("Struct")]
		[Description("Synthexer: struct")]
		public const string Struct = ClassificationTypeNames.StructName;
		
		[Microsoft.VisualStudio.Utilities.DisplayName("Field")]
		[Description("Synthexer: field")]
		public const string Field = "field name";

		[Microsoft.VisualStudio.Utilities.DisplayName("Property")]
		[Description("Synthexer: property")]
		public const string Property = "property name";

		[Microsoft.VisualStudio.Utilities.DisplayName("Constant")]
		[Description("Synthexer: constant")]
		public const string Constant = "constant name";

		[Microsoft.VisualStudio.Utilities.DisplayName("Enum")]
		[Description("Synthexer: enum")]
		public const string Enum = ClassificationTypeNames.EnumName;

		[Microsoft.VisualStudio.Utilities.DisplayName("Enum value")]
		[Description("Synthexer: enum value")]
		public const string EnumValue = "enum member name";

        [Microsoft.VisualStudio.Utilities.DisplayName("Attribute")]
        [Description("Synthexer: attribute")]
        public const string Attribute = "attribute name";

        [Microsoft.VisualStudio.Utilities.DisplayName("Method")]
		[Description("Synthexer: method")]
		public const string Method = "method name";

		[Microsoft.VisualStudio.Utilities.DisplayName("Static method")]
		[Description("Synthexer: static method")]
		public const string StaticMethod = "static method name";

		[Microsoft.VisualStudio.Utilities.DisplayName("Extension method")]
		[Description("Synthexer: extension method")]
		public const string ExtensionMethod = "extension method name";

		[Microsoft.VisualStudio.Utilities.DisplayName("Local function")]
		[Description("Synthexer: local function")]
		public const string LocalFunction = "local function name";

		[Microsoft.VisualStudio.Utilities.DisplayName("Parameter")]
		[Description("Synthexer: parameter")]
		public const string Parameter = "parameter name";

		[Microsoft.VisualStudio.Utilities.DisplayName("Type parameter")]
		[Description("Synthexer: type parameter")]
		public const string TypeParameter = ClassificationTypeNames.TypeParameterName;

		[Microsoft.VisualStudio.Utilities.DisplayName("Local")]
		[Description("Synthexer: local variable")]
		public const string LocalVariable = "local variable name";

		[Microsoft.VisualStudio.Utilities.DisplayName("Delegate")]
		[Description("Synthexer: delegate")]
		public const string Delegate = ClassificationTypeNames.DelegateName;

		[Microsoft.VisualStudio.Utilities.DisplayName("Event")]
		[Description("Synthexer: event")]
		public const string Event = "event name";

        [Microsoft.VisualStudio.Utilities.DisplayName("Preprocessor directive")]
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
			var name = field?.GetCustomAttribute<Microsoft.VisualStudio.Utilities.DisplayNameAttribute>().DisplayName;
			var descr = field?.GetCustomAttribute<DescriptionAttribute>().Description;
			return (name, descr);
		}
	}
}