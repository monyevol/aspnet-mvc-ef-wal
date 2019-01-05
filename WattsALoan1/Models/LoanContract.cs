namespace WattsALoan3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Management.LoanContracts")]
    public partial class LoanContract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoanContract()
        {
            Payments = new HashSet<Payment>();
        }

        [Display(Name = "Loan Contract ID")]
        public int LoanContractID { get; set; }
        [Display(Name = "Loan #")]
        public int LoanNumber { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date Allocated")]
        public DateTime? DateAllocated { get; set; }
        [Display(Name = "Employee ID")]
        public int? EmployeeID { get; set; }

        [StringLength(20)]
        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }

        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }

        [StringLength(20)]
        [Display(Name = "Loan Type")]
        public string LoanType { get; set; }
        [Display(Name = "Loan Amount")]
        public decimal? LoanAmount { get; set; }
        [Display(Name = "Interest Rate")]
        public decimal? InterestRate { get; set; }

        public short? Periods { get; set; }
        [Display(Name = "Monthly Payment")]
        public decimal? MonthlyPayment { get; set; }
        [Display(Name = "Future Value")]
        public decimal? FutureValue { get; set; }
        [Display(Name = "Interest Amount")]
        public decimal? InterestAmount { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Payment Start Date")]
        public DateTime? PaymentStartDate { get; set; }

        public string Identification
        {
            get
            {
                return LoanContractID + " - " + LoanNumber + " as " + LoanType + " to " +
                       CustomerFirstName + " " + CustomerLastName + " for " +
                       LoanAmount + " (" + MonthlyPayment + "/month)";
            }
        }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
