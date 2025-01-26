namespace HashChecker
{
    partial class UCMain
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
            _tbFileSel = new TextBox();
            _btnSelFile = new Button();
            _cbHashType = new ComboBox();
            _rtbHash = new RichTextBox();
            _lblEnterHash = new Label();
            _btnCompare = new Button();
            SuspendLayout();
            // 
            // _tbFileSel
            // 
            _tbFileSel.Location = new Point(36, 37);
            _tbFileSel.Name = "_tbFileSel";
            _tbFileSel.ReadOnly = true;
            _tbFileSel.Size = new Size(355, 23);
            _tbFileSel.TabIndex = 0;
            // 
            // _btnSelFile
            // 
            _btnSelFile.Location = new Point(397, 36);
            _btnSelFile.Name = "_btnSelFile";
            _btnSelFile.Size = new Size(30, 23);
            _btnSelFile.TabIndex = 1;
            _btnSelFile.Text = "...";
            _btnSelFile.UseVisualStyleBackColor = true;
            _btnSelFile.Click += _btnSelFile_Click;
            // 
            // _cbHashType
            // 
            _cbHashType.FormattingEnabled = true;
            _cbHashType.Location = new Point(481, 37);
            _cbHashType.Name = "_cbHashType";
            _cbHashType.Size = new Size(120, 23);
            _cbHashType.TabIndex = 2;
            _cbHashType.SelectedIndexChanged += _cbHashType_SelectedIndexChanged;
            // 
            // _rtbHash
            // 
            _rtbHash.Location = new Point(36, 142);
            _rtbHash.Name = "_rtbHash";
            _rtbHash.Size = new Size(355, 96);
            _rtbHash.TabIndex = 3;
            _rtbHash.Text = "";
            // 
            // _lblEnterHash
            // 
            _lblEnterHash.AutoSize = true;
            _lblEnterHash.Location = new Point(36, 124);
            _lblEnterHash.Name = "_lblEnterHash";
            _lblEnterHash.Size = new Size(16, 15);
            _lblEnterHash.TabIndex = 4;
            _lblEnterHash.Text = "...";
            // 
            // _btnCompare
            // 
            _btnCompare.Location = new Point(36, 244);
            _btnCompare.Name = "_btnCompare";
            _btnCompare.Size = new Size(75, 23);
            _btnCompare.TabIndex = 5;
            _btnCompare.Text = "Compare";
            _btnCompare.UseVisualStyleBackColor = true;
            _btnCompare.Click += _btnCompare_Click;
            // 
            // UCMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_btnCompare);
            Controls.Add(_lblEnterHash);
            Controls.Add(_rtbHash);
            Controls.Add(_cbHashType);
            Controls.Add(_btnSelFile);
            Controls.Add(_tbFileSel);
            Name = "UCMain";
            Size = new Size(1080, 569);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox _tbFileSel;
        private Button _btnSelFile;
        private ComboBox _cbHashType;
        private RichTextBox _rtbHash;
        private Label _lblEnterHash;
        private Button _btnCompare;
    }
}
