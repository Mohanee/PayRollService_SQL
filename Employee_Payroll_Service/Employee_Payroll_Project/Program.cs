using System;

namespace Employee_Payroll_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EmployeeModel model = new EmployeeModel();
            EmployeeRepo obj = new EmployeeRepo();
            obj.AddEmployee(model);
        }
    }
}
