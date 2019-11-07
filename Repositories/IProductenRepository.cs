using System.Collections.Generic;
using DistributiecenterFonq.Models;

namespace DistributiecenterFonq.Repositories
{
    public interface IProductenRepository
    {
        void AddNewProduct(Producten productModel);
        void DeleteProduct(int productId);
        List<Producten> GetAllProducten();
        Producten GetOneProduct(int productId);
        void UpdateProduct(Producten productModel);
    }
}