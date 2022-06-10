using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Models
{
    public class Location
    {
        public string City { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Location()
        {

        }
        public Location(string city, string Description, DateTime startDate, DateTime endDate)
        {
            this.City = city;
            this.Description = Description;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
 
    }
}
