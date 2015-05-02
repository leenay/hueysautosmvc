using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HueysAutosMvc.Models
{
    public class VehicleModel
    {
        [ScaffoldColumn(false)]
        public int VehicleModelID { get; set; }

        [Required, StringLength(100), Display(Name= "Model")]
        public string VehicleModelName { get; set; }

        public int? ManufacturerID { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
