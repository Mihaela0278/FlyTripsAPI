using FlyTrips.DTO.Role;
using FlyTrips.Entities;

namespace FlyTrips.Services
{
    public interface IRoleService : IBaseService<Role>
    {
        RoleResponseDto Create(RoleCreateUpdateDto dto);

        new RoleResponseDto GetById(int id);

        new IEnumerable<RoleResponseDto> GetAll();

        RoleResponseDto Update(RoleCreateUpdateDto dto, int id);

        void Delete(int id);
    }
}