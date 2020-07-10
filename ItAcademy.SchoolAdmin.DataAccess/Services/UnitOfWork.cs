namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    using System;
    using System.Threading.Tasks;
    using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
    using ItAcademy.SchoolAdmin.DataAccess.Models;

    public class UnitOfWork : IUnitOfWork
    {
        private EmployeeDbRepository _empRepository;
        private SubjectDbRepository _sbjRepository;
        private PositionDbRepository _posRepository;

        private bool _disposedValue = false;

        public UnitOfWork()
        {
            Db = new SchoolContext();
        }

        public UnitOfWork(SchoolContext context)
        {
            Db = context;
        }

        ////public UnitOfWork(IRepository<EmployeeDb> empRepo)
        ////{
        ////    Db = new SchoolContext();
        ////}

        public SchoolContext Db { get; }

        public virtual IRepository<EmployeeDb> Employees => _empRepository ?? (_empRepository = new EmployeeDbRepository(Db));

        public virtual IRepository<SubjectDb> Subjects => _sbjRepository ?? (_sbjRepository = new SubjectDbRepository(Db));

        public virtual IRepository<PositionDb> Positions => _posRepository ?? (_posRepository = new PositionDbRepository(Db));

        public virtual void Save()
        {
            Db.SaveChanges();
        }

        public virtual async Task SaveAsync()
        {
            await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Db.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
