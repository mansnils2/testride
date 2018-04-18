using System.Collections.Generic;
using System.Threading.Tasks;
using TestRide.Models;

namespace TestRide.Graph.Repositories.Testdrives
{
    public interface ITestdriveRepository : IBaseRepository<Testdrive, int>
    {
        Task<List<Testdrive>> MyTestdrives();
    }
}
