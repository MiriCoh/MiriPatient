using CoronaApp.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CoronaApp.Services.Interface;

public interface ILocationRepository
{
    public Task<List<Location>> Get(int id);
    public Task<List<Location>> Get(string city);
    public void Create(Location patient, int id);
}
