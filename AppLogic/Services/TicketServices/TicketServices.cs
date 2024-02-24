using Newtonsoft.Json;
using System.Net.Http.Json;
using static Shared.Models.ApiModels;

namespace AppLogic.Services.TicketServices
{
    public class TicketServices : ITicketServices
    { // Klass som gör anrop till API:et och försöker mappa json-strängarna mot API-modellen. 
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7249/api/")
        };

        public async Task<List<TicketAPIModel>> GetTickets()
        {
            var response = await Client.GetAsync("Ticket/Tickets");

            if (response.IsSuccessStatusCode)
            {
                string ticketjson = await response.Content.ReadAsStringAsync();

                List<TicketAPIModel>? tickets = JsonConvert.DeserializeObject<List<TicketAPIModel>>(ticketjson);

                if (tickets != null)
                {
                    return tickets;
                }

                throw new JsonException();
            }

            throw new HttpRequestException();
        }



        public async Task PostTicket(TicketAPIModel ticket)
        {
            await Client.PostAsJsonAsync("tickets", ticket);
        }
    }
}
