namespace OutlookObjectives
{
    using CommonObjectives;
    using LogNET;
    using System.Runtime.InteropServices;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// IWAppointmentObjectivesDayReport class.
    /// </summary>
    public class IWAppointmentObjectivesDayReport : IAppointment
    {
        private Outlook.Inspector inspector;
        private readonly Outlook.AppointmentItem appointment;
        private string folderPath;

        /// <summary>
        /// A reference to the Inspector displaying the appointment.
        /// </summary>
        public Outlook.Inspector Inspector
        {
            get
            {
                return inspector;
            }
        }

        /// <summary>
        /// A reference to the appointment object.
        /// </summary>
        public Outlook.AppointmentItem Appointment
        {
            get { return appointment; }
        }

        /// <summary>
        /// The Outlook path to the folder that contains the appointment.
        /// </summary>
        public string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }

        /// <summary>
        /// The type of appointment.
        /// </summary>
        public AppointmentType AppointmentType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IWAppointmentObjectivesDayReport"/> class.
        /// </summary>
        /// <param name="Inspector">Passes the Inspector of the appointment.</param>
        /// <param name="folderPath">The Outlook folder path to the appointment.</param>
        /// <param name="appointmentType">The type of appointment.</param>
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

        /// <summary>
        /// Method to remove the event handlers and remove this from the collection of inspectors.
        /// </summary>
        void InspectorWrapper_Close()
        {
            Log.MethodEntry();

            Globals.ThisAddIn.IAppointments.Remove(inspector);

            ((Outlook.InspectorEvents_Event)inspector).Close -= new Outlook.InspectorEvents_CloseEventHandler(InspectorWrapper_Close);
            inspector = null;

            Log.MethodExit();
        }

        /// <summary>
        /// Method to save the appointment when it is closed.
        /// </summary>
        /// <param name="cancel">This parameter is unused.</param>
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