using System.Threading.Tasks;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess;

namespace ItAcademy.SchoolAdmin.BusinessLogic.SignalR
{
    public class SubjectContextModificationNotifyingServiceDecorator : CommonServiceContextModificationNotifyingDecorator<Subject, ISubjectService>, ISubjectService
    {
        public const string MethodName = "subjectListModified";

        private readonly IMapper _mapper;

        private readonly ISubjectService _sbjService;

        private bool _disposedValue = false;

        public SubjectContextModificationNotifyingServiceDecorator(
            ISubjectService sbjService,
            IMapper mapper,
            SchoolContext context,
            ISchoolHub hub)
            : base(sbjService, context, hub, MethodName)
        {
            _mapper = mapper;
            _sbjService = sbjService;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public Task<bool> FindByName(string name)
        {
            return _sbjService.FindByName(name);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _sbjService.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
