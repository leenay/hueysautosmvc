using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HueysAutosMvc.Models;
using HueysAutosMvc.ViewModels;
using PagedList;

namespace HueysAutosMvc.Controllers
{
    public class VehiclesController : Controller
    {
        private VehicleContext db = new VehicleContext();

        // GET: /Vehicles/
        public ActionResult Index(int? id, int? model, string searchString, string manufacturer, string vmodel, int? page)
        {
            //var viewModel = new VehicleManuData();
            //TempData["selectedManu"] = "";
            ViewBag.SelectedModelName = "";
            ViewBag.ManufacturerName = "";
            //ViewBag.SearchString = "";
            var vehicles = db.Vehicles.Include(v => v.Manufacturer).Include(v => v.VehicleModel);
            IQueryable<VehicleModel> vmodels = null;
            if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(v => v.VehicleName.Contains(searchString) || v.VehicleModel.VehicleModelName.Contains(searchString) || v.Description.Contains(searchString));
                ViewBag.SearchString = searchString;
            }
            

            /*
            if (id.HasValue)
            {
                vehicles = vehicles.Where(v => v.ManufacturerID == id);
                vmodels = vehicles.Select(v => v.VehicleModel).Distinct();
                if (model.HasValue)
                {
                    vehicles = vehicles.Where(v => v.VehicleModelID == model);
                    ViewBag.SelectedModel = model;
                    var modelName = vehicles.Select(v => v.VehicleModel.VehicleModelName).FirstOrDefault();
                    ViewBag.SelectedModelName = modelName;
                }

                TempData["selectedManu"] = RouteData.Values["id"];
                var manufacturerName = vehicles.Select(v => v.Manufacturer.ManufacturerName).FirstOrDefault();
                ViewBag.ManufacturerName = manufacturerName;
            }
            */

            if (!String.IsNullOrEmpty(manufacturer))
            {
                vehicles = vehicles.Where(v => v.Manufacturer.ManufacturerName == manufacturer);
                vmodels = vehicles.Select(v => v.VehicleModel).Distinct();
                if (!String.IsNullOrEmpty(vmodel))
                {
                    vehicles = vehicles.Where(v => v.VehicleModel.VehicleModelName == vmodel);
                    ViewBag.SelectedModel = model;
                    var modelName = vehicles.Select(v => v.VehicleModel.VehicleModelName).FirstOrDefault();
                    ViewBag.SelectedModelName = modelName;
                }

                //TempData["selectedManu"] = manufacturer;
                //var manufacturerName = vehicles.Select(v => v.Manufacturer.ManufacturerName).FirstOrDefault();

                ViewBag.ManufacturerName = manufacturer;
                ViewBag.VModels = vmodels.ToList();
            }

            //viewModel.Vehicles = vehicles;
            
            ViewBag.VCount = vehicles.Count();
            vehicles = vehicles.OrderBy(v => v.VehicleName);
            vehicles.ToList();
            

            int pageSize = 2;
            int pageNumber = (page ?? 1);

            return View(vehicles.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: /Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName");
            //ViewBag.VehicleModelID = new SelectList(db.VehicleModels, "VehicleModelID", "VehicleModelName");
            return View();
        }

        public JsonResult GetModels(int id)
        {
            var models = db.VehicleModels.Where(vm => vm.ManufacturerID == id);
            return Json(new SelectList(models, "VehicleModelID", "VehicleModelName"));
        }

        // POST: /Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle, HttpPostedFileBase file)
        {
            Boolean fileOk = false;
            string path = Server.MapPath("~/Images/");
            if (file != null && file.ContentLength > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
                string[] allowedExtension = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtension.Length; i++)
                {
                    if (fileExtension == allowedExtension[i])
                    {
                        fileOk = true;
                    }
                }
            }
            if (fileOk)
            {
                try
                {
                    file.SaveAs(path + file.FileName);
                    file.SaveAs(path + "Thumbs/" + file.FileName);
                    vehicle.ImagePath = file.FileName;
                    if (ModelState.IsValid)
                    {
                        db.Vehicles.Add(vehicle);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {
                    
                }

                
            }            

            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName", vehicle.ManufacturerID);
            ViewBag.VehicleModelID = new SelectList(db.VehicleModels, "VehicleModelID", "VehicleModelName", vehicle.VehicleModelID);
            return View(vehicle);
        }

        // GET: /Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            var vModels = db.VehicleModels.Where(vm => vm.ManufacturerID == vehicle.ManufacturerID);

            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName", vehicle.ManufacturerID);
            ViewBag.VehicleModelID = new SelectList(vModels, "VehicleModelID", "VehicleModelName", vehicle.VehicleModelID);
            return View(vehicle);
        }

        // POST: /Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleID,VehicleName,Description,Price,ManufacturerID,VehicleModelID,ImagePath")] Vehicle vehicle, HttpPostedFileBase file)
        {
            Boolean fileOk = false;
            string path = Server.MapPath("~/Images/");
            if (file != null && file.ContentLength > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
                string[] allowedExtension = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtension.Length; i++)
                {
                    if (fileExtension == allowedExtension[i])
                    {
                        fileOk = true;
                    }
                }
            }
            if (fileOk)
            {
                try
                {
                    file.SaveAs(path + file.FileName);
                    file.SaveAs(path + "Thumbs/" + file.FileName);
                    vehicle.ImagePath = file.FileName;
                    
                }
                catch (Exception)
                {

                }


            }

            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            var vModels = db.VehicleModels.Where(vm => vm.ManufacturerID == vehicle.ManufacturerID);

            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName", vehicle.ManufacturerID);
            ViewBag.VehicleModelID = new SelectList(vModels, "VehicleModelID", "VehicleModelName", vehicle.VehicleModelID);
            return View(vehicle);
        }

        // GET: /Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: /Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
