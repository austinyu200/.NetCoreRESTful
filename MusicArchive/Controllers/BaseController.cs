using Microsoft.AspNetCore.Mvc;
using MusicArchive.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicArchive.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly PieciesDbContext _context;

        public BaseController(PieciesDbContext context)
        {
            _context = context;
        }
    }
}
