using Domain.Shared.Model.Entities;

namespace Domain.SpeedyRent.Model.Entities
{
    public class Post : ModelBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId  { get; set; }
        public User User { get; set; }
    }
}