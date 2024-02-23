using Database.DbConnection;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly GenericRepo<TicketApiModel> _ticketRepo;

        public TicketController(AppDbContext context, GenericRepo<TicketApiModel> ticketRepo)
        {
            _context = context;
            _ticketRepo = ticketRepo;
        }


        [HttpGet("Tickets")]
        public ActionResult<List<TicketApiModel>> GetTickets()
        {
            var tickets = _ticketRepo.GetAll();
            return Ok(tickets);
        }



        [HttpPost("Ticket")]
        public ActionResult PostTicket(TicketApiModel ticket)
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
