using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.PlatformUI;
using Synthexer.Settings;

namespace Synthexer.UI
{
	public partial class SettingsItemControl : UserControl
	{
		private readonly SettingsItem _item;

		public SettingsItemControl()
		{
			InitializeComponent();
		}

		public SettingsItemControl(SettingsItem item) : this()
		{
			_item = item;
			_lblClassificationId.Text = $@"{item.DisplayName}:";
			_pnlForgroundColor.BackColor = Color.FromArgb((int) item.ForegroundColor.ToArgb());
			_pnlBackgroundColor.BackColor = Color.FromArgb((int) item.BackgroundColor.ToArgb());
			_chkIsBold.Checked = item.IsBold;
			_chkIsItalic.Checked = item.IsItalic;
			_chkIsUnderline.Checked = item.IsUnderline;
		}

		private void On_pnlForgroundColor_Click(object sender, EventArgs e)
		{
			_colorDialog.Color = Color.FromArgb((int)_item.ForegroundColor.ToArgb());
			if (_colorDialog.ShowDialog() != DialogResult.OK) return;
			var color = _colorDialog.Color;
			_pnlForgroundColor.BackColor = color;
			_item.ForegroundColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
		}

		private void On_pnlBackgroundColor_Click(object sender, EventArgs e)
		{
			_colorDialog.Color = Color.FromArgb((int)_item.BackgroundColor.ToArgb());
			if (_colorDialog.ShowDialog() != DialogResult.OK) return;
			var color = _colorDialog.Color;
			_pnlBackgroundColor.BackColor = color;
			_item.BackgroundColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
		}

		private void On_chkIsItalic_CheckedChanged(object sender, EventArgs e)
		{
			_item.IsItalic = _chkIsItalic.Checked;
		}

		private void On_chkIsBold_CheckedChanged(object sender, EventArgs e)
		{
			_item.IsBold = _chkIsBold.Checked;
		}

		private void On_chkIsUnderline_CheckedChanged(object sender, EventArgs e)
		{
			_item.IsUnderline = _chkIsUnderline.Checked;
		}
	}
}
