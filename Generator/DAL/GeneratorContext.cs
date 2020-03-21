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
        public DbSet<Location> Locations { get; set; }
        public DbSet<Human> People { get; set; }
        public DbSet<HumanType> humanTypes { get; set; }
        public DbSet<HumanTypeLiking> humanTypeLikings { get; set; }
        public DbSet<Leg> Legs { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Duration2> Durations { get; set; }
        public DbSet<StartLocation2> StartLocations { get; set; }
        public DbSet<EndLocation2> EndLocations { get; set; }
    }
}