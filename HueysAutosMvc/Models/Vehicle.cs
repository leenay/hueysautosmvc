using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HueysAutosMvc.Models
{
    public class Vehicle
    {
        [ScaffoldColumn(false)]
        public int VehicleID { get; set; }

        [Required, StringLength(200), Display(Name="Name")]
        public string VehicleName { get; set; }

        [Required, StringLength(10000), Display(Name="Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Price { get; set; }

        public int? ManufacturerID { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public int? VehicleModelID { get; set; }

        public virtual VehicleModel VehicleModel { get; set; }
    }
}