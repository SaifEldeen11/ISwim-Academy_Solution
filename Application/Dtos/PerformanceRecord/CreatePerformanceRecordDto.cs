using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.PerformanceRecord
{
    public class CreatePerformanceRecordDto
    {
        public int SwimmerId { get; set; }
        public EventDistance Distance { get; set; }
        public decimal TimeInSeconds { get; set; }
        public DateTime RecordedDate { get; set; }
        public int RecordedByCoachId { get; set; }
        public string? Comments { get; set; }
    }
}
