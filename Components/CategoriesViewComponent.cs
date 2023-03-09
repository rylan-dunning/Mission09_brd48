using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission09_brd48.Models;

namespace Mission09_brd48.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookRepository repo { get; set; }

        public CategoriesViewComponent (IBookRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
