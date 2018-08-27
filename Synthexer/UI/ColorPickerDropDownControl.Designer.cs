namespace SemanticColorizer.UI
{
	sealed partial class ColorPickerDropDownControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPickerDropDownControl));
			this._toolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new ToolStripColorPickerSplitButton();
			this._toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this._toolStrip.AutoSize = false;
			this._toolStrip.BackColor = System.Drawing.Color.Transparent;
			this._toolStrip.CanOverflow = false;
			this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this._toolStrip.GripMargin = new System.Windows.Forms.Padding(0);
			this._toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this._toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
			this._toolStrip.Location = new System.Drawing.Point(0, 0);
			this._toolStrip.Name = "_toolStrip";
			this._toolStrip.Padding = new System.Windows.Forms.Padding(1);
			this._toolStrip.Size = new System.Drawing.Size(115, 23);
			this._toolStrip.TabIndex = 0;
			this._toolStrip.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.AutoSize = false;
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.DropDownButtonWidth = 15;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0);
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(113, 21);
			// 
			// UserControl1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._toolStrip);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "ColorPickerDropDownControl";
			this.Size = new System.Drawing.Size(115, 23);
			this._toolStrip.ResumeLayout(false);
			this._toolStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip _toolStrip;
		private ToolStripColorPickerSplitButton toolStripButton1;
	}
}
