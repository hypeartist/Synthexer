using System;

namespace Synthexer.Settings
{
	public sealed class SettingsChangedEventArgs : EventArgs
	{
		public SettingsChangedEventArgs(SettingsItem item, string propertyName)
		{
			Item = item;
			PropertyName = propertyName;
		}

		public SettingsItem Item { get; }

		public string PropertyName { get; }
	}
}