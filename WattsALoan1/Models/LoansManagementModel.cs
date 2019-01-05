namespace WattsALoan3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LoansManagementModel : DbContext
    {
        public LoansManagementModel()
            : base("name=LoansManagementModel")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LoanContract> LoanContracts { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanContract>()
                .Property(e => e.LoanAmount)
                .HasPrecision(8, 2);

            modelBuilder.Entity<LoanContract>()
                .Property(e => e.InterestRate)
                .HasPrecision(8, 2);

            modelBuilder.Entity<LoanContract>()
                .Property(e => e.MonthlyPayment)
                .HasPrecision(8, 2);

            modelBuilder.Entity<LoanContract>()
                .Property(e => e.FutureValue)
                .HasPrecision(8, 2);

            modelBuilder.Entity<LoanContract>()
                .Property(e => e.InterestAmount)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Payment>()
                .Property(e => e.PaymentAmount)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Balance)
                .HasPrecision(8, 2);
        }
    }
}
