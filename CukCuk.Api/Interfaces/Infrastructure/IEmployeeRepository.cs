using CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CukCuk.Core.Interfaces.Infrastructure
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Lấy tất cả nhân viên
        /// </summary>
        /// <returns>IEnumerable<Employee></returns>
        /// Created By nlanh(7/11/2023)
        IEnumerable<Employee> GetAll();
        /// <summary>
        /// Lấy nhân viên theo ID
        /// </summary>
        /// <param name="employeeId">mã nhân viên</param>
        /// <returns>Employee</returns>
        /// Created By nlanh(7/11/2023)
        Employee GetById(Guid employeeId);
        /// <summary>
        /// Thêm 1 nhân viên vào DB
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Row Effeted</returns>
        /// Created By nlanh(7/11/2023)
        int Insert(Employee employee);
        /// <summary>
        /// Cập nhật 1 nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        int Update(Employee employee, Guid employeeId);
        /// <summary>
        /// Xóa 1 nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Row Effeted</returns>
        /// Created By nlanh(7/11/2023)
        int Delete(Guid employeeId);
        IEnumerable<Employee> GetPaging(int pageSize, int pageIndex);
        /// <summary>
        /// Kiểm tra xem mã nhân viên có trùng không
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        bool CheckDuplicateCode(string employeeCode);

        /// <summary>
        /// Kiêm tra xem id có tồn tại không
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        bool isIdExist(Guid employeeId);
    }
}
