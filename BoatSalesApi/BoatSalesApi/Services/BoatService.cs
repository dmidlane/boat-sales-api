
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
    public Boat? GetBoatById(Guid boatId) => _boatData.SingleOrDefault(b => b.Id == boatId);

    public List<Boat>? GetBoats() => _boatData;

    public void CreateBoat(Boat boat)
    {
        _boatData.Add(boat);
    }

    public bool UpdateBoat(Boat boat)
    {
       var boatToUpdate = _boatData.SingleOrDefault(b => b.Id == boat.Id);

       if (boatToUpdate == null)
            return false;

        boatToUpdate.Name = boat.Name;
        return true;
    }

    public bool DeleteBoat(Guid boatId)
    {
        if (boatId == Guid.Empty)
            return false;

        Boat? boat = GetBoatById(boatId);

        if (boat == null)
            return false;

        _boatData.Remove(boat);

        return true;
    }

}