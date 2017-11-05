using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Moq;
using BookAndLearn.Common.Entities;
using BookAndLearn.DataAccess.Repositories;
using System.Collections.Generic;
using BookAndLearn.Services.Concrete;
using System.Linq;

namespace BookAndLearn.Tests
{
    // Don`t give a fuck why i`m start writing this.
    [TestClass]
    public class LessonsServiceTests
    {
        [TestMethod]
        public async Task GetLessons_Test()
        {
            var mock = new Mock<IRepository<Lesson>>();

            var lessons = new List<Lesson>
            {
                new Lesson{ Id = 1 },
                new Lesson{ Id = 2 }
            };

            mock.Setup(foo => foo.GetAllAsync()).ReturnsAsync(() => lessons);

            var obj = mock.Object;
            var service = new LessonsService(obj);
            var mockResult = await service.GetLessonsAsync();

            Assert.AreEqual(lessons, mockResult);
        }

        [TestMethod]
        public async Task GetLessonsByGroup_Test()
        {
            var mock = new Mock<IRepository<Lesson>>();

            int groupId = 2;
            var lessons = new List<Lesson>
            {
                new Lesson{Id = 1, LessonGroups = new List<LessonGroup>{ new LessonGroup { GroupId = groupId } } }
            };

            mock.Setup(foo => foo.GetAsync(x => x.LessonGroups.Any(y => y.GroupId == groupId)))
                .ReturnsAsync(() => lessons);

            var obj = mock.Object;
            var service = new LessonsService(obj);
            var mockResult = await service.GetLessonsByGroupAsync(groupId);

            Assert.AreEqual(groupId, lessons.First().LessonGroups.First().GroupId);
        }
    }
}
