using LettingsManager.WebSite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LettingsManager.WebSite.Data
{
    public class LettingsManagerContext: DbContext
    {
        public LettingsManagerContext(DbContextOptions<LettingsManagerContext> options) : base(options)
        {

        }
        public DbSet<House> Houses { get; set; }
        public DbSet<Landlord> Landlords { get; set; }
    }
}
