using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndLearn.Common.Entities;

namespace BookAndLearn.Services.Abstract
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroupsAsync();
    }
}
