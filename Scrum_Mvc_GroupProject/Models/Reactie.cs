namespace Scrum_Mvc_GroupProject.Models
{
    public class Reactie
    {
        public int Id { get; set; }
        public string Comentaar { get; set; }
        //relationships
        public int DiscussieThreadId { get; set; }
        public DiscussieThread discussieThread { get; set; }
    }
}
