using COMP_1640.Data;
using COMP_1640.Models;
using COMP_1640.Repository.IRepository;
using COMP_1640.Models;

namespace COMP_1640.Repository
{
    public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public AssignmentRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        public void Update(Assignment entity)
        {
            _dbContext.Assignments.Update(entity);
        }
    }
}
