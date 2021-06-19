namespace OutlookObjectives
{
    using CommonObjectives;

    /// <summary>
    /// Appointment Interface for the inspector wrapper.
    /// </summary>
    public interface IAppointment
    {
        /// <summary>
        /// The outlook folder path.
        /// </summary>
        string FolderPath
        {
            get;
            set;
        }

        /// <summary>
        /// The type of appointment.
        /// </summary>
        AppointmentType AppointmentType
        {
            get;
            set;
        }
    }
}
