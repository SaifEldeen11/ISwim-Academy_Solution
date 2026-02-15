using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.PerformanceRecord
{
    public class UpdatePerformanceRecordDto
    {
        public int Id { get; set; }
        public decimal TimeInSeconds { get; set; }
        public DateTime RecordedDate { get; set; }
        public string? Comments { get; set; }
    }
}
