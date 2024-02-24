using Database.DbConnection;
using Microsoft.AspNetCore.Mvc;
using static Shared.Models.ApiModels;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly GenericRepo<TicketAPIModel> _ticketRepo;

        public TicketController(AppDbContext context, GenericRepo<TicketAPIModel> ticketRepo)
        {
            _context = context;
            _ticketRepo = ticketRepo;
        }


        [HttpGet("Tickets")]
        public ActionResult<List<TicketAPIModel>> GetTickets()
        {
            var tickets = _ticketRepo.GetAll();
            return Ok(tickets);
        }



        [HttpPost("Ticket")]
        public ActionResult PostTicket(TicketAPIModel ticket)
        {
            if (ticket != null)
            {
                _ticketRepo.Add(ticket);
                return Ok();
            }

            return BadRequest();
        }




        [HttpDelete("Ticket/{id}")]
        public ActionResult DeleteTicket(int id)
        {
            var ticket = _context.Tickets.FirstOrDefault(x => x.Id == id);

            if (ticket != null)
            {
                _ticketRepo.Delete(id);
                return Ok(ticket);
            }

            return NoContent();
        }

    }
}
