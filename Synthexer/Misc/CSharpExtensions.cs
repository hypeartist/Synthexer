using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Synthexer.Misc
{
	public static class CSharpExtensions
	{
		public static SyntaxKind CSharpKind(this SyntaxNode node) => node.Kind();
	}
}