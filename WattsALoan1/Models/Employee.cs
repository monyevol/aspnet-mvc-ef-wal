namespace WattsALoan3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HumanResources.Employees")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            LoanContracts = new HashSet<LoanContract>();
            Payments = new HashSet<Payment>();
        }

        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }

        [StringLength(10)]
        [Display(Name = "Employee #")]
        public string EmployeeNumber { get; set; }

        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Display(Name = "Employee Title")]
        public string EmploymentTitle { get; set; }

        public string Identification
        {
            get
            {
                return EmployeeNumber + " - " + FirstName + " " + LastName + " (" + EmploymentTitle + ")";
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanContract> LoanContracts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
