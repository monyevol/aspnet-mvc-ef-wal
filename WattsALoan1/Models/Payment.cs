namespace WattsALoan3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Management.Payments")]
    public partial class Payment
    {
        [Display(Name = "Payment ID")]
        public int PaymentID { get; set; }
        [Display(Name = "Receipt #")]
        public int? ReceiptNumber { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Payment Date")]
        public DateTime? PaymentDate { get; set; }

        public int? EmployeeID { get; set; }

        public int? LoanContractID { get; set; }
        [Display(Name = "Payment Amount")]
        public decimal? PaymentAmount { get; set; }

        public decimal? Balance { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual LoanContract LoanContract { get; set; }
    }
}
