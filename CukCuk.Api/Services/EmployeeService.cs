using CukCuk.Core.Entities;
using CukCuk.Core.Exceptions;
using CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CukCuk.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        public int InsertService(Employee employee)
        {
            // validate
            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                throw new EmployeeValidException("Mã nhân viên không được để trống!");
            }
            else if (string.IsNullOrEmpty(employee.FullName))
            {
                throw new EmployeeValidException("Tên nhân viên không được để trống!");
            }

            return 0;
        }

        public int UpdateService(Guid employeeId, Employee employee)
        {
            // validate
            return 0;
        }
    }
}
