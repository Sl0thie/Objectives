namespace OutlookObjectives
{

    partial class FormCreateObjective
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
            this.TextBoxObjective = new System.Windows.Forms.TextBox();
            this.ButtonCreateObjective = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxObjective
            // 
            this.TextBoxObjective.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.TextBoxObjective.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxObjective.ForeColor = System.Drawing.Color.White;
            this.TextBoxObjective.Location = new System.Drawing.Point(12, 12);
            this.TextBoxObjective.Name = "TextBoxObjective";
            this.TextBoxObjective.Size = new System.Drawing.Size(402, 27);
            this.TextBoxObjective.TabIndex = 0;
            // 
            // ButtonCreateObjective
            // 
            this.ButtonCreateObjective.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonCreateObjective.ForeColor = System.Drawing.Color.White;
            this.ButtonCreateObjective.Location = new System.Drawing.Point(420, 12);
            this.ButtonCreateObjective.Name = "ButtonCreateObjective";
            this.ButtonCreateObjective.Size = new System.Drawing.Size(142, 28);
            this.ButtonCreateObjective.TabIndex = 1;
            this.ButtonCreateObjective.Text = "Create Objective";
            this.ButtonCreateObjective.UseVisualStyleBackColor = true;
            this.ButtonCreateObjective.Click += new System.EventHandler(this.ButtonCreateObjective_Click);
            // 
            // FormCreateObjective
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(573, 51);
            this.Controls.Add(this.ButtonCreateObjective);
            this.Controls.Add(this.TextBoxObjective);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCreateObjective";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Objective";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxObjective;
        private System.Windows.Forms.Button ButtonCreateObjective;
    }
}