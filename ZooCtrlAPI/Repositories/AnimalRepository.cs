using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZooCtrlAPI.Data;
using ZooCtrlAPI.Models;
using ZooCtrlAPI.Repositories.Interfaces;

namespace ZooCtrlAPI.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly Context _context;
        public AnimalRepository(Context context)
        {
            this._context = context;
        }
        public async Task<List<Animal>> GetAll()
        {
            var listaAnimal = await _context.Animal.ToListAsync();
            return listaAnimal;

        }
        public async Task<Animal> GetById(int id)
        {
            var animalID = await _context.Animal.FirstOrDefaultAsync(a => a.Id_Animal == id);
            return animalID;
        }
        public async Task Add(Animal animal)
        {
            _context.Animal.Add(animal);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            _context.Animal.Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }
        public async Task Update(Animal animal)
        {
            _context.Animal.Update(animal);
            await _context.SaveChangesAsync();
        }

    }
}
