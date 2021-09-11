using Igra80.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Igra80.Data
{
    public class IgraContext : DbContext
    {
        public IgraContext(DbContextOptions<IgraContext> opt) : base(opt)
        {

        }

        public DbSet<Incidence> igra80 { get; set; }
    }
}
