using Deezefy.Business.Models;
using System.Threading.Tasks;

namespace Deezefy.Business.Interfaces
{
    public interface IMusicaRepository : IRepository<Musica>
    {
        Task<Musica> ObterPorId(int id);
        Task Remover(int id);
    }

}
