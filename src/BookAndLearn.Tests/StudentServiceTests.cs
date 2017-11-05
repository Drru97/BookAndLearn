using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using BookAndLearn.Common.Entities;
using Moq;
using BookAndLearn.DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq.Expressions;
using BookAndLearn.Services.Concrete;
using System.Linq;

namespace BookAndLearn.Tests
{
    [TestClass]
    public class StudentServiceTests
    {
        [TestMethod]
        public async Task GetStudentsByGroup_Success()
        {
            var mock = new Mock<IRepository<Student>>();

            int groupId = 1;

            var students = new List<Student>
            {
                new Student{ GroupId = groupId },
                new Student{ GroupId = groupId }
            };

            mock.Setup(foo => foo.GetAsync(It.IsAny<Expression<Func<Student, bool>>>()))
                .ReturnsAsync(() => students);

            var obj = mock.Object;
            var service = new StudentService(obj);
            var mockResult = await service.GetStudentsByGroupAsync(groupId);

            Assert.IsTrue(mockResult.All(x => x.GroupId == groupId));
        }

        [TestMethod]
        public async Task SearchStudent_Success()
        {
            var mock = new Mock<IRepository<Student>>();

            var searchString = "JaVa";

            var student = new Student { FirstName = "Java", LastName = "Man" }; //азазаза :)

            mock.Setup(foo => foo.GetAsync(It.IsAny<Expression<Func<Student, bool>>>()))
                .ReturnsAsync(() => new List<Student> { student });

            var obj = mock.Object;
            var service = new StudentService(obj);
            var mockResult = await service.SearchStudentsAsync(searchString);

            Assert.AreEqual(1, mockResult.Count());
        }
    }
}
