using DVD_Store_API.Exceptions;
using DVD_Store_API.Interfaces;
using DVD_Store_API.Models;
using DVD_Store_API.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace DVD_Store_API.Controllers
{
    [Route("api/controllers")]
    [ApiController]
    public class ActorActressController : Controller
    {
        private readonly IActorActressRepository actorActressRepository;

        public ActorActressController(IActorActressRepository actorActressRepository)
        {
            this.actorActressRepository = actorActressRepository;
        }

        [HttpPost]
        [Route("/ActorsActresses/add/name")]
        public ActionResult<ActorActress> AddActorActress(string name)
        {
            try
            {
                ActorActress actorActress = new ActorActress();
                actorActress.Name = name;
                actorActressRepository.AddActorActress(actorActress);

                return Ok(actorActress);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("/ActorsActresses/del/id")]
        public ActionResult DeleteActorActress(int id)
        {
            try
            {
                ActorActress a = actorActressRepository.GetActorActress(id);
                actorActressRepository.DeleteActorActress(a);

                return Ok();
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("/ActorsActresses/upd/id/newname")]
        public ActionResult<ActorActress> UpdateActorActress(int id, string newname)
        {
            try
            {
                ActorActress a = new ActorActress();
                a.Name = newname;
                actorActressRepository.UpdateActorActress(id, a);

                return Ok(a);
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("/ActorsActresses/getall")]
        public ActionResult<ICollection<ActorActress>> GetActorsActresses()
        {
            try
            {
                ICollection<ActorActress> a = actorActressRepository.GetActorsActresses();

                return Ok(a);
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("ActorsActresses/get/id")]
        public ActionResult<ActorActress> GetActorActress(int id)
        {
            try
            {
                ActorActress a = actorActressRepository.GetActorActress(id);
                
                return Ok(a);
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
