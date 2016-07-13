using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repo;
        public const int PageSize = 5;

        public ProductController(IProductRepository repository)
        {
            this.repo = repository;
        }

        public ViewResult List(int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel {
                Products = repo.Products
                    .OrderBy( p => p.ProductID)
                    .Skip((page -1) * PageSize)
                    .Take(PageSize), 
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repo.Products.Count()
                }
            };

            return View(model);
        }
	}
}