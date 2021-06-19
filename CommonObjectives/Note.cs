namespace CommonObjectives
{
    using System;

    /// <summary>
    /// Note holds data for notes created for other objects.</br>
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Id for the note.</br>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The time the note is first created.</br>
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The time the note is modified.</br>
        /// </summary>
        public DateTime Modified { get; set; }

        /// <summary>
        /// The title for the note.</br>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The content of the note.</br>
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Empty constructor for serialization.</br>
        /// </summary>
        public Note()
        {
        }

        /// <summary>
        /// Constructor to fill data on creation.</br>
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public Note(string title, string content)
        {
            Id = Guid.NewGuid();
            Created = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
            Modified = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
            Title = title;
            Content = content;
        }
    }
}
