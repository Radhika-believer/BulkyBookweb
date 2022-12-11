using BulkyBookweb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BulkyBookweb.data
{
    public class applicationDbcontext : DbContext
    {
        public applicationDbcontext(DbContextOptions<applicationDbcontext> options) : base(options)
        {

        }
        public DbSet<category> categories { get; set; }
    }
}
