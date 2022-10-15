using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CongReports.Models;

public class CongReportsContext : DbContext
{
    public CongReportsContext(DbContextOptions<CongReportsContext> options)
        : base(options)
    {
    }

    public DbSet<Publicador> Publicador { get; set; } = default!;
}
