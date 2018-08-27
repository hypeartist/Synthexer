using Cyotek.Windows.Forms;

namespace SemanticColorizer.UI
{
	sealed partial class ColorPickerDialog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
			this.components = new System.ComponentModel.Container();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.colorWheel = new Cyotek.Windows.Forms.ColorWheel();
			this.colorEditor = new Cyotek.Windows.Forms.ColorEditor();
			this.colorGrid = new Cyotek.Windows.Forms.ColorGrid();
			this.colorEditorManager = new Cyotek.Windows.Forms.ColorEditorManager();
			this.previewPanel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.Location = new System.Drawing.Point(365, 252);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(282, 252);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// colorWheel
			// 
			this.colorWheel.Location = new System.Drawing.Point(12, 4);
			this.colorWheel.Name = "colorWheel";
			this.colorWheel.Size = new System.Drawing.Size(192, 155);
			this.colorWheel.TabIndex = 4;
			// 
			// colorEditor
			// 
			this.colorEditor.Location = new System.Drawing.Point(210, 12);
			this.colorEditor.Name = "colorEditor";
			this.colorEditor.Size = new System.Drawing.Size(230, 233);
			this.colorEditor.TabIndex = 0;
			// 
			// colorGrid
			// 
			this.colorGrid.AutoAddColors = false;
			this.colorGrid.CellBorderStyle = Cyotek.Windows.Forms.ColorCellBorderStyle.None;
			this.colorGrid.EditMode = Cyotek.Windows.Forms.ColorEditingMode.Both;
			this.colorGrid.Location = new System.Drawing.Point(12, 165);
			this.colorGrid.Name = "colorGrid";
			this.colorGrid.Padding = new System.Windows.Forms.Padding(0);
			this.colorGrid.Palette = Cyotek.Windows.Forms.ColorPalette.Paint;
			this.colorGrid.SelectedCellStyle = Cyotek.Windows.Forms.ColorGridSelectedCellStyle.Standard;
			this.colorGrid.ShowCustomColors = false;
			this.colorGrid.Size = new System.Drawing.Size(192, 72);
			this.colorGrid.Spacing = new System.Drawing.Size(0, 0);
			this.colorGrid.TabIndex = 7;
			this.colorGrid.EditingColor += new System.EventHandler<Cyotek.Windows.Forms.EditColorCancelEventArgs>(this.colorGrid_EditingColor);
			// 
			// colorEditorManager
			// 
			this.colorEditorManager.ColorEditor = this.colorEditor;
			this.colorEditorManager.ColorGrid = this.colorGrid;
			this.colorEditorManager.ColorWheel = this.colorWheel;
			this.colorEditorManager.ColorChanged += new System.EventHandler(this.colorEditorManager_ColorChanged);
			// 
			// previewPanel
			// 
			this.previewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.previewPanel.Location = new System.Drawing.Point(12, 243);
			this.previewPanel.Name = "previewPanel";
			this.previewPanel.Size = new System.Drawing.Size(192, 32);
			this.previewPanel.TabIndex = 8;
			this.previewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.previewPanel_Paint);
			// 
			// ColorPickerDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(450, 284);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.previewPanel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.colorWheel);
			this.Controls.Add(this.colorEditor);
			this.Controls.Add(this.colorGrid);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ColorPickerDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Color Picker";
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private ColorGrid colorGrid;
    private ColorEditor colorEditor;
    private ColorWheel colorWheel;
    private ColorEditorManager colorEditorManager;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Panel previewPanel;
	}
}