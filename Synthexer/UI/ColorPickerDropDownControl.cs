using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SemanticColorizer.UI
{
	public sealed partial class ColorPickerDropDownControl : UserControl
	{
		private class ToolStripProfessionalRendererEx : ToolStripProfessionalRenderer
		{
			protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
			{
			}
		}

		public event EventHandler ColorChanged;

		public ColorPickerDropDownControl()
		{
			InitializeComponent();
			_toolStrip.Renderer = new ToolStripProfessionalRendererEx();
			Text = null;
			toolStripButton1.ColorChanged += (sender, args) => { OnColorChanged();};
		}

		[Category("Appearance")]
		[DefaultValue(typeof(Color), "Transparent")]
		public Color Color
		{
			get => toolStripButton1.Color;
			set => toolStripButton1.Color = value;
		}

		protected override Size DefaultSize => new Size(115, 23);

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if(_toolStrip == null) return;
			_toolStrip.Height = Height;
			_toolStrip.Width = Width;
		}

		[Browsable(false)]
		public override bool AutoSize
		{
			get => false;
			set => base.AutoSize = false;
		}

		private void OnColorChanged()
		{
			ColorChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
