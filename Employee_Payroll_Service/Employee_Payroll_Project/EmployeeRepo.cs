using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Employee_Payroll_Project
{

   public class EmployeeRepo
    {

        //Setting up connection
        public SqlConnection ConnectionEstablishment()
        {
            string connectionString = @"Data Source=(LocalDB)\BLDBserver;Initial Catalog=Payroll_Service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        /// <summary>
        /// Check if connection is set up or not
        /// </summary>
        /// <returns>true if connection is set up</returns>
        public bool CheckConnection()
        {
            SqlConnection connection= ConnectionEstablishment();
            try
            {
                using (connection)
                {
                    connection.Open();
                    Console.WriteLine("Connection is opened");
                    Console.WriteLine("Connection good");
                    connection.Close();
                    Console.WriteLine("Connection is closed");
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //UC2
            /// <summary>
            /// Method to retrieve all the Employee Details from the DB
            /// </summary>
        public void GetAllEmployee()
        {
            SqlConnection connection = ConnectionEstablishment();
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (connection)
                {
                    string query = @"Select id,name,start_date, gender, phoneNumber,address,department, basic_Pay, Taxable_Pay, Income_Tax, Net_Pay from ((employee e inner join Payroll p on e.Id = p.Id) inner join Department ed on e.Id = ed.EmployeeId);";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.StartDate = dr.GetDateTime(2);
                            employeeModel.Gender = dr.GetString(3);
                            employeeModel.PhoneNumber = dr.GetString(4);
                            employeeModel.Address = dr.GetString(5);
                            employeeModel.Department = dr.GetString(6);
                            employeeModel.BasicPay = dr.GetDecimal(7);
                            employeeModel.TaxablePay = dr.GetDouble(8);
                            employeeModel.Tax = dr.GetDouble(9);
                            employeeModel.NetPay = dr.GetDouble(10);

                            System.Console.WriteLine(employeeModel.EmployeeName + "|" + employeeModel.BasicPay + "|" + employeeModel.StartDate + "|" + employeeModel.Gender + "|" + employeeModel.PhoneNumber + 
                                "|" + employeeModel.Address + "|" + employeeModel.Department +  "|" + employeeModel.TaxablePay + "|" + employeeModel.Tax + "|" + employeeModel.NetPay);
                            System.Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        //UC8 Add Employee Details for a new employee
        public bool AddEmployee(EmployeeModel model)
        {
            SqlConnection connection = ConnectionEstablishment();
            SqlTransaction transaction = null;
            
            try
            {
                using (connection)
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", connection,transaction);
                    try
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Name", model.EmployeeName);
                        command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                        command.Parameters.AddWithValue("@Gender", model.Gender);
                        command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                        command.Parameters.AddWithValue("@Address", model.Address);
                        command.Parameters.AddWithValue("@Department", model.Department);
                        command.Parameters.AddWithValue("@Basic_Pay", model.BasicPay);
                        command.Parameters.AddWithValue("@Taxable_Pay", model.TaxablePay);
                        command.Parameters.AddWithValue("@Income_Tax", model.Tax);
                        command.Parameters.AddWithValue("@Net_Pay", model.NetPay);
                        var rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine(rowsAffected + " number of rows afffcted");
                            return true;
                        }
                    }
                    catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            transaction.Rollback();
                        }
                    transaction.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        /// <summary>
        /// Update salary 
        /// </summary>
        /// <param name="name">Name of the person to update salary</param>
        /// <param name="salary">New salary</param>
        /// <returns></returns>
        public bool UpdateSalary(string name, decimal salary)
        {
            SqlConnection connection = ConnectionEstablishment();
            try
            {
                using (connection)
                {
                    string query = @"Update Payroll set basic_pay = '" + salary + "' where name = '" + name + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public void RetrieveEmployeesWithParticularDateRange(DateTime startDate, DateTime endDate)
        {
            SqlConnection connection = ConnectionEstablishment();
            EmployeeModel employeeModel = new EmployeeModel();
            try
            {
                using (connection)
                {
                    string query = @"select * from Employee where start between '" + startDate + "'and '" + endDate + "';";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = !dr.IsDBNull(1) ? dr.GetString(1) : "NA";
                            employeeModel.BasicPay = !dr.IsDBNull(2) ? dr.GetDecimal(2) : 0;
                            employeeModel.StartDate = !dr.IsDBNull(3) ? dr.GetDateTime(3) : Convert.ToDateTime("01/01/0001");
                            employeeModel.Gender = !dr.IsDBNull(4) ? dr.GetString(4) : "NA";
                            employeeModel.PhoneNumber = !dr.IsDBNull(5) ? dr.GetString(5) : "NA";
                            employeeModel.Address = !dr.IsDBNull(6) ? dr.GetString(6) : "NA";
                            employeeModel.Department = !dr.IsDBNull(7) ? dr.GetString(7) : "NA";
                            employeeModel.TaxablePay = !dr.IsDBNull(9) ? Convert.ToDouble(dr.GetDecimal(9)) : 0;
                            employeeModel.Tax = !dr.IsDBNull(10) ? Convert.ToDouble(dr.GetDecimal(10)) : 0;
                            employeeModel.NetPay = !dr.IsDBNull(11) ? Convert.ToDouble(dr.GetDecimal(11)) : 0;
                            System.Console.WriteLine(employeeModel.EmployeeName + " " + employeeModel.BasicPay + " " + employeeModel.StartDate + " " + employeeModel.Gender + " " + employeeModel.PhoneNumber + " " + employeeModel.Address + " " + employeeModel.Department +  " " + employeeModel.TaxablePay + " " + employeeModel.Tax + " " + employeeModel.NetPay);
                            System.Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }

        //UC6 Aggregate Functions


        /// <summary>
        /// Sum of Salaries
        /// </summary>
        public void SumOfSalaryGenderWise()
        {
            SqlConnection connection = ConnectionEstablishment();
            try
            {
                using (connection)
                {
                    string query = @"select gender, SUM(basic_pay) from employee group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.Write(dr.GetString(0) + "\t");
                            Console.Write(dr.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Average salary for male and female
        /// </summary>
        public void AverageOfSalaryGenderWise()
        {
            SqlConnection connection = ConnectionEstablishment();
            try
            {
                using (connection)
                {
                    string query = @"select gender, AVG(basic_pay) from employee group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.Write(dr.GetString(0) + "\t");
                            Console.Write(dr.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Minimum salary for male and female
        /// </summary>
        public void MinimumSalaryGenderWise()
        {
            SqlConnection connection = ConnectionEstablishment();
            try
            {
                using (connection)
                {
                    string query = @"select gender, MIN(basic_pay) from employee group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.Write(dr.GetString(0) + "\t");
                            Console.Write(dr.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Maximum Salary fro Male and Female
        /// </summary>
        public void MaximumSalaryGenderWise()
        {
            SqlConnection connection = ConnectionEstablishment();
            try
            {
                using (connection)
                {
                    string query = @"select gender, MAX(basic_pay) from employee group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.Write(dr.GetString(0) + "\t");
                            Console.Write(dr.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public void CountOfEmployeesGenderWise()
        {
            SqlConnection connection = ConnectionEstablishment();
            try
            {
                using (connection)
                {
                    string query = @"select gender, COUNT(gender) from employee group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.Write(dr.GetString(0) + "\t");
                            Console.Write(dr.GetInt32(1));
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Add Multiple Employees to database (WITHOUT THREADS)
        /// </summary>
        /// <param name="list">List of Employees</param>
        /// <returns></returns>
        public int AddMultipleEmployees(List<EmployeeModel> list)
        {
            int noOfEmployeesAdded = 0;
            foreach (EmployeeModel employee in list)
            {
                noOfEmployeesAdded++;
                AddEmployee(employee);
            }
            return noOfEmployeesAdded;
        }

        /// <summary>
        /// Add Multiple Employees to database (USING THREADS)
        /// </summary>
        /// <param name="list">List of Employees</param>
        /// <returns></returns>
        public int AddMultipleEmployeesUsingThreads(List<EmployeeModel> list)
        {
            int noOfEmployeesAdded = 0;
            list.ForEach(employee =>
            {
                noOfEmployeesAdded++;
                AddEmployee(employee);
                Task task = new Task(() =>
                {
                    AddEmployee(employee);
                }
                );
                task.Start();
            }
            );
            return noOfEmployeesAdded;
        }



       

    }

}
