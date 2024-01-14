using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        public string Destination { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BussNumber { get; set; }

        [ForeignKey("adminId")]
        public Admin Admin { get; set; }




        public ICollection<Buss> bus {  get; set; }
        public ICollection<Passengers_Trips> passenger_trip { set; get; }
    }
}
