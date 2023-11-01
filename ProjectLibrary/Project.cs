using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace ProjectLibrary
{
    public class Project
    {
        
        public string Code { get; set; }
        private string prName;

        public string ProjectName
        {
            get { return prName; }
            set
            {
                if (value.Trim().Length < 3)
                {
                    throw new Exception($"Project name ({prName}) should be at least 3 characters long ");
                }
                prName = value;
            }
        }
        public DateTime StartDate { get; set; }
        private DateTime _endDate;

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (value < StartDate)
                {
                    throw new Exception($"The end date ({EndDate}) cannot be before the start date ({StartDate})");
                }
                else
                {
                    _endDate = value;
                }

            }
        }
        public int Duration { get; set; }
        public double EstimatedCost { get; set; }

        public Project(string code, string projectName, DateTime startDate, DateTime endDate, double rate)
        {
            Code = code;
            ProjectName = projectName;
            StartDate = startDate;
            EndDate = endDate;
            //Duration = (EndDate.Day - StartDate.Day);
            Duration = GetDuration(StartDate, EndDate);
            EstimatedCost = CalcEstimatedCost(rate);
        }

        public Project(string code, string projectName, DateTime startDate, DateTime endDate, int duration, double estimatedCost)
        {
            Code = code;
            ProjectName = projectName;
            StartDate = startDate;
            EndDate = endDate;
            Duration = duration;
            EstimatedCost = estimatedCost;
        }

        public Project() { }
        /// <summary>
        /// Return the Estimated cost for the project
        /// </summary>
        /// <param name="hourlyRate"></param>
        /// <returns>Estimated Cost</returns>
        public double CalcEstimatedCost(double hourlyRate)
        {
            return (hourlyRate * 8) * Duration;
        }

        public async void AddProject()
        {
            using (SqlConnection con = Connections.GetConnection())
            {
                string strInsert = $"INSERT INTO Project VALUES('{Code}','{ProjectName}','" +
                    $"{StartDate.ToString("yyyy-MM-dd")}','{EndDate.ToString("yyyy-MM-dd")}'," +
                    $"{Duration},{EstimatedCost})";
                 await  con.OpenAsync();
                SqlCommand cmdInsert = new SqlCommand(strInsert, con);
               await cmdInsert.ExecuteNonQueryAsync();

            }
        }
        //(PR123)  SISONKE - 14 days, EC: R22 400.00
        /// <summary>
        /// Returns the details of the Project. Eg: (PR123) SISONKE - 14 days, EC: R22 400.00
        /// </summary>
        /// <returns>Project Details</returns>
        public override string? ToString()
        {
            return $"({Code}) {ProjectName} - {Duration} days, EC: {EstimatedCost.ToString("C2")}";
        }
        /// <summary>
        /// Returns the project obejct with a matching project code
        /// </summary>
        /// <param name="x">Project code to be specified</param>
        /// <returns>Project</returns>
        public Project this[string x]
        {
            get
            {
                foreach (Project p in AllProjects().Result)
                {
                    if (string.Equals(p.Code,x,StringComparison.OrdinalIgnoreCase))
                    {
                        return p;
                    }
                }
                return new Project();
            }
        }

        public static async Task<List<Project>> AllProjects()
        {
            List<Project> ls = new();
            using (SqlConnection con = Connections.GetConnection())
            {
                string strSelect = $"SELECT * FROM Project";
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                await con.OpenAsync();
                using (SqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (await reader.ReadAsync())
                    {
                        Project p = new Project((string)reader[0], (string)reader[1],
                            Convert.ToDateTime(reader[2]), Convert.ToDateTime(reader[3]),
                            (int)reader[4], (double)reader[5]);
                        ls.Add(p);
                    }
                }

            }
            return ls;
        }

        public static async Task<List<Project>> EmployeeProjects(string empNo)
        {
            List<Project> ls = new();
            using (SqlConnection con = Connections.GetConnection())
            {
                string strSelect = $"SELECT * FROM Project where ProjectCode in (select ProjectCode from Assignment where EmployeeNo = '{empNo}')";
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);
               await con.OpenAsync();
                using (SqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (await reader.ReadAsync())
                    {
                        Project p = new Project((string)reader[0], (string)reader[1],
                            Convert.ToDateTime(reader[2]), Convert.ToDateTime(reader[3]),
                            (int)reader[4], (double)reader[5]);
                        ls.Add(p);
                    }
                }

            }
            return ls;
        }
        /// <summary>
        /// Returns all the projects that are above the specified estimated cost
        /// </summary>
        /// <param name="x">Estimated cost to be specified</param>
        /// <returns>List of Projects</returns>
        //public List<Project> this[double x]
        //{
        //    get
        //    {
        //        List<Project> pr = (from p in prList
        //                            where p.EstimatedCost > x
        //                            select p).ToList();
        //        return pr;
        //    }
        //}
        /// <summary>
        /// Get Projects that started between two dates
        /// </summary>
        /// <param name="start">Start date to be specified</param>
        /// <param name="end">End date to be specified</param>
        /// <returns>List of projects that started between the two dates</returns>
        //public static List<Project> BetweenDates(DateTime start, DateTime end) =>
        //    (from p in prList
        //     where p.StartDate.Date >= start && p.EndDate.Date <= end
        //     select p).ToList();

        //public static List<Project> MoreThanSixWeeks() =>
        //    (from p in prList
        //     where (p.Duration / 5) > 6
        //     select p).ToList();
        /// <summary>
        /// Get all the completed projects from the list
        /// </summary>
        /// <returns>A list of completed projects</returns>
        //public static List<Project> CompletedProjects() =>
        //     (from p in prList
        //      where p.EndDate < DateTime.Now.Date
        //      select p).ToList();
        /// <summary>
        /// Get the total number of days between two dates
        /// </summary>
        /// <param name="start">Start date (Excluding Saturday and Sunday)</param>
        /// <param name="end">End date (Excluding Saturday and Sunday</param>
        /// <returns>Total number of days between two dates</returns>
        public int GetDuration(DateTime start, DateTime end)
        {
            int totalDays = 0;

            while (start != end)
            {
                if (start.IsBusinessDay())
                {
                    totalDays++;
                }
                start = start.AddDays(1);
            }
            return totalDays;
        }

    }
}
