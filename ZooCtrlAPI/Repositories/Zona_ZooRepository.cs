using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZooCtrlAPI.Data;
using ZooCtrlAPI.Models;
using ZooCtrlAPI.Repositories.Interfaces;

namespace ZooCtrlAPI.Repositories
{
    public class Zona_ZooRepository : IZonaZooRepository
    {
        private readonly Context _context;
        public Zona_ZooRepository(Context context)
        {
            this._context = context;
        }
        public async Task<List<Zona_Zoo>> GetAll()
        {
            var listaFilo = await _context.zona_Zoo.ToListAsync();
            return listaFilo;

        }
        public async Task<Zona_Zoo> GetById(int id)
        {
            var zonaId = await _context.zona_Zoo.FirstOrDefaultAsync(z => z.Id_Zona == id);
            return zonaId;
        }

        public async Task Add(Zona_Zoo zona_Zoo)
        {
            _context.Add(zona_Zoo);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Zona_Zoo zona_Zoo)
        {
            _context.zona_Zoo.Update(zona_Zoo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.zona_Zoo.Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }
    }
}
