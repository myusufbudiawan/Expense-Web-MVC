using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        //dependency injection
        //no need sql query
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //retrieve item from database and display
            IEnumerable<Item> objList = _db.Items;

            return View(objList);
        }

        //Get-Create
        public IActionResult Create()
        {

            return View();
        }

        //Post-Create
        [HttpPost]
        //token, check if still login or token
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
