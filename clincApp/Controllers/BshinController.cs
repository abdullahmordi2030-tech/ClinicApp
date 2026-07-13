using clincApp.Models;
using clincApp.ViewModles;
using clinicApp.Models; 
using clinicApp.ViewModles; 
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ClincApp.Controllers
{
    public class BshinController : Controller
    {
      
        private readonly ClinicContext _db;

      
        public BshinController(ClinicContext db)
        {
            _db = db;
        }


        public IActionResult Index(BshinFilterVM vm, int page = 1)
        {
            int pageSize = 5; 

          
            var query = _db.Bshins.AsQueryable();

           
            if (!string.IsNullOrEmpty(vm.Name))
            {
                query = query.Where(b => b.Name.Contains(vm.Name));
            }

            
            if (vm.Mrn != null)
            {
                query = query.Where(b => b.Mrn == vm.Mrn);
            }

            // حساب الإجمالي والصفحات
            int totalItems = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            if (page < 1) page = 1;
            if (page > totalPages && totalPages > 0) page = totalPages;

           
            var bshinsList = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

          
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.SearchName = vm.Name;
            ViewBag.SearchMrn = vm.Mrn;

            
            return View(bshinsList);
        }

        public IActionResult Details(int id)
        {
            var Bshin = _db.Bshins.SingleOrDefault(d => d.Id == id);
            if (Bshin == null) return NotFound();
            return View(Bshin);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Bshin bshin)
        {
            if (!ModelState.IsValid)
            {
                return View(bshin);
            }

            
            _db.Bshins.Add(bshin);
            _db.SaveChanges();

            return RedirectToAction(nameof(Details), new { id = bshin.Id });
        }

        public IActionResult Delete(int id)
        {
            var Bshin = _db.Bshins.SingleOrDefault(d => d.Id == id);
            if (Bshin == null) return NotFound();

            _db.Bshins.Remove(Bshin);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var Bshin = _db.Bshins.SingleOrDefault(d => d.Id == id);
            if (Bshin == null) return NotFound();

            var updateVm = Bshin.BshinUpdate(); 
            return View(updateVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, BshinUpdate vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var Bshin = _db.Bshins.SingleOrDefault(d => d.Id == id);
            if (Bshin == null) return NotFound();

            vm.ToBshin(Bshin); 
            _db.SaveChanges(); 

            return RedirectToAction(nameof(Index));
        }
    }
}