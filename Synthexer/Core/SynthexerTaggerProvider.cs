using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Formatting;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using Synthexer.Settings;

namespace Synthexer.Core
{
	[Export(typeof(ITaggerProvider))]
	[ContentType("CSharp")]
	[TagType(typeof(IClassificationTag))]
	internal class SynthexerTaggerProvider : ITaggerProvider
	{
#pragma warning disable CS0649
		[Import] internal IClassificationTypeRegistryService ClassificationRegistry;
		[Import] internal IClassificationFormatMapService ClassificationFormatMapService;

#pragma warning restore CS0649
		private bool _initiallyApplied;

		private SynthexerTaggerProvider()
		{
			Settings.Settings.Instance.OptionsChanged += (sender, args) =>
			{
				var formatMap = ClassificationFormatMapService.GetClassificationFormatMap("text");
                formatMap.BeginBatchUpdate();
				ApplyFormatting(args.Item, formatMap);
				formatMap.EndBatchUpdate();
            };
		}

		public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
		{
			if (_initiallyApplied)
			{
				return (ITagger<T>) new SynthexerTagger(buffer, ClassificationRegistry);
			}

			_initiallyApplied = true;

			var formatMap = ClassificationFormatMapService.GetClassificationFormatMap("text");
			formatMap.BeginBatchUpdate();

            foreach (var kv in Settings.Settings.Instance.Items)
			{
                var item = kv.Value;
				ApplyFormatting(item, formatMap);
			}
			formatMap.EndBatchUpdate();

			return (ITagger<T>) new SynthexerTagger(buffer, ClassificationRegistry);
		}

        private void ApplyFormatting(SettingsItem item, IClassificationFormatMap formatMap)
		{
			if(!item.IsActive) return;

			var classificationType = ClassificationRegistry.GetClassificationType(item.ClassificationId);
			var oldFormatting = formatMap.GetTextProperties(classificationType);
			var foregroundBrush = item.ForegroundColor == Colors.Transparent ? null : new SolidColorBrush(item.ForegroundColor);
			var backgroundBrush = item.BackgroundColor == Colors.Transparent ? null : new SolidColorBrush(item.BackgroundColor);
			var formatting = TextFormattingRunProperties.CreateTextFormattingRunProperties(foregroundBrush, backgroundBrush, oldFormatting.Typeface, null, null, oldFormatting.TextDecorations, oldFormatting.TextEffects, oldFormatting.CultureInfo);

			formatting = Settings.Settings.Instance.UpdateProperties(item, formatting);
            var identifierPosition = formatMap.CurrentPriorityOrder.IndexOf(classificationType);
            var afterIdentifierClassification = formatMap.CurrentPriorityOrder[identifierPosition/* + 1*/];
            // formatMap.AddExplicitTextProperties(classificationType, formatting, afterIdentifierClassification);
            formatMap.AddExplicitTextProperties(classificationType, formatting, afterIdentifierClassification);
		}
	}
}