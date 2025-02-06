using Reserverly.Domain.Entities;

namespace Reserverly.Domain.Repositories;

public interface IReservationRepository
{
    Task<int> Create(Reservation reservation);
    Task<Reservation?> GetById(int id);
    Task<IEnumerable<Reservation>> GetAll();
    Task Update(Reservation reservation);
}
