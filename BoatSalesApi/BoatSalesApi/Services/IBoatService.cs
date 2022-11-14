using BoatSalesApi.Domain;

namespace BoatSalesApi.Services
{
    public interface IBoatService
    {
        Task<List<Boat>?> GetBoatsAsync();
        Task<Boat?> GetBoatByIdAsync(Guid boatId);
        Task<bool> CreateBoatAsync(Boat boat);
        Task<bool> UpdateBoatAsync(Boat boat);
        Task<bool> DeleteBoatAsync(Guid postId);

    }
}