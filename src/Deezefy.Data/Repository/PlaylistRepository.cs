using Deezefy.Business.Interfaces;
using Deezefy.Business.Models;
using Deezefy.Data.Context;
using System.Threading.Tasks;

namespace Deezefy.Data.Repository
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {

        public PlaylistRepository(DeezefyDbContext deezefyDbContext) : base(deezefyDbContext) { }
       
        public async Task<Playlist> ObterPlaylist(string nome)
        {
            return await DbSet.FindAsync(nome);
        }

        public async Task Remover(string nome)
        {
            DbSet.Remove(await DbSet.FindAsync(nome));
            await SaveChanges();
        }
    }
}
