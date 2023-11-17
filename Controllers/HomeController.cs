using Microsoft.AspNetCore.Mvc;
using MyHotels.Controllers.Tuwiq.Controllers;
using MyHotels.Data;
using MyHotels.Models;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace MyHotels.Controllers
{

	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _context;
		private char hotel;

		List<Hotel> hotels;
		public HomeController(ApplicationDbContext context)
		{
			_context = context;
		}
        public IActionResult CreatNewRecord(Hotel hotel)
        {
            _context.Hotel.AddAsync(hotel);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
        public IActionResult Update(Hotel hotel)
		{
			_context.Update(hotel);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Edit(int id)
		{
			var hoteledit = _context.Hotel.SingleOrDefault(x => x.Id == id);

			return View(hoteledit);
		}

		public IActionResult Delete(int id)
		{
			var hoteldelete = _context.Hotel.SingleOrDefault(x => x.Id == id);

			_context.Hotel.Remove(hoteldelete); //Delete 
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

        public IActionResult Search(string Name)
        {
			var Searchotel = _context.Hotel.Where(x => x.Name.Contains(Name));

            if (Searchotel != null)
            {
                
                TempData["search"] = "ok";
            }

            return RedirectToAction("Index");
        }
        

        public IActionResult  Index()
		{
			var hotel = _context.Hotel.ToList();

			return View(hotel);

		}
		public IActionResult Hotels()
		{
			ViewBag.room = hotel;
			return View();
		}
		

		public IActionResult Privacy()
		{
			return View();
		}
		


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
	


