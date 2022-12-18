using AutoMapper;
using FlyTrips.DTO.Role;
using FlyTrips.Entities;

namespace FlyTrips.Services
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        public RoleService(FlyTripsDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public RoleResponseDto Create(RoleCreateUpdateDto dto)
        {
            Role role = _mapper.Map<Role>(dto);

            Create(role);

            return _mapper.Map<RoleResponseDto>(role);
        }

        public void Delete(int id)
        {
            Role role = base.GetById(id);
            
            Delete(role);
        }

        public RoleResponseDto Update(RoleCreateUpdateDto dto, int id)
        {
            Role role = base.GetById(id);

            _mapper.Map(dto, role);

            Update(role);

            return _mapper.Map<RoleResponseDto>(role);
        }

        public new IEnumerable<RoleResponseDto> GetAll()
        {
            return base.GetAll().Select(_mapper.Map<RoleResponseDto>);
        }

        public new RoleResponseDto GetById(int id)
        {
            return _mapper.Map<RoleResponseDto>(base.GetById(id));
        }
    }
}
