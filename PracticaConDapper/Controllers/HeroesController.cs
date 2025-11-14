using Contract.Interfacees;
using Contract.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Sienra.Exceptions;


namespace PracticaConDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        public readonly IHeroeRepositorio _heroeRepositorio;

        public HeroesController(IHeroeRepositorio heroeRepositorio)
        {
            _heroeRepositorio = heroeRepositorio;
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerHeroe(int idHeroe) 
        {
            return Ok(await _heroeRepositorio.ObtenerHeroe(idHeroe));
        }

        [HttpGet("all")]
        public async Task<IActionResult> ObtenerTodosLosHeroes()
        {
            return Ok(await _heroeRepositorio.ObtenerTodosLosHeroes());
        }

        [HttpPost]
        public async Task<IActionResult> CrearHeroe(HeroeRequest request)
        {
            return Ok(await _heroeRepositorio.CrearHeroe(request));
        }

        [HttpDelete]
        public async Task<IActionResult> BorrarHeroe(int idHeroe)
        {
            return Ok(await _heroeRepositorio.BorrarHeroe(idHeroe));
        }
    }
}
