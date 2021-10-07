using System.Threading.Tasks;
using campeonato.Entities;

namespace campeonato.Services.Interfaces
{
    public interface ICampeonatoService
    {
         Task<Campeonato> GetCampeonato(int id);                  
         Task<bool> AddCampeonato(Campeonato model);
    }
}