using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        #region Métodos abstratos
            void Add(TEntity entity);
            void Update(TEntity entity);    
            void Remove(TEntity entity);
            List<TEntity> GetAll();
            TEntity GetById(int id);
        #endregion
    }
}
