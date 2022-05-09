using System.ComponentModel.DataAnnotations;
namespace MVCPractice.Models
{
    public class Customer
    {
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
