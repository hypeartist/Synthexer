using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Cyotek.Windows.Forms;

namespace SemanticColorizer.UI
{
	[DefaultEvent("PreviewColorChanged")]
	[DefaultProperty("Color")]
	public sealed partial class ColorPickerDialog : Form
	{
		private static readonly object EventPreviewColorChanged = new object();
		private Brush _textureBrush;

		public ColorPickerDialog()
		{
			InitializeComponent();
			ShowAlphaChannel = true;
			Font = SystemFonts.DialogFont;
		}

		[Category("Property Changed")]
		public event EventHandler PreviewColorChanged
		{
			add => Events.AddHandler(EventPreviewColorChanged, value);
			remove => Events.RemoveHandler(EventPreviewColorChanged, value);
		}

		public Color Color
		{
			get => colorEditorManager.Color;
			set => colorEditorManager.Color = value;
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ShowAlphaChannel { get; set; }

		/// <summary>
		///     Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();

				if (_textureBrush != null)
				{
					_textureBrush.Dispose();
					_textureBrush = null;
				}
			}

			base.Dispose(disposing);
		}

		/// <summary>
		///     Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data. </param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			colorEditor.ShowAlphaChannel = ShowAlphaChannel;

			if (!ShowAlphaChannel)
			{
				for (var i = 0; i < colorGrid.Colors.Count; i++)
				{
					var color = colorGrid.Colors[i];
					if (color.A != 255)
					{
						colorGrid.Colors[i] = Color.FromArgb(255, color);
					}
				}
			}
		}

		/// <summary>
		///     Raises the <see cref="PreviewColorChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		private void OnPreviewColorChanged(EventArgs e)
		{
			(Events[EventPreviewColorChanged] as EventHandler)?.Invoke(this, e);
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void colorEditorManager_ColorChanged(object sender, EventArgs e)
		{
			previewPanel.Invalidate();

			OnPreviewColorChanged(e);
		}

		private void colorGrid_EditingColor(object sender, EditColorCancelEventArgs e)
		{
			e.Cancel = true;

			using (var dialog = new ColorDialog
			{
				FullOpen = true,
				Color = e.Color
			})
			{
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					colorGrid.Colors[e.ColorIndex] = dialog.Color;
				}
			}
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void previewPanel_Paint(object sender, PaintEventArgs e)
		{
			var region = previewPanel.ClientRectangle;

			if (Color.A != 255)
			{
				if (_textureBrush == null)
				{
					var bmp = GetType().Assembly.GetManifestResourceStream(string.Concat(GetType().Namespace, ".Resources.cellbackground.png"));

					using (var background = bmp != null ? new Bitmap(bmp) : new Bitmap(region.Width, region.Height))
					{
						_textureBrush = new TextureBrush(background, WrapMode.Tile);
					}
				}

				e.Graphics.FillRectangle(_textureBrush, region);
			}

			using (Brush brush = new SolidBrush(Color))
			{
				e.Graphics.FillRectangle(brush, region);
			}

			e.Graphics.DrawRectangle(SystemPens.ControlText, region.Left, region.Top, region.Width - 1, region.Height - 1);
		}
	}
}