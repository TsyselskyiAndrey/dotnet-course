using Application.Abstractions.Persistence;
using Core.Models;

namespace Infrastructure.Repositories
{
    public class InstructionRepository : GenericRepository<Instruction>, IInstructionRepository
    {
        public InstructionRepository(string filePath) : base(filePath)
        {
        }
    }
}
