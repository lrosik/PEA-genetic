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
            this.buttonTest = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.buttonOX = new System.Windows.Forms.Button();
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
            this.buttonLoadFile.Text = "button1";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(12, 41);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 1;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(93, 12);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(455, 563);
            this.listBox.TabIndex = 2;
            // 
            // buttonOX
            // 
            this.buttonOX.Location = new System.Drawing.Point(12, 71);
            this.buttonOX.Name = "buttonOX";
            this.buttonOX.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonOX.Size = new System.Drawing.Size(75, 23);
            this.buttonOX.TabIndex = 3;
            this.buttonOX.Text = "OX";
            this.buttonOX.UseVisualStyleBackColor = true;
            this.buttonOX.Click += new System.EventHandler(this.buttonOX_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 585);
            this.Controls.Add(this.buttonOX);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonLoadFile);
            this.Name = "FormMain";
            this.Text = "PEA Algorytm genetyczny";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button buttonOX;
    }
}

