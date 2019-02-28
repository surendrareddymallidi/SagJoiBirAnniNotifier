using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SagEmpDataModel;

namespace SagEmpMaintenance.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private SagEmployeeDbContext db = new SagEmployeeDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.employees.Include(b => b.location);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            busSagEmployee bussagemployee = db.employees.Find(id);
            if (bussagemployee == null)
            {
                return HttpNotFound();
            }
            return View(bussagemployee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.locationId = new SelectList(db.locations, "locationId", "locationName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sagId,firstName,middleName,lastName,email,dateOfBirth,dateOfJoining,project,designation,locationId,education,previousCompany,previousCompanyDesignation,hobbies,photo,user_image_data,joiningMailSent,IsTerminated")] busSagEmployee abussagemployee)
        {
            if (ModelState.IsValid)
            {
                var originalFilename = Path.GetFileName(abussagemployee.user_image_data.FileName);
                string fileId = Guid.NewGuid().ToString().Replace("-", "");
                abussagemployee.photo = fileId + originalFilename;
                var path = Path.Combine(Server.MapPath("~/Pictures/"), abussagemployee.photo);
                abussagemployee.user_image_data.SaveAs(path);
                db.employees.Add(abussagemployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.locationId = new SelectList(db.locations, "locationId", "locationName", abussagemployee.locationId);
            return View(abussagemployee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            busSagEmployee lbussagemployee = db.employees.Find(id);
            if (lbussagemployee == null)
            {
                return HttpNotFound();
            }
            lbussagemployee.photo = $"{Request.Url.Scheme}://{Request.Url.Authority}{Url.Content("~")}/Pictures/{lbussagemployee.photo}";
            if (System.IO.File.Exists(Server.MapPath(lbussagemployee.photo)))
                lbussagemployee.user_image_data = new HttpPostedFile();

            ViewBag.locationId = new SelectList(db.locations, "locationId", "locationName", lbussagemployee.locationId);
            return View(lbussagemployee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sagId,firstName,middleName,lastName,email,dateOfBirth,dateOfJoining,project,designation,locationId,education,previousCompany,previousCompanyDesignation,hobbies,photo,user_image_data,joiningMailSent,IsTerminated")] busSagEmployee bussagemployee)
        {
            if (ModelState.IsValid)
            {
                if(bussagemployee.user_image_data == null)
                {

                }
                else
                {
                    var originalFilename = Path.GetFileName(bussagemployee.user_image_data.FileName);
                    string fileId = Guid.NewGuid().ToString().Replace("-", "");
                    bussagemployee.photo = fileId + originalFilename;
                    var path = Path.Combine(Server.MapPath("~/Pictures/"), bussagemployee.photo);
                    bussagemployee.user_image_data.SaveAs(path);
                }
                db.Entry(bussagemployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.locationId = new SelectList(db.locations, "locationId", "locationName", bussagemployee.locationId);
            return View(bussagemployee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            busSagEmployee bussagemployee = db.employees.Find(id);
            if (bussagemployee == null)
            {
                return HttpNotFound();
            }
            return View(bussagemployee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            busSagEmployee bussagemployee = db.employees.Find(id);
            db.employees.Remove(bussagemployee);
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
