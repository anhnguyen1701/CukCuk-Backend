﻿using CukCuk.Core.Entities;
using CukCuk.Core.Interfaces.Infrastructure;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CukCuk.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;
        private readonly MySqlConnection _conn;
        public EmployeeRepository()
        {
            this._connectionString = "Host=18.179.16.166;" +
                " Port=3306;" +
                " Database = WEB081_MF1790_NLAnh;" +
                " User Id = nvmanh; " +
                "Password = 12345678";
            this._conn = new MySqlConnection(this._connectionString);
        }

        public IEnumerable<Employee> GetAll()
        {
            var sql = "SELECT * FROM Employee";
            var result = _conn.Query<Employee>(sql);
            return result.ToList();
        }

        public Employee? GetById(Guid employeeId)
        {

            var sql = $"SELECT * FROM Employee WHERE EmployeeId = '{employeeId}'";
            var result = _conn.QuerySingleOrDefault<Employee>(sql);

            return result;
        }


        public int Insert(Employee employee)
        {
            var sql = $"INSERT INTO Employee(EmployeeId, EmployeeCode, FullName) VALUES (@EmployeeId, @EmployeeCode, @FullName)";
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeId", employee.EmployeeId);
            param.Add("@EmployeeCode", employee.EmployeeCode);
            param.Add("@FullName", employee.FullName);

            var res = _conn.Execute(sql, param: param);

            return res;
        }

        public IEnumerable<Employee> GetPaging(int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
        }


        public int Update(Employee employee, Guid employeeId)
        {
            var sql = $"UPDATE Employee SET EmployeeCode = @EmployeeCode, FullName = @Fullname WHERE EmployeeId = '{employeeId}'";
            var result = _conn.Execute(sql, employee);

            return result;
        }

        public int Delete(Guid employeeId)
        {
            var sql = $"DELETE FROM Employee WHERE EmployeeId = '{employeeId}'";
            var result = _conn.Execute(sql);

            return result;
        }

        public bool CheckDuplicateCode(string employeeCode)
        {
            var sql = $"SELECT EmployeeCode FROM Employee WHERE EmployeeCode = '{employeeCode}'";
            var result = _conn.QueryFirstOrDefault<Employee>(sql);

            return result != null;

        }

        public bool isIdExist(Guid employeeId)
        {
            var sql = $"SELECT EmployeeId FROM Employee WHERE EmployeeId = '{employeeId}'";
            var result = _conn.QuerySingleOrDefault<object>(sql);

            return result != null;
        }
    }
}
