using Figure.Data.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Figure.Database.Context
{
    public class FigureDb : DbContext
    {
        public DbSet<Circle> Circles { get; set; }
        public DbSet<Triangle> Triangles { get; set; }



        public FigureDb([NotNullAttribute] DbContextOptions options) : base(options) { }

    }
}
