using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HueysAutosMvc.Models
{
    public class Manufacturer
    {
        [ScaffoldColumn(false)]
        public int ManufacturerID { get; set; }

        [Required, StringLength(100), Display(Name="Manufacturer")]
        public string ManufacturerName { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
