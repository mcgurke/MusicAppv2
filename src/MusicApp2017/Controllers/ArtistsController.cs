using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicApp2017.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApp2017.Controllers
{
    [Authorize]
    public class ArtistsController : Controller
    {
        private MusicDbContext _context;

        public ArtistsController(MusicDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var musicDbContext = _context.Artists;
            return View(musicDbContext.ToList());
        }

        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Artist artist = _context.Artists.SingleOrDefault(m => m.ArtistID == id);
            ViewData["ID"] = id;
            ViewData["Name"] = artist.Name;
            ViewData["Bio"] = artist.Bio;
            var musicDbContext = _context.Albums.Include(m => m.Artist);
            return View(musicDbContext.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("ArtistID, Name, Bio")] Artist artist)
        {
            if (_context.Artists.SingleOrDefault(m => (m.Name == artist.Name && m.ArtistID != artist.ArtistID)) != null)
            {
                ViewData["Error"] = "Artist Name must be unique.";
            }
            else if (ModelState.IsValid)
            {
                _context.Add(artist);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Name"] = artist.Name;
            return View(artist);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var artist = _context.Artists.SingleOrDefault(m => m.ArtistID == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Edit(int id, [Bind("ArtistID, Name, Bio")] Artist artist)
        {
            if (_context.Artists.SingleOrDefault(m => (m.Name == artist.Name && m.ArtistID != artist.ArtistID)) != null)
            {
                ViewData["Error"] = "Artist Name must be unique.";
            }
            else
            {
                if (id != artist.ArtistID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _context.Update(artist);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return View(artist);
        }
    }
}

