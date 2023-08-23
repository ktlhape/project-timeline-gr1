using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeline.Models
{
    public class Project
    {
        public string Code { get; set; }
		private string prName;

		public string ProjectName
		{
			get { return prName; }
			set {
                if (prName.Length < 3)
                {
                    throw new Exception($"Project name ({prName}) should be at least 3 characters long ");
                }
                prName = value; }
		}
        public DateOnly StartDate { get; set; }
        private DateOnly _endDate;

        public DateOnly EndDate
        {
            get { return _endDate; }
            set {
                if (_endDate < StartDate )
                {
                    throw new Exception($"The end date ({_endDate}) cannot be before the start date ({StartDate})");
                }
                _endDate = value; }
        }

        public int Duration { get; set; }
        public double EstimatedCost { get; set; }

        public static List<Project> prList = new List<Project>();
        public Project(string code, string projectName, DateOnly startDate, DateOnly endDate)
        {
 
            Code = code;
            ProjectName = projectName;
            StartDate = startDate;
            EndDate = endDate;
            Duration = (EndDate.Day - StartDate.Day);
        }
        public Project(){}
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
    }
}
