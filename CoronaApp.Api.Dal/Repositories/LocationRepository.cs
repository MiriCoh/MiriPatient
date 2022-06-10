using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Services.Interface;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;
namespace CoronaApp.Api.Dal.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private DB _context;

        public LocationRepository(DB context)
        {
            _context = context;
        }
        public async Task<List<Location>> Get(int id)
        {
            return await Task.FromResult(_context.Patients_lst.First(e => e.ID == id).Location.ToList());
        }

        public async Task<List<Location>> Get(string city)
        {
            List<Location> lst1 = _context.Patients_lst.SelectMany(p => p.Location).ToList();
            return await Task.FromResult(lst1.Where(p => p.City == city).ToList());

        }
        public async void Create(Location patientLocation, int id)
        {
            _context.Patients_lst.Add(new Patient(patientLocation, id));
        }
    }
}
