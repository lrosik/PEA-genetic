namespace Projekt3
{
    partial class FormMain
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.listBoxInvert = new System.Windows.Forms.ListBox();
            this.listBoxSwap = new System.Windows.Forms.ListBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.comboBoxMutationType = new System.Windows.Forms.ComboBox();
            this.labelMutationType = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPopulationSize = new System.Windows.Forms.TextBox();
            this.labelInvert = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Location = new System.Drawing.Point(12, 12);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadFile.TabIndex = 0;
            this.buttonLoadFile.Text = "Wczytaj";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // listBoxInvert
            // 
            this.listBoxInvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxInvert.FormattingEnabled = true;
            this.listBoxInvert.Location = new System.Drawing.Point(12, 137);
            this.listBoxInvert.Name = "listBoxInvert";
            this.listBoxInvert.Size = new System.Drawing.Size(300, 316);
            this.listBoxInvert.TabIndex = 2;
            // 
            // listBoxSwap
            // 
            this.listBoxSwap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxSwap.FormattingEnabled = true;
            this.listBoxSwap.Location = new System.Drawing.Point(318, 137);
            this.listBoxSwap.Name = "listBoxSwap";
            this.listBoxSwap.Size = new System.Drawing.Size(300, 316);
            this.listBoxSwap.TabIndex = 3;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(237, 14);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(75, 20);
            this.textBoxTime.TabIndex = 4;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(131, 17);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(100, 13);
            this.labelTime.TabIndex = 5;
            this.labelTime.Text = "Czas wykonywania:";
            // 
            // comboBoxMutationType
            // 
            this.comboBoxMutationType.FormattingEnabled = true;
            this.comboBoxMutationType.Items.AddRange(new object[] {
            "Invert",
            "Swap"});
            this.comboBoxMutationType.Location = new System.Drawing.Point(422, 13);
            this.comboBoxMutationType.Name = "comboBoxMutationType";
            this.comboBoxMutationType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMutationType.TabIndex = 6;
            // 
            // labelMutationType
            // 
            this.labelMutationType.AutoSize = true;
            this.labelMutationType.Location = new System.Drawing.Point(352, 17);
            this.labelMutationType.Name = "labelMutationType";
            this.labelMutationType.Size = new System.Drawing.Size(64, 13);
            this.labelMutationType.TabIndex = 7;
            this.labelMutationType.Text = "Typ mutacji:";
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(12, 82);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 8;
            this.buttonRun.Text = "Uruchom";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Rozmiar populacji:";
            // 
            // textBoxPopulationSize
            // 
            this.textBoxPopulationSize.Location = new System.Drawing.Point(237, 41);
            this.textBoxPopulationSize.Name = "textBoxPopulationSize";
            this.textBoxPopulationSize.Size = new System.Drawing.Size(75, 20);
            this.textBoxPopulationSize.TabIndex = 9;
            // 
            // labelInvert
            // 
            this.labelInvert.AutoSize = true;
            this.labelInvert.Location = new System.Drawing.Point(9, 121);
            this.labelInvert.Name = "labelInvert";
            this.labelInvert.Size = new System.Drawing.Size(34, 13);
            this.labelInvert.TabIndex = 11;
            this.labelInvert.Text = "Invert";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Swap";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 471);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelInvert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPopulationSize);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.labelMutationType);
            this.Controls.Add(this.comboBoxMutationType);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.listBoxSwap);
            this.Controls.Add(this.listBoxInvert);
            this.Controls.Add(this.buttonLoadFile);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PEA Algorytm genetyczny - Łukasz Rosik 225987";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.ListBox listBoxInvert;
        private System.Windows.Forms.ListBox listBoxSwap;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.ComboBox comboBoxMutationType;
        private System.Windows.Forms.Label labelMutationType;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPopulationSize;
        private System.Windows.Forms.Label labelInvert;
        private System.Windows.Forms.Label label2;
    }
}

