using ApiApp.Dtos.Character;
using ApiApp.Models;
using ApiApp.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace ApiApp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")] 
        public async Task<ActionResult<ServiceResponse<List<Character>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> UpdateCharacter(UpdateCharacterDto newCharacter)
        {
            var response = await _characterService.UpdateCharacter(newCharacter);
            
            if(response.Data is null)
            {
                return NotFound(response);
            }
                
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);

            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
