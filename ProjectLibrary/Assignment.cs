using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectLibrary
{
    public class Assignment
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public string EmployeeNo { get; set; }
        public DateTime AssignmentDate { get; set; }

        public Assignment(int id, string projectCode, string employeeNo, DateTime assignmentDate)
        {
            Id = id;
            ProjectCode = projectCode;
            EmployeeNo = employeeNo;
            AssignmentDate = assignmentDate;
        }

        public void Assign()
        {
            using (SqlConnection con = Connections.GetConnection())
            {
                string strInsert = $"INSERT INTO Assignment " +
                    $"VALUES({Id},'{ProjectCode}','{EmployeeNo}'," +
                    $"'{AssignmentDate.ToString("yyyy-MM-dd")}')";
                con.Open();

                SqlCommand cmdInsert = new(strInsert, con);
                cmdInsert.ExecuteNonQuery();
            }
        }
    }
}
