using Generator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Generator.DAL
{
    public class GeneratorContext:DbContext
    {
        public GeneratorContext() : base("Generator")
        {
        }
        public DbSet<Miejsce> Locations { get; set; }
        public DbSet<Human> People { get; set; }
        public DbSet<Pozycja> Pozycje { get; set; }
    }
}