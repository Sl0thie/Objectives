namespace CommonObjectives
{
    using System;

    public class Note
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Note()
        {
        }

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
