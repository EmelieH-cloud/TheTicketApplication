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
        public List<TicketTagModel> TicketTags { get; set; } = new List<TicketTagModel>();
    }


    public class TicketModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string SubmittedBy { get; set; } = null!;
        public bool IsResolved { get; set; }
        public List<TicketTagModel> TicketTags { get; set; } = new List<TicketTagModel>();
        public List<ResponseModel> Responses { get; set; } = new List<ResponseModel>();
    }

    public class TicketTagModel
    {
        public int TicketId { get; set; }
        public TicketModel Ticket { get; set; } = null!;
        public int TagId { get; set; }
        public TagModel Tag { get; set; } = null!;

    }
}
