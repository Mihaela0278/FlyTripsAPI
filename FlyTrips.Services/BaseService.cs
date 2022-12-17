using AutoMapper;
using FlyTrips.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlyTrips.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly FlyTripsDbContext context;
        protected readonly IMapper mapper;

        public BaseService(FlyTripsDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
