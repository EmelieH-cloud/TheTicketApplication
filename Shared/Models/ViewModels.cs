namespace Shared.Models
{
    using System.ComponentModel.DataAnnotations;
    using static global::Shared.Models.ApiModels;

    namespace Shared.Models
    {
        public class ResponseViewModel
        {

            public int Id { get; set; }
            [Required(ErrorMessage = "Please write your response!")]
            [MinLength(1, ErrorMessage = "Response to short!")]
            public string Response { get; set; } = null!;
            public string SubmittedBy { get; set; } = null!;
            public int TicketId { get; set; }
            public TicketViewModel Ticket { get; set; } = null!;

        }

        public class TagViewModel
        {

            public int Id { get; set; }
            public string Name { get; set; } = null!;
        }

        public class TicketViewModel
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Please write your title for the ticket!")]
            [MinLength(3, ErrorMessage = "The title is too short!")]
            public string Title { get; set; } = null!;
            [Required(ErrorMessage = "Please write your ticket!")]
            [MinLength(10, ErrorMessage = "The ticket is too short!")]
            public string? Description { get; set; }
            public string SubmittedBy { get; set; } = null!;
            public bool IsResolved { get; set; }
            public string? Image { get; set; }

            /* 
             En statisk metod passar bäst när den inte är beroende av någon specifik instans 
            för att utföra sin uppgift. Det innebär att metoden inte behöver någon information från
            instansvariabler eller andra instansspecifika egenskaper för att fungera korrekt.
             */
            public static TicketViewModel TicketViewModelFromApiModel(TicketAPIModel apiModel)
            {
                return new TicketViewModel
                {
                    Id = apiModel.Id,
                    Title = apiModel.Title,
                    Description = apiModel.Description ?? string.Empty,
                    SubmittedBy = apiModel.SubmittedBy,
                    IsResolved = apiModel.IsResolved,
                    Image = apiModel.Image ?? string.Empty,
                };
            }
        }


    }

}
