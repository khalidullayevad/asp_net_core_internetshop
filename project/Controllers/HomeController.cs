using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Models;
using System.Linq;
using System.Threading.Tasks;
using project.Data;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController(ApplicationDbContext context)
        {
            this.db = context;
            // добавляем начальные данные
            if (db.Category.Count() == 0)
            {
                Category phone = new Category { Name = "Phone" };
                Category laptop = new Category { Name = "Laptop" };
                Category gadget = new Category { Name = "Gadget" };


                Product product1 = new Product { Name = "Apple XS Max", Category = phone, Price = 5000, IsPreferred = true, ShortDescription = "Short Description", LongDescriprion = "Long Description" };

                Product product2 = new Product { Name = "Apple XS Max", Category = phone, Price = 5000, IsPreferred = true, ShortDescription = "Short Description", LongDescriprion = "Long Description" };
                db.Category.AddRange(phone, laptop, gadget);
                db.Product.AddRange(product1, product2);
                db.SaveChanges();
            }
        }
        public async Task<IActionResult> Index(string sortOrder, int? category, string name,int page = 1 )
        {
            IQueryable<Product> source = db.Product.Include(x => x.Category);

            int pageSize = 3;   // количество элементов на странице

            if (category != null && category != 0)
            {
                source = source.Where(p => p.CategoryId == category);
            }
            if (!String.IsNullOrEmpty(name))
            {
                source = source.Where(p => p.Name.Contains(name));
            }

            List<Category> companies = db.Category.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            companies.Insert(0, new Category { Name = "Все", Id = 0 });
            ViewData["NameOrder"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            switch (sortOrder)
            {
                case "name_desc":
                    source = source.OrderByDescending(a => a.Name);
                    break;
                default:
                    source = source.OrderBy(a => a.Name);
                    break;

            }

            
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
               
                Category = new SelectList(companies, "Id", "Name"),
                Name = name,
                PageViewModel = pageViewModel,
                Products = items
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}

