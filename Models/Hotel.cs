using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MyHotels.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(25)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string Images { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        [StringLength(100)]
        public string Emile { get; set; }

  
    }
}
