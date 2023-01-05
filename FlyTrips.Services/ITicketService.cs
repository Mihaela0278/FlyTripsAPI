using FlyTrips.DTO.Ticket;
using FlyTrips.Entities;

namespace FlyTrips.Services
{
    public interface ITicketService : IBaseService<Ticket>
    {
        TicketResponseDto Create(TicketCreateUpdateDto dto);
        
        new TicketResponseDto GetById(int id);  

        new IEnumerable<TicketResponseDto> GetAll();

        TicketResponseDto Update(int id, TicketCreateUpdateDto dto);

        void Delete(int id);
    }
}
