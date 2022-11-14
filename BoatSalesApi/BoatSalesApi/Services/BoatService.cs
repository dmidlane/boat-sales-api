
using BoatSalesApi.Data;
using BoatSalesApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace BoatSalesApi.Services;

public class BoatService : IBoatService
{
    private readonly  DataContext _dataContext;

    public BoatService(DataContext dataContext)
    {
        _dataContext = dataContext;
        
    }
    public async Task<Boat?> GetBoatByIdAsync(Guid boatId) => await _dataContext.Boats.SingleOrDefaultAsync(b => b.Id == boatId);

    public async Task<List<Boat>?> GetBoatsAsync() => await _dataContext.Boats.ToListAsync();

    public async Task<bool> CreateBoatAsync(Boat boat)
    {
        await _dataContext.Boats.AddAsync(boat);
        int createdCount = await _dataContext.SaveChangesAsync();
        return createdCount > 0;
    }

    public async Task<bool> UpdateBoatAsync(Boat boat)
    {
        _dataContext.Boats.Update(boat);
        int updatedCount = await _dataContext.SaveChangesAsync();
        return updatedCount > 0;
    }

    public async Task<bool> DeleteBoatAsync(Guid boatId)
    {
        if(boatId == Guid.Empty)
            return false;

        Boat? boat = await GetBoatByIdAsync(boatId);
        if (boat == null)
            return false;

        _dataContext.Boats.Remove(boat);
        int deletedCount = await _dataContext.SaveChangesAsync();
        return deletedCount > 0;
    }

}