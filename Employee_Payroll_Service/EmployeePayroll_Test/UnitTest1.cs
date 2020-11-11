using NUnit.Framework;
using System;
using Employee_Payroll_Project;

namespace EmployeePayroll_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        EmployeeRepo repo = new EmployeeRepo();

        [Test]
        public void  GivenNameAndUpdatedSalary_ShouldUpdateSalaryInDatabase()
        { 
            {
                bool updateResult = repo.UpdateSalary("Terissa", Convert.ToDecimal("500000"));
                bool expected = true;
                Assert.AreEqual(updateResult, expected);
            }
        }
    }
}