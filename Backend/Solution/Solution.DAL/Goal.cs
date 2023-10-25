using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Goal : ICRUD<data.Goal>
    {
        private Repository<data.Goal> _repo = null;

        public Goal(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Goal>(solutionDbContext);
        }

        public void Delete(data.Goal t)
        {
           _repo.Delete(t);
           _repo.Commit();

        }

        public IEnumerable<data.Goal> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Goal GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Goal t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Goal t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
