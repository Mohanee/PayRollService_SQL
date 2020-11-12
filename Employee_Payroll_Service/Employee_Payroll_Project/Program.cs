using System;
using System.Collections.Generic;

namespace Employee_Payroll_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EmployeeModel model = new EmployeeModel();
            EmployeeRepo repo = new EmployeeRepo();

            List<EmployeeModel> employeeList = new List<EmployeeModel>();

            //Check connection establishment
            repo.CheckConnection();

            //UC1&2 Connect Database and Get all employee details
            repo.GetAllEmployee();

            //UC8 Add new Employee Details
            EmployeeModel employee = new EmployeeModel();
            employee.EmployeeName = "Indal";
            employee.StartDate = employee.StartDate = Convert.ToDateTime("2020-11-03");
            employee.Gender = "male";
            employee.PhoneNumber = "6302907918";
            employee.Department = "Tech";
            employee.Address = "02-Khajauli";
            employee.BasicPay = 10000.00M;
            employee.Tax = 500.00;
            employee.TaxablePay = 12000.00;
            employee.NetPay = 15000.00;

            repo.AddEmployee(model);

            if (repo.AddEmployee(employee))
                Console.WriteLine("Records added successfully");

            //UC3 Update Salary
            repo.UpdateSalary("Terissa",Convert.ToDecimal(50000));

            //UC5 Retrieve Employees belonging to a particular date range
            repo.RetrieveEmployeesWithParticularDateRange(Convert.ToDateTime("2015-12-September"), Convert.ToDateTime("2020-12-September"));


            //UC6 Aggregate Functions
            repo.AverageOfSalaryGenderWise();
            repo.CountOfEmployeesGenderWise();
            repo.MaximumSalaryGenderWise();
            repo.MinimumSalaryGenderWise();
            repo.SumOfSalaryGenderWise();


            //UC1(Section4) Add Multiple Employees to DataBase
            EmployeeModel employee2 = new EmployeeModel();
            employee2.EmployeeName = "Sushree";
            employee2.StartDate = employee.StartDate = Convert.ToDateTime("2020-11-03");
            employee2.Gender = "female";
            employee2.PhoneNumber = "6302907918";
            employee2.Department = "Tech";
            employee2.Address = "Raigarh";
            employee2.BasicPay = 20000.00M;
            employee2.Tax = 700.00;
            employee2.TaxablePay = 15000.00;
            employee2.NetPay = 18000.00;

            EmployeeModel employee3 = new EmployeeModel();
            employee3.EmployeeName = "Rakesh";
            employee3.StartDate = employee.StartDate = Convert.ToDateTime("2020-12-03");
            employee3.Gender = "Male";
            employee3.PhoneNumber = "6305687918";
            employee3.Department = "Logistics";
            employee3.Address = "Hyderabad Branch";
            employee3.BasicPay = 50000.00M;
            employee3.Tax = 500.00;
            employee3.TaxablePay = 15000.00;
            employee3.NetPay = 35000.00;

            EmployeeModel employee4 = new EmployeeModel();
            employee3.EmployeeName = "Ritika";
            employee3.StartDate = employee.StartDate = Convert.ToDateTime("2020-05-03");
            employee3.Gender = "Female";
            employee3.PhoneNumber = "9995687918";
            employee3.Department = "Sales";
            employee3.Address = "Hyderabad Branch";
            employee3.BasicPay = 55000.00M;
            employee3.Tax = 500.00;
            employee3.TaxablePay = 15500.00;
            employee3.NetPay = 40000.00;

            employeeList.Add(employee4);
            employeeList.Add(employee2);
            employeeList.Add(employee3);

            repo.AddMultipleEmployees(employeeList);






        }
    }
}
