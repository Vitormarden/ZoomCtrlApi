using System.Collections.Generic;
using System.Threading.Tasks;
using ZooCtrlAPI.Models;

namespace ZooCtrlAPI.Repositories.Interfaces
{
    public interface IZonaZooRepository
    {
        Task<List<Zona_Zoo>> GetAll();
        Task<Zona_Zoo> GetById(int id);
        Task Add(Zona_Zoo zona);
        Task Update(Zona_Zoo zona);
        Task Delete(int id);
    }
}
