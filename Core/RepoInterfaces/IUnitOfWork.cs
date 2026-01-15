using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RepoInterfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IGenaricRepository<Coach> Coaches { get; }
        ISwimmerRepository Swimmers { get; }
        IGenaricRepository<Team> Teams { get; }
        IPerformanceRecordRepository PerformanceRecords { get; }
        IGenaricRepository<PerformanceNote> PerformanceNotes { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
