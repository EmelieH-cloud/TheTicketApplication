using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class ResponseModel
    {
        [Key]
        public int Id { get; set; }
        public string Response { get; set; } = null!;
        public string SubmittedBy { get; set; } = null!;
        public int TicketId { get; set; }
        public TicketModel Ticket { get; set; } = null!;

    }

    public class TagModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public List<TicketTag> TicketTags { get; set; } = new List<TicketTag>();
    }


    public class TicketModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string SubmittedBy { get; set; } = null!;
        public bool IsResolved { get; set; }
        public List<TicketTag> TicketTags { get; set; } = new List<TicketTag>();
        public List<ResponseModel> Responses { get; set; } = new List<ResponseModel>();
    }

    public class TicketTag
    {
        public int TicketId { get; set; }
        public TicketModel Ticket { get; set; } = null!;
        public int TagId { get; set; }
        public TagModel Tag { get; set; } = null!;

    }
}
