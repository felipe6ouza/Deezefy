using Deezefy.Business.Models;
using System.Threading.Tasks;

namespace Deezefy.Business.Interfaces
{
    public interface IArtistaRepository : IRepository<Artista>
    {
        Task<Artista> ObterPorId(string email);
        Task Remover(string email);
    }

}
