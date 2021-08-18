namespace OutlookObjectives
{
    using CommonObjectives;
    using Newtonsoft.Json;
    using Outlook = Microsoft.Office.Interop.Outlook;

    partial class FRObjectivesWeekReport
    {
        #region Form Region Factory

        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Appointment)]
        [Microsoft.Office.Tools.Outlook.FormRegionName("InTouch-Objectives.FRObjectivesWeekReport")]
        public partial class FRObjectivesWeekReportFactory
        {
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void FRObjectivesWeekReportFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
            {
            }
        }

        #endregion

        private Outlook.Inspector inspector;
        private Outlook.AppointmentItem appointment;
        private WeekReport weekReport;

        // Occurs before the form region is displayed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void FRObjectivesWeekReport_FormRegionShowing(object sender, System.EventArgs e)
        {
            inspector = ((Outlook.AppointmentItem)this.OutlookItem).GetInspector;
            if (inspector is object)
            {
                if (Globals.ThisAddIn.IAppointments.TryGetValue(inspector, out IAppointment iAppointment))
                {
                    appointment = ((Outlook.AppointmentItem)this.OutlookItem);
                    SetupRegion();
                }
            }
        }

        private void SetupRegion()
        {
            weekReport = JsonConvert.DeserializeObject<WeekReport>(appointment.Body);

            //appointment.Attachments[1].SaveAsFile(System.IO.Path.GetTempPath() + "ObjectivesChart.png");
            //appointment.Attachments[2].SaveAsFile(System.IO.Path.GetTempPath() + "SystemTime.png");
            //appointment.Attachments[3].SaveAsFile(System.IO.Path.GetTempPath() + "Applicatoins.png");
            //appointment.Attachments[4].SaveAsFile(System.IO.Path.GetTempPath() + "DayBar.png");
            string HTML = weekReport.HTML;
            string path = System.IO.Path.GetTempPath();
            HTML = HTML.Replace("[[[TEMPDIRECTORY]]]", path);
            InTouch.CreateCSS();
            webBrowser.DocumentText = HTML;
        }

        // Occurs when the form region is closed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void FRObjectivesWeekReport_FormRegionClosed(object sender, System.EventArgs e)
        {
        }
    }
}