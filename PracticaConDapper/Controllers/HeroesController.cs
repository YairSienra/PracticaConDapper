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
        [HttpGet]
        public ActionResult GetHeroe(int id)
        {
            var heroes = new List<Heroe>()
            {
                new Heroe() { Id = 1, Name ="SpiderMan" },
                new Heroe() { Id = 2, Name ="Hulk" },
                new Heroe() { Id = 3, Name ="Thor" }
            };


            var hero = heroes.FirstOrDefault(x => x.Id == id);

            if (hero == null)
                 throw new NotFoundException(id);

            return Ok(hero);
        }
    }
}
