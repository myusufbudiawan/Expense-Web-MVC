using InAndOut.Data;
using Microsoft.AspNetCore.Mvc;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using InAndOut.Models.ViewModels;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;

            foreach (var obj in objList)
            {
                obj.ExpenseType = _db.ExpenseTypes.FirstOrDefault(u => u.Id == obj.ExpenseTypeId);
            }
            
            return View(objList);
        }

        //GET Create
        public IActionResult Create()
        {
            //Selecting expense type
            //IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});

            ////Pass value from controller to views
            //ViewBag.TypeDropDown = TypeDropDown;

            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(expenseVM);
        }

        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ExpenseVM obj)
        {
            //var errors = ModelState
            //    .Where(x => x.Value.Errors.Count > 0)
            //    .Select(x => new { x.Key, x.Value.Errors })
            //    .ToArray();
            //server side validation
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }

        //GET Delete
        public IActionResult Delete(int? id) //optional id
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        //POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id) //optional id
        {
            var obj = _db.Expenses.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

                _db.Expenses.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

        }

        //GET Update
        public IActionResult Update(int? id) //optional id
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            //return View(expenseVM);

            if (id == null || id == 0)
            {
                return NotFound();
            }

            expenseVM.Expense = _db.Expenses.Find(id);

            if (expenseVM.Expense == null)
            {
                return NotFound();
            }

            return View(expenseVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(ExpenseVM obj)
        {
            //server side validation
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }

    }
}
