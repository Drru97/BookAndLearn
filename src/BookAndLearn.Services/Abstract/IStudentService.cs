﻿using BookAndLearn.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAndLearn.Services.Abstract
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudentsByGroupAsync(int groupId);
        Task<IEnumerable<Student>> SearchStudentsAsync(string searchRequest);
        Task<Student> GetStudentById(int studentId);
    }
}
