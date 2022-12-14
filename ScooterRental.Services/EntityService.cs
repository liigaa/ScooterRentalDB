using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using ScooterRental.Core.Models;
using ScooterRental.Core.Services;
using ScooterRental.Data;

namespace ScooterRental.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(IScooterRentalDbContext context) : base(context)
        {
        }

        public void Create(T entity)
        {
            Create<T>(entity);
        }

        public void Delete(T entity)
        {
            Delete<T>(entity);
        }

        public void Update(T entity)
        {
            Update<T>(entity);
        }

        public List<T> GetAll()
        {
            return GetAll<T>();
        }

        public T GetById(string id)
        {
            return GetById<T>(id);
        }

        public IQueryable<T> Query()
        {
            return Query<T>();
        }
    }
}
