using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Synthexer.Core
{
    internal static class SynthexerClassificationTypes
    {
#pragma warning disable CS0649
        [Export(typeof(ClassificationTypeDefinition))] [Name(SynthexerConstants.Namespace)]
        internal static ClassificationTypeDefinition NamespaceType;

        [Export(typeof(ClassificationTypeDefinition))] [Name(SynthexerConstants.Field)]
        internal static ClassificationTypeDefinition FieldType;

        [Export(typeof(ClassificationTypeDefinition))] [Name(SynthexerConstants.Property)]
        internal static ClassificationTypeDefinition PropertyType;

        [Export(typeof(ClassificationTypeDefinition))] [Name(SynthexerConstants.Constant)]
        internal static ClassificationTypeDefinition ConstantType;

        [Export(typeof(ClassificationTypeDefinition))] [Name(SynthexerConstants.EnumValue)]
        internal static ClassificationTypeDefinition EnumFieldType;

        [Export(typeof(ClassificationTypeDefinition))] [Name(SynthexerConstants.Attribute)]
        internal static ClassificationTypeDefinition AttributeType;

        [Export(typeof(ClassificationTypeDefinition))] [Name(SynthexerConstants.Method)]
        internal static ClassificationTypeDefinition MethodType;

        [Export(typeof(ClassificationTypeDefinition))] [Name(SynthexerConstants.StaticMethod)]
        internal static ClassificationTypeDefinition StaticMethodType;

        [Export(typeof(ClassificationTypeDefinition))] [Name(SynthexerConstants.ExtensionMethod)]
        internal static ClassificationTypeDefinition ExtensionMethodType;

        [Export(typeof(ClassificationTypeDefinition))] [Name(SynthexerConstants.LocalFunction)]
        internal static ClassificationTypeDefinition LocalFunctionType;

        [Export(typeof(ClassificationTypeDefinition))] [Name(SynthexerConstants.Parameter)]
        internal static ClassificationTypeDefinition ParameterType;

        [Export(typeof(ClassificationTypeDefinition))] [Name(SynthexerConstants.LocalVariable)]
        internal static ClassificationTypeDefinition LocalVariableType;

        [Export(typeof(ClassificationTypeDefinition))] [Name(SynthexerConstants.Event)]
        internal static ClassificationTypeDefinition EventType;
#pragma warning restore CS0649
    }
}