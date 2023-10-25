using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Goal : ICRUD<data.Goal>
    {
        private SolutionDbContext context;

        public Goal(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.Goal t)
        {
            new DAL.Goal(context).Delete(t);
        }

        public IEnumerable<data.Goal> GetAll()
        {
            return new DAL.Goal(context).GetAll();
        }

        public data.Goal GetOneById(int id)
        {
            return new DAL.Goal(context).GetOneById(id);
        }

        public void Insert(data.Goal t)
        {
            new DAL.Goal(context).Insert(t);
        }

        public void Update(data.Goal t)
        {
            new DAL.Goal(context).Update(t) ;
        }
    }
}
