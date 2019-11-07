using System.Collections.Generic;
using DistributiecenterFonq.Models;

namespace DistributiecenterFonq.Repositories
{
    public interface IVestigingRepository
    {
        Vestigingvoorraad GetOneVestigingVoorraad(int productID, int vestId);
        List<Vestigingvoorraad> GetVestigingvoorraad(int productId);
        void TotaleVoorraadUpdate(Vestigingvoorraad VModel, int beginVoorraad);
        void UpdateVestigingVoorraad(Vestigingvoorraad voorraadModel);
    }
}