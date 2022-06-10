using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CoronaApp.Services.Interface;

public interface IPatientRepository
{
    Task<List<Patient>> Get();
    Task<bool> SaveNewLocation(Patient patient);
    Task<Patient> Get(int id);
}
