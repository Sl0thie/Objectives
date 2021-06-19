namespace OutlookObjectives
{

    partial class FormChangeWorkType
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
            this.label1 = new System.Windows.Forms.Label();
            this.TextName = new System.Windows.Forms.TextBox();
            this.TextDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumCostPerHour = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.NumMinMinutes = new System.Windows.Forms.NumericUpDown();
            this.NumMaxMinutes = new System.Windows.Forms.NumericUpDown();
            this.ComboApplication = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumCostPerHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // TextName
            // 
            this.TextName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.TextName.ForeColor = System.Drawing.Color.White;
            this.TextName.Location = new System.Drawing.Point(161, 12);
            this.TextName.Name = "TextName";
            this.TextName.Size = new System.Drawing.Size(368, 27);
            this.TextName.TabIndex = 1;
            this.TextName.TextChanged += new System.EventHandler(this.TextName_TextChanged);
            // 
            // TextDescription
            // 
            this.TextDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.TextDescription.ForeColor = System.Drawing.Color.White;
            this.TextDescription.Location = new System.Drawing.Point(161, 45);
            this.TextDescription.Name = "TextDescription";
            this.TextDescription.Size = new System.Drawing.Size(368, 27);
            this.TextDescription.TabIndex = 3;
            this.TextDescription.TextChanged += new System.EventHandler(this.TextDescription_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // NumCostPerHour
            // 
            this.NumCostPerHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.NumCostPerHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumCostPerHour.DecimalPlaces = 2;
            this.NumCostPerHour.ForeColor = System.Drawing.Color.White;
            this.NumCostPerHour.Location = new System.Drawing.Point(161, 78);
            this.NumCostPerHour.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumCostPerHour.Name = "NumCostPerHour";
            this.NumCostPerHour.Size = new System.Drawing.Size(79, 23);
            this.NumCostPerHour.TabIndex = 34;
            this.NumCostPerHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumCostPerHour.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.NumCostPerHour.ValueChanged += new System.EventHandler(this.NumCostPerHour_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Cost per Hour";
            // 
            // NumMinMinutes
            // 
            this.NumMinMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.NumMinMinutes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumMinMinutes.ForeColor = System.Drawing.Color.White;
            this.NumMinMinutes.Location = new System.Drawing.Point(161, 107);
            this.NumMinMinutes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumMinMinutes.Name = "NumMinMinutes";
            this.NumMinMinutes.Size = new System.Drawing.Size(79, 23);
            this.NumMinMinutes.TabIndex = 36;
            this.NumMinMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumMinMinutes.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.NumMinMinutes.ValueChanged += new System.EventHandler(this.NumMinMinutes_ValueChanged);
            // 
            // NumMaxMinutes
            // 
            this.NumMaxMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.NumMaxMinutes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumMaxMinutes.ForeColor = System.Drawing.Color.White;
            this.NumMaxMinutes.Location = new System.Drawing.Point(161, 136);
            this.NumMaxMinutes.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.NumMaxMinutes.Name = "NumMaxMinutes";
            this.NumMaxMinutes.Size = new System.Drawing.Size(79, 23);
            this.NumMaxMinutes.TabIndex = 37;
            this.NumMaxMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumMaxMinutes.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.NumMaxMinutes.Value = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.NumMaxMinutes.ValueChanged += new System.EventHandler(this.NumMaxMinutes_ValueChanged);
            // 
            // ComboApplication
            // 
            this.ComboApplication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ComboApplication.ForeColor = System.Drawing.Color.White;
            this.ComboApplication.FormattingEnabled = true;
            this.ComboApplication.Location = new System.Drawing.Point(161, 165);
            this.ComboApplication.Name = "ComboApplication";
            this.ComboApplication.Size = new System.Drawing.Size(368, 28);
            this.ComboApplication.TabIndex = 38;
            this.ComboApplication.SelectedIndexChanged += new System.EventHandler(this.ComboApplication_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Min Minutes per Day";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "Max Minutes per Day";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 42;
            this.label6.Text = "Application";
            // 
            // FormChangeWorkType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(543, 235);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ComboApplication);
            this.Controls.Add(this.NumMaxMinutes);
            this.Controls.Add(this.NumMinMinutes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumCostPerHour);
            this.Controls.Add(this.TextDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChangeWorkType";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WorkType Details";
            this.Load += new System.EventHandler(this.FormChangeWorkType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumCostPerHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextName;
        private System.Windows.Forms.TextBox TextDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumCostPerHour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumMinMinutes;
        private System.Windows.Forms.NumericUpDown NumMaxMinutes;
        private System.Windows.Forms.ComboBox ComboApplication;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}