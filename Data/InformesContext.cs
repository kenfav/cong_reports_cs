using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CongReports.Models;

    public class InformesContext : DbContext
    {
        public InformesContext (DbContextOptions<InformesContext> options)
            : base(options)
        {
        }

        public DbSet<CongReports.Models.Informe> Informe { get; set; } = default!;
    }
