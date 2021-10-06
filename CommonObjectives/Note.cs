namespace CommonObjectives
{
    using System;

    /// <summary>
    /// Note holds data for notes created for other objects.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Gets or sets the Id for the note.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the time the note is first created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the time the note is modified.
        /// </summary>
        public DateTime Modified { get; set; }

        /// <summary>
        /// Gets or sets the title for the note.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content of the note.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class.
        /// </summary>
        public Note()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class.
        /// </summary>
        /// <param name="title">The title of the note.</param>
        /// <param name="content">The content of the note.</param>
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
