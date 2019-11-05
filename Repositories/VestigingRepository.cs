using DistributieClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistributiecenterFonq.Models;

namespace DistributiecenterFonq.Repositories
{
    public class VestigingRepository
    {
        private DistributiecenterEntities entities = new DistributiecenterEntities();

        public List<Vestigingvoorraad> GetVestigingvoorraad(int productId)
        {
            var VestigingModelLijst = new List<Vestigingvoorraad>();

            foreach (var vestigingVoorraad in entities.vestigingsvoorraads.Where(v => v.products_ID == productId))

                VestigingModelLijst.Add(new Vestigingvoorraad
                {
                    Naam = vestigingVoorraad.vestiging.vestiging_naam,
                    Voorraad = vestigingVoorraad.vestigingsvoorraad_voorraad.Value,
                    VestigingId = vestigingVoorraad.vestiging_ID,
                    ProductId = vestigingVoorraad.products_ID
                });

            var beginVoorraad = entities.vestigingsvoorraads; 

            return VestigingModelLijst;
        }

        public Vestigingvoorraad GetOneVestigingVoorraad(int productID, int vestId)
        {
            var entity = entities.vestigingsvoorraads.Single(v => v.products_ID == productID && v.vestiging_ID == vestId);
            return new Vestigingvoorraad
            {
                Naam = entity.product.products_merk,
                Voorraad = entity.vestigingsvoorraad_voorraad.Value,
                VestigingId = entity.vestiging_ID,
                ProductId = entity.products_ID
            };
        }

        public void UpdateVestigingVoorraad(Vestigingvoorraad voorraadModel)
        {
            var entity = entities.vestigingsvoorraads.Single(v => v.vestiging.vestiging_ID == voorraadModel.VestigingId && v.products_ID == voorraadModel.ProductId);
            int beginVoorraad = entity.vestigingsvoorraad_voorraad.Value; 
            entity.vestigingsvoorraad_voorraad = voorraadModel.Voorraad;
            TotaleVoorraadUpdate(voorraadModel, beginVoorraad);
            entities.SaveChanges();
        }

        public void TotaleVoorraadUpdate(Vestigingvoorraad voorraadModel, int beginVoorraad)
        {
            int verschilVoorraad = voorraadModel.Voorraad - beginVoorraad;
            var entity = entities.products.Single(p => p.products_ID == voorraadModel.ProductId);
            entity.products_voorraad += verschilVoorraad;
            entities.SaveChanges();

        }
    }
}