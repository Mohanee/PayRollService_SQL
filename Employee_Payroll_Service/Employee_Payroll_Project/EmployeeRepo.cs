using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Employee_Payroll_Project
{

    class EmployeeRepo
    {

        //Setting up connection
        public SqlConnection ConnectionEstablishment()
        {
            string connectionString = @"Data Source=(LocalDB)\BLDBserver;Initial Catalog=Payroll_service;Integrated Security=True";
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
                    string query = @"Select * from payroll_service_table;";
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


        public bool AddEmployee(EmployeeModel model)
        {
            SqlConnection connection = ConnectionEstablishment();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    connection.Open();
                    var rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected> 0)
                    {
                        Console.WriteLine(rowsAffected+" number of rows afffcted");
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

    }

}
