using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Swimmer_Dto
{
    public class UpdateSwimmerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public CompetitionReadiness CompetitionReadiness { get; set; }
        public bool IsActive { get; set; }
        public int? TeamId { get; set; }
    }
}
