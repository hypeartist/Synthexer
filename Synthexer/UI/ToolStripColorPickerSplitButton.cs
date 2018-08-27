using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Cyotek.Windows.Forms;

namespace SemanticColorizer.UI
{
	[DefaultProperty("Color")]
	[DefaultEvent("ColorChanged")]
	[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
	public sealed class ToolStripColorPickerSplitButton : ToolStripSplitButton
	{
		private static readonly object EventColorChanged = new object();

		public ToolStripColorPickerSplitButton()
		{
			AutoSize = false;
			DropDownButtonWidth = 15;
			Margin = Padding.Empty;
		}

		[Category("Property Changed")]
		public event EventHandler ColorChanged
		{
			add => Events.AddHandler(EventColorChanged, value);
			remove => Events.RemoveHandler(EventColorChanged, value);
		}

		private Color _color;

		private ToolStripColorPickerDropDown _dropDown;

		[Category("Data")]
		[DefaultValue(typeof(Color), "Black")]
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
				OnColorChanged(EventArgs.Empty);
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ToolStripDropDown DropDown
		{
			get => base.DropDown;
			set => base.DropDown = value;
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ColorGrid Host
		{
			get
			{
				EnsureDropDownIsCreated();

				return _dropDown.Host;
			}
		}

		protected override ToolStripDropDown CreateDefaultDropDown()
		{
			EnsureDropDownIsCreated();

			return _dropDown;
		}

		protected override void OnOwnerChanged(EventArgs e)
		{
			base.OnOwnerChanged(e);
			if(Owner == null) return;
			Owner.SizeChanged += OwnerOnSizeChanged;
		}

		private void OwnerOnSizeChanged(object sender, EventArgs e)
		{
			Height = Owner.Height - Owner.Padding.All * 2;
			Width = Owner.Width - Owner.Padding.All * 2;
		}

		/// <summary>
		///     Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> and
		///     optionally releases the managed resources.
		/// </summary>
		/// <param name="disposing">
		///     true to release both managed and unmanaged resources; false to release only unmanaged
		///     resources.
		/// </param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_dropDown != null)
				{
					DropDown = null;
					_dropDown.Dispose();
					_dropDown.ColorChanged -= DropDownColorChangedHandler;
					_dropDown = null;
				}
			}

			base.Dispose(disposing);
		}

		/// <summary>
		///     Raises the <see cref="E:System.Windows.Forms.ToolStripSplitButton.ButtonClick" /> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data. </param>
		protected override void OnButtonClick(EventArgs e)
		{
			base.OnButtonClick(e);

			using (var dialog = new ColorPickerDialog {ShowAlphaChannel = false})
			{
				dialog.Color = Color;

				if (dialog.ShowDialog(GetCurrentParent()) == DialogResult.OK)
				{
					Color = dialog.Color;
				}
			}
		}

		/// <summary>
		///     Raises the <see cref="ColorChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		private void OnColorChanged(EventArgs e)
		{
			Invalidate();

			if (_dropDown != null)
			{
				_dropDown.Color = Color;
			}
			(Events[EventColorChanged] as EventHandler)?.Invoke(this, e);
		}

		/// <summary>
		///     Raised in response to the <see cref="M:System.Windows.Forms.ToolStripDropDownItem.ShowDropDown" /> method.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		protected override void OnDropDownShow(EventArgs e)
		{
			EnsureDropDownIsCreated();
			base.OnDropDownShow(e);
		}

		/// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data. </param>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			using (Brush brush = new SolidBrush(Color))
			{
				e.Graphics.FillRectangle(brush, new Rectangle(1, 1, Width - DropDownButtonWidth - 2, Height - 2));
			}
		}

		private void DropDownColorChangedHandler(object sender, EventArgs e)
		{
			Color = _dropDown.Color;
		}

		private void EnsureDropDownIsCreated()
		{
			if (_dropDown != null)
			{
				return;
			}

			_dropDown = new ToolStripColorPickerDropDown();
			_dropDown.ColorChanged += DropDownColorChangedHandler;
		}
	}
}