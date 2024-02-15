using DAL.Models;
using DAL.Repositories;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee,int> _EmpRepo;
        public EmployeeService(IGenericRepository<Employee, int> repository) 
        {
            _EmpRepo = repository;
        }

        public Employee CreateEmployee(Employee entity)
        {
           var emp =  _EmpRepo.Create(entity);
            return emp;
        }

        public void DeleteEmployee(int id)
        {
            _EmpRepo.Delete(id);
        }

        public IQueryable<Employee> GetAllEmplyees()
        {
            return _EmpRepo.GetAll();
        }

        public bool IsExist(Expression<Func<Employee, bool>> predicate)
        {
            return _EmpRepo.IsExist(predicate);
        }

        public Employee UpdateEmployee(int id, Employee entity)
        {
            
            var emp = _EmpRepo.Update(id, entity);
            return emp;
        }
    }
}
