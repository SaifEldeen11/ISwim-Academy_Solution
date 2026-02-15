using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.PerformanceNote
{
    public class CreatePerformanceNoteDto
    {
        public int SwimmerId { get; set; }
        public int CoachId { get; set; }
        public string Note { get; set; } = string.Empty;
        public DateTime NoteDate { get; set; }
    }
}
