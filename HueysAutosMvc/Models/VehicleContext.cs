using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HueysAutosMvc.Models
{
    public class VehicleContext : DbContext
    {
        public VehicleContext() : base ("HueysCars")
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

    }
}