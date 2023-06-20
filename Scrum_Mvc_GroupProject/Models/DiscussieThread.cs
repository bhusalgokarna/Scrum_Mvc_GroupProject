namespace Scrum_Mvc_GroupProject.Models
{
    public class DiscussieThread
    {
        public int Id { get; set; }
        public string Comentaar { get; set; }
        //relationships
        public ICollection<Reactie> Reacties { get; set; }
        public int ForumCategoryId { get; set; }
        public ForumCategory forumCategory { get; set; }
    }
}
