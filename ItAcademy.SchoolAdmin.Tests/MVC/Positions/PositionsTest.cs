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

namespace ItAcademy.SchoolAdmin.Tests.Positions
{
    [TestFixture]
    public class PositionsTest
    {
        private IMapper _mapper;
        private IQueryable<PositionDb> _positions;
        private Mock<SchoolContext> _mockContext;
        private Mock<DbSet<PositionDb>> _mockSet;
        private Mock<UnitOfWork> _mockUow;
        private Mock<PositionDbRepository> _mockRepo;

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
            _positions = new List<PositionDb>()
            {
                new PositionDb
                {
                    Id = "123",
                },
                new PositionDb
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Position"
                },
                new PositionDb
                {
                    Id = Guid.NewGuid().ToString(),
                },
                new PositionDb
                {
                    Id = Guid.NewGuid().ToString(),
                },
            }.AsQueryable();

            _mockSet = new Mock<DbSet<PositionDb>>();
            _mockSet.As<IDbAsyncEnumerable<PositionDb>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<PositionDb>(_positions.GetEnumerator()));
            _mockSet.As<IQueryable<PositionDb>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<PositionDb>(_positions.Provider));
            _mockSet.As<IQueryable<PositionDb>>().Setup(m => m.Expression).Returns(_positions.Expression);
            _mockSet.As<IQueryable<PositionDb>>().Setup(m => m.ElementType).Returns(_positions.ElementType);
            _mockSet.As<IQueryable<PositionDb>>().Setup(m => m.GetEnumerator()).Returns(_positions.GetEnumerator());

            _mockContext = new Mock<SchoolContext>();
            _mockContext.Setup(x => x.Positions).Returns(_mockSet.Object);

            _mockRepo = new Mock<PositionDbRepository>(_mockContext.Object, _mockSet.Object);
            _mockRepo.Setup(x => x.GetAll()).Returns(_positions);

            _mockUow = new Mock<UnitOfWork>();
            _mockUow.Setup(x => x.Positions).Returns(_mockRepo.Object);
        }

        [Test]
        [Category("Position")]
        public async Task ShouldAddPosition()
        {
            // Arrage
            var service = new PositionService(_mockUow.Object, _mapper, _mockRepo.Object);

            // Act
            var b = new Position
            {
                Name = "Position",
            };

            await service.AddAsync(b);

            // Assert
            _mockUow.Verify(m => m.SaveAsync(), Times.Once());
        }

        [Test]
        [Category("Position")]
        public async Task ShouldGetAllPositionsAsync()
        {
            // Arrage
            var service = new PositionService(_mockUow.Object, _mapper, _mockRepo.Object);

            // Act
            var q = await service.GetAllAsync();

            // Assert
            _mockUow.Verify(m => m.Positions.GetAllAsync(), Times.Once());
        }

        [Test]
        [Category("Position")]
        public async Task ShouldGetPositionByIdAsync()
        {
            // Arrage
            var service = new PositionService(_mockUow.Object, _mapper, _mockRepo.Object);

            // Act
            var x = await service.GetByIdAsync("123");

            // Assert
            _mockRepo.Verify(m => m.GetByIdAsync(It.IsAny<string>()), Times.Once());
        }

        [Test]
        [Category("Position")]
        public async Task ShouldDeletePositionById()
        {
            // Arrage
            var service = new PositionService(_mockUow.Object, _mapper, _mockRepo.Object);

            // Act
            await service.RemoveByIdAsync("123");

            // Assert
            _mockSet.Verify(m => m.Remove(It.IsAny<PositionDb>()), Times.Once());
        }

        [Test]
        [Category("Position")]
        public async Task ShouldReturnPositionByQuery()
        {
            // Arrage
            var service = new PositionService(_mockUow.Object, _mapper, _mockRepo.Object);

            // Act
            var result = await service.SearchAsync("Position");

            // Assert
            _mockRepo.Verify(m => m.SearchAsync(It.IsAny<string>()), Times.Once());
        }
    }
}
