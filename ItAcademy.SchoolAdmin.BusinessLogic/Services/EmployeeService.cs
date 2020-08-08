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
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;

        private readonly IEmployeeDbService _empDbService;

        private bool _disposedValue = false;

        private IUnitOfWork _uow;

        public EmployeeService(IUnitOfWork uow, IMapper mapper, IEmployeeDbService empDbService)
        {
            _uow = uow;
            _empDbService = empDbService;
            _mapper = mapper;
        }

        public Result Add(Employee emp)
        {
            _uow.Employees.Create(_mapper.Map<Employee, EmployeeDb>(emp));
            return _uow.Employees.Save();
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = _uow.Employees.GetAll();
            return _mapper.Map<IEnumerable<EmployeeDb>, IEnumerable<Employee>>(employees);
        }

        public async Task AddAsync(Employee emp)
        {
            _uow.Employees.Create(_mapper.Map<Employee, EmployeeDb>(emp));
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employees = await _uow.Employees.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDb>, IEnumerable<Employee>>(employees);
        }

        public async Task<Employee> GetByIdAsync(string id)
        {
            var employee = await _uow.Employees.GetByIdAsync(id);
            var emp = _mapper.Map<EmployeeDb, Employee>(employee);
            SetPrimaryPhone(emp);
            return emp;
        }

        public async Task RemoveByIdAsync(string id)
        {
            await _uow.Employees.DeleteAsync(id);
            _uow.Employees.Save();
        }

        public async Task UpdateAsync(Employee emp)
        {
            var empWithPhoneId = UpdateEmployeePhones(emp.Phones, emp);
            var employee = _mapper.Map<Employee, EmployeeDb>(empWithPhoneId);
            await _uow.Employees.UpdateAsync(employee);
            _uow.Employees.Save();
        }

        public async Task<IEnumerable<Employee>> SearchAsync(string query)
        {
            var employees = await _uow.Employees.SearchAsync(query);
            return _mapper.Map<IEnumerable<EmployeeDb>, IEnumerable<Employee>>(employees);
        }

        public async Task<IEnumerable<Employee>> GetAllWithPhonesSubjectsAndPositionsSorted()
        {
            var employees = await _empDbService.GetAllWithPhonesSubjectsAndPositionsSorted();
            return _mapper.Map<IEnumerable<EmployeeDb>, IEnumerable<Employee>>(employees);
        }

        public async Task<Employee> GetByNameSorted(string name)
        {
            var employee = await _empDbService.GetByNameSorted(name);
            return _mapper.Map<EmployeeDb, Employee>(employee);
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

        private Employee UpdateEmployeePhones(IEnumerable<Phone> newPhones, Employee employeeToUpdate)
        {
            if (newPhones == null)
            {
                employeeToUpdate.Phones = new List<Phone>();
            }

            foreach (var phone in employeeToUpdate.Phones)
            {
                phone.EmployeeId = employeeToUpdate.Id;
            }

            return employeeToUpdate;
        }

        private Employee SetPrimaryPhone(Employee emp)
        {
            if (emp.Phones != null && emp != null)
            {
                foreach (Phone ph in emp.Phones)
                {
                    if (ph.Id == emp.PrimaryPhoneId)
                    {
                        ph.IsPrimary = true;
                        break;
                    }
                }
            }

            return emp;
        }
    }
}
