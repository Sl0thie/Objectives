namespace OutlookObjectives
{

    partial class FormSettings
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxObjectivesRootFolder = new System.Windows.Forms.TextBox();
            this.ButtonObjectivesRootFolder = new System.Windows.Forms.Button();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.LabelErrorObjectivesRootFolder = new System.Windows.Forms.Label();
            this.LabelErrorArchiveFolder = new System.Windows.Forms.Label();
            this.ButtonArchiveFolder = new System.Windows.Forms.Button();
            this.TextBoxArchiveFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LabelErrorAddinStorageFolder = new System.Windows.Forms.Label();
            this.ButtonAddinStorageFolder = new System.Windows.Forms.Button();
            this.TextBoxAddinStorageFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Objectives Folder Path";
            // 
            // TextBoxObjectivesRootFolder
            // 
            this.TextBoxObjectivesRootFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.TextBoxObjectivesRootFolder.ForeColor = System.Drawing.Color.White;
            this.TextBoxObjectivesRootFolder.Location = new System.Drawing.Point(16, 32);
            this.TextBoxObjectivesRootFolder.Name = "TextBoxObjectivesRootFolder";
            this.TextBoxObjectivesRootFolder.Size = new System.Drawing.Size(363, 27);
            this.TextBoxObjectivesRootFolder.TabIndex = 1;
            this.TextBoxObjectivesRootFolder.TabStop = false;
            this.TextBoxObjectivesRootFolder.TextChanged += new System.EventHandler(this.TextBoxObjectivesRootFolder_TextChanged);
            // 
            // ButtonObjectivesRootFolder
            // 
            this.ButtonObjectivesRootFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonObjectivesRootFolder.Location = new System.Drawing.Point(385, 32);
            this.ButtonObjectivesRootFolder.Name = "ButtonObjectivesRootFolder";
            this.ButtonObjectivesRootFolder.Size = new System.Drawing.Size(27, 27);
            this.ButtonObjectivesRootFolder.TabIndex = 2;
            this.ButtonObjectivesRootFolder.Text = "...";
            this.ButtonObjectivesRootFolder.UseVisualStyleBackColor = true;
            this.ButtonObjectivesRootFolder.Click += new System.EventHandler(this.ButtonObjectivesRootFolder_Click);
            // 
            // ButtonOk
            // 
            this.ButtonOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonOk.Location = new System.Drawing.Point(336, 238);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(76, 29);
            this.ButtonOk.TabIndex = 3;
            this.ButtonOk.Text = "Ok";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // LabelErrorObjectivesRootFolder
            // 
            this.LabelErrorObjectivesRootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelErrorObjectivesRootFolder.ForeColor = System.Drawing.Color.Red;
            this.LabelErrorObjectivesRootFolder.Location = new System.Drawing.Point(179, 9);
            this.LabelErrorObjectivesRootFolder.Name = "LabelErrorObjectivesRootFolder";
            this.LabelErrorObjectivesRootFolder.Size = new System.Drawing.Size(200, 20);
            this.LabelErrorObjectivesRootFolder.TabIndex = 4;
            this.LabelErrorObjectivesRootFolder.Text = " ";
            this.LabelErrorObjectivesRootFolder.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelErrorArchiveFolder
            // 
            this.LabelErrorArchiveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelErrorArchiveFolder.ForeColor = System.Drawing.Color.Red;
            this.LabelErrorArchiveFolder.Location = new System.Drawing.Point(227, 76);
            this.LabelErrorArchiveFolder.Name = "LabelErrorArchiveFolder";
            this.LabelErrorArchiveFolder.Size = new System.Drawing.Size(152, 20);
            this.LabelErrorArchiveFolder.TabIndex = 8;
            this.LabelErrorArchiveFolder.Text = " ";
            this.LabelErrorArchiveFolder.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ButtonArchiveFolder
            // 
            this.ButtonArchiveFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonArchiveFolder.Location = new System.Drawing.Point(385, 99);
            this.ButtonArchiveFolder.Name = "ButtonArchiveFolder";
            this.ButtonArchiveFolder.Size = new System.Drawing.Size(27, 27);
            this.ButtonArchiveFolder.TabIndex = 7;
            this.ButtonArchiveFolder.Text = "...";
            this.ButtonArchiveFolder.UseVisualStyleBackColor = true;
            this.ButtonArchiveFolder.Click += new System.EventHandler(this.ButtonArchiveFolder_Click);
            // 
            // TextBoxArchiveFolder
            // 
            this.TextBoxArchiveFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.TextBoxArchiveFolder.ForeColor = System.Drawing.Color.White;
            this.TextBoxArchiveFolder.Location = new System.Drawing.Point(16, 99);
            this.TextBoxArchiveFolder.Name = "TextBoxArchiveFolder";
            this.TextBoxArchiveFolder.Size = new System.Drawing.Size(363, 27);
            this.TextBoxArchiveFolder.TabIndex = 6;
            this.TextBoxArchiveFolder.TabStop = false;
            this.TextBoxArchiveFolder.TextChanged += new System.EventHandler(this.TextBoxArchiveFolder_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Objectives Archive Folder Path";
            // 
            // LabelErrorAddinStorageFolder
            // 
            this.LabelErrorAddinStorageFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelErrorAddinStorageFolder.ForeColor = System.Drawing.Color.Red;
            this.LabelErrorAddinStorageFolder.Location = new System.Drawing.Point(227, 143);
            this.LabelErrorAddinStorageFolder.Name = "LabelErrorAddinStorageFolder";
            this.LabelErrorAddinStorageFolder.Size = new System.Drawing.Size(152, 20);
            this.LabelErrorAddinStorageFolder.TabIndex = 12;
            this.LabelErrorAddinStorageFolder.Text = " ";
            this.LabelErrorAddinStorageFolder.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ButtonAddinStorageFolder
            // 
            this.ButtonAddinStorageFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonAddinStorageFolder.Location = new System.Drawing.Point(385, 166);
            this.ButtonAddinStorageFolder.Name = "ButtonAddinStorageFolder";
            this.ButtonAddinStorageFolder.Size = new System.Drawing.Size(27, 27);
            this.ButtonAddinStorageFolder.TabIndex = 11;
            this.ButtonAddinStorageFolder.Text = "...";
            this.ButtonAddinStorageFolder.UseVisualStyleBackColor = true;
            this.ButtonAddinStorageFolder.Click += new System.EventHandler(this.ButtonAddinStorageFolder_Click);
            // 
            // TextBoxAddinStorageFolder
            // 
            this.TextBoxAddinStorageFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.TextBoxAddinStorageFolder.ForeColor = System.Drawing.Color.White;
            this.TextBoxAddinStorageFolder.Location = new System.Drawing.Point(16, 166);
            this.TextBoxAddinStorageFolder.Name = "TextBoxAddinStorageFolder";
            this.TextBoxAddinStorageFolder.Size = new System.Drawing.Size(363, 27);
            this.TextBoxAddinStorageFolder.TabIndex = 10;
            this.TextBoxAddinStorageFolder.TabStop = false;
            this.TextBoxAddinStorageFolder.TextChanged += new System.EventHandler(this.TextBoxAddinStorageFolder_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Addin\'s Storage Folder Path";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(424, 279);
            this.Controls.Add(this.LabelErrorAddinStorageFolder);
            this.Controls.Add(this.ButtonAddinStorageFolder);
            this.Controls.Add(this.TextBoxAddinStorageFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LabelErrorArchiveFolder);
            this.Controls.Add(this.ButtonArchiveFolder);
            this.Controls.Add(this.TextBoxArchiveFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LabelErrorObjectivesRootFolder);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.ButtonObjectivesRootFolder);
            this.Controls.Add(this.TextBoxObjectivesRootFolder);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Objectives Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxObjectivesRootFolder;
        private System.Windows.Forms.Button ButtonObjectivesRootFolder;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Label LabelErrorObjectivesRootFolder;
        private System.Windows.Forms.Label LabelErrorArchiveFolder;
        private System.Windows.Forms.Button ButtonArchiveFolder;
        private System.Windows.Forms.TextBox TextBoxArchiveFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LabelErrorAddinStorageFolder;
        private System.Windows.Forms.Button ButtonAddinStorageFolder;
        private System.Windows.Forms.TextBox TextBoxAddinStorageFolder;
        private System.Windows.Forms.Label label4;
    }
}