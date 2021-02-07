using Deezefy.Business.Models;
using System.Threading.Tasks;

namespace Deezefy.Business.Interfaces
{
    public interface IPlaylistRepository : IRepository<Playlist>
    {
        Task<Playlist> ObterPlaylist(string nome);
        Task Remover(string nome);
    }

}
