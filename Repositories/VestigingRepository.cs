using DistributieClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistributiecenterFonq.Models;

namespace DistributiecenterFonq.Repositories
{
    public class VestigingRepository : IVestigingRepository
    {
        private DistributiecenterEntities entities = new DistributiecenterEntities();

        public List<Vestigingvoorraad> GetVestigingvoorraad(int productId)
        {
            var VestigingModelLijst = new List<Vestigingvoorraad>();

            foreach (var vestigingVoorraad in entities.vestigingsvoorraads.Where(v => v.products_ID == productId))

                VestigingModelLijst.Add(new Vestigingvoorraad
                {
                    Naam = vestigingVoorraad.vestiging.vestiging_naam,
                    Voorraad = vestigingVoorraad.vestigingsvoorraad_voorraad.HasValue ? vestigingVoorraad.vestigingsvoorraad_voorraad.Value : 0,
                    VestigingId = vestigingVoorraad.vestiging_ID,
                    ProductId = vestigingVoorraad.products_ID
                });

            return VestigingModelLijst;
        }

        //Geeft voorraad per vestiging a.d.h.v. productID
        public Vestigingvoorraad GetOneVestigingVoorraad(int productID, int vestId)
        {
            var entity = entities.vestigingsvoorraads.Single(v => v.products_ID == productID && v.vestiging_ID == vestId);
            return new Vestigingvoorraad
            {
                Naam = entity.product.products_merk,
                Voorraad = entity.vestigingsvoorraad_voorraad.HasValue ? entity.vestigingsvoorraad_voorraad.Value : 0,
                VestigingId = entity.vestiging_ID,
                ProductId = entity.products_ID
            };
        }

        public void UpdateVestigingVoorraad(Vestigingvoorraad voorraadModel)
        {
            var entity = entities.vestigingsvoorraads.Single(v => v.vestiging.vestiging_ID == voorraadModel.VestigingId && v.products_ID == voorraadModel.ProductId);
            int beginVoorraad = entity.vestigingsvoorraad_voorraad.HasValue ? entity.vestigingsvoorraad_voorraad.Value : 0;
            entity.vestigingsvoorraad_voorraad = voorraadModel.Voorraad;
            TotaleVoorraadUpdate(voorraadModel, beginVoorraad);
            entities.SaveChanges();
        }

        public void TotaleVoorraadUpdate(Vestigingvoorraad VModel, int beginVoorraad)
        {
            int verschilVoorraad = VModel.Voorraad - beginVoorraad;
            var entity = entities.products.Single(p => p.products_ID == VModel.ProductId);
            entity.products_voorraad += verschilVoorraad;
            entities.SaveChanges();
        }

        //public void AddVoorraadAanAlleVestigingen(int productID)
        //{
        //    var vestigingen = entities.vestigings.ToList();

        //    foreach (var vestiging in vestigingen)
        //    {
        //        entities.vestigingsvoorraads.Add(new vestigingsvoorraad
        //        {
        //            products_ID = productID,
        //            vestiging_ID = vestiging.vestiging_ID,
        //            vestigingsvoorraad_voorraad = 0
        //        });
        //        entities.SaveChanges();
        //    }
        //}
    }
}