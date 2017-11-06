using BookAndLearn.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndLearn.Services.Abstract
{
    public interface ILessonsService
    {
        Task<IEnumerable<Lesson>> GetLessonsAsync();
        Task<IEnumerable<Lesson>> GetLessonsByDayAsync(DayOfWeek dayOfWeek);
        Task<IEnumerable<Lesson>> GetLessonsByGroupAsync(int groupId);
        Task<IEnumerable<Lesson>> GetLessonsByGroupAndDayOfWeekAsync(int groupId, DayOfWeek dayOfWeek);
    }
}
