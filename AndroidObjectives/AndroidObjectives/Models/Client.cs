namespace AndroidObjectives.Data
{
    using SQLite;

    /// <summary>
    /// Client class.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Gets or sets the EntryID.
        /// </summary>
        [PrimaryKey]
        [Unique]
        public string EntryID { get; set; }

        /// <summary>
        /// Gets or sets the Title of the client.
        /// This is the prefix for the persons full name.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the FirstName.
        /// This is the client's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName.
        /// This is the last name of the client.
        /// </summary>
        public string LastName { get; set; }
    }
}
