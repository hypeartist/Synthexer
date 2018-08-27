using System.Collections.Generic;

namespace Synthexer.Settings
{
	internal class SerializableSettings
	{
		public Dictionary<string, SerializableSettingsItem> Items { get; set; }
	}
}