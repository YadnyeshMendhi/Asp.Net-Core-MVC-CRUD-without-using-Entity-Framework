using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUDwithoutEF.Models;

namespace CRUDwithoutEF.Data
{
    public class CRUDwithoutEFContext : DbContext
    {
        public CRUDwithoutEFContext (DbContextOptions<CRUDwithoutEFContext> options)
            : base(options)
        {
        }

        public DbSet<CRUDwithoutEF.Models.PhoneViewModel> PhoneViewModel { get; set; }
    }
}
