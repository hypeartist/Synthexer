using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Synthexer.UI;
using Task = System.Threading.Tasks.Task;

namespace Synthexer
{
	[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
	[InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]       
	[Guid(PackageGuidString)]
	[ProvideOptionPage(typeof(OptionPage), "Synthexer", "Settings", 0, 0, true)]
	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
	public sealed class VSPackage : AsyncPackage
	{
		public const string PackageGuidString = "f9a3f133-d6f3-4fab-a4d4-ba79200caa0e";

		protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
		{
			await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
		}
	}
}
