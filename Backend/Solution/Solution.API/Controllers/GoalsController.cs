using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.DAL.EF;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using data = Solution.DO.Objects;
using datamodels = Solution.API.DataModels;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public GoalsController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Goals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Goal>>> GetGoals()
        {
            var aux = new BS.Goal(_context).GetAll();
            var mapaux = _mapper.Map<IEnumerable<data.Goal>,IEnumerable<datamodels.Goal>>(aux).ToList();

            return mapaux;
        }

        // GET: api/Goals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Goal>> GetGoal(int id)
        {

           var goal = new BS.Goal(_context).GetOneById(id);

            if (goal == null)
            {
                return NotFound();
            }
            var mapaux = _mapper.Map<data.Goal, datamodels.Goal>(goal);

            return mapaux;
        }

        // PUT: api/Goals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoal(int id, datamodels.Goal goal)
        {
            if (id != goal.GoalId)
            {
                return BadRequest();
            }

            

            try
            {
               var mapaux = _mapper.Map<datamodels.Goal, data.Goal>(goal);
                new BS.Goal(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!GoalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Goals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<datamodels.Goal>> PostGoal(datamodels.Goal goal)
        {
            var mapaux = _mapper.Map<datamodels.Goal, data.Goal>(goal);
            new BS.Goal(_context).Insert(mapaux);

            return CreatedAtAction("GetGoal", new { id = goal.GoalId }, goal);
        }

        // DELETE: api/Goals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Goal>> DeleteGoal(int id)
        {
            var goal = new BS.Goal(_context).GetOneById(id);

            if (goal == null)
            {
                return NotFound();
            }
            new BS.Goal(_context).Delete(goal);
            var mapaux = _mapper.Map<data.Goal, datamodels.Goal>(goal);

            return mapaux;
        }

        private bool GoalExists(int id)
        {
            return (new BS.Goal(_context).GetOneById(id) != null);
        }
    }
}
