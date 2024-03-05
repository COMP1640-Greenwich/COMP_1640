using COMP_1640.Repository.IRepository;
using COMP_1640.Models;

namespace COMP_1640.Repository.IRepository
{
    public interface IAssignmentRepository : IRepository<Assignment>
    {
        void Add(Assignment assignment);
    }
}
