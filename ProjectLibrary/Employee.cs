using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class Employee
    {
        static SqlConnection con = Connections.GetConnection();
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
            using (con)
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
    }
}
