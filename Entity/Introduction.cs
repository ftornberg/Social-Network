namespace Entity
{
    public class Introduction
    {
        public DateTime JoinedDate { get; set; }

        public string ?LivesNowAt { get; set; }

        public string ?LivedBeforeAt { get; set; }

        public string ?WorksAt { get; set; }

        public List<string> ?HasWorkedAt { get; set; }
        
        public Relationship ?Relationship { get; set; }
    }
}