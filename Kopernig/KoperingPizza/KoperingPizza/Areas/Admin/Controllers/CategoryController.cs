using KoperingPizza.Models;
using Microsoft.AspNetCore.Mvc;

namespace KoperingPizza.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        
            private readonly MyDbContext _context;
            public CategoryController(MyDbContext context)
            {
                _context = context;
            }
            public IActionResult Index()
            {
                return View(_context.Categories.ToList());
            }
            [HttpGet]
            public IActionResult Add()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Add(Category category)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            public IActionResult Delete(int id)
            {
                var c = _context.Categories.Find(id);
                if (c != null)
                {
                    _context.Categories.Remove(c);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            [HttpGet]
            public IActionResult Edit(Category newC)
            {
                var categoryEdit = _context.Categories.FirstOrDefault(x=>x.Id==newC.Id);
                if (categoryEdit != null)
                {
                categoryEdit.Name = newC.Name;
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

        [NonAction]
        public JsonResult GetCategory()
        {
            var category = _context.Categories.ToList();
            return Json(category);
        }
        }

    }