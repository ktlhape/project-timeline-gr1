﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class Employee
    {
        
        public string EmployeeNo { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public double Salary { get; set; }
        public string Password { get; set; }
        public string EmpType { get; set; }

        public Employee(string employeeNo, string firstname, string lastname, double salary, string password, string empType)
        {
            EmployeeNo = employeeNo;
            Firstname = firstname;
            Lastname = lastname;
            Salary = salary;
            Password = password;
            EmpType = empType;
        }

        public static Employee GetEmployee(string empNo)
        {
            Employee em = null;
            using (SqlConnection con = Connections.GetConnection())
            {
                string strSelect = $"SELECT * FROM Employee WHERE EmployeeNo = '{empNo}'";
                con.Open();
                SqlCommand cmdSelect = new(strSelect, con);
                using (SqlDataReader rd = cmdSelect.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        em = new(rd.GetString(0), rd.GetString(1), 
                            rd.GetString(2), rd.GetDouble(3), rd.GetString(4), 
                            rd.GetString(5));
                    }
                }
            }
            return em;
        }
        public static List<Employee> AllEmployees()
        {
            List<Employee> emList = new();
            using (SqlConnection con = Connections.GetConnection())
            {
                string strSelect = $"SELECT * FROM Employee";
                con.Open();
                SqlCommand cmdSelect = new(strSelect, con);
                using (SqlDataReader rd = cmdSelect.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        emList.Add(new(rd.GetString(0), rd.GetString(1),
                            rd.GetString(2), rd.GetDouble(3), rd.GetString(4),
                            rd.GetString(5)));
                    }
                }
            }
            return emList;
        }
        /// <summary>
        /// Get employees who are not assigned to a specific project
        /// </summary>
        /// <param name="prCode">Project code to be specified</param>
        /// <returns>A list of employees not assigned to a project</returns>
        public static List<Employee> NotAssignedEmployees(string prCode)
        {
            List<Employee> emList = new();
            using (SqlConnection con = Connections.GetConnection())
            {
                string strSelect = $"SELECT * from Employee e " +
                    $"join Assignment a on e.EmployeeNo = a.EmployeeNo " +
                    $"where e.EmployeeNo not in (select EmployeeNo from Assignment where ProjectCode = '{prCode}')";
                con.Open();
                SqlCommand cmdSelect = new(strSelect, con);
                using (SqlDataReader rd = cmdSelect.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        emList.Add(new(rd.GetString(0), rd.GetString(1),
                            rd.GetString(2), rd.GetDouble(3), rd.GetString(4),
                            rd.GetString(5)));
                    }
                }
            }
            return emList;
        }
    }
}
