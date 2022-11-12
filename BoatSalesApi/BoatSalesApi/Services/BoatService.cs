
using BoatSalesApi.Domain.V1;

namespace BoatSalesApi.Services;

public class BoatService : IBoatService
{
    private readonly  List<Boat> _boatData;

    public BoatService()
    {
        _boatData = new();
        
        for (int i = 0; i < 5; i++)
        {
            _boatData.Add(new Boat() { Id = Guid.NewGuid() });
        }
        
    }
    public Boat GetBoatById(Guid boatId)
    {
        return _boatData.SingleOrDefault(b => b.Id == boatId);
    }

    public List<Boat> GetBoats()
    {
        return _boatData;
    }

    public void CreateBoat(Boat boat)
    {
        _boatData.Add(boat);
    }
}