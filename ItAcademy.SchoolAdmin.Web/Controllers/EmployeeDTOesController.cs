//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
//using ItAcademy.SchoolAdmin.DataAccess;

//namespace ItAcademy.SchoolAdmin.Web.Controllers
//{
//    public class EmployeeDTOesController : Controller
//    {
//        private SchoolContext db = new SchoolContext();

//        // GET: EmployeeDTOes
//        public async Task<ActionResult> Index()
//        {
//            return View(await db.EmployeeDTOes.ToListAsync());
//        }

//        // GET: EmployeeDTOes/Details/5
//        public async Task<ActionResult> Details(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            EmployeeDTO employeeDTO = await db.EmployeeDTOes.FindAsync(id);
//            if (employeeDTO == null)
//            {
//                return HttpNotFound();
//            }
//            return View(employeeDTO);
//        }

//        // GET: EmployeeDTOes/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: EmployeeDTOes/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Create([Bind(Include = "Id,FullName,BirthDate,Email,Phone")] EmployeeDTO employeeDTO)
//        {
//            if (ModelState.IsValid)
//            {
//                db.EmployeeDTOes.Add(employeeDTO);
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }

//            return View(employeeDTO);
//        }

//        // GET: EmployeeDTOes/Edit/5
//        public async Task<ActionResult> Edit(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            EmployeeDTO employeeDTO = await db.EmployeeDTOes.FindAsync(id);
//            if (employeeDTO == null)
//            {
//                return HttpNotFound();
//            }
//            return View(employeeDTO);
//        }

//        // POST: EmployeeDTOes/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Edit([Bind(Include = "Id,FullName,BirthDate,Email,Phone")] EmployeeDTO employeeDTO)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(employeeDTO).State = EntityState.Modified;
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return View(employeeDTO);
//        }

//        // GET: EmployeeDTOes/Delete/5
//        public async Task<ActionResult> Delete(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            EmployeeDTO employeeDTO = await db.EmployeeDTOes.FindAsync(id);
//            if (employeeDTO == null)
//            {
//                return HttpNotFound();
//            }
//            return View(employeeDTO);
//        }

//        // POST: EmployeeDTOes/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> DeleteConfirmed(string id)
//        {
//            EmployeeDTO employeeDTO = await db.EmployeeDTOes.FindAsync(id);
//            db.EmployeeDTOes.Remove(employeeDTO);
//            await db.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
