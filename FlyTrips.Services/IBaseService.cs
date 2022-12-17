using FlyTrips.Entities;

namespace FlyTrips.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
