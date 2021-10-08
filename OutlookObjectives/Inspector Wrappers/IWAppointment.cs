namespace OutlookObjectives
{
    using CommonObjectives;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// IWAppointment class.
    /// </summary>
    internal class IWAppointment : IAppointment
    {
        private readonly Outlook.AppointmentItem appointment;
        private Outlook.Inspector inspector;
        private string folderPath;

        /// <summary>
        /// Gets the Appointment.
        /// </summary>
        public Outlook.AppointmentItem Appointment
        {
            get { return appointment; }
        }

        /// <summary>
        /// Gets the Inspector associated with the appointment.
        /// </summary>
        public Outlook.Inspector Inspector
        {
            get
            {
                return inspector;
            }
        }

        /// <summary>
        /// Gets or sets the folder path.
        /// </summary>
        public string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }

        /// <summary>
        /// Gets or sets the appointment type.
        /// </summary>
        public AppointmentType AppointmentType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IWAppointment"/> class.
        /// </summary>
        /// <param name="inspector">The inspector associated with the appointment.</param>
        /// <param name="folderPath">The folder path of the appointment.</param>
        /// <param name="appointmentType">The type of appointment.</param>
        public IWAppointment(Outlook.Inspector inspector, string folderPath, AppointmentType appointmentType)
        {
            this.inspector = inspector;
            this.folderPath = folderPath;
            appointment = (Outlook.AppointmentItem)this.inspector.CurrentItem;
            AppointmentType = appointmentType;

            ((Outlook.ItemEvents_10_Event)appointment).Close += Appointment_Close;
            ((Outlook.InspectorEvents_Event)this.inspector).Close += new Outlook.InspectorEvents_CloseEventHandler(InspectorWrapper_Close);
        }

        private void InspectorWrapper_Close()
        {
            _ = Globals.ThisAddIn.IAppointments.Remove(inspector);
            ((Outlook.InspectorEvents_Event)inspector).Close -=
                new Outlook.InspectorEvents_CloseEventHandler(InspectorWrapper_Close);
            inspector = null;
        }

        private void Appointment_Close(ref bool cancel)
        {
            ((Outlook.ItemEvents_10_Event)appointment).Close -= Appointment_Close;
            appointment.Save();
        }
    }
}
