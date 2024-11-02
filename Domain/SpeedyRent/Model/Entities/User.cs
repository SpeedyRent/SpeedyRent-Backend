using System.ComponentModel.DataAnnotations;
using Domain.Shared.Model.Entities;

namespace Domain.SpeedyRent.Model.Entities;

public class User : ModelBase
{
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        public ICollection<Post> Posts { get; set; } = new List<Post>();
}