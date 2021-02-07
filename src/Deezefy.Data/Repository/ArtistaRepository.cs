using Deezefy.Business.Interfaces;
using Deezefy.Business.Models;
using Deezefy.Data.Context;
using System.Threading.Tasks;
using System.Linq;

namespace Deezefy.Data.Repository
{
    public class ArtistaRepository : Repository<Artista>, IArtistaRepository
    {
        public ArtistaRepository(DeezefyDbContext deezefyDbContext): base(deezefyDbContext) { }
   
        public async Task<Artista> ObterPorId(string email)
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
