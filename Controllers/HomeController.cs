using DistributiecenterFonq.Models;
using DistributiecenterFonq.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistributiecenterFonq.Controllers
{
    public class HomeController : Controller
    {
        public ProductenRepository productenRepository = new ProductenRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Products()
        {            
            var producten = productenRepository.GetAllProducten();
            return View(producten);
        }
        public ActionResult Add()
        {
            return View(new Producten());
        }

        [HttpPost]
        public ActionResult Add(Producten productModel)
        {
            if (ModelState.IsValid)
            {
                productenRepository.AddNewProduct(productModel);
                return RedirectToAction("Products");
            }
                
            else 
            {
                return View(productModel);
            }    
        }
        public ActionResult Update(int productId)
        {
            return View(productenRepository.GetOneProduct(productId)); 
        }

        [HttpPost]
        public ActionResult Update(Producten productModel)
        {
            productenRepository.UpdateProduct(productModel);
            return RedirectToAction("Products");
        }

        public ActionResult Delete(int productId)
        {
            productenRepository.DeleteProduct(productId);
            return RedirectToAction("Products");
        }
    }
}