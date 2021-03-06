﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.SignalR
{
    public abstract class CommonServiceContextModificationNotifyingDecorator<TEntity, TDecoratedService> : ICommonService<TEntity>
        where TEntity : class
        where TDecoratedService : ICommonService<TEntity>
    {
        private readonly TDecoratedService _decoratedService;
        private readonly SchoolContext _context;
        private readonly ISchoolHub _hub;

        public CommonServiceContextModificationNotifyingDecorator(
            TDecoratedService decoratedService,
            SchoolContext context,
            ISchoolHub hub,
            string methodName)
        {
            _decoratedService = decoratedService;
            _context = context;
            _hub = hub;
            _hub.Initialize(methodName);
        }

        public Result Add(TEntity entity)
        {
            var result = _decoratedService.Add(entity);
            NotifyOnListModified();
            return result;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _decoratedService.AddAsync(entity);
            NotifyOnListModified();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _decoratedService.GetAll();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return _decoratedService.GetAllAsync();
        }

        public Task<TEntity> GetByIdAsync(string id)
        {
            return _decoratedService.GetByIdAsync(id);
        }

        public async Task RemoveByIdAsync(string id)
        {
            await _decoratedService.RemoveByIdAsync(id);
            NotifyOnListModified();
        }

        public async Task<IEnumerable<TEntity>> SearchAsync(string query)
        {
            return await _decoratedService.SearchAsync(query);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _decoratedService.UpdateAsync(entity);
            NotifyOnListModified();
        }

        protected virtual void NotifyOnListModified()
        {
            var currentEntities = _decoratedService.GetAll();
            _hub.NotifyAll(new object[] { currentEntities,  });
        }

        protected virtual IEnumerable<object> MapEntities(IEnumerable<TEntity> entities)
        {
            return entities;
        }
    }
}
