using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_SMART_ICE.Data
{
    public class EmployeeDBContext : DbContext
    {

        #region Constructor
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion

        #region Public properties
        public DbSet<Employee> Employees { get; set; }
        #endregion

        #region Overridden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(GetEmployees());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Private methods
        private Employee[] GetEmployees()
        {
            return new Employee[]
            {
            new Employee { Id = 1, FirstName = "Jonathan", LastName = "Bodnar", UserName = "jBodnar", Salary = 8000, Position = "CTO"},
            new Employee { Id = 2, FirstName = "Jason", LastName = "Smith", UserName = "jSmith", Salary = 6000, Position = "Manager IT"},


            };
        }
        #endregion

    }

}
