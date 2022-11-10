using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using ZooCtrlAPI.Models;
using ZooCtrlAPI.Repositories.Interfaces;
using ZooCtrlAPI.Services.Interfaces;

namespace ZooCtrlAPI.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IFiloRepository _filoRepository;
        public AnimalService(IAnimalRepository animalRepository, IFiloRepository filoRepository)
        {
            this._animalRepository = animalRepository;
            this._filoRepository = filoRepository;

        }
        public async Task<bool> UseId(int id)
        {
            var listaAnimal = await _animalRepository.GetAll();
            if (listaAnimal.Exists(x => x.Id_Animal == id))
                return true;
            return false;
        }
        public async Task<List<Animal>> GetAll()
        {
            var getListaAnimals = await _animalRepository.GetAll();
            return getListaAnimals;

        }
        public async Task<Animal>GetById(int id)
        {
            if(await UseId(id))
            {
                var animalById =await _animalRepository.GetById(id);
                return animalById;
            }
            return null;
        }
       public async Task<bool> Add(Animal animal)
        {
            Filo filo = await _filoRepository.GetById(animal.Id_Filo);
            if(!(await UseId(animal.Id_Animal)) && filo != null)
            {
                await _animalRepository.Add(animal);
                return true;
            }
            return false;
   
        }
        public async Task<bool> Update(Animal animal)
        {
            Filo filo = await _filoRepository.GetById(animal.Id_Filo);
            if(await UseId(animal.Id_Animal) && filo != null)
            {
                await _animalRepository.Update(animal);
                return true;
            }
            return false;
               
        }
        public async Task<bool>Delete(int id)
        {
            if (await UseId(id))
            {
                await _animalRepository.Delete(id);
                return true;
            }
            return false;
        }
    }
    
   
}
