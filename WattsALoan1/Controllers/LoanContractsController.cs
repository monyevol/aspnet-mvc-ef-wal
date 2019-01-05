using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WattsALoan3.Models;

namespace WattsALoan3.Controllers
{
    public class LoanContractsController : Controller
    {
        private LoansManagementModel db = new LoansManagementModel();

        // GET: LoanContracts
        public ActionResult Index()
        {
            var loanContracts = db.LoanContracts.Include(l => l.Employee);
            return View(loanContracts.ToList());
        }

        // GET: LoanContracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanContract loanContract = db.LoanContracts.Find(id);

            ViewData["DateAllocated"] = loanContract.DateAllocated.Value.ToLongDateString();
            ViewData["PaymentStartDate"] = DateTime.Parse(loanContract.PaymentStartDate.ToString()).ToLongDateString();

            if (loanContract == null)
            {
                return HttpNotFound();
            }

            // var loansContracts = db.Payments.Select(pmt => pmt.PaymentID == loanContract.P);
            // ViewData["LoansPayments"] = loansContracts;

            return View(loanContract);
        }

        // GET: LoanContracts/Create
        public ActionResult Create()
        {
            Random rndNumber = new Random();

            // Create a list of loans types for a combo box
            List<SelectListItem> loanTypes = new List<SelectListItem>();

            loanTypes.Add(new SelectListItem() { Text = "Personal Loan", Value = "Personal Loan" });
            loanTypes.Add(new SelectListItem() { Text = "Car Financing", Value = "Car Financing" });
            loanTypes.Add(new SelectListItem() { Text = "Boat Financing", Value = "Boat Financing" });
            loanTypes.Add(new SelectListItem() { Text = "Furniture Purchase", Value = "Furniture Purchase" });
            loanTypes.Add(new SelectListItem() { Text = "Musical Instrument", Value = "Musical Instrument" });

            ViewData["LoanNumber"] = rndNumber.Next(100001, 999999);

            // Store the list in a View Bag so it can be access by a combo box
            ViewBag.LoanType = loanTypes;

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Identification");
            return View();
        }

        // POST: LoanContracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoanContractID,LoanNumber,DateAllocated,EmployeeID,CustomerFirstName,CustomerLastName,LoanType,LoanAmount,InterestRate,Periods,MonthlyPayment,FutureValue,InterestAmount,PaymentStartDate")] LoanContract loanContract)
        {
            if (ModelState.IsValid)
            {
                db.LoanContracts.Add(loanContract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Identification", loanContract.EmployeeID);
            return View(loanContract);
        }

        // GET: LoanContracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanContract loanContract = db.LoanContracts.Find(id);
            if (loanContract == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Identification", loanContract.EmployeeID);
            return View(loanContract);
        }

        // POST: LoanContracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoanContractID,LoanNumber,DateAllocated,EmployeeID,CustomerFirstName,CustomerLastName,LoanType,LoanAmount,InterestRate,Periods,MonthlyPayment,FutureValue,InterestAmount,PaymentStartDate")] LoanContract loanContract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loanContract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Identification", loanContract.EmployeeID);
            return View(loanContract);
        }

        // GET: LoanContracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanContract loanContract = db.LoanContracts.Find(id);

            ViewData["DateAllocated"] = loanContract.DateAllocated.Value.ToLongDateString();
            ViewData["PaymentStartDate"] = DateTime.Parse(loanContract.PaymentStartDate.ToString()).ToLongDateString();

            if (loanContract == null)
            {
                return HttpNotFound();
            }
            return View(loanContract);
        }

        // POST: LoanContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoanContract loanContract = db.LoanContracts.Find(id);
            db.LoanContracts.Remove(loanContract);
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
