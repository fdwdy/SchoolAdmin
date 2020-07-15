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

namespace ItAcademy.SchoolAdmin.Tests.Subjects
{
    [TestFixture]
    public class SubjectsTest
    {
        private IMapper _mapper;
        private IQueryable<SubjectDb> _subjects;
        private Mock<SchoolContext> _mockContext;
        private Mock<DbSet<SubjectDb>> _mockSet;
        private Mock<UnitOfWork> _mockUow;
        private Mock<SubjectDbRepository> _mockRepo;

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
            _subjects = new List<SubjectDb>()
            {
                new SubjectDb
                {
                    Id = "123",
                },
                new SubjectDb
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Subject"
                },
                new SubjectDb
                {
                    Id = Guid.NewGuid().ToString(),
                },
                new SubjectDb
                {
                    Id = Guid.NewGuid().ToString(),
                },
            }.AsQueryable();

            _mockSet = new Mock<DbSet<SubjectDb>>();
            _mockSet.As<IDbAsyncEnumerable<SubjectDb>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<SubjectDb>(_subjects.GetEnumerator()));
            _mockSet.As<IQueryable<SubjectDb>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<SubjectDb>(_subjects.Provider));
            _mockSet.As<IQueryable<SubjectDb>>().Setup(m => m.Expression).Returns(_subjects.Expression);
            _mockSet.As<IQueryable<SubjectDb>>().Setup(m => m.ElementType).Returns(_subjects.ElementType);
            _mockSet.As<IQueryable<SubjectDb>>().Setup(m => m.GetEnumerator()).Returns(_subjects.GetEnumerator());

            _mockContext = new Mock<SchoolContext>();
            _mockContext.Setup(x => x.Subjects).Returns(_mockSet.Object);

            _mockRepo = new Mock<SubjectDbRepository>(_mockContext.Object, _mockSet.Object);

            _mockUow = new Mock<UnitOfWork>();
            _mockUow.Setup(x => x.Subjects).Returns(_mockRepo.Object);
        }

        [Test]
        [Category("Subject")]
        public async Task ShouldAddSubject()
        {
            // Arrage
            var service = new SubjectService(_mockUow.Object, _mapper);

            // Act
            var b = new Subject
            {
                Name = "Subject",
            };

            await service.AddAsync(b);

            // Assert
            _mockUow.Verify(m => m.SaveAsync(), Times.Once());
        }

        [Test]
        [Category("Subject")]
        public async Task ShouldGetAllSubjectsAsync()
        {
            // Arrage
            var service = new SubjectService(_mockUow.Object, _mapper);

            // Act
            var q = await service.GetAllAsync();

            // Assert
            _mockUow.Verify(m => m.Subjects.GetAllAsync(), Times.Once());
        }

        [Test]
        [Category("Subject")]
        public async Task ShouldGetSubjectByIdAsync()
        {
            // Arrage
            var service = new SubjectService(_mockUow.Object, _mapper);

            // Act
            var x = await service.GetByIdAsync("123");

            // Assert
            _mockUow.Verify(m => m.Subjects.GetByIdAsync(It.IsAny<string>()), Times.Once());
        }

        [Test]
        [Category("Subject")]
        public async Task ShouldDeleteSubjectById()
        {
            // Arrage
            var service = new SubjectService(_mockUow.Object, _mapper);

            // Act
            await service.RemoveByIdAsync("123");

            // Assert
            _mockSet.Verify(m => m.Remove(It.IsAny<SubjectDb>()), Times.Once());
        }

        [Test]
        [Category("Subject")]
        public async Task ShouldReturnSubjectByQuery()
        {
            // Arrage
            var service = new SubjectService(_mockUow.Object, _mapper);

            // Act
            var result = await service.SearchAsync("Subject");

            // Assert
            _mockRepo.Verify(m => m.SearchAsync(It.IsAny<string>()), Times.Once());
        }
    }
}
