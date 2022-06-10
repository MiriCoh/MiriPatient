using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Models
{
    public class Patient
    {
        public List<Location> Location { get; set; }
        public int ID { get; set; }
        public Patient()
        {

        }
        public Patient(Location locations, int ID)
        {
            this.Location = new List<Location>();
            this.ID = ID;
        }
    }
}
