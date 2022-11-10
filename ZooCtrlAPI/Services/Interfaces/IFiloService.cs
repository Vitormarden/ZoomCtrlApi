using System.Collections.Generic;
using System.Threading.Tasks;
using ZooCtrlAPI.Models;

namespace ZooCtrlAPI.Services.Interfaces
{
    public interface IFiloService
    {
        Task<List<Filo>> GetAll();
        Task<Filo> GetById(int id);
        Task<bool> Add(Filo filo);
        Task<bool> Delete(int id);
        Task<bool> Update(Filo filo);
    
    }
}
