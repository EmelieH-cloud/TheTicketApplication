using static Shared.Models.ApiModels;

namespace AppLogic.Services.TicketServices
{
    public interface ITicketServices
    {
        public HttpClient Client { get; set; }

        public Task<List<TicketAPIModel>> GetTickets();

        public Task PostTicket(TicketAPIModel ticket);
    }
}
