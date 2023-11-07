using CukCuk.Core.Entities;
using CukCuk.Core.Exceptions;
using CukCuk.Core.Interfaces.Infrastructure;
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
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


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

            var isDuplicate = _employeeRepository.CheckDuplicateCode(employee.EmployeeCode);
            if (isDuplicate)
            {
                throw new EmployeeValidException("Mã nhân viên không được trùng!");
            }

            //add to database
            var res = _employeeRepository.Insert(employee);
            return res;
        }

        public int UpdateService(Guid employeeId, Employee employee)
        {
            // validate
            var isId = _employeeRepository.isIdExist(employeeId);
            if (!isId)
            {
                throw new EmployeeValidException("Id không tồn tại");
            }

            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                throw new EmployeeValidException("Mã nhân viên không được để trống!");
            }
            else if (string.IsNullOrEmpty(employee.FullName))
            {
                throw new EmployeeValidException("Tên nhân viên không được để trống!");
            }

            //add to database
            var res = _employeeRepository.Update(employee, employeeId);
            return res;
        }

        public int DeleteService(Guid employeeId)
        {
            // validate
            var isId = _employeeRepository.isIdExist(employeeId);
            if (!isId)
            {
                throw new EmployeeValidException("Id không tồn tại");
            }

            //query
            var res = _employeeRepository.Delete(employeeId);
            return res;
        }

    }
}
