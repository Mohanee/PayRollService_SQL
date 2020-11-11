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


          



        }
    }
}
