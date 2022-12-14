using System.Collections.Generic;
using System.Threading.Tasks;
using ZooCtrlAPI.Models;

namespace ZooCtrlAPI.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        public Task<List<Animal>> GetAll();
        public Task<Animal> GetById(int id);
        public Task Add(Animal animal);
        public Task Delete(int id);
        public Task Update(Animal animal);
    }
}
