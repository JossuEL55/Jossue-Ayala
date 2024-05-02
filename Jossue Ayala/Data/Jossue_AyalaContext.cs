using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jossue_Ayala.Models;

namespace Jossue_Ayala.Data
{
    public class Jossue_AyalaContext : DbContext
    {
        public Jossue_AyalaContext (DbContextOptions<Jossue_AyalaContext> options)
            : base(options)
        {
        }

        public DbSet<Jossue_Ayala.Models.Estudiante> Estudiante { get; set; } = default!;
        public DbSet<Jossue_Ayala.Models.Carrera> Carrera { get; set; } = default!;
    }
}
