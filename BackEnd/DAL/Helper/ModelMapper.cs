using DAL.Models;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
    public static class ModelMapper
    {
        public static Employee ToEntity(this EmployeeVM empDto )
        {
            return new Employee
            {
                Id = empDto.Id,
                Name = empDto.Name,
                Address = empDto.Address,
                Email = empDto.Email,
                Phone = empDto.Phone
            };
        }

        public static EmployeeVM ToViewModel(this Employee empEntity)
        {
            return new EmployeeVM
            {
              
                Name = empEntity.Name,
                Address = empEntity.Address,
                Email = empEntity.Email,
                Phone = empEntity.Phone
            };
        }
    }
}
