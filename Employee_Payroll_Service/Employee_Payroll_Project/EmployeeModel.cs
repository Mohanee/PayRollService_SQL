using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll_Project
{
    /// <summary>
    /// Employee Modal Class
    /// </summary>
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public decimal BasicPay { get; set; }
        public double TaxablePay { get; set; }
        public double Tax { get; set; }
        public double NetPay { get; set; }
        public DateTime StartDate { get; set; }


        public List<EmployeeModel> employeeList = new List<EmployeeModel>();

    }

}
