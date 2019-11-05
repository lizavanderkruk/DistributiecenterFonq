using DistributiecenterFonq.Models;
using DistributiecenterFonq.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistributiecenterFonq.Controllers
{
    public class VestigingController : Controller
    {
        public VestigingRepository vestigingRepository = new VestigingRepository();
        public ProductenRepository productenRepository = new ProductenRepository();
        public ActionResult ShowVestigingvoorraad(int productId)
        {
            ViewBag.Message = "Voorraad per vestiging:";
            var vestigingvoorraad = vestigingRepository.GetVestigingvoorraad(productId);
            return View(vestigingvoorraad);
        }

        public ActionResult Update(int vestId, int productID)
        {
            return View(vestigingRepository.GetOneVestigingVoorraad(productID, vestId));
        }

        [HttpPost]
        public ActionResult Update(Vestigingvoorraad vestigingvoorraadModel)
        {
            if (ModelState.IsValid)
            {
                vestigingRepository.UpdateVestigingVoorraad(vestigingvoorraadModel);                
                return RedirectToAction("ShowVestigingvoorraad", new { productId = vestigingvoorraadModel.ProductId });
            }
            else
            {
                return View(vestigingvoorraadModel);
            }
        }
    }
}