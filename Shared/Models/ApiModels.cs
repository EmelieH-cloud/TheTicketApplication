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
        }

        public class ResponseAPIModel
        {
            public int Id { get; set; }
            public string Response { get; set; } = null!;
            public string SubmittedBy { get; set; } = null!;

        }
    }
}
