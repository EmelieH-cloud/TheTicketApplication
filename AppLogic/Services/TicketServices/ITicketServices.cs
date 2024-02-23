using Shared.Models;

namespace AppLogic.Services.TicketServices
{
    public interface ITicketServices
    {
        public HttpClient Client { get; set; }

        public Task<List<TicketApiModel>> GetTickets();

        public Task PostTicket(TicketApiModel ticket);
    }
}
