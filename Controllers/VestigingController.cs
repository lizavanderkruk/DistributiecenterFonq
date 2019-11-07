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
        private readonly IVestigingRepository vestigingRepository;
       // public VestigingRepository vestigingRepository = new VestigingRepository();
        public ProductenRepository productenRepository = new ProductenRepository();

        public VestigingController(IVestigingRepository vestigingRepository)
        {
            this.vestigingRepository = vestigingRepository;
        }


        //laat de voorraden zien voor alle vestigingen
        public ActionResult ShowVestigingvoorraad(int productId)
        {
            ViewBag.Message = "Voorraad per vestiging:";
            var vestigingvoorraad = vestigingRepository.GetVestigingvoorraad(productId);
            return View(vestigingvoorraad);
        }

        // update per vestiging van een product
        public ActionResult Update(int vestId, int productID)
        {
            return View(vestigingRepository.GetOneVestigingVoorraad(productID, vestId));
        }

        [HttpPost]
        public ActionResult Update(Vestigingvoorraad vestigingvoorraadModel)
        {
            if (ModelState.IsValid) //validatie van de data annotation
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