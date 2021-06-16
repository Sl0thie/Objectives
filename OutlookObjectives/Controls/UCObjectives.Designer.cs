namespace OutlookObjectives
{

    partial class UCObjectives
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCObjectives));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListObjectives = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MenuObjective = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.MenuArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuActivate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRates = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1.SuspendLayout();
            this.MenuObjective.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ListObjectives);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 850);
            this.panel1.TabIndex = 3;
            // 
            // ListObjectives
            // 
            this.ListObjectives.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ListObjectives.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListObjectives.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ListObjectives.ContextMenuStrip = this.MenuObjective;
            this.ListObjectives.ForeColor = System.Drawing.Color.White;
            this.ListObjectives.FullRowSelect = true;
            this.ListObjectives.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListObjectives.HideSelection = false;
            this.ListObjectives.Location = new System.Drawing.Point(0, 0);
            this.ListObjectives.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListObjectives.MultiSelect = false;
            this.ListObjectives.Name = "ListObjectives";
            this.ListObjectives.Size = new System.Drawing.Size(570, 845);
            this.ListObjectives.SmallImageList = this.imageList1;
            this.ListObjectives.TabIndex = 1;
            this.ListObjectives.UseCompatibleStateImageBehavior = false;
            this.ListObjectives.View = System.Windows.Forms.View.Details;
            this.ListObjectives.SelectedIndexChanged += new System.EventHandler(this.ListObjectives_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Objective";
            this.columnHeader1.Width = 295;
            // 
            // MenuObjective
            // 
            this.MenuObjective.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.MenuObjective.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuObjective.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuDetails,
            this.MenuRates,
            this.toolStripSeparator1,
            this.MenuArchive,
            this.MenuActivate});
            this.MenuObjective.Name = "contextMenuStrip1";
            this.MenuObjective.Size = new System.Drawing.Size(200, 128);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "tick_button.png");
            this.imageList1.Images.SetKeyName(1, "prohibition_button.png");
            // 
            // MenuArchive
            // 
            this.MenuArchive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuArchive.ForeColor = System.Drawing.Color.White;
            this.MenuArchive.Name = "MenuArchive";
            this.MenuArchive.Size = new System.Drawing.Size(199, 24);
            this.MenuArchive.Text = "Archive Objective";
            this.MenuArchive.Click += new System.EventHandler(this.MenuArchive_Click);
            // 
            // MenuActivate
            // 
            this.MenuActivate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuActivate.ForeColor = System.Drawing.Color.White;
            this.MenuActivate.Name = "MenuActivate";
            this.MenuActivate.Size = new System.Drawing.Size(199, 24);
            this.MenuActivate.Text = "Activate Objective";
            this.MenuActivate.Click += new System.EventHandler(this.MenuActivate_Click);
            // 
            // MenuRates
            // 
            this.MenuRates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuRates.ForeColor = System.Drawing.Color.White;
            this.MenuRates.Name = "MenuRates";
            this.MenuRates.Size = new System.Drawing.Size(199, 24);
            this.MenuRates.Text = "Rates and Costs";
            this.MenuRates.Click += new System.EventHandler(this.MenuRates_Click);
            // 
            // MenuDetails
            // 
            this.MenuDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuDetails.ForeColor = System.Drawing.Color.White;
            this.MenuDetails.Name = "MenuDetails";
            this.MenuDetails.Size = new System.Drawing.Size(199, 24);
            this.MenuDetails.Text = "Objective Details";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // UCObjectives
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UCObjectives";
            this.Size = new System.Drawing.Size(512, 912);
            this.Load += new System.EventHandler(this.UCObjectives_Load);
            this.Resize += new System.EventHandler(this.UCObjectives_Resize);
            this.panel1.ResumeLayout(false);
            this.MenuObjective.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView ListObjectives;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip MenuObjective;
        private System.Windows.Forms.ToolStripMenuItem MenuArchive;
        private System.Windows.Forms.ToolStripMenuItem MenuActivate;
        private System.Windows.Forms.ToolStripMenuItem MenuRates;
        private System.Windows.Forms.ToolStripMenuItem MenuDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
