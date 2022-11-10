using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZooCtrlAPI.Models;
using ZooCtrlAPI.Services.Interfaces;

namespace ZooCtrlAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase

    {
        private readonly IAnimalService _animalService;
        public AnimalController(IAnimalService animalService)
        {
            this._animalService = animalService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todosAnimais = await _animalService.GetAll();
            return Ok(todosAnimais);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Id passado é invalido");
            var animalID = await _animalService.GetById(id);
            if(animalID != null)
                return Ok(animalID);
            return NotFound();
        }
            
        [HttpPost]
        public async Task<IActionResult>Add(Animal animal)
        {
            var animalAdd = await _animalService.Add(animal);
            if(animalAdd)
                return Created("", animal.Id_Animal);
            return BadRequest();
        }
       
            
        [HttpPut]
        public async Task<IActionResult>Update(Animal animal)
        {
            var atulizarAnimal = await _animalService.Update(animal);
            if (atulizarAnimal)
                NoContent();
            return BadRequest();
        }
      
            
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id passado é invalido");
            var deletarIdAnimal = await _animalService.Delete(id);
            if (deletarIdAnimal)
                return NoContent();
            return BadRequest();
        }

    }
}
