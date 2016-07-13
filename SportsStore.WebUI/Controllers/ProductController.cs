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
        private IProductRepository repository;

        public int PageSize { get; set; }

        public ProductController(IProductRepository repository)
        {
            this.PageSize = 4;
            this.repository = repository;
        }

        [HttpGet]
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy( p => p.ProductID)
                    .Skip((page -1) * PageSize)
                    .Take(PageSize), 
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? 
                        repository.Products.Count() :
                        repository.Products
                                  .Where(p => p.Category == category)
                                  .Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int productId)
        {
            var product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            return View(product);
        }

        [HttpGet]
        public ActionResult ViewImage(int productId)
        {
            var product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        /// <summary>Used for Image retrieval </summary>
        /// <param name="productId">
        ///      The Id of the product whos image is returned
        /// </param>
        /// <returns>The Image File</returns>
        public FileContentResult GetImage(int productId)
        {
            var product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                return File(product.ImageData, product.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
	}
}