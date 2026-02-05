namespace Clock
{
    partial class FontDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontDialog));
            this.comboBoxFonts = new System.Windows.Forms.ComboBox();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.labelExample = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxFonts
            // 
            this.comboBoxFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFonts.FormattingEnabled = true;
            this.comboBoxFonts.Location = new System.Drawing.Point(63, 47);
            this.comboBoxFonts.Name = "comboBoxFonts";
            this.comboBoxFonts.Size = new System.Drawing.Size(507, 28);
            this.comboBoxFonts.TabIndex = 0;
            this.comboBoxFonts.SelectedIndexChanged += new System.EventHandler(this.comboBoxFonts_SelectedIndexChanged);
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Location = new System.Drawing.Point(587, 48);
            this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            58,
            0,
            0,
            0});
            this.numericUpDownFontSize.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownFontSize.TabIndex = 1;
            this.numericUpDownFontSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownFontSize.ValueChanged += new System.EventHandler(this.numericUpDownFontSize_ValueChanged);
            // 
            // labelExample
            // 
            this.labelExample.AutoSize = true;
            this.labelExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelExample.Location = new System.Drawing.Point(63, 111);
            this.labelExample.Name = "labelExample";
            this.labelExample.Size = new System.Drawing.Size(282, 73);
            this.labelExample.TabIndex = 2;
            this.labelExample.Text = "Example";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(495, 403);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(102, 37);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(614, 403);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(93, 37);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // FontDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 487);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelExample);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.comboBoxFonts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FontDialog";
            this.ShowInTaskbar = false;
            this.Text = "FontDialog";
            this.Load += new System.EventHandler(this.FontDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFonts;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.Label labelExample;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}