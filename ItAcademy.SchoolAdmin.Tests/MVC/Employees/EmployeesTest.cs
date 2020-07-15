////using System;
////using System.Collections.Generic;
////using System.Data.Entity;
////using System.Data.Entity.Infrastructure;
////using System.Linq;
////using System.Threading.Tasks;
////using Autofac;
////using AutoMapper;
////using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
////using ItAcademy.SchoolAdmin.BusinessLogic.Models;
////using ItAcademy.SchoolAdmin.BusinessLogic.Services;
////using ItAcademy.SchoolAdmin.DataAccess;
////using ItAcademy.SchoolAdmin.DataAccess.Models;
////using ItAcademy.SchoolAdmin.DataAccess.Services;
////using ItAcademy.SchoolAdmin.Tests.Providers;
////using Moq;
////using NUnit.Framework;

////namespace ItAcademy.SchoolAdmin.Tests.Employees
////{
////    [TestFixture]
////    public class EmployeesTest
////    {
////        private IMapper _mapper;
////        private IQueryable<EmployeeDb> _employees;
////        private Mock<SchoolContext> _mockContext;
////        private Mock<DbSet<EmployeeDb>> _mockSet;
////        private Mock<UnitOfWork> _mockUow;
////        private Mock<EmployeeDbRepository> _mockRepo;

////        [OneTimeSetUp]
////        public void Setup()
////        {
////            ////var resolver = DependencyResolver.Current;
////            ////_mapper = resolver.GetService<IMapper>();

////            var builder = new ContainerBuilder();
////            ////builder.AddAutoMapper(typeof(MvcApplication).Assembly);
////            builder.RegisterModule(new AutoMapperBusinessModule());
////            ////builder.RegisterModule(new AutoMapperWebModule());
////            var container = builder.Build();
////            ////container.Resolve<MapperConfiguration>();
////            _mapper = container.Resolve<IMapper>();

////            ////var container = builder.Build();
////            ////var container = AutofacConfig.ConfigureContainer();
////            ////_mapper = container.< IMapper > ();
////        }

////        [SetUp]
////        public void SetupMocks()
////        {
////            _employees = new List<EmployeeDb>()
////            {
////                new EmployeeDb
////                {
////                    Id = "123",
////                },
////                new EmployeeDb
////                {
////                    Id = Guid.NewGuid().ToString(),
////                    Name = "Ivan"
////                },
////                new EmployeeDb
////                {
////                    Id = Guid.NewGuid().ToString(),
////                },
////                new EmployeeDb
////                {
////                    Id = Guid.NewGuid().ToString(),
////                },
////            }.AsQueryable();

////            _mockSet = new Mock<DbSet<EmployeeDb>>();
////            _mockSet.As<IDbAsyncEnumerable<EmployeeDb>>()
////                .Setup(m => m.GetAsyncEnumerator())
////                .Returns(new TestDbAsyncEnumerator<EmployeeDb>(_employees.GetEnumerator()));
////            _mockSet.As<IQueryable<EmployeeDb>>()
////                .Setup(m => m.Provider)
////                .Returns(new TestDbAsyncQueryProvider<EmployeeDb>(_employees.Provider));
////            _mockSet.As<IQueryable<EmployeeDb>>().Setup(m => m.Expression).Returns(_employees.Expression);
////            _mockSet.As<IQueryable<EmployeeDb>>().Setup(m => m.ElementType).Returns(_employees.ElementType);
////            _mockSet.As<IQueryable<EmployeeDb>>().Setup(m => m.GetEnumerator()).Returns(_employees.GetEnumerator());

////            _mockContext = new Mock<SchoolContext>();
////            _mockContext.Setup(x => x.Employees).Returns(_mockSet.Object);

////            _mockRepo = new Mock<EmployeeDbRepository>(_mockContext.Object, _mockSet.Object);

////            _mockUow = new Mock<UnitOfWork>();
////            _mockUow.Setup(x => x.Employees).Returns(_mockRepo.Object);
////        }

////        [Test]
////        [Category("Employee")]
////        public async Task ShouldAddEmployee()
////        {
////            // Arrage
////            var service = new EmployeeService(_mockUow.Object, _mapper);

////            // Act
////            var b = new Employee
////            {
////                Name = "Petr",
////            };
////            await service.AddAsync(b);

////            // Assert
////            _mockUow.Verify(m => m.SaveAsync(), Times.Once());
////        }

////        [Test]
////        [Category("Employee")]
////        public async Task ShouldGetAllEmployeesAsync()
////        {
////            // Arrage
////            var service = new EmployeeService(_mockUow.Object, _mapper);

////            // Act
////            var q = await service.GetAllAsync();

////            // Assert
////            _mockUow.Verify(m => m.Employees.GetAllAsync(), Times.Once());
////        }

////        [Test]
////        [Category("Employee")]
////        public async Task ShouldGetEmployeeByIdAsync()
////        {
////            // Arrage
////            var service = new EmployeeService(_mockUow.Object, _mapper);

////            // Act
////            var x = await service.GetByIdAsync("123");

////            // Assert
////            ////Assert.AreEqual(x.Id, "123");
////            _mockUow.Verify(m => m.Employees.GetByIdAsync(It.IsAny<string>()), Times.Once());
////        }

////        [Test]
////        [Category("Employee")]
////        public async Task ShouldDeleteEmployeeById()
////        {
////            // Arrage
////            var service = new EmployeeService(_mockUow.Object, _mapper);

////            // Act
////            await service.RemoveByIdAsync("123");

////            // Assert
////            _mockSet.Verify(m => m.Remove(It.IsAny<EmployeeDb>()), Times.Once());
////        }

////        [Test]
////        [Category("Employee")]
////        public async Task ShouldReturnEmployeeByQuery()
////        {
////            // Arrage
////            var service = new EmployeeService(_mockUow.Object, _mapper);

////            // Act
////            var result = await service.SearchAsync("Ivan");

////            // Assert
////            _mockRepo.Verify(m => m.SearchAsync(It.IsAny<string>()), Times.Once());
////        }
////    }
////}
