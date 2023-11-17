using System.ComponentModel.DataAnnotations;

namespace MyHotels.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdHotel { get; set; }
        [Required]

        public int IdHRoom { get; set; }
        [Required]
        public int IdRoomDetails { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public decimal Tax { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public decimal DisCount { get; set; }
        [Required]
        public decimal Net { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
    }
}
