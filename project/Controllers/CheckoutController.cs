using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Helpers;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckoutController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,ProductId,DateTime,Count,Total")] Order order)
        {
            DateTime datetime = DateTime.Now;
           var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
          
           
               if (ModelState.IsValid)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    int id = cart[i].Product.Id;
                    var product = await _context.Product
               .Include(p => p.Category)
               .FirstOrDefaultAsync(m => m.Id == id);
                    order.Product = product;
                    order.Count = cart[i].Quantity;
                    order.DateTime = datetime;
                    order.Total = (int)(cart[i].Quantity * product.Price);
                    _context.Order.Add(order);
                    cart.RemoveAt(i);
                   

                }
              _context.SaveChanges();



            }

            return RedirectToAction("Index");
        }

    }
    }

