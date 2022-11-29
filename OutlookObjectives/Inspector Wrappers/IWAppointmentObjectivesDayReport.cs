namespace OutlookObjectives
{
    using System.Runtime.InteropServices;
    using CommonObjectives;
    using Serilog;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// IWAppointmentObjectivesDayReport class.
    /// </summary>
    public class IWAppointmentObjectivesDayReport : IAppointment
    {
        private readonly Outlook.AppointmentItem appointment;
        private Outlook.Inspector inspector;
        private string folderPath;

        /// <summary>
        /// Gets a reference to the Inspector displaying the appointment.
        /// </summary>
        public Outlook.Inspector Inspector
        {
            get
            {
                return inspector;
            }
        }

        /// <summary>
        /// Gets a reference to the appointment object.
        /// </summary>
        public Outlook.AppointmentItem Appointment
        {
            get { return appointment; }
        }

        /// <summary>
        /// Gets or sets the Outlook path to the folder that contains the appointment.
        /// </summary>
        public string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }

        /// <summary>
        /// Gets or sets the type of appointment.
        /// </summary>
        public AppointmentType AppointmentType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IWAppointmentObjectivesDayReport"/> class.
        /// </summary>
        /// <param name="inspector">Passes the Inspector of the appointment.</param>
        /// <param name="folderPath">The Outlook folder path to the appointment.</param>
        /// <param name="appointmentType">The type of appointment.</param>
        public IWAppointmentObjectivesDayReport(Outlook.Inspector inspector, string folderPath, AppointmentType appointmentType)
        {
            this.inspector = inspector;
            this.folderPath = folderPath;
            appointment = (Outlook.AppointmentItem)this.inspector.CurrentItem;
            AppointmentType = appointmentType;

            ((Outlook.ItemEvents_10_Event)appointment).Close += Appointment_Close;
            ((Outlook.InspectorEvents_Event)this.inspector).Close += new Outlook.InspectorEvents_CloseEventHandler(InspectorWrapper_Close);
        }

        /// <summary>
        /// Method to remove the event handlers and remove this from the collection of inspectors.
        /// </summary>
        private void InspectorWrapper_Close()
        {
            _ = Globals.ThisAddIn.IAppointments.Remove(inspector);

            ((Outlook.InspectorEvents_Event)inspector).Close -= new Outlook.InspectorEvents_CloseEventHandler(InspectorWrapper_Close);
            inspector = null;
        }

        /// <summary>
        /// Method to save the appointment when it is closed.
        /// </summary>
        /// <param name="cancel">This parameter is unused.</param>
        private void Appointment_Close(ref bool cancel)
        {
            ((Outlook.ItemEvents_10_Event)appointment).Close -= Appointment_Close;

            if (!appointment.Saved)
            {
                appointment.Save();
            }

            if (appointment != null)
            {
                _ = Marshal.ReleaseComObject(appointment);
            }
        }
    }
}