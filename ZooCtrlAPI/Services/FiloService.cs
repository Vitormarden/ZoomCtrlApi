using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using ZooCtrlAPI.Models;
using ZooCtrlAPI.Repositories.Interfaces;
using ZooCtrlAPI.Services.Interfaces;

namespace ZooCtrlAPI.Services
{
    public class FiloService : IFiloService
    {
        private IFiloRepository _filoRepository;
        public FiloService(IFiloRepository filoRepository)
        {
            this._filoRepository = filoRepository;
        }

        public async Task<bool>UseId(int id)
        {
            var listaFilo = await _filoRepository.GetAll();
            if(listaFilo.Exists(x => x.Id_Filo == id))
                return true;
            return false;
        }
        public async Task<List<Filo>> GetAll()
        {
            var getListaFilo = await _filoRepository.GetAll();
            return getListaFilo;
        }

        public async Task<Filo> GetById(int id)
        {
            if(await UseId(id))
            {
                var filoById = await _filoRepository.GetById(id);
                return filoById;
            }
            return null;
        }
        public async Task<bool> Add(Filo filo)
        {
            if (await UseId(filo.Id_Filo))
                return false;
            await _filoRepository.Add(filo);
            return true;
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
        public async Task<bool> Update(Filo filo)
        {
            if(await UseId(filo.Id_Filo))
            {
                await _filoRepository.Update(filo);
                return true;
            }
            return false;
        }
    }
}
