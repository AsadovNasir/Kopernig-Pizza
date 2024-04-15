using KoperingPizza.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KoperingPizza.ViewCompanents
{
    public class Category:ViewComponent
    {
        private readonly MyDbContext _context;
        public Category(MyDbContext context)
        {
            _context = context;

        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Categories.ToList());
        }
    }
}
