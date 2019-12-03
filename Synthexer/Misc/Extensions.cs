using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;

namespace Synthexer.Misc
{
	public static class Extensions
	{
		public static ITagSpan<IClassificationTag> ToTagSpan(this TextSpan span, ITextSnapshot snapshot, IClassificationType classificationType)
		{
			return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.Start, span.Length), new ClassificationTag(classificationType));
		}

		public static bool IsAttribute(this INamedTypeSymbol namedTypeSymbol)
		{
			var typeSymbol = namedTypeSymbol;
			while (typeSymbol != null)
			{
				if (typeSymbol.Name == typeof(Attribute).Name)
				{
					return true;
				}

				typeSymbol = typeSymbol.BaseType;
			}

			return false;
		}
	}
}