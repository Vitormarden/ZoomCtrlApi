using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Threading.Tasks;
using ZooCtrlAPI.Models;

namespace ZooCtrlAPI.Services.Interfaces
{
    public interface IZona_ZooService
    {
        Task<List<Zona_Zoo>> GetAll();
        Task<Zona_Zoo> GetById(int id);
        Task<bool> Add(Zona_Zoo zona);
        Task <bool> Delete (int id);
        Task <bool> Update(Zona_Zoo zona);
    }
}
