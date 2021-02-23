using Dapper;
using MISA.CukCuk.Common.EntityModels;
using MISA.CukCuk.Common.Enumeration;
using MISA.CukCuk.Common.Util;
using MISA.CukCuk.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MISA.CukCuk.Infrastructure.Repositories
{
    public class EmployeeRepository : DbContext<Employee>, IEmployeeRepository
    {
        #region Constructor
        public EmployeeRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        #endregion
        #region Method
        public Guid? GetByProp(string propName, string propValue)
        {
            var procName = Util.GenerateProcedureName<Employee>(TypeName.GetByProp);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("column", propName);
            parameters.Add("value", propValue);
            Guid? id = _dbConnection.Query<Guid?>(procName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return id;
        }
        public Employee GetById(Guid id)
        {
            var procName = Util.GenerateProcedureName<Employee>(TypeName.GetById);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(typeof(Employee).GetProperties().First().Name, id);
            var employee = _dbConnection.Query<Employee>(procName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return employee;
        }
        public string GetNewEntityCode()
        {
            var procName = Util.GenerateProcedureName<Employee>(TypeName.GetEntityCode);
            var entities = _dbConnection.Query<string>(procName, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entities;
        }

        public IEnumerable<Employee> GetByStatus(int status)
        {
            var procName = Util.GenerateProcedureName<Employee>(TypeName.GetByStatus);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Status", status);
            var employees = _dbConnection.Query<Employee>(procName, parameters, commandType: CommandType.StoredProcedure).ToList();
            return employees;
        }
        #endregion
    }
}
