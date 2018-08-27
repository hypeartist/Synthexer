namespace SemanticColorizer.UI
{
	partial class OptionPageControl
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
			this._pnlClassificationFormat = new System.Windows.Forms.Panel();
			this._cpBackgroundColor = new ColorPickerDropDownControl();
			this._cpForegroundColor = new ColorPickerDropDownControl();
			this._chkIsUnderline = new System.Windows.Forms.CheckBox();
			this._chkIsItalic = new System.Windows.Forms.CheckBox();
			this._chkIsBold = new System.Windows.Forms.CheckBox();
			this._chkBackgroundColor = new System.Windows.Forms.CheckBox();
			this._chkForegroundColor = new System.Windows.Forms.CheckBox();
			this._lblBackgroundColor = new System.Windows.Forms.Label();
			this._lblForegroundColor = new System.Windows.Forms.Label();
			this._lbClassificationTypes = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this._pnlClassificationFormat.SuspendLayout();
			this.SuspendLayout();
			// 
			// _pnlClassificationFormat
			// 
			this._pnlClassificationFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._pnlClassificationFormat.Controls.Add(this._cpBackgroundColor);
			this._pnlClassificationFormat.Controls.Add(this._cpForegroundColor);
			this._pnlClassificationFormat.Controls.Add(this._chkIsUnderline);
			this._pnlClassificationFormat.Controls.Add(this._chkIsItalic);
			this._pnlClassificationFormat.Controls.Add(this._chkIsBold);
			this._pnlClassificationFormat.Controls.Add(this._chkBackgroundColor);
			this._pnlClassificationFormat.Controls.Add(this._chkForegroundColor);
			this._pnlClassificationFormat.Controls.Add(this._lblBackgroundColor);
			this._pnlClassificationFormat.Controls.Add(this._lblForegroundColor);
			this._pnlClassificationFormat.Location = new System.Drawing.Point(341, 3);
			this._pnlClassificationFormat.Name = "_pnlClassificationFormat";
			this._pnlClassificationFormat.Size = new System.Drawing.Size(227, 526);
			this._pnlClassificationFormat.TabIndex = 5;
			// 
			// colorPickerDropDownControl2
			// 
			this._cpBackgroundColor.Color = System.Drawing.Color.Empty;
			this._cpBackgroundColor.Location = new System.Drawing.Point(99, 30);
			this._cpBackgroundColor.Margin = new System.Windows.Forms.Padding(0);
			this._cpBackgroundColor.Name = "_cpBackgroundColor";
			this._cpBackgroundColor.Size = new System.Drawing.Size(104, 23);
			this._cpBackgroundColor.TabIndex = 12;
			// 
			// colorPickerDropDownControl1
			// 
			this._cpForegroundColor.Color = System.Drawing.Color.Black;
			this._cpForegroundColor.Location = new System.Drawing.Point(99, 5);
			this._cpForegroundColor.Margin = new System.Windows.Forms.Padding(0);
			this._cpForegroundColor.Name = "_cpForegroundColor";
			this._cpForegroundColor.Size = new System.Drawing.Size(104, 23);
			this._cpForegroundColor.TabIndex = 11;
			// 
			// checkBox2
			// 
			this._chkIsUnderline.AutoSize = true;
			this._chkIsUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._chkIsUnderline.Location = new System.Drawing.Point(153, 64);
			this._chkIsUnderline.Name = "_chkIsUnderline";
			this._chkIsUnderline.Size = new System.Drawing.Size(71, 17);
			this._chkIsUnderline.TabIndex = 10;
			this._chkIsUnderline.Text = "Underline";
			this._chkIsUnderline.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this._chkIsItalic.AutoSize = true;
			this._chkIsItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._chkIsItalic.Location = new System.Drawing.Point(99, 64);
			this._chkIsItalic.Name = "_chkIsItalic";
			this._chkIsItalic.Size = new System.Drawing.Size(48, 17);
			this._chkIsItalic.TabIndex = 9;
			this._chkIsItalic.Text = "Italic";
			this._chkIsItalic.UseVisualStyleBackColor = true;
			// 
			// _chkIsBold
			// 
			this._chkIsBold.AutoSize = true;
			this._chkIsBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._chkIsBold.Location = new System.Drawing.Point(42, 64);
			this._chkIsBold.Name = "_chkIsBold";
			this._chkIsBold.Size = new System.Drawing.Size(51, 17);
			this._chkIsBold.TabIndex = 8;
			this._chkIsBold.Text = "Bold";
			this._chkIsBold.UseVisualStyleBackColor = true;
			// 
			// _chkBackgroundColor
			// 
			this._chkBackgroundColor.AutoSize = true;
			this._chkBackgroundColor.Location = new System.Drawing.Point(206, 35);
			this._chkBackgroundColor.Name = "_chkBackgroundColor";
			this._chkBackgroundColor.Size = new System.Drawing.Size(15, 14);
			this._chkBackgroundColor.TabIndex = 7;
			this._chkBackgroundColor.UseVisualStyleBackColor = true;
			// 
			// _chkForegroundColor
			// 
			this._chkForegroundColor.AutoSize = true;
			this._chkForegroundColor.Checked = true;
			this._chkForegroundColor.CheckState = System.Windows.Forms.CheckState.Checked;
			this._chkForegroundColor.Location = new System.Drawing.Point(206, 10);
			this._chkForegroundColor.Name = "_chkForegroundColor";
			this._chkForegroundColor.Size = new System.Drawing.Size(15, 14);
			this._chkForegroundColor.TabIndex = 6;
			this._chkForegroundColor.UseVisualStyleBackColor = true;
			// 
			// _lblBackgroundColor
			// 
			this._lblBackgroundColor.AutoSize = true;
			this._lblBackgroundColor.Location = new System.Drawing.Point(6, 35);
			this._lblBackgroundColor.Name = "_lblBackgroundColor";
			this._lblBackgroundColor.Size = new System.Drawing.Size(94, 13);
			this._lblBackgroundColor.TabIndex = 3;
			this._lblBackgroundColor.Text = "Background color:";
			// 
			// _lblForegroundColor
			// 
			this._lblForegroundColor.AutoSize = true;
			this._lblForegroundColor.Location = new System.Drawing.Point(6, 10);
			this._lblForegroundColor.Name = "_lblForegroundColor";
			this._lblForegroundColor.Size = new System.Drawing.Size(90, 13);
			this._lblForegroundColor.TabIndex = 0;
			this._lblForegroundColor.Text = "Foreground color:";
			// 
			// _lbClassificationTypes
			// 
			this._lbClassificationTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._lbClassificationTypes.FormattingEnabled = true;
			this._lbClassificationTypes.Location = new System.Drawing.Point(5, 31);
			this._lbClassificationTypes.Name = "_lbClassificationTypes";
			this._lbClassificationTypes.Size = new System.Drawing.Size(330, 498);
			this._lbClassificationTypes.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(3, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Display items:";
			// 
			// OptionPageControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label2);
			this.Controls.Add(this._lbClassificationTypes);
			this.Controls.Add(this._pnlClassificationFormat);
			this.Name = "OptionPageControl";
			this.Size = new System.Drawing.Size(571, 536);
			this._pnlClassificationFormat.ResumeLayout(false);
			this._pnlClassificationFormat.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel _pnlClassificationFormat;
		private System.Windows.Forms.ListBox _lbClassificationTypes;
		private System.Windows.Forms.CheckBox _chkBackgroundColor;
		private System.Windows.Forms.CheckBox _chkForegroundColor;
		private System.Windows.Forms.Label _lblBackgroundColor;
		private System.Windows.Forms.Label _lblForegroundColor;
		private System.Windows.Forms.CheckBox _chkIsUnderline;
		private System.Windows.Forms.CheckBox _chkIsItalic;
		private System.Windows.Forms.CheckBox _chkIsBold;
		private System.Windows.Forms.Label label2;
		private ColorPickerDropDownControl _cpBackgroundColor;
		private ColorPickerDropDownControl _cpForegroundColor;
	}
}
