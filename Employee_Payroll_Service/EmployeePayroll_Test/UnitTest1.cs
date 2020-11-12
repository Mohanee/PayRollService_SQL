using NUnit.Framework;
using System;
using Employee_Payroll_Project;

namespace EmployeePayroll_Test
{
    public class Tests
    {

        EmployeeRepo repo = new EmployeeRepo();
        EmployeeModel model = new EmployeeModel();

        [Test]
        public void Given_NewEmployeeWhenAdded_Should_SyncWithDB()
        {
            EmployeeModel employee = new EmployeeModel();
            employee.EmployeeName = "Manpreet";
            employee.Department = "Sales";
            employee.PhoneNumber = "568793223";
            employee.Address = "03-Pancham Society";
            employee.Gender = "Female";
            employee.StartDate = DateTime.Today;
            employee.BasicPay = 20000;
            employee.TaxablePay = 500;
            employee.Tax = 5000;
            employee.NetPay = 15000;

            bool actualResult = repo.AddEmployee(employee);
            Assert.AreEqual(actualResult, true);
        }

        [Test]
        public void  GivenNameAndUpdatedSalary_ShouldUpdateSalaryInDatabase()
        { 
            
                bool updateResult = repo.UpdateSalary("Terissa", Convert.ToDecimal("500000"));
                bool expected = true;
                Assert.AreEqual(updateResult, expected);
            
        }

        [Test]
        public void GiveMultipleEmployee_ShouldREturn_NumberofEmployeesAdded()
        {
            
           EmployeeModel employee2 = new EmployeeModel();
            employee2.EmployeeName = "Sushree";
            employee2.StartDate = employee2.StartDate = Convert.ToDateTime("2020-11-03");
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
            employee3.StartDate = employee3.StartDate = Convert.ToDateTime("2020-12-03");
            employee3.Gender = "Male";
            employee3.PhoneNumber = "6305687918";
            employee3.Department = "Logistics";
            employee3.Address = "Hyderabad Branch";
            employee3.BasicPay = 50000.00M;
            employee3.Tax = 500.00;
            employee3.TaxablePay = 15000.00;
            employee3.NetPay = 35000.00;

            EmployeeModel employee4 = new EmployeeModel();
            employee4.EmployeeName = "Ritika";
            employee4.StartDate = employee4.StartDate = Convert.ToDateTime("2020-05-03");
            employee4.Gender = "Female";
            employee4.PhoneNumber = "9995687918";
            employee4.Department = "Sales";
            employee4.Address = "Hyderabad Branch";
            employee4.BasicPay = 55000.00M;
            employee4.Tax = 500.00;
            employee4.TaxablePay = 15500.00;
            employee4.NetPay = 40000.00;


            model.employeeList.Add(employee4);
            model.employeeList.Add(employee2);
            model.employeeList.Add(employee3);
           int actualRecordsAdded= repo.AddMultipleEmployees(model.employeeList);

            Assert.AreEqual(actualRecordsAdded, 3);
        }


    }
}