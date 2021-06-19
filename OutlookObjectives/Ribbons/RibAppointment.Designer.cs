namespace OutlookObjectives
{

    partial class RibAppointment : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RibAppointment"/> class.
        /// </summary>
        public RibAppointment()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.buttonDefault = this.Factory.CreateRibbonButton();
            this.buttonMain = this.Factory.CreateRibbonButton();
            this.buttonDayReport = this.Factory.CreateRibbonButton();
            this.buttonAllFields = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group2);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group2
            // 
            this.group2.Items.Add(this.buttonDefault);
            this.group2.Items.Add(this.buttonMain);
            this.group2.Items.Add(this.buttonDayReport);
            this.group2.Items.Add(this.buttonAllFields);
            this.group2.Label = "View";
            this.group2.Name = "group2";
            // 
            // buttonDefault
            // 
            this.buttonDefault.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonDefault.Label = "Default";
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.ShowImage = true;
            // 
            // buttonMain
            // 
            this.buttonMain.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonMain.Label = "Main";
            this.buttonMain.Name = "buttonMain";
            this.buttonMain.ShowImage = true;
            // 
            // buttonDayReport
            // 
            this.buttonDayReport.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonDayReport.Label = "Day Report";
            this.buttonDayReport.Name = "buttonDayReport";
            this.buttonDayReport.ShowImage = true;
            // 
            // buttonAllFields
            // 
            this.buttonAllFields.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonAllFields.Label = "All Fields";
            this.buttonAllFields.Name = "buttonAllFields";
            this.buttonAllFields.ShowImage = true;
            // 
            // RibAppointment
            // 
            this.Name = "RibAppointment";
            this.RibbonType = "Microsoft.Outlook.Appointment";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibAppointment_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonDefault;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonMain;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonDayReport;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonAllFields;
    }

    partial class ThisRibbonCollection
    {
        internal RibAppointment RibAppointment
        {
            get { return this.GetRibbon<RibAppointment>(); }
        }
    }
}
