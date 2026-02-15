using Core;
using Core.Models;
using Core.RepoInterfaces;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = new Dictionary<string, object>();
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction? _transaction;

        private readonly IGenericRepository<Coach> _coaches;
        private readonly ISwimmerRepository _swimmers;
        private readonly IGenericRepository<Team> _teams;
        private readonly IPerformanceRecordRepository _performanceRecords;
        private readonly IGenericRepository<PerformanceNote> _performanceNotes;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _coaches = new GenericRepository<Coach>(_context);
            _swimmers = new SwimmerRepository(_context);
            _teams = new GenericRepository<Team>(_context);
            _performanceRecords = new PerformanceRecordRepository(_context);
            _performanceNotes = new GenericRepository<PerformanceNote>(_context);
        }

        public IGenericRepository<Coach> Coaches => _coaches;

        public ISwimmerRepository Swimmers => _swimmers;

        public IGenericRepository<Team> Teams => _teams;

        public IPerformanceRecordRepository PerformanceRecords => _performanceRecords;

        public IGenericRepository<PerformanceNote> PerformanceNotes => _performanceNotes;

        public async Task BeginTransactionAsync()
        {
            _transaction =  await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                if(_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if(_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }

        public async Task RollbackTransactionAsync()
        {
            if(_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
