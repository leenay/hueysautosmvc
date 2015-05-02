using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HueysAutosMvc.Models;

namespace HueysAutosMvc.ViewModels
{
    public class VehicleManuData
    {
        public IQueryable<Vehicle> Vehicles { get; set; }
        public IQueryable<VehicleModel> VModels { get; set; }
    }
}