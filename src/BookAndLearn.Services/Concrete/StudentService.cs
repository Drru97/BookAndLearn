using BookAndLearn.Common.Entities;
using BookAndLearn.DataAccess.Repositories;
using BookAndLearn.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndLearn.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetStudentsByGroupAsync(int groupId)
        {
            return await _studentRepository.GetAsync(x => x.GroupId == groupId);
        }

        public async Task<IEnumerable<Student>> SearchStudents(string searchRequest)
        {
            return await _studentRepository
                .GetAsync(x => x.FirstName.Contains(searchRequest) || x.LastName.Contains(searchRequest));
        }
    }
}
