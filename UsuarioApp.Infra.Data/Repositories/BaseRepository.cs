using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Interfaces.Repositories;
using UsuarioApp.Infra.Data.Contexts;

namespace UsuarioApp.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            using(var dataContext = new DataContext())
            {
                dataContext.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using(var dataContext = new DataContext())
            {
                var entity = dataContext.Set<TEntity>().Find(id);
                if(entity is null)
                    throw new ApplicationException("Objeto não encontrado");

                return entity;
            }
        }

        public void Remove(TEntity entity)
        {
            using(var dataContext = new DataContext())
            {
                dataContext.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(entity);
                dataContext.SaveChanges();
            }
        }
    }
}
