using CoronaApp.Services.Models;
namespace CoronaApp.Api.Dal
{
    public class DB
    {
        public List<Patient> Patients_lst { get; set; }
        public DB()
        {

            Patients_lst = new List<Patient>();
            Patient l1 = new Patient()
            {
                Location = new List<Location> {
            new Location{ City = "bb", Description = "park", StartDate = new System.DateTime(2020, 5, 19), EndDate = new System.DateTime(2020, 6, 20) } ,
            new Location{ City = "Elad", Description = "centeral station", StartDate = new System.DateTime(2020, 5, 19), EndDate = new System.DateTime(2020, 6, 20) }
            },
                ID = 123456
            };
            Patient l2 = new Patient()
            {
                Location = new List<Location> {
            new Location{ City = "Jerusalem", Description = "school", StartDate = new System.DateTime(2020, 5, 19), EndDate = new System.DateTime(2020, 6, 20) } ,
            new Location{ City = "Tzfat", Description = "mall", StartDate = new System.DateTime(2020, 5, 19), EndDate = new System.DateTime(2020, 6, 20) }
            },
                ID = 1234567
            };
            Patient l3 = new Patient()
            {
                Location = new List<Location> {
            new Location{ City = "bb", Description = "office", StartDate = new System.DateTime(2020, 5, 19), EndDate = new System.DateTime(2020, 6, 20) } ,
            new Location{ City = "Elad", Description = "mall", StartDate = new System.DateTime(2020, 5, 19), EndDate = new System.DateTime(2020, 6, 20) }
            },
                ID = 12345678
            };
            Patients_lst.Add(l1);
            Patients_lst.Add(l2);
            Patients_lst.Add(l3);
        }

    }
}
