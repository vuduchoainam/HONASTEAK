using HONASTEAK.Data;
using HONASTEAK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HONASTEAK.Controllers
{
    public class ProductController : BaseController<Product>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<PropertyProduct> _propertyProductRepositoy;
        private readonly IRepository<OptionProduct> _optionProductRepositoy;
        public ProductController()
        {
            _categoryRepository = new Repository<Category>(Context);
            _propertyProductRepositoy = new Repository<PropertyProduct>(Context);
            _optionProductRepositoy = new Repository<OptionProduct>(Context);
        }
       
        public ActionResult Index()
        {
            //var p = GetProducts();
            var p = GetAll().ToList();
            var c = _categoryRepository.GetAll().ToList();
            ViewBag.Categories = c;
            ViewBag.PropertyProducts = _propertyProductRepositoy.GetAll().ToList();
            ViewBag.OptionProducts = _optionProductRepositoy.GetAll().ToList();
            return View(p);
        }
        [Route("Product/{Slug}")]
        public ActionResult Details(string Slug)
        {
            try
            {
                ViewBag.PropertyProducts = Context.PropertyProducts.Where(x => x.Product.Slug == Slug).OrderBy(x => x.Price).ToList();
                ViewBag.OptionProducts = Context.OptionProducts.Where(x => x.Product.Slug == Slug).ToList();
                var product = Context.Products.FirstOrDefault(x => x.Slug == Slug);
                if (product == null || Slug == null)
                {
                    return Redirect("/Collections/All");
                }
                return View(product);
            }
            catch (Exception)
            {
                return Redirect("/Collections/All");
            }
        }
    }
}