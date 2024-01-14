using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class Buss
    {
        [Key]
        public int Id { get; set; }
        public string CapName { get; set; }
        public int SeatsNumber { get; set; }

        [ForeignKey("tripId")]
        public Trip Trip { get; set; }

        [ForeignKey("adminId")]
        public Admin Admin { get; set; }
    }
}
