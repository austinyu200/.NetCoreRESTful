using Microsoft.EntityFrameworkCore;
using MusicArchive.Entities;
using MusicArchive.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MusicArchive.Utilities
{
    public class PieciesDbContext : DbContext
    {
        public PieciesDbContext(DbContextOptions<PieciesDbContext> options) : base(options)
        { }

        public DbSet<Composer> Composer { get; set; }

        public DbSet<Piece> Piece { get; set; }
    }
}
