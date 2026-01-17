using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RepoInterfaces
{
    public interface IPerformanceRecordRepository:IGenaricRepository<PerformanceRecord>
    {
        Task<IEnumerable<PerformanceRecord>> GetRecordsBySwimmerAsync(int swimmerId);
        Task<IEnumerable<PerformanceRecord>> GetRecordsBySwimmerAndDistanceAsync(int swimmerId, EventDistance distance);
        Task<PerformanceRecord?> GetBestTimeAsync(int swimmerId, EventDistance distance);
        Task<IEnumerable<PerformanceRecord>> GetRecentRecordsAsync(int swimmerId, int count = 10);
    }
}
