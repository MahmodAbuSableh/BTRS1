using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    [Index(nameof(Passenger.Username), IsUnique =true)]
    public class Passenger
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public ICollection<Passengers_Trips> passenger_trip { set; get; }

    }
}
