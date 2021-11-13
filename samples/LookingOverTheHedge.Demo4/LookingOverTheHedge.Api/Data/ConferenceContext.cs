using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookingOverTheHedge.Api.Data
{
    public class ConferenceContext : DbContext
    {
        public ConferenceContext(DbContextOptions<ConferenceContext> options) : base(options )
        {

        }
        public DbSet<Speaker> Speakers { get; set; }

        public DbSet<Talk> Talks { get; set; }
    }
}
