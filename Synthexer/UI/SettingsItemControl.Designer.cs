namespace Synthexer.UI
{
	partial class SettingsItemControl
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
			this._chkIsItalic = new System.Windows.Forms.CheckBox();
			this._chkIsBold = new System.Windows.Forms.CheckBox();
			this._chkIsUnderline = new System.Windows.Forms.CheckBox();
			this._pnlForgroundColor = new System.Windows.Forms.Panel();
			this._lblForgroundColor = new System.Windows.Forms.Label();
			this._lblBackgroundColor = new System.Windows.Forms.Label();
			this._pnlBackgroundColor = new System.Windows.Forms.Panel();
			this._colorDialog = new System.Windows.Forms.ColorDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this._lblClassificationId = new System.Windows.Forms.Label();
			this.separator1 = new Synthexer.UI.Separator();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// _chkIsItalic
			// 
			this._chkIsItalic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._chkIsItalic.AutoSize = true;
			this._chkIsItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._chkIsItalic.Location = new System.Drawing.Point(396, 11);
			this._chkIsItalic.Name = "_chkIsItalic";
			this._chkIsItalic.Size = new System.Drawing.Size(48, 17);
			this._chkIsItalic.TabIndex = 1;
			this._chkIsItalic.Text = "Italic";
			this._chkIsItalic.UseVisualStyleBackColor = true;
			this._chkIsItalic.CheckedChanged += new System.EventHandler(this.On_chkIsItalic_CheckedChanged);
			// 
			// _chkIsBold
			// 
			this._chkIsBold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._chkIsBold.AutoSize = true;
			this._chkIsBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._chkIsBold.Location = new System.Drawing.Point(450, 11);
			this._chkIsBold.Name = "_chkIsBold";
			this._chkIsBold.Size = new System.Drawing.Size(51, 17);
			this._chkIsBold.TabIndex = 2;
			this._chkIsBold.Text = "Bold";
			this._chkIsBold.UseVisualStyleBackColor = true;
			this._chkIsBold.CheckedChanged += new System.EventHandler(this.On_chkIsBold_CheckedChanged);
			// 
			// _chkIsUnderline
			// 
			this._chkIsUnderline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._chkIsUnderline.AutoSize = true;
			this._chkIsUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._chkIsUnderline.Location = new System.Drawing.Point(507, 11);
			this._chkIsUnderline.Name = "_chkIsUnderline";
			this._chkIsUnderline.Size = new System.Drawing.Size(71, 17);
			this._chkIsUnderline.TabIndex = 3;
			this._chkIsUnderline.Text = "Underline";
			this._chkIsUnderline.UseVisualStyleBackColor = true;
			this._chkIsUnderline.CheckedChanged += new System.EventHandler(this.On_chkIsUnderline_CheckedChanged);
			// 
			// _pnlForgroundColor
			// 
			this._pnlForgroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._pnlForgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._pnlForgroundColor.Location = new System.Drawing.Point(140, 10);
			this._pnlForgroundColor.Name = "_pnlForgroundColor";
			this._pnlForgroundColor.Size = new System.Drawing.Size(25, 18);
			this._pnlForgroundColor.TabIndex = 4;
			this._pnlForgroundColor.Click += new System.EventHandler(this.On_pnlForgroundColor_Click);
			// 
			// _lblForgroundColor
			// 
			this._lblForgroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._lblForgroundColor.AutoSize = true;
			this._lblForgroundColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._lblForgroundColor.Location = new System.Drawing.Point(171, 12);
			this._lblForgroundColor.Name = "_lblForgroundColor";
			this._lblForgroundColor.Size = new System.Drawing.Size(82, 13);
			this._lblForgroundColor.TabIndex = 5;
			this._lblForgroundColor.Text = "Forground Color";
			// 
			// _lblBackgroundColor
			// 
			this._lblBackgroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._lblBackgroundColor.AutoSize = true;
			this._lblBackgroundColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._lblBackgroundColor.Location = new System.Drawing.Point(290, 12);
			this._lblBackgroundColor.Name = "_lblBackgroundColor";
			this._lblBackgroundColor.Size = new System.Drawing.Size(92, 13);
			this._lblBackgroundColor.TabIndex = 7;
			this._lblBackgroundColor.Text = "Background Color";
			// 
			// _pnlBackgroundColor
			// 
			this._pnlBackgroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._pnlBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._pnlBackgroundColor.Location = new System.Drawing.Point(259, 10);
			this._pnlBackgroundColor.Name = "_pnlBackgroundColor";
			this._pnlBackgroundColor.Size = new System.Drawing.Size(25, 18);
			this._pnlBackgroundColor.TabIndex = 6;
			this._pnlBackgroundColor.Click += new System.EventHandler(this.On_pnlBackgroundColor_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this._lblClassificationId);
			this.groupBox1.Controls.Add(this.separator1);
			this.groupBox1.Controls.Add(this._chkIsItalic);
			this.groupBox1.Controls.Add(this._lblBackgroundColor);
			this.groupBox1.Controls.Add(this._chkIsBold);
			this.groupBox1.Controls.Add(this._pnlBackgroundColor);
			this.groupBox1.Controls.Add(this._chkIsUnderline);
			this.groupBox1.Controls.Add(this._lblForgroundColor);
			this.groupBox1.Controls.Add(this._pnlForgroundColor);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(0, -5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(582, 32);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// _lblClassificationId
			// 
			this._lblClassificationId.AutoSize = true;
			this._lblClassificationId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._lblClassificationId.Location = new System.Drawing.Point(6, 12);
			this._lblClassificationId.Name = "_lblClassificationId";
			this._lblClassificationId.Size = new System.Drawing.Size(80, 13);
			this._lblClassificationId.TabIndex = 9;
			this._lblClassificationId.Text = "ClassificationId:";
			// 
			// separator1
			// 
			this.separator1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.separator1.Location = new System.Drawing.Point(388, 10);
			this.separator1.Name = "separator1";
			this.separator1.Orientation = Synthexer.UI.Separator.LineOrientation.Vertical;
			this.separator1.Size = new System.Drawing.Size(2, 18);
			this.separator1.TabIndex = 8;
			// 
			// SettingsItemControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "SettingsItemControl";
			this.Size = new System.Drawing.Size(582, 27);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.CheckBox _chkIsItalic;
		private System.Windows.Forms.CheckBox _chkIsBold;
		private System.Windows.Forms.CheckBox _chkIsUnderline;
		private System.Windows.Forms.Panel _pnlForgroundColor;
		private System.Windows.Forms.Label _lblForgroundColor;
		private System.Windows.Forms.Label _lblBackgroundColor;
		private System.Windows.Forms.Panel _pnlBackgroundColor;
		private UI.Separator separator1;
		private System.Windows.Forms.ColorDialog _colorDialog;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label _lblClassificationId;
	}
}
