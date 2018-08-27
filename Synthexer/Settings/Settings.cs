using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Settings;
using Microsoft.VisualStudio.Text.Formatting;
using Synthexer.Core;
using Polenter.Serialization;

namespace Synthexer.Settings
{
	[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
	[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
	[SuppressMessage("ReSharper", "UnusedMember.Local")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class Settings
	{
		private static volatile Settings _instance;

		public event SettingsChangedEventHandler OptionsChanged;

		private readonly Dictionary<string, SettingsItem> _items;
		private readonly WritableSettingsStore _writableSettingsStore;

		public Settings()
		{
			var shellSettingsManager = new ShellSettingsManager(ServiceProvider.GlobalProvider);
			_writableSettingsStore = shellSettingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);

			_items = SynthexerConstants.All.Select(i => new KeyValuePair<string, SettingsItem>(i.classificationId, new SettingsItem((i.classificationId, i.info.displayName)))).ToDictionary(kv => kv.Key, kv => kv.Value);
			foreach (var kv in _items)
			{
				kv.Value.OptionsChanged += OnItemOptionsChanged;
			}
		}

		internal TextFormattingRunProperties UpdateProperties(SettingsItem item, TextFormattingRunProperties p)
		{
			return !_items.ContainsKey(item.ClassificationId) ? p : _items[item.ClassificationId].UpdateProperties(p);
		}

		internal static Settings Instance
		{
			get
			{
				if (_instance != null)
				{
					return _instance;
				}

				_instance = new Settings();
				_instance.Load();
				return _instance;
			}
		}

		public IReadOnlyDictionary<string, SettingsItem> Items => _items;

		private void OnItemOptionsChanged(object sender, SettingsChangedEventArgs e)
		{
			OnOptionsChanged(e);
		}

		internal void Load()
		{
			try
			{
				var collectionName = typeof(Settings).FullName;
				// _writableSettingsStore.DeleteCollection(collectionName);
				if (!_writableSettingsStore.CollectionExists(collectionName))
				{
					Save();
				}

				var settings = new SharpSerializerBinarySettings(BinarySerializationMode.SizeOptimized) { IncludeAssemblyVersionInTypeName = false, IncludeCultureInTypeName = false, IncludePublicKeyTokenInTypeName = false };				
				var serializer = new SharpSerializer(settings);
				var xml = _writableSettingsStore.GetMemoryStream(collectionName, nameof(Items));
				FromSerializable((serializer.Deserialize(xml) as SerializableSettings));
			}
			catch (Exception ex)
			{
				Debug.Fail(ex.Message);
			}
		}

		internal void Load(string fileName)
		{
			var settings = new SharpSerializerBinarySettings(BinarySerializationMode.SizeOptimized) { IncludeAssemblyVersionInTypeName = false, IncludeCultureInTypeName = false, IncludePublicKeyTokenInTypeName = false };
			var serializer = new SharpSerializer(settings);
			var data = File.ReadAllBytes(fileName);
			using (var m = new MemoryStream(data))
			{
				FromSerializable((serializer.Deserialize(m) as SerializableSettings));
			}
		}

		private SerializableSettings ToSerializable()
		{
			return new SerializableSettings {Items = _items.Select(kv => new KeyValuePair<string, SerializableSettingsItem>(kv.Key, new SerializableSettingsItem(kv.Value))).ToDictionary(kv => kv.Key, kv => kv.Value)};
		}

		private void FromSerializable(SerializableSettings ss)
		{
			foreach (var kv in ss.Items)
			{
				var item = _items[kv.Key];
				item.ForegroundColor = kv.Value.ForegroundColor;
				item.BackgroundColor = kv.Value.BackgroundColor;
				item.IsBold = kv.Value.IsBold;
				item.IsItalic = kv.Value.IsItalic;
				item.IsUnderline = kv.Value.IsUnderline;
			}
		}

		internal void Save()
		{
			try
			{
				var collectionName = typeof(Settings).FullName;
				if (!_writableSettingsStore.CollectionExists(collectionName))
				{
					_writableSettingsStore.CreateCollection(collectionName);
				}

				var settings = new SharpSerializerBinarySettings(BinarySerializationMode.SizeOptimized) { IncludeAssemblyVersionInTypeName = false, IncludeCultureInTypeName = false, IncludePublicKeyTokenInTypeName = false };
				var serializer = new SharpSerializer(settings);
				using (var m = new MemoryStream())
				{
					serializer.Serialize(ToSerializable(), m);
					_writableSettingsStore.SetMemoryStream(collectionName, nameof(Items), m);
				}
			}
			catch (Exception)
			{
				//
			}
		}

		internal void Save(string fileName)
		{
			var settings = new SharpSerializerBinarySettings(BinarySerializationMode.SizeOptimized) { IncludeAssemblyVersionInTypeName = false, IncludeCultureInTypeName = false, IncludePublicKeyTokenInTypeName = false };
			var serializer = new SharpSerializer(settings);
			using (var m = new MemoryStream())
			{
				serializer.Serialize(ToSerializable(), m);
				File.WriteAllBytes(fileName, m.GetBuffer());
			}
		}

		private void OnOptionsChanged(SettingsChangedEventArgs e)
		{
			OptionsChanged?.Invoke(this, e);
		}		
	}
}