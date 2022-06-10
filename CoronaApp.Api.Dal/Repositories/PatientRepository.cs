using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Services.Interface;
namespace CoronaApp.Api.Dal.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DB _context;
        public PatientRepository(DB context)
        {
            _context = context;
        }
        public async Task<List<Patient>> Get()
        {
            return await Task.FromResult(_context.Patients_lst);
        }

        public async Task<Patient> Get(int id)
        {
            return await Task.FromResult(_context.Patients_lst.First(p => p.ID == id));
        }

        public async Task<bool> SaveNewLocation(Patient patient)
        {
            _context.Patients_lst.Add(patient);
            return true;
        }
    }
}
