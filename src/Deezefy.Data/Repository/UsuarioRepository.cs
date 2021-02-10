using Deezefy.Business.Interfaces;
using Deezefy.Business.Models;
using Deezefy.Data.Context;
using System.Threading.Tasks;

namespace Deezefy.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DeezefyDbContext deezefyDbContext) : base(deezefyDbContext) { }

         public async Task<Usuario> ObterPorEmail(string email)
        {
            return await DbSet.FindAsync(email);
        }

        public async Task Remover(string email)
        {
            DbSet.Remove(await DbSet.FindAsync(email));
            await SaveChanges();
        }
    }
}
