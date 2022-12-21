using AutoMapper;
using FlyTrips.DTO.Airline;
using FlyTrips.Entities;

namespace FlyTrips.Services
{
    public class AirlineService : BaseService<Airline>, IAirlineService
    {
        public AirlineService(FlyTripsDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public AirlineResponseDto Create(AirlineCreateUpdateDto dto)
        {
            if (_context.Airlines.Any(a => a.Name == dto.Name))
            {
                return null;
            }

            Airline airline = _mapper.Map<Airline>(dto);

            Create(airline);

            return _mapper.Map<AirlineResponseDto>(airline);
        }

        public void Delete(int id)
        {
            Airline airline = base.GetById(id);

            Delete(airline);
        }

        public AirlineResponseDto Update(int id, AirlineCreateUpdateDto dto)
        {
            if (_context.Airlines.Any(a => a.Name == dto.Name))
            {
                return null;
            }

            Airline airline = base.GetById(id);

            _mapper.Map(dto, airline);

            Update(airline);

            return _mapper.Map<AirlineResponseDto>(airline);
        }

        public new IEnumerable<AirlineResponseDto> GetAll()
        {
            return base.GetAll().Select(_mapper.Map<AirlineResponseDto>);
        }

        public new AirlineResponseDto GetById(int id)
        {
            return _mapper.Map<AirlineResponseDto>(base.GetById(id));
        }
    }
}
