using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistributiecenterFonq.Models;
using DistributieClassLibrary;

namespace DistributiecenterFonq.Repositories
{
    public class ProductenRepository : IProductenRepository
    {
        private DistributiecenterEntities entities = new DistributiecenterEntities();

        public List<Producten> GetAllProducten()
        {
            var ProductenModelLijst = new List<Producten>();

            foreach (var product in entities.products)

                ProductenModelLijst.Add(new Producten
                {
                    Merk = product.products_merk,
                    Type = product.products_type,
                    Afmeting = product.products_afmeting,
                    Gewicht = product.products_gewicht.Value,
                    Voorraad = product.products_voorraad.Value,
                    Id = product.products_ID,
                    Afbeelding = product.products_afbeelding
                });

            return ProductenModelLijst;

        }
        public Producten GetOneProduct(int productId)
        {
            var entity = entities.products.Single(p => p.products_ID == productId);
            return new Producten
            {
                Id = entity.products_ID,
                Merk = entity.products_merk,
                Afmeting = entity.products_afmeting,
                Gewicht = entity.products_gewicht.Value,
                Voorraad = entity.products_voorraad.Value,
                Afbeelding = entity.products_afbeelding
            };

        }
        public void AddNewProduct(Producten productModel)
        {
            entities.products.Add(new DistributieClassLibrary.product
            {
                products_merk = productModel.Merk,
                products_type = productModel.Type,
                products_afmeting = productModel.Afmeting,
                products_gewicht = productModel.Gewicht,
                products_voorraad = productModel.Voorraad,
                products_afbeelding = productModel.Afbeelding
            });

            entities.SaveChanges();
        }

        public void UpdateProduct(Producten productModel)
        {
            var entity = entities.products.Single(p => p.products_ID == productModel.Id);

            entity.products_merk = productModel.Merk;
            entity.products_type = productModel.Type;
            entity.products_afmeting = productModel.Afmeting;
            entity.products_gewicht = productModel.Gewicht;
            entity.products_voorraad = productModel.Voorraad;
            entity.products_afbeelding = productModel.Afbeelding;

            entities.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var entity = entities.products.Single(p => p.products_ID == productId);
            entities.products.Remove(entity);
            entities.SaveChanges();
        }
    }
}