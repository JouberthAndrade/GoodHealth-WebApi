using GoodHealth.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace GoodHealth.Shared.Data
{
    /// <summary>
    /// Implements database transaction control 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }        

        /// <summary>
        /// Commits the database transaction
        /// </summary>
        public int Commit()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Commits the database transaction using async way
        /// </summary>
        public Task<int> CommitAsync()
        {
           return _context.SaveChangesAsync();
        }

        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
