using BoatSalesApi.Domain.V1;

namespace BoatSalesApi.Services
{
    public interface IBoatService
    {
        List<Boat>? GetBoats();
        Boat? GetBoatById(Guid boatId);
        void CreateBoat(Boat boat);
        bool UpdateBoat(Boat boat);
        bool DeleteBoat(Guid postId);

    }
}