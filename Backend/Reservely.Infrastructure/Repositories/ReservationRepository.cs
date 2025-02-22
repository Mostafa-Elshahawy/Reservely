using Microsoft.EntityFrameworkCore;
using Reservely.Infrastructure.ApplicationContext;
using Reserverly.Application.Users;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Repositories;

namespace Reservely.Infrastructure.Repositories;

internal class ReservationRepository(ReservelyDBContext dbContext, IUserContext userContext) : IReservationRepository
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
        return await dbContext.Reservations.Include(r=>r.Flight).ToListAsync();
    }

    public async Task Update(Reservation reservation)
    {
        dbContext.Reservations.Update(reservation);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Reservation>> GetAllByUserId()
    {
        var user = userContext.GetCurrentUser();
        return await dbContext.Reservations
            .Include(r => r.Flight)
            .ThenInclude(f => f.FlightClasses)
            .Where(r => r.UserId == user.Id)
            .ToListAsync();
    }
}
