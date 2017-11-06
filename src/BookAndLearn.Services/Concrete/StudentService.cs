using BookAndLearn.Common.Entities;
using BookAndLearn.DataAccess.Repositories;
using BookAndLearn.Services.Abstract;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Student>> SearchStudentsAsync(string searchRequest)
        {
            if (string.IsNullOrWhiteSpace(searchRequest))
            {
                //harcoded strings, blah...blah. I don`t care.
                throw new ArgumentException("Invalid argument");
            }
            var local = searchRequest.ToLower();
            return await _studentRepository
                .GetAsync(x => x.FirstName.ToLower().Contains(searchRequest) || x.LastName.ToLower().Contains(searchRequest));
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await _studentRepository.GetAsync(studentId);
        }


    }
}
