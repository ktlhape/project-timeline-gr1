using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static List<Project> prList = new List<Project>() { 
        new("PR123","MICROSOFT",Convert.ToDateTime("06-05-2023"),Convert.ToDateTime("06-06-2023")),
        new("PR124","ANGLO",Convert.ToDateTime("11-05-2023"),Convert.ToDateTime("21-06-2023")),
        new("PR125","XBOX",Convert.ToDateTime("12-06-2023"),Convert.ToDateTime("16-11-2023")),
        new("PR126","SONY",Convert.ToDateTime("13-06-2023"),Convert.ToDateTime("15-09-2023")),
        new("PR127","MAC OS",Convert.ToDateTime("24-05-2023"),Convert.ToDateTime("05-06-2023")),
        };
        public Project(string code, string projectName, DateTime startDate, DateTime endDate)
        {

            Code = code;
            ProjectName = projectName;
            StartDate = startDate;
            EndDate = endDate;
            //Duration = (EndDate.Day - StartDate.Day);
            Duration = GetDuration(StartDate, EndDate);
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
                foreach (Project p in prList)
                {
                    if (p.Code.Equals(x))
                    {
                        return p;
                    }
                }
                return new Project();
            }
        }
        /// <summary>
        /// Returns all the projects that are above the specified estimated cost
        /// </summary>
        /// <param name="x">Estimated cost to be specified</param>
        /// <returns>List of Projects</returns>
        public List<Project> this[double x]
        {
            get
            {
                List<Project> pr = (from p in prList
                                    where p.EstimatedCost > x
                                    select p).ToList();
                return pr;
            }
        }
        /// <summary>
        /// Get Projects that started between two dates
        /// </summary>
        /// <param name="start">Start date to be specified</param>
        /// <param name="end">End date to be specified</param>
        /// <returns>List of projects that started between the two dates</returns>
        public static List<Project> BetweenDates(DateTime start, DateTime end) =>
            (from p in prList
             where p.StartDate.Date >= start && p.EndDate.Date <= end
             select p).ToList();

        public static List<Project> MoreThanSixWeeks() =>
            (from p in prList
             where (p.Duration / 5) > 6
             select p).ToList();

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
