using AutoMapper;
using FlyTrips.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlyTrips.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly FlyTripsDbContext _context;
        protected readonly IMapper _mapper;

        public BaseService(FlyTripsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public int GetCount()
        {
            return _context.Set<T>().Count();
        }
    }
}
