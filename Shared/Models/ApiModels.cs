using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class ApiModels
    {
        public class TicketAPIModel
        {
            public int Id { get; set; }
            public string Title { get; set; } = null!;
            public string? Description { get; set; }
            public string SubmittedBy { get; set; } = null!;
            public bool IsResolved { get; set; }
            public string? Image { get; set; }

            public List<TicketTagAPIModel> TicketTags { get; set; } = new();
            public List<ResponseAPIModel> Responses { get; set; } = new();
        }

        public class TicketTagAPIModel
        {
            public int TicketId { get; set; }
            public TicketModel Ticket { get; set; } = null!;
            public int TagId { get; set; }
            public TagModel Tag { get; set; } = null!;

        }



        public class TagModelAPIModel
        {

            public int Id { get; set; }

            public string Name { get; set; } = null!;
            public List<TicketTagModel> TicketTags { get; set; } = new();

        }

        public class TagApiModel
        {
            [Key]
            public int Id { get; set; }

            public string Name { get; set; } = null!;
            public List<TicketTagModel> TicketTags { get; set; } = new List<TicketTagModel>();
        }

        public class ResponseAPIModel
        {
            public int Id { get; set; }
            public string Response { get; set; } = null!;
            public string SubmittedBy { get; set; } = null!;

        }
    }
}
