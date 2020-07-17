using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.BusinessLogic.Services;
using ItAcademy.SchoolAdmin.DataAccess;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.DataAccess.Services;
using ItAcademy.SchoolAdmin.Tests.Providers;
using Moq;
using NUnit.Framework;

namespace ItAcademy.SchoolAdmin.Tests.Employees
{
    [TestFixture]
    public class EmployeesAPITest
    {
        private IMapper _mapper;
        private IQueryable<EmployeeDb> _employees;
        private Mock<SchoolContext> _mockContext;
        private Mock<DbSet<EmployeeDb>> _mockSet;
        private Mock<UnitOfWork> _mockUow;
        private Mock<EmployeeDbRepository> _mockRepo;

        [OneTimeSetUp]
        public void Setup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutoMapperBusinessModule());
            var container = builder.Build();
            _mapper = container.Resolve<IMapper>();
        }

        [SetUp]
        public void SetupMocks()
        {
            _employees = new List<EmployeeDb>()
            {
                new EmployeeDb
                {
                    Id = "123",
                },
                new EmployeeDb
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Ivan"
                },
                new EmployeeDb
                {
                    Id = Guid.NewGuid().ToString(),
                },
                new EmployeeDb
                {
                    Id = Guid.NewGuid().ToString(),
                },
            }.AsQueryable();

            _mockSet = new Mock<DbSet<EmployeeDb>>();
            _mockSet.As<IDbAsyncEnumerable<EmployeeDb>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<EmployeeDb>(_employees.GetEnumerator()));
            _mockSet.As<IQueryable<EmployeeDb>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<EmployeeDb>(_employees.Provider));
            _mockSet.As<IQueryable<EmployeeDb>>().Setup(m => m.Expression).Returns(_employees.Expression);
            _mockSet.As<IQueryable<EmployeeDb>>().Setup(m => m.ElementType).Returns(_employees.ElementType);
            _mockSet.As<IQueryable<EmployeeDb>>().Setup(m => m.GetEnumerator()).Returns(_employees.GetEnumerator());

            _mockContext = new Mock<SchoolContext>();
            _mockContext.Setup(x => x.Employees).Returns(_mockSet.Object);

            _mockRepo = new Mock<EmployeeDbRepository>(_mockContext.Object, _mockSet.Object);
            _mockRepo.Setup(x => x.GetAllWithPhonesSubjectsAndPositionsSorted())
                .Returns(Task.FromResult(_employees.AsEnumerable()));

            _mockUow = new Mock<UnitOfWork>();
            _mockUow.Setup(x => x.Employees).Returns(_mockRepo.Object);
        }

        [Test]
        [Category("Employee")]
        public async Task ShouldGetAllEmployeesAsync()
        {
            // Arrage
            var service = new EmployeeService(_mockUow.Object, _mapper, _mockRepo.Object);

            // Act
            var q = await service.GetAllWithPhonesSubjectsAndPositionsSorted();

            // Assert
            _mockRepo.Verify(m => m.GetAllWithPhonesSubjectsAndPositionsSorted(), Times.Once());
        }
    }
}
