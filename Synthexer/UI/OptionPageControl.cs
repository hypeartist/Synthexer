using System;
using System.Drawing;
using System.Windows.Forms;

namespace SemanticColorizer.UI
{
	public partial class OptionPageControl : UserControl
	{
		private SettingsItem _currentItem;

		public OptionPageControl()
		{
			InitializeComponent();

			_cpForegroundColor.ColorChanged += (sender, args) =>
			{
				if (_currentItem == null) return;
				var color = _cpForegroundColor.Color;
				_currentItem.ForegroundColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
			};

			_cpBackgroundColor.ColorChanged += (sender, args) =>
			{
				if (_currentItem == null) return;
				var color = _cpBackgroundColor.Color;
				_currentItem.BackgroundColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
			};

			_chkIsBold.CheckedChanged += (sender, args) =>
			{
				if (_currentItem == null) return;
				_currentItem.IsBold = _chkIsBold.Checked;
			};

			_chkIsItalic.CheckedChanged += (sender, args) =>
			{
				if (_currentItem == null) return;
				_currentItem.IsItalic = _chkIsItalic.Checked;
			};

			_chkIsUnderline.CheckedChanged += (sender, args) =>
			{
				if (_currentItem == null) return;
				_currentItem.IsUnderline = _chkIsUnderline.Checked;
			};

			_lbClassificationTypes.SelectedIndexChanged += On_lbClassificationTypesSelectedIndexChanged;

			_lbClassificationTypes.Items.Clear();
			foreach (var item in Settings.Instance.Items.Values)
			{
				_lbClassificationTypes.Items.Add(item);
			}

			_lbClassificationTypes.SelectedIndex = 0;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
		}

		private void On_lbClassificationTypesSelectedIndexChanged(object sender, EventArgs e)
		{
			_currentItem = _lbClassificationTypes.Items[_lbClassificationTypes.SelectedIndex] as SettingsItem;
			if(_currentItem == null) return;

			_cpForegroundColor.Color = Color.FromArgb(_currentItem.ForegroundColor.A, _currentItem.ForegroundColor.R, _currentItem.ForegroundColor.G, _currentItem.ForegroundColor.B);
			_cpBackgroundColor.Color = Color.FromArgb(_currentItem.BackgroundColor.A, _currentItem.BackgroundColor.R, _currentItem.BackgroundColor.G, _currentItem.BackgroundColor.B);
			_chkIsBold.Checked = _currentItem.IsBold;
			_chkIsItalic.Checked = _currentItem.IsItalic;
			_chkIsUnderline.Checked = _currentItem.IsUnderline;
		}
	}
}
