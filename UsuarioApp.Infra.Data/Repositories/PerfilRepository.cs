using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Entities;
using UsuarioApp.Domain.Interfaces.Repositories;
using UsuarioApp.Infra.Data.Contexts;

namespace UsuarioApp.Infra.Data.Repositories
{
    public class PerfilRepository : BaseRepository<Perfil>, IPerfilRepository
    {
        public Perfil? Get(string nome)
        {
            using(var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Perfil>()
                    .Where(p=> p.Nome.Equals(nome))
                    .FirstOrDefault();
            }
        }
    }
}
