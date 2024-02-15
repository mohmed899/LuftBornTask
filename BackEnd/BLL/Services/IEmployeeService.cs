using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetAllEmplyees();
        Employee CreateEmployee(Employee entity);
        Employee UpdateEmployee(int id, Employee entity);
        void DeleteEmployee(int id);

        bool IsExist(Expression<Func<Employee, bool>> predicate);
    }
}
