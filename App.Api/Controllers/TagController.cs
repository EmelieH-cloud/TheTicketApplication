using Database.DbConnection;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : Controller
    {
        private readonly AppDbContext _context;
        private readonly GenericRepo<TagModel> _tagRepo;

        public TagController(AppDbContext context, GenericRepo<TagModel> tagRepo)
        {
            _context = context;
            _tagRepo = tagRepo;
        }


        [HttpGet("Tags")]
        public ActionResult<List<TagModel>> GetTags()
        {
            var tags = _tagRepo.GetAll();

            return Ok(tags);
        }



        [HttpPost("Tag")]
        public ActionResult PostTag(TagModel tag)
        {
            if (tag != null)
            {
                _tagRepo.Add(tag);
                return Ok();
            }

            return BadRequest();
        }




        [HttpDelete("Tag/{id}")]
        public ActionResult DeleteTag(int id)
        {
            var tag = _context.Tags.FirstOrDefault(x => x.Id == id);

            if (tag != null)
            {
                _tagRepo.Delete(id);
                return Ok(tag);
            }

            return NoContent();
        }

        [HttpGet("Tag/{id}")]
        public ActionResult<TicketModel> GetTagById(int id)
        {
            var tag = _tagRepo.GetById(id);

            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }
    }
}
