using Microsoft.AspNetCore.Mvc;
using Mission09_brd48.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_brd48.Controllers
{
    public class MadePurchaseController : Controller
    {
        private IMadePurchaseRepository repo { get; set; }
        private Cart cart { get; set; }

        public MadePurchaseController(IMadePurchaseRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new MadePurchase());
        }

        [HttpPost]
        public IActionResult Checkout(MadePurchase madePurchase)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                madePurchase.Lines = cart.Items.ToArray();
                repo.SaveMadePurchase(madePurchase);
                cart.ClearCart();

                return RedirectToPage("/MadePurchaseCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
