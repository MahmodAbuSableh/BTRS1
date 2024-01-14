using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class Passengers_Trips
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FK_Passnegers")]
        public Passenger passenger { get; set; }

        [ForeignKey("FK_Trips")]
        public Trip trip { get; set; }
    }
}
