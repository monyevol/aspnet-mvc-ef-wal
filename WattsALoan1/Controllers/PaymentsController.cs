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
    public class PaymentsController : Controller
    {
        private LoansManagementModel db = new LoansManagementModel();

        // GET: Payments
        public ActionResult Index()
        {
            var payments = db.Payments.Include(p => p.Employee).Include(p => p.LoanContract);
            return View(payments.ToList());
        }

        // GET: Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);

            ViewData["PaymentDate"] = payment.PaymentDate.Value.ToLongDateString();

            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        public ActionResult Create()
        {
            Random rndNumber = new Random();

            ViewData["ReceiptNumber"] = rndNumber.Next(1001, 9999);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Identification");
            ViewBag.LoanContractID = new SelectList(db.LoanContracts, "LoanContractID", "Identification");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentID,ReceiptNumber,PaymentDate,EmployeeID,LoanContractID,PaymentAmount,Balance")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Identification", payment.EmployeeID);
            ViewBag.LoanContractID = new SelectList(db.LoanContracts, "LoanContractID", "Identification", payment.LoanContractID);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Identification", payment.EmployeeID);
            ViewBag.LoanContractID = new SelectList(db.LoanContracts, "LoanContractID", "Identification", payment.LoanContractID);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentID,ReceiptNumber,PaymentDate,EmployeeID,LoanContractID,PaymentAmount,Balance")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Identification", payment.EmployeeID);
            ViewBag.LoanContractID = new SelectList(db.LoanContracts, "LoanContractID", "Identification", payment.LoanContractID);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
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
