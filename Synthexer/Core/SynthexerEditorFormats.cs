using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Synthexer.Core
{

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SynthexerConstants.Namespace)]
	[Name(SynthexerConstants.Namespace)]
	[UserVisible(false)]
	[Order(After = Priority.High)]
	internal sealed class NamespaceFormat : ClassificationFormatDefinition
	{
		public NamespaceFormat()
		{
			DisplayName = SynthexerConstants.All.Where(i => i.classificationId == SynthexerConstants.Namespace).Select(i => i.info.description).FirstOrDefault();
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SynthexerConstants.Field)]
	[Name(SynthexerConstants.Field)]
	[UserVisible(false)]
	[Order(After = Priority.High)]
	internal sealed class FieldFormat : ClassificationFormatDefinition
	{
		public FieldFormat()
		{
			DisplayName = SynthexerConstants.All.Where(i => i.classificationId == SynthexerConstants.Field).Select(i => i.info.description).FirstOrDefault();
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SynthexerConstants.Property)]
	[Name(SynthexerConstants.Property)]
	[UserVisible(false)]
	[Order(After = Priority.High)]
	internal sealed class PropertyFormat : ClassificationFormatDefinition
	{
		public PropertyFormat()
		{
			DisplayName = SynthexerConstants.All.Where(i => i.classificationId == SynthexerConstants.Property).Select(i => i.info.description).FirstOrDefault();
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SynthexerConstants.Constant)]
	[Name(SynthexerConstants.Constant)]
	[UserVisible(false)]
	[Order(After = Priority.High)]
	internal sealed class ConstantFormat : ClassificationFormatDefinition
	{
		public ConstantFormat()
		{
			DisplayName = SynthexerConstants.All.Where(i => i.classificationId == SynthexerConstants.Constant).Select(i => i.info.description).FirstOrDefault();
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SynthexerConstants.EnumValue)]
	[Name(SynthexerConstants.EnumValue)]
	[UserVisible(false)]
	[Order(After = Priority.High)]
	internal sealed class EnumValueFormat : ClassificationFormatDefinition
	{
		public EnumValueFormat()
		{
			DisplayName = SynthexerConstants.All.Where(i => i.classificationId == SynthexerConstants.EnumValue).Select(i => i.info.description).FirstOrDefault();
		}
	}

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = SynthexerConstants.Attribute)]
    [Name(SynthexerConstants.Attribute)]
    [UserVisible(false)]
    [Order(After = Priority.High)]
    internal sealed class AttributeFormat : ClassificationFormatDefinition
    {
        public AttributeFormat()
        {
            DisplayName = SynthexerConstants.All.Where(i => i.classificationId == SynthexerConstants.Attribute).Select(i => i.info.description).FirstOrDefault();
        }
    }

    [Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SynthexerConstants.Method)]
	[Name(SynthexerConstants.Method)]
	[UserVisible(false)]
	[Order(After = Priority.High)]
	internal sealed class MethodFormat : ClassificationFormatDefinition
	{
		public MethodFormat()
		{
			DisplayName = SynthexerConstants.All.Where(i => i.classificationId == SynthexerConstants.Method).Select(i => i.info.description).FirstOrDefault();
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SynthexerConstants.StaticMethod)]
	[Name(SynthexerConstants.StaticMethod)]
	[UserVisible(false)]
	[Order(After = Priority.High)]
	internal sealed class StaticMethodFormat : ClassificationFormatDefinition
	{
		public StaticMethodFormat()
		{
			DisplayName = SynthexerConstants.All.Where(i => i.classificationId == SynthexerConstants.StaticMethod).Select(i => i.info.description).FirstOrDefault();
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SynthexerConstants.ExtensionMethod)]
	[Name(SynthexerConstants.ExtensionMethod)]
	[UserVisible(false)]
	[Order(After = Priority.High)]
	internal sealed class ExtensionMethodFormat : ClassificationFormatDefinition
	{
		public ExtensionMethodFormat()
		{
			DisplayName = SynthexerConstants.All.Where(i => i.classificationId == SynthexerConstants.ExtensionMethod).Select(i => i.info.description).FirstOrDefault();
		}
	}
	
	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SynthexerConstants.LocalFunction)]
	[Name(SynthexerConstants.LocalFunction)]
	[UserVisible(false)]
	[Order(After = Priority.High)]
	internal sealed class LocalFunctionFormat : ClassificationFormatDefinition
	{
		public LocalFunctionFormat()
		{
			DisplayName = SynthexerConstants.All.Where(i => i.classificationId == SynthexerConstants.LocalFunction).Select(i => i.info.description).FirstOrDefault();
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SynthexerConstants.Parameter)]
	[Name(SynthexerConstants.Parameter)]
	[UserVisible(false)]
	[Order(After = Priority.High)]
	internal sealed class ParameterFormat : ClassificationFormatDefinition
	{
		public ParameterFormat()
		{
			DisplayName = SynthexerConstants.All.Where(i => i.classificationId == SynthexerConstants.Parameter).Select(i => i.info.description).FirstOrDefault();
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SynthexerConstants.LocalVariable)]
	[Name(SynthexerConstants.LocalVariable)]
	[UserVisible(false)]
	[Order(After = Priority.High)]
	internal sealed class LocalFormat : ClassificationFormatDefinition
	{
		public LocalFormat()
		{
			DisplayName = SynthexerConstants.All.Where(i => i.classificationId == SynthexerConstants.LocalVariable).Select(i => i.info.description).FirstOrDefault();
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SynthexerConstants.Event)]
	[Name(SynthexerConstants.Event)]
	[UserVisible(false)]
	[Order(After = Priority.High)]
	internal sealed class EventFormat : ClassificationFormatDefinition
	{
		public EventFormat()
		{
			DisplayName = SynthexerConstants.All.Where(i => i.classificationId == SynthexerConstants.Event).Select(i => i.info.description).FirstOrDefault();
		}
	}
}