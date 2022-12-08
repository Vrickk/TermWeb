using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TermWeb.Models;

namespace TermWeb.Data
{
    public class TermWebContext : DbContext
    {
        public TermWebContext (DbContextOptions<TermWebContext> options)
            : base(options)
        {
        }

        public DbSet<TermWeb.Models.Article> Article { get; set; }
    }
}
