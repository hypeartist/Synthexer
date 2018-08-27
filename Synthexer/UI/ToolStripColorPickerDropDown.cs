using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Cyotek.Windows.Forms;

namespace SemanticColorizer.UI
{
	[DefaultProperty("Color")]
	[DefaultEvent("ColorChanged")]
	internal sealed class ToolStripColorPickerDropDown : ToolStripDropDown
	{
		private static readonly object EventColorChanged = new object();
		private Color _color;

		public ToolStripColorPickerDropDown()
		{
			Host = new ColorGrid
			{
				AutoSize = true,
				Columns = 11,
//				Palette = ColorPalette.Named,
				Colors = ColorPalettes.HexagonPalette
			};

			Host.MouseClick += HostMouseClickHandler;
			Host.KeyDown += HostKeyDownHandler;

			Items.Add(new ToolStripControlHost(Host));
		}

		[Category("Property Changed")]
		public event EventHandler ColorChanged
		{
			add => Events.AddHandler(EventColorChanged, value);
			remove => Events.RemoveHandler(EventColorChanged, value);
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color Color
		{
			get => _color;
			set
			{
				if (Color == value)
				{
					return;
				}

				_color = value;
				if (!Host.CustomColors.Contains(_color))
				{
					if (_selectionCount >= Host.CustomColors.Count)
					{
						_selectionCount = 0;
					}
					Host.CustomColors[_selectionCount++] = _color;
				}
				OnColorChanged(EventArgs.Empty);
			}
		}

		private int _selectionCount;

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ColorGrid Host { get; private set; }

		/// <summary>
		///     Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.ToolStripDropDown" /> and optionally
		///     releases the managed resources.
		/// </summary>
		/// <param name="disposing">
		///     true to release both managed and unmanaged resources; false to release only unmanaged
		///     resources.
		/// </param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Items.Clear();
				Host.MouseClick -= HostMouseClickHandler;
				Host.KeyDown -= HostKeyDownHandler;
				Host.Dispose();
				Host = null;
			}

			base.Dispose(disposing);
		}

		/// <summary>
		///     Raises the <see cref="ColorChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		private void OnColorChanged(EventArgs e)
		{
			Host.Color = Color;
			(Events[EventColorChanged] as EventHandler)?.Invoke(this, e);
		}

		protected override void OnOpened(EventArgs e)
		{
			base.OnOpened(e);

			Host.Focus();
		}

		protected override void OnOpening(CancelEventArgs e)
		{
			base.OnOpening(e);

			if (Renderer is ToolStripProfessionalRenderer renderer)
			{
				Host.BackColor = renderer.ColorTable.ToolStripDropDownBackground;
			}

			Host.Color = Color;
		}

		private void HostKeyDownHandler(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					Close(ToolStripDropDownCloseReason.Keyboard);
					Color = Host.Color;
					break;
				case Keys.Escape:
					Close(ToolStripDropDownCloseReason.Keyboard);
					break;
			}
		}

		private void HostMouseClickHandler(object sender, MouseEventArgs e)
		{
			var info = Host.HitTest(e.Location);

			if (info.Index == ColorGrid.InvalidIndex)
			{
				return;
			}

			Close(ToolStripDropDownCloseReason.ItemClicked);

			Color = info.Color;
		}
	}
}