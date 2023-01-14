using System.ComponentModel.DataAnnotations;

namespace Elytra.Domain.Models
{
    //Just a test class
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public User? User { get; set; }
        public string? MessageText { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
