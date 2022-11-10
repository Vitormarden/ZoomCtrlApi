using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ZooCtrlAPI.Models;

namespace ZooCtrlAPI.Repositories.Interfaces
{
    public interface IFiloRepository
    {
        Task<List<Filo>> GetAll();
        Task<Filo> GetById(int id);
        Task Add(Filo filo);
        Task Update(Filo filo);
        Task Delete(int Id);

    }
}
