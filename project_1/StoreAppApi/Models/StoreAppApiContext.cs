using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace StoreAppApi.Models 
{
    public class StoreAppApiContext : DbContext
    {
        public StoreAppApiContext(DbContextOptions<StoreAppApiContext> options)
            : base(options)
        {

        }

        public DbSet<StoreAppApi_c> StoreAppItems { get; set; }
    }
}
