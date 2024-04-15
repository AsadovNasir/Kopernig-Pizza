using KoperingPizza.Models;
using Microsoft.AspNetCore.Mvc;

namespace KoperingPizza.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyDbContext _context;
        public ProductController(MyDbContext context)
        {
            _context = context;

        }
        public IActionResult ProductList(int categoryId)
        {
            var products=_context.Products.Where(x=>x.CatgeoryId==categoryId).ToList();
            return View(products);
        }
    }
}
