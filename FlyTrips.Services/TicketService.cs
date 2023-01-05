using AutoMapper;
using FlyTrips.DTO.Ticket;
using FlyTrips.Entities;

namespace FlyTrips.Services
{
    public class TicketService : BaseService<Ticket>, ITicketService
    {
        private readonly IUserService _userService;

        private readonly IAirlineService _airlineService;

        public TicketService(FlyTripsDbContext context, IMapper mapper, IUserService userService, IAirlineService airlineService) : base(context, mapper)
        {
            _userService = userService;
            _airlineService = airlineService;
        }

        public TicketResponseDto Create(TicketCreateUpdateDto dto)
        {
            Ticket ticket = _mapper.Map<Ticket>(dto);

            User user = _userService.GetEntityById(dto.UserId);
            ticket.User = user;

            ticket.Airlines = SetTicketAirlines(dto.AirlineIds);

            Create(ticket);

            return _mapper.Map<TicketResponseDto>(ticket);
        }

        public void Delete(int id)
        {
            Ticket ticket = base.GetById(id);

            Delete(ticket);
        }

        public TicketResponseDto Update(int id, TicketCreateUpdateDto dto)
        {
            Ticket ticket = base.GetById(id);

            if (ticket == null)
            {
                return null;
            }

            _mapper.Map(dto, ticket);

            User user = _userService.GetEntityById(dto.UserId);
            ticket.User = user;
            ticket.Airlines = SetTicketAirlines(dto.AirlineIds);

            Update(ticket);

            return _mapper.Map<TicketResponseDto>(ticket);
        }

        public new IEnumerable<TicketResponseDto> GetAll() 
        {
            return base.GetAll().Select(_mapper.Map<TicketResponseDto>);
        }

        public new TicketResponseDto GetById(int id) 
        {
            return _mapper.Map<TicketResponseDto>(base.GetById(id));
        }

        private ISet<Airline> SetTicketAirlines(ISet<int> airlineIds)
        {
            ISet<Airline> airlines = new HashSet<Airline>();

            foreach (int id in airlineIds)
            {
                airlines.Add(_airlineService.GetEntityById(id));
            }

            return airlines;
        }
    }
}
