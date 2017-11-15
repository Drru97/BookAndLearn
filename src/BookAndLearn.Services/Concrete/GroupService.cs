using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndLearn.Common.Entities;
using BookAndLearn.DataAccess.Repositories;
using BookAndLearn.Services.Abstract;

namespace BookAndLearn.Services.Concrete
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<Group> _groupRepository;

        public GroupService(IRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            return await _groupRepository.GetAllAsync();
        }
    }
}
