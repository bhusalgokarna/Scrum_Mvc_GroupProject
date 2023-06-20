namespace Scrum_Mvc_GroupProject.Models
{
    public class ForumCategory
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        //relationships
        public ICollection<DiscussieThread> discussies { get; set; }
    }
}
