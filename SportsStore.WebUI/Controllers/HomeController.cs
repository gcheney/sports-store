using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Infrastructure.Extensions;

namespace SportsStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository repository;

        public HomeController(IProductRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {

            Product featuredProduct = repository.Products
                                      .RandomElement(new Random());
            return View(featuredProduct);
        }
	}
}