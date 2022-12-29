using Microsoft.EntityFrameworkCore;
using CollectResponseQr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectResponseQr.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}

        public DbSet<ResponseQr> ResponseQrs { get; set; }
    }
}
