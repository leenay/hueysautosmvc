using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HueysAutosMvc.Models
{
    public class VehicleDatabaseInitializer : DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            GetManufacturers().ForEach(m => context.Manufacturers.Add(m));
            GetVehicleModels().ForEach(mo => context.VehicleModels.Add(mo));
            GetVehicles().ForEach(v => context.Vehicles.Add(v));
        }

        private static List<Manufacturer> GetManufacturers()
        {
            var manufacturers = new List<Manufacturer> {
                new Manufacturer {
                    ManufacturerID = 1,
                    ManufacturerName = "Mercedes-Benz"
                },
                new Manufacturer {
                    ManufacturerID = 2,
                    ManufacturerName = "Ford"
                },
                new Manufacturer {
                    ManufacturerID = 3,
                    ManufacturerName = "Fiat"
                },
                new Manufacturer {
                    ManufacturerID = 4,
                    ManufacturerName = "Toyota"
                },
            };
            return manufacturers;
        }

        private static List<VehicleModel> GetVehicleModels()
        {
            var models = new List<VehicleModel> {
                new VehicleModel{
                    VehicleModelID = 1,
                    VehicleModelName = "A-Class",
                    ManufacturerID = 1
                },
                new VehicleModel{
                    VehicleModelID = 2,
                    VehicleModelName = "C-Class",
                    ManufacturerID = 1
                },
                new VehicleModel{
                    VehicleModelID = 3,
                    VehicleModelName = "E-Class",
                    ManufacturerID = 1
                },
                new VehicleModel{
                    VehicleModelID = 4,
                    VehicleModelName = "M-Class",
                    ManufacturerID = 1
                },
                new VehicleModel{
                    VehicleModelID = 5,
                    VehicleModelName = "S-Class",
                    ManufacturerID = 1
                },
                new VehicleModel{
                    VehicleModelID = 6,
                    VehicleModelName = "Fiesta",
                    ManufacturerID = 2
                },
                new VehicleModel{
                    VehicleModelID = 7,
                    VehicleModelName = "Focus",
                    ManufacturerID = 2
                },
                new VehicleModel{
                    VehicleModelID = 8,
                    VehicleModelName = "Mondeo",
                    ManufacturerID = 2
                },
                new VehicleModel{
                    VehicleModelID = 9,
                    VehicleModelName = "Panda",
                    ManufacturerID = 3
                },
                new VehicleModel{
                    VehicleModelID = 10,
                    VehicleModelName = "500",
                    ManufacturerID = 3
                },
                new VehicleModel{
                    VehicleModelID = 11,
                    VehicleModelName = "Punto",
                    ManufacturerID = 3
                },
                new VehicleModel{
                    VehicleModelID = 12,
                    VehicleModelName = "Barchetta",
                    ManufacturerID = 3
                },
                new VehicleModel{
                    VehicleModelID = 13,
                    VehicleModelName = "Aygo",
                    ManufacturerID = 4
                },
                new VehicleModel{
                    VehicleModelID = 14,
                    VehicleModelName = "RAV4",
                    ManufacturerID = 4
                }
            };

            return models;
        }

        private static List<Vehicle> GetVehicles()
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle{
                    VehicleID = 1,
                    VehicleName = "Limited Edition Fiat Barchetta 1.7",
                    Description = "Stelivio Green, 77000 miles, excellent runner, some rust",
                    ManufacturerID = 3,
                    VehicleModelID = 12,
                    ImagePath = "barchetta1.png",
                    Price = 2000.00
                },
                new Vehicle{
                    VehicleID = 2,
                    VehicleName = "2008 Mercedes S500",
                    Description = "Silver, 60000 miles, working air suspension",
                    ManufacturerID = 1,
                    VehicleModelID = 5,
                    ImagePath = "sclassS5001.png",
                    Price = 12000.00
                },
                new Vehicle{
                    VehicleID = 3,
                    VehicleName = "2010 Mercedes C220D",
                    Description = "Silver, Diesel, nice tidy car, 65000 miles",
                    ManufacturerID = 1,
                    VehicleModelID = 2,
                    ImagePath = "cclass220D1.png",
                    Price = 12000.00
                },
                new Vehicle{
                    VehicleID = 4,
                    VehicleName = "2009 Mercedes C270D Estate",
                    Description = "Red, Diesel, roomy estate, fsh, 52000 miles",
                    ManufacturerID = 1,
                    VehicleModelID = 2,
                    ImagePath = "cclass270D1.png",
                    Price = 12000.00
                },
                new Vehicle{
                    VehicleID = 5,
                    VehicleName = "2013 Fiat Panda 1.2 pop",
                    Description = "Red, Petrol, fsh, 14000 miles",
                    ManufacturerID = 3,
                    VehicleModelID = 9,
                    ImagePath = "pandapop1.png",
                    Price = 5000.00
                },
                new Vehicle{
                    VehicleID = 6,
                    VehicleName = "2014 Fiat Panda Cross 0.9 Twinair",
                    Description = "White, Petrol, 4x4, fsh, 5000 miles",
                    ManufacturerID = 3,
                    VehicleModelID = 9,
                    ImagePath = "pandacross1.png",
                    Price = 14500.00
                },
                new Vehicle{
                    VehicleID = 7,
                    VehicleName = "2011 Ford Focus 1.6 Zetec Estate",
                    Description = "Midnight Sky, Petrol, roomy estate, fsh, 29000 miles",
                    ManufacturerID = 2,
                    VehicleModelID = 7,
                    ImagePath = "focus1.png",
                    Price = 9000.00
                }
            };
            return vehicles;
        }

    }
}