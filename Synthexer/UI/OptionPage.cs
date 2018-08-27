using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;

namespace Synthexer.UI
{
	public sealed class OptionPage : DialogPage
	{
		private readonly OpenFileDialog _openFileDialog = new OpenFileDialog { Filter = @"SemanticColorizer settings: (*.scsettings)|*.scsettings" };
		private readonly SaveFileDialog _saveFileDialog = new SaveFileDialog { Filter = @"SemanticColorizer settings: (*.scsettings)|*.scsettings" };

		protected override IWin32Window Window
		{
			get
			{
				var ctrl = new ScrollableControl {Padding = Padding.Empty, Margin = Padding.Empty, AutoScroll = true};
				foreach (var item in Settings.Settings.Instance.Items.Values.Reverse())
				{
					ctrl.Controls.Add(new SettingsItemControl(item){Dock = DockStyle.Top});
				}

				ctrl.Controls.Add(new ToolStrip(new ToolStripButton("Import settings", null, OnImportSettingsClick)
					{
						DisplayStyle = ToolStripItemDisplayStyle.Text,
						Alignment = ToolStripItemAlignment.Right
					},
					new ToolStripSeparator{ Alignment = ToolStripItemAlignment.Right },
					new ToolStripButton("Export settings", null, OnExportSettingsClick)
					{
						DisplayStyle = ToolStripItemDisplayStyle.Text,
						Alignment = ToolStripItemAlignment.Right
					}) {GripStyle = ToolStripGripStyle.Hidden, AllowItemReorder = false, AllowMerge = false, AllowDrop = false});
				return ctrl;
			}
		}

		private void OnExportSettingsClick(object sender, EventArgs e)
		{
			_saveFileDialog.FileName = DateTime.Now.ToFileTimeUtc().ToString();
			if(_saveFileDialog.ShowDialog() != DialogResult.OK) return;
			if (File.Exists(_saveFileDialog.FileName) && MessageBox.Show(@"A file with the same name already exsists. Overwrite?", @"Attention", MessageBoxButtons.YesNo) == DialogResult.No) return;
			Settings.Settings.Instance.Save(_saveFileDialog.FileName);
		}

		private void OnImportSettingsClick(object sender, EventArgs e)
		{
			if (MessageBox.Show(@"Do you want to save current settings before loading?", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				OnExportSettingsClick(null, null);
			}
			if (_openFileDialog.ShowDialog() != DialogResult.OK) return;
			Settings.Settings.Instance.Load(_openFileDialog.FileName);
		}

		public override void LoadSettingsFromStorage()
		{
			Settings.Settings.Instance.Load();
		}

		public override void SaveSettingsToStorage()
		{
			Settings.Settings.Instance.Save();
		}
	}
}