using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZooCtrlAPI.Models;
using ZooCtrlAPI.Services.Interfaces;

namespace ZooCtrlAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FiloController : ControllerBase
    {
        private readonly IFiloService _filoService;
        public FiloController(IFiloService filoService)
        {
            this._filoService = filoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _filoService.GetAll());
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            if(id <= 0)
                return BadRequest("Id passado é invalido");    
            var filoId = await _filoService.GetById(id);
            if (filoId != null)
                return Ok(filoId);
            return NotFound();
            
        }
        [HttpPost]
        public async Task<IActionResult>Add(Filo filo)
        {
            var filoAdd =await _filoService.Add(filo);
            if(filoAdd)
                return Created("",filo.Id_Filo);
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult>Update(Filo filo)
        {   
            var atualizarFilo = await _filoService.Update(filo);
            if (atualizarFilo)
                return NoContent();
            return BadRequest("Filo não existe");

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id passado é invalido");
            var deletarIdFilo = await _filoService.Delete(id);
            if(deletarIdFilo)
                return NoContent();
            return BadRequest();
        }
 
    }

}
