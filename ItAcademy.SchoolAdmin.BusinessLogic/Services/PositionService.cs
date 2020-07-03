using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Services
{
    public class PositionService : IPositionService
    {
        private readonly IMapper _mapper;

        private bool _disposedValue = false;

        private IUnitOfWork _uow;

        public PositionService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Result Add(Position pos)
        {
            _uow.Positions.Create(_mapper.Map<Position, PositionDb>(pos));
            return _uow.Positions.Save();
        }

        public async Task AddAsync(Position pos)
        {
            _uow.Positions.Create(_mapper.Map<Position, PositionDb>(pos));
            await _uow.SaveAsync();
        }

        public async Task<bool> FindByName(string name)
        {
            return await _uow.Positions.FindByName(name);
        }

        public IEnumerable<Position> GetAll()
        {
            var positions = _uow.Positions.GetAll();
            return _mapper.Map<IEnumerable<PositionDb>, IEnumerable<Position>>(positions);
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            var positions = await _uow.Positions.GetAllAsync();
            return _mapper.Map<IEnumerable<PositionDb>, IEnumerable<Position>>(positions);
        }

        public async Task<Position> GetByIdAsync(string id)
        {
            var positions = await _uow.Positions.GetByIdAsync(id);
            return _mapper.Map<PositionDb, Position>(positions);
        }

        public async Task RemoveByIdAsync(string id)
        {
            await _uow.Positions.DeleteAsync(id);
            _uow.Positions.Save();
        }

        public async Task<IEnumerable<Position>> SearchAsync(string query)
        {
            var positions = await _uow.Positions.SearchAsync(query);
            return _mapper.Map<IEnumerable<PositionDb>, IEnumerable<Position>>(positions);
        }

        public async Task UpdateAsync(Position pos)
        {
            var position = _mapper.Map<Position, PositionDb>(pos);
            await _uow.Positions.UpdateAsync(position);
            _uow.Positions.Save();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _uow.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
