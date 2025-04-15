using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.DataAccess
{
    public class EmployeeDataAccess
    {
        public List<Employee> GetEmployeeList()

        {
            List<Employee> employees = new List<Employee>();

            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                String query = "GetEmployeeInfo";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee emp = new Employee
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Title = reader["Title"].ToString(),
                        };

                        employees.Add(emp);
                    }
                }

                sqlConnection.Close();
            }

            catch (Exception e)
            {
                sqlConnection.Close();
            }

            return employees;

        }
        public bool CreateEmployee(Employee employee)
        {
            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("CreateEmployee", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Title", employee.Title);

                sqlConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return rowsAffected > 0;
            }
        }


    }

}