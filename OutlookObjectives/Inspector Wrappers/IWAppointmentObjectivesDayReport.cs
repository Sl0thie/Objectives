namespace OutlookObjectives
{
    using CommonObjectives;
    using LogNET;
    using System.Runtime.InteropServices;
    using Outlook = Microsoft.Office.Interop.Outlook;

    public class IWAppointmentObjectivesDayReport : IAppointment
    {
        private Outlook.Inspector inspector;
        public Outlook.Inspector Inspector
        {
            get
            {
                return inspector;
            }
        }

        private Outlook.AppointmentItem appointment;
        public Outlook.AppointmentItem Appointment
        {
            get { return appointment; }
        }

        private string folderPath;
        public string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }

        public AppointmentType AppointmentType { get; set; }

        public IWAppointmentObjectivesDayReport(Outlook.Inspector Inspector, string folderPath, AppointmentType appointmentType)
        {
            Log.MethodEntry();

            this.inspector = Inspector;
            this.folderPath = folderPath;
            appointment = (Outlook.AppointmentItem)inspector.CurrentItem;
            AppointmentType = appointmentType;

            ((Outlook.ItemEvents_10_Event)appointment).Close += Appointment_Close;
            ((Outlook.InspectorEvents_Event)inspector).Close += new Outlook.InspectorEvents_CloseEventHandler(InspectorWrapper_Close);

            Log.MethodExit();

        }

        void InspectorWrapper_Close()
        {
            Log.MethodEntry();

            Globals.ThisAddIn.IAppointments.Remove(inspector);

            ((Outlook.InspectorEvents_Event)inspector).Close -= new Outlook.InspectorEvents_CloseEventHandler(InspectorWrapper_Close);
            inspector = null;

            Log.MethodExit();
        }

        private void Appointment_Close(ref bool cancel)
        {
            Log.MethodEntry();
            ((Outlook.ItemEvents_10_Event)appointment).Close -= Appointment_Close;

            Log.MethodEntry();

            if (!appointment.Saved)
            {
                appointment.Save();
            }

            Log.MethodEntry();
            if (appointment != null) Marshal.ReleaseComObject(appointment);

            Log.MethodExit();
        }
    }
}