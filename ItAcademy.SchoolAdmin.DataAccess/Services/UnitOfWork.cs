namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    using System;
    using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
    using ItAcademy.SchoolAdmin.DataAccess.Models;

    public class UnitOfWork : IUnitOfWork
    {
        private EmployeeDbRepository _empRepository;
        private SubjectDbRepository _sbjRepository;

        private bool _disposedValue = false;

        public UnitOfWork()
        {
            Db = new SchoolContext();
        }

        public UnitOfWork(SchoolContext context)
        {
            Db = context;
        }

        public SchoolContext Db { get; }

        public IRepository<EmployeeDb> Employees => _empRepository ?? (_empRepository = new EmployeeDbRepository(Db));

        public IRepository<SubjectDb> Subjects => _sbjRepository ?? (_sbjRepository = new SubjectDbRepository(Db));

        public void Save()
        {
            Db.SaveChanges();
        }

        public async void SaveAsync()
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
