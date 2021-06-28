namespace CommonObjectives
{
    /// <summary>
    /// Client class extends the outlook ContactItem 
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Get or sets the EntryID. 
        /// This is the Outlook ContactItem EntryID for the contact that is a client.
        /// </summary>
        public string EntryId { get; set; }

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