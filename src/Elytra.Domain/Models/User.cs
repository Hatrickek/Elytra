using System.ComponentModel.DataAnnotations;

namespace Elytra.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
