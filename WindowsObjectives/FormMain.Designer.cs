
namespace WindowsObjectives
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventLogApplication = new System.Diagnostics.EventLog();
            this.eventLogSecurity = new System.Diagnostics.EventLog();
            this.eventLogSetup = new System.Diagnostics.EventLog();
            this.eventLogSystem = new System.Diagnostics.EventLog();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogSecurity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogSetup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogSystem)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripMain;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Objectives - System Monitor";
            this.notifyIconMain.Visible = true;
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(117, 48);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // eventLogApplication
            // 
            this.eventLogApplication.EnableRaisingEvents = true;
            this.eventLogApplication.Log = "Application";
            this.eventLogApplication.SynchronizingObject = this;
            // 
            // eventLogSecurity
            // 
            this.eventLogSecurity.Log = "Security";
            this.eventLogSecurity.SynchronizingObject = this;
            // 
            // eventLogSetup
            // 
            this.eventLogSetup.Log = "Key Management Service";
            this.eventLogSetup.SynchronizingObject = this;
            // 
            // eventLogSystem
            // 
            this.eventLogSystem.EnableRaisingEvents = true;
            this.eventLogSystem.Log = "System";
            this.eventLogSystem.SynchronizingObject = this;
            // 
            // timerMain
            // 
            this.timerMain.Enabled = true;
            this.timerMain.Interval = 50000;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(96, 84);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStripMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventLogApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogSecurity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogSetup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogSystem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Diagnostics.EventLog eventLogApplication;
        private System.Diagnostics.EventLog eventLogSecurity;
        private System.Diagnostics.EventLog eventLogSetup;
        private System.Diagnostics.EventLog eventLogSystem;
        private System.Windows.Forms.Timer timerMain;
    }
}

