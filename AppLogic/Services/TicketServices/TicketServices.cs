using Newtonsoft.Json;
using System.Net.Http.Json;
using static Shared.Models.ApiModels;

namespace AppLogic.Services.TicketServices
{
    public class TicketServices : ITicketServices
    { // Klass som gör HTTP-anrop till API:et och försöker returnera en API-modell efter deserialiseringen. 
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7249/api/")
        };



        public async Task<TicketAPIModel> GetTicketById(int id)
        {
            var response = await Client.GetAsync($"Ticket/Ticket/{id}");

            if (response.IsSuccessStatusCode)
            {
                string ticketJson = await response.Content.ReadAsStringAsync();

                TicketAPIModel? ticket = JsonConvert.DeserializeObject<TicketAPIModel>(ticketJson);
                if (ticket != null)
                {
                    return ticket;
                }
                throw new JsonException();
            }

            throw new HttpRequestException($"Error getting ticket with ID: {id}");
        }

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
            await Client.PostAsJsonAsync("Ticket/PostTicket", ticket);
        }
    }
}
