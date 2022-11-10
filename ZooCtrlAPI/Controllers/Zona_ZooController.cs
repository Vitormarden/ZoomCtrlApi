using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZooCtrlAPI.Models;
using ZooCtrlAPI.Services.Interfaces;

namespace ZooCtrlAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Zona_ZooController : ControllerBase
    {
        private readonly IZona_ZooService _zonaZooService;
        public Zona_ZooController(IZona_ZooService zonaZooService)
        {
            this._zonaZooService = zonaZooService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _zonaZooService.GetAll());
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Id passado é invalido");
            var zonaid = await _zonaZooService.GetById(id);
            if (zonaid != null)
                return Ok(zonaid);
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Zona_Zoo zona_Zoo)
        {
            var zonaAdd = await _zonaZooService.Add(zona_Zoo);
            if (zonaAdd)
                return Created("",zona_Zoo.Id_Zona);
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Zona_Zoo zona_Zoo)
        {
            var atualizarZona = await _zonaZooService.Update(zona_Zoo);
            if (atualizarZona)
                return NoContent();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("id passado pe invalido");
            var deletarIdZona = await _zonaZooService.Delete(id);
            if (deletarIdZona)
                return NoContent();
            return BadRequest();
        }
    }
}
