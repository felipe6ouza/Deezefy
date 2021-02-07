using Deezefy.Business.Interfaces;
using Deezefy.Business.Models;
using Deezefy.Data.Context;
using System.Threading.Tasks;

namespace Deezefy.Data.Repository
{
    public class MusicaRepository : Repository<Musica>, IMusicaRepository
    {
        public MusicaRepository(DeezefyDbContext deezefyDbContext): base(deezefyDbContext) { }

        public async Task<Musica> ObterPorId(int id)
        {
           return await DbSet.FindAsync(id);
        }

        public async Task Remover(int id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));
            await SaveChanges();
        }
    }
}
