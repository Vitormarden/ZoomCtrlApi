using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ZooCtrlAPI.Models;
using ZooCtrlAPI.Repositories.Interfaces;
using ZooCtrlAPI.Services.Interfaces;

namespace ZooCtrlAPI.Services
{
    public class Zona_ZooService : IZona_ZooService
    {
        private readonly IZonaZooRepository _zooRepository;
        private readonly IFiloRepository _filoRepository;

        public Zona_ZooService(IZonaZooRepository zooRepository, IFiloRepository filoRepository)
        {
            this._zooRepository = zooRepository;
            this._filoRepository = filoRepository;
        }
        public async Task<bool>UseId(int id)
        {
            var listaZona = await _zooRepository.GetAll();
            if(listaZona.Exists(x=>x.Id_Zona == id))
                return true;
            return false;
        }
        public async Task<List<Zona_Zoo>> GetAll()
        {
            var listFilo = await _zooRepository.GetAll();
            return listFilo;
        }

        public async  Task<Zona_Zoo> GetById(int id)
        {
            if(await UseId(id))
            {
                var zonaById = await _zooRepository.GetById(id);
                return zonaById;
            }
            return null;
        }
        public async  Task<bool> Add (Zona_Zoo zona)
        {
            if(!(await UseId(zona.Id_Zona)))
            {
                await _zooRepository.Add(zona);
                return true;
            }
            return false;
           
        }

        public async Task<bool> Delete(int id)
        {
            if(await UseId(id))
            {
                await _filoRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(Zona_Zoo zona)
        {
            if(await UseId(zona.Id_Zona))
            {
                await _zooRepository.Update(zona);
                return true;
            }
            return false;
        }
    }

   
}
