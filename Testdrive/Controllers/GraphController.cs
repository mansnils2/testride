using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Testdrive.Graph.GraphContext;
using Testdrive.Graph.Models;

namespace Testdrive.Controllers
{
    [Route("graph"), Produces("application/json")]
    public class GraphController : Controller
    {
        private readonly IGraphContext _gql;

        public GraphController(IGraphContext gql) => _gql = gql;

        [HttpPost("")]
        public async Task<IActionResult> Query([FromBody] GraphQlQuery query)
        {
            var result = await _gql.QueryAsync(query);
            if (result.Errors == null) return Ok(result);

            return BadRequest(new { errors = result.Errors.Select(e => e.Message) });
        }
    }
}
