namespace OutlookObjectives
{
    using CommonObjectives;
    using Newtonsoft.Json;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// A Form Region for the Objectives Day Report.
    /// </summary>
    internal partial class FRObjectivesDayReport
    {
        #region Form Region Factory

        /// <summary>
        /// FRObjectivesDayReportFactory.
        /// </summary>
        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Appointment)]
        [Microsoft.Office.Tools.Outlook.FormRegionName("InTouch-Objectives.FRObjectivesDayReport")]
        public partial class FRObjectivesDayReportFactory
        {
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void FRObjectivesDayReportFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
            {
            }
        }

        #endregion

        private Outlook.Inspector inspector;
        private Outlook.AppointmentItem appointment;
        private DayReport dayReport;

        /// <summary>
        /// FRObjectivesDayReport_FormRegionShowing method.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private void FRObjectivesDayReport_FormRegionShowing(object sender, System.EventArgs e)
        {
            inspector = ((Outlook.AppointmentItem)OutlookItem).GetInspector;
            if (inspector is object)
            {
                if (Globals.ThisAddIn.IAppointments.TryGetValue(inspector, out IAppointment iAppointment))
                {
                    appointment = (Outlook.AppointmentItem)OutlookItem;
                    SetupRegion();
                }
            }
        }

        private void SetupRegion()
        {
            dayReport = JsonConvert.DeserializeObject<DayReport>(appointment.Body);

            appointment.Attachments[1].SaveAsFile(System.IO.Path.GetTempPath() + "ObjectivesChart.png");
            appointment.Attachments[2].SaveAsFile(System.IO.Path.GetTempPath() + "SystemTime.png");
            appointment.Attachments[3].SaveAsFile(System.IO.Path.GetTempPath() + "Applicatoins.png");
            appointment.Attachments[4].SaveAsFile(System.IO.Path.GetTempPath() + "DayBar.png");
            string html = dayReport.HTML;
            string path = System.IO.Path.GetTempPath();
            html = html.Replace("[[[TEMPDIRECTORY]]]", path);
            InTouch.CreateCSS();
            webBrowser.DocumentText = html;
        }

        private void FRObjectivesDayReport_FormRegionClosed(object sender, System.EventArgs e)
        {
        }
    }
}