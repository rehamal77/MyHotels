using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyHotels.Data;
using MyHotels.Models;

namespace MyHotels.Controllers
{

    public class ShoppingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private int id;

        public ShoppingController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var hotel = _context.Hotel.ToList();
            return View(hotel);
        }
        public IActionResult Invoice(int id)
        {
            
            var rooms = _context.Rooms.SingleOrDefault(p => p.Id == id);
            var invoice = new Invoice()
            {
                IdHRoom = rooms.Id,
                IdHotel = rooms.IdHotel,
                IdRoomDetails = rooms.Id,
                Price = rooms.Price,
                Total = (decimal)(rooms.Price * 1),
                DisCount = 0,
                Tax = (15/100),
                Net = (decimal)(rooms.Price * 1),
                Date = DateTime.Now,
                DateFrom = DateTime.Now.Date,
                DateTo = DateTime.Now.Date,
                UserId = 1,

            };
            _context.Invoice.Add(invoice);
            _context.SaveChanges();
            ViewBag.invoice = invoice;
            return View(invoice);
        }
        public IActionResult Rooms(int id)
        {
            var rooms = _context.Rooms.Where(x => x.IdHotel == id).ToList();
            return View(rooms);
        }
    }
}
