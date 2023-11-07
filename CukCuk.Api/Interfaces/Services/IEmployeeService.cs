using CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CukCuk.Core.Interfaces.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// them moi du lieu
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        int InsertService(Employee employee);
        /// <summary>
        /// sua
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        int UpdateService(Guid employeeId, Employee employee);
    }
}
