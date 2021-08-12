using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_SMART_ICE.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }

        public string EmployeeAsCommaSepratedString() => Id + " " + FirstName + " " + LastName + " " + UserName + " " + Position + " " + Salary;


    }
}
