using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using MyHotels.Data;
using MyHotels.Models;
using MimeKit;
using MailKit.Net.Smtp;



namespace MyHotels.Controllers
{
    public class DashBoardController : Controller
    {
		private readonly ApplicationDbContext _context;
        public DashBoardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> SendEmail()
        {
            var message = new MimeMessage(); //تعريف المستقبل والمرسل
            message.From.Add(new MailboxAddress("test messsag", "Reham6384@gmail.com"));
            message.To.Add(MailboxAddress.Parse("Reham5081@gmail.com"));
            message.Subject = "test emaile my project in asp.net core mvc";
            message.Body = new TextPart("plain")
            {
                Text = "welcom in my app"
            };

            using( var Client=new SmtpClient())
            {
                try
                {
                    Client.Connect("Smtp.gmail.com",587);
                    Client.Authenticate("Reham6384@gmail.com" , "zytpaswvdciewrjy");
                    await Client.SendAsync(message);
                    Client.Disconnect(true);
                }
                catch ( Exception e )
                {
                    return e.Message.ToString();
                }
                
            }
            return "ok";
        }

		//zytpaswvdciewrjy   //passwordMyApp
		public IActionResult Update(Hotel hotel)
        {
            _context.Update(hotel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var hotelDel = _context.Hotel.SingleOrDefault(x=>x.Id==id);
            if (hotelDel != null)
            {
                _context.Hotel.Remove(hotelDel);
                _context.SaveChanges();
                TempData["Del"] = "ok";
            }

            return RedirectToAction("Index");
        }
		public IActionResult Edit(int id)
		{
			var hoteledit = _context.Hotel.SingleOrDefault(x => x.Id == id);

			return View(hoteledit);
		}

		[Authorize]
		public IActionResult Index()
        {
            var currentuser = HttpContext.User.Identity.Name;

            ViewBag.currentuser = currentuser;
            //CookieOptions Option = new CookieOptions(); //save darta in cookies 
            //Option.Expires = DateTime.Now.AddMinutes(20);
            //Response.Cookies.Append("UserName", currentuser, Option);

            HttpContext.Session.SetString("username", currentuser);
            var hotel = _context.Hotel.ToList();
            return View(hotel);
           
        }
		[HttpPost] //overload function
        public async Task<IActionResult> Index(String City)
        {
            var findhotel = _context.Hotel.Where(x => x.City.Contains(City));

            ViewBag.Hotel = findhotel;
            return View(findhotel);
        }

		public IActionResult CreateNewRooms(Rooms rooms)
        {
            _context.Rooms.Add(rooms);
            _context.SaveChanges();
			return RedirectToAction("Rooms");
		}

		public IActionResult CreatNewRoomDetails(RoomDetails roomDetails)
		{
			_context.RoomDetails.Add(roomDetails);
			_context.SaveChanges();
			return RedirectToAction("RoomDetails");
		}


		public IActionResult RoomDetails()
		{
			var hotel = _context.Hotel.ToList();
			ViewBag.hotel = hotel;


            var roomDetails = _context.RoomDetails.ToList();
			return View(roomDetails);
			
		}

		public IActionResult Rooms()
        {
            var hotel = _context.Hotel.ToList();
            ViewBag.hotel = hotel;

            ViewBag.currentuser = HttpContext.Session.GetString("username");
            //ViewBag.currentuser = Request.Cookies["UserName"];
			var rooms = _context.Rooms.ToList();

			return View(rooms);
            
        }

		public IActionResult CreateNewHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            _context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
