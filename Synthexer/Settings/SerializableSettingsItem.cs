using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;

namespace Synthexer.Settings
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Local")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    internal class SerializableSettingsItem
	{
		// ReSharper disable once UnusedMember.Global
		public SerializableSettingsItem() { }

		public SerializableSettingsItem(SettingsItem item)
		{
			ForegroundColor = item.ForegroundColor;
			BackgroundColor = item.BackgroundColor;
			IsBold = item.IsBold;
			IsItalic = item.IsItalic;
			IsUnderline = item.IsUnderline;
		}

		public Color ForegroundColor { get; set; }

		public Color BackgroundColor { get; set; }

		public bool IsItalic { get; set; }

		public bool IsBold { get; set; }

		public bool IsUnderline { get; set; }
	}
}