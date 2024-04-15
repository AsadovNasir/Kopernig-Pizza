using KoperingPizza.Extensions;
using KoperingPizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KoperingPizza.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SliderController : Controller
    {
        private readonly MyDbContext _context;
        public SliderController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders.ToList());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Slider slider)
        {
            if (FileExtensions.IsImage(slider.ImgFile))
            {
                string nameImg = await FileExtensions.SaveAsync(slider.ImgFile, "Slider-image");
                slider.Image = nameImg;
                _context.Sliders.Add(slider);
                _context.SaveChanges();
            }
            else
            {
                return RedirectToAction("Add");
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var p = _context.Sliders.Find(id);
            if (p != null)
            {
                _context.Sliders.Remove(p);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Slider = _context.Sliders.ToList();
            return View(_context.Sliders.Find(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Slider newSlider)
        {
            var slideritem = _context.Sliders.Find(newSlider.Id);
            if (slideritem != null)
            {

                if (FileExtensions.IsImage(newSlider.ImgFile))
                {
                    string nameImg = await FileExtensions.SaveAsync(newSlider.ImgFile, "Slider-image");
                    slideritem.ImgFile = newSlider.ImgFile;
                    slideritem.Image = nameImg;
                    slideritem.Title = newSlider.Title;
                    slideritem.Description= newSlider.Description;
                    slideritem.Name = newSlider.Name;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Edit");
                }
            }
            return RedirectToAction("Edit");
        }
    }
}