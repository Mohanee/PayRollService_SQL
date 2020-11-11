using System;

namespace Employee_Payroll_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EmployeeModel model = new EmployeeModel();
            EmployeeRepo repo = new EmployeeRepo();
            //obj.AddEmployee(model);

            //EmployeeModel employee = new EmployeeModel();
            //employee.EmployeeName = "Indal";
            //employee.StartDate = employee.StartDate = Convert.ToDateTime("2020-11-03");
            //employee.Gender = "male";
            //employee.PhoneNumber = "6302907918";
            //employee.Department = "Tech";
            //employee.Address = "02-Khajauli";
            //employee.BasicPay = 10000.00M;
            //employee.Tax = 500.00;
            //employee.TaxablePay = 12000.00;
            //employee.NetPay = 15000.00;

            //if (repo.AddEmployee(employee))
            //    Console.WriteLine("Records added successfully");

            repo.GetAllEmployee();
        }
    }
}
