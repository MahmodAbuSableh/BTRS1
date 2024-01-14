using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    [Index(nameof(Admin.Username), IsUnique = true)]
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }


        public ICollection<Buss> bus { get; set; }
        public ICollection<Trip> trip { get; set; }
    }
}
