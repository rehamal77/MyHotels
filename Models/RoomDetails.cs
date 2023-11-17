using System.ComponentModel.DataAnnotations;

namespace MyHotels.Models
{
    public class RoomDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Images1 { get; set; }
        [Required]
        [StringLength(50)]
        public string Images2 { get; set; }
        [Required]
        [StringLength(50)]
        public string Images3 { get; set; }
        [StringLength(50)]
        public string Food { get; set; }
        [Required]
        [StringLength(50)]
        public string Fettures { get; set; }
        [Required]
        [StringLength(50)]
        public int IdRoom { get; set; }
        [Required]
		[StringLength(50)]
		public int IdHotel { get; set; }

    }
}
