using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZooCtrlAPI.Data;
using ZooCtrlAPI.Models;
using ZooCtrlAPI.Repositories.Interfaces;

namespace ZooCtrlAPI.Repositories
{
    public class FiloRepository : IFiloRepository
    {
        private readonly Context _context;
        public FiloRepository(Context context)
        {
            this._context = context;
        }
        public async Task<List<Filo>> GetAll()
        {
            var listaFilo = await _context.Filo.ToListAsync();
            return listaFilo;
        }
        public async Task<Filo> GetById(int id)
        {
            var filoId = await _context.Filo.FirstOrDefaultAsync(f=> f.Id_Filo == id);
            return filoId;
        }
        public async Task Add(Filo filo)
        {
            _context.Filo.Add(filo);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            _context.Filo.Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }
        public async Task Update(Filo filo)
        {
            _context.Filo.Update(filo);
            await _context.SaveChangesAsync();

        }
    }
}
