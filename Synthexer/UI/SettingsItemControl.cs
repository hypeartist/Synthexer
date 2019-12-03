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
			UpdateState(_chkIsActive.Checked = item.IsActive);
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

		private void On_chkIsActive_CheckedChanged(object sender, EventArgs e)
		{
			UpdateState(_item.IsActive = _chkIsActive.Checked);
		}

		private void UpdateState(bool isActive)
		{
			_lblClassificationId.Text = $@"{_item.DisplayName}:";

			if (!isActive)
			{
				_lblClassificationId.Enabled = false;
				_lblForgroundColor.Enabled = false;
				_lblBackgroundColor.Enabled = false;
				_pnlForgroundColor.Enabled = false;
				_pnlBackgroundColor.Enabled = false;
				_chkIsBold.Enabled = false;
				_chkIsItalic.Enabled = false;
				_chkIsUnderline.Enabled = false;
				return;
			}

			_lblClassificationId.Enabled = true;
			_lblForgroundColor.Enabled = true;
			_lblBackgroundColor.Enabled = true;
			_pnlForgroundColor.Enabled = true;
			_pnlBackgroundColor.Enabled = true;
			_chkIsBold.Enabled = true;
			_chkIsItalic.Enabled = true;
			_chkIsUnderline.Enabled = true;

			_pnlForgroundColor.BackColor = Color.FromArgb((int) _item.ForegroundColor.ToArgb());
			_pnlBackgroundColor.BackColor = Color.FromArgb((int) _item.BackgroundColor.ToArgb());
			_chkIsBold.Checked = _item.IsBold;
			_chkIsItalic.Checked = _item.IsItalic;
			_chkIsUnderline.Checked = _item.IsUnderline;
		}
	}
}
