namespace OutlookObjectives
{
    using CommonObjectives;

    /// <summary>
    /// Appointment Interface for the inspector wrapper.
    /// </summary>
    public interface IAppointment
    {
        /// <summary>
        /// Gets or sets the outlook folder path.
        /// </summary>
        string FolderPath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of appointment.
        /// </summary>
        AppointmentType AppointmentType
        {
            get;
            set;
        }
    }
}
