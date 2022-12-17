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
            Role role = mapper.Map<Role>(dto);

            Create(role);

            return mapper.Map<RoleResponseDto>(role);
        }

        public void Delete(int id)
        {
            Role role = base.GetById(id);
            
            Delete(role);
        }

        public RoleResponseDto Update(RoleCreateUpdateDto dto, int id)
        {
            Role role = base.GetById(id);

            mapper.Map(dto, role);

            Update(role);

            return mapper.Map<RoleResponseDto>(role);
        }

        public new IEnumerable<RoleResponseDto> GetAll()
        {
            return base.GetAll().Select(mapper.Map<RoleResponseDto>);
        }

        public new RoleResponseDto GetById(int id)
        {
            return mapper.Map<RoleResponseDto>(base.GetById(id));
        }
    }
}
