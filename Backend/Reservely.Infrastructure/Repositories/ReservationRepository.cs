using Microsoft.EntityFrameworkCore;
using Reservely.Infrastructure.ApplicationContext;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Repositories;

namespace Reservely.Infrastructure.Repositories;

internal class ReservationRepository(ReservelyDBContext dbContext) : IReservationRepository
{
    public async Task<int> Create(Reservation reservation)
    {
        await dbContext.Reservations.AddAsync(reservation);
        await dbContext.SaveChangesAsync();
        return reservation.Id;
    }
    public async Task<Reservation?> GetById(int id)
    {
        return await dbContext.Reservations
            .Include(r => r.Flight)
            .ThenInclude(f => f.FlightClasses)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<Reservation>> GetAll()
    {
        return await dbContext.Reservations.ToListAsync();
    }

    public async Task Update(Reservation reservation)
    {
        dbContext.Reservations.Update(reservation);
        await dbContext.SaveChangesAsync();
    }
}
