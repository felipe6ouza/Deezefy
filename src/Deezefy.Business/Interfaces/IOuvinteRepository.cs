using Deezefy.Business.Models;
using System.Threading.Tasks;

namespace Deezefy.Business.Interfaces
{
    public interface IOuvinteRepository : IRepository<Ouvinte>
    {
        Task<Ouvinte> ObterPorId(string email);
        Task Remover(string email);
    }

}
