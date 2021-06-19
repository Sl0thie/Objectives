namespace OutlookObjectives
{
    using CommonObjectives;

    /// <summary>
    /// Appointment Interface for the inspector wrapper.</br>
    /// </summary>
    public interface IAppointment
    {
        /// <summary>
        /// The outlook folder path.</br>
        /// </summary>
        string FolderPath
        {
            get;
            set;
        }

        /// <summary>
        /// The type of appointment.</br>
        /// </summary>
        AppointmentType AppointmentType
        {
            get;
            set;
        }
    }
}
