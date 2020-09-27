using Microsoft.EntityFrameworkCore;
using MusicArchive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicArchive.DbContext
{
    public interface IBaseDbContext : IDisposable
    {         

        int SaveChange();

        Task<int> SaveChangeAsync();
    }

    public class BaseDbContext : Microsoft.EntityFrameworkCore.DbContext,IBaseDbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {

        }


        public int SaveChange()
        {
            return SaveChanges();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
