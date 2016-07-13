using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class NavigationController : Controller
    {
        private IProductRepository repository;

        public NavigationController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public PartialViewResult Menu(string category = null)
        {
            NavigationViewModel model = new NavigationViewModel
            {
                Categories = repository.Products
                                        .Select(p => p.Category)
                                        .Distinct()
                                        .OrderBy(p => p),
                SelectedCategory = category
            };

            return PartialView(model);
        }
	}
}