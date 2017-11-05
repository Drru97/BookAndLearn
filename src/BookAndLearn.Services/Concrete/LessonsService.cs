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
    public class LessonsService: ILessonsService
    {
        private readonly IRepository<Lesson> _lessonRepository;

        public LessonsService(IRepository<Lesson> lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<IEnumerable<Lesson>> GetLessonsAsync()
        {
            return await _lessonRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Lesson>> GetLessonsByDayAsync(DayOfWeek dayOfWeek)
        {
            return await _lessonRepository.GetAsync(x => x.SubjectDay.DayOfWeek == (int)dayOfWeek);
        }

        public async Task<IEnumerable<Lesson>> GetLessonsByGroupAsync(int groupId)
        {
            return await _lessonRepository.GetAsync(x => x.LessonGroups.Any(y => y.GroupId == groupId));
        }

        public async Task<IEnumerable<Lesson>> GetLessonsByGroupAndDayOfWeekAsync(int groupId, DayOfWeek dayOfWeek)
        {
            return (await GetLessonsByGroupAsync(groupId)).Where(x => x.SubjectDay.DayOfWeek == (int)dayOfWeek);
        }
    }
}
