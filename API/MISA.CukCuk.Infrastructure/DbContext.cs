using Dapper;
using MISA.CukCuk.Common.Util;
using MISA.CukCuk.Common.Enumeration;
using MISA.CukCuk.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MISA.CukCuk.Infrastructure
{
    public class DbContext<TEntity> : IDbContext<TEntity>
    {
        #region Declare
        protected readonly IDbConnection _dbConnection;
        #endregion
        #region Constructor
        public DbContext(IDbConnection dbConnection){
            _dbConnection = dbConnection;
        }
        #endregion
        #region Method
        public IEnumerable<TEntity> GetAll()
        {
            var procName = Util.GenerateProcedureName<TEntity>(TypeName.Get);
            var entities = _dbConnection.Query<TEntity>(procName, commandType: CommandType.StoredProcedure).ToList();
            return entities;
        }
        public int Insert(TEntity entity)
        {
            string procName = Util.GenerateProcedureName<TEntity>(TypeName.Insert);
            // Lấy danh sách các thuộc tính của thực thể
            var properties = typeof(TEntity).GetProperties();
            
            DynamicParameters parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propValue = property.GetValue(entity);
                var propName = property.Name;
                parameters.Add(propName, propValue);
            }
            // Số bản ghi được thêm vào database
            int insertedRow = _dbConnection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);

            return insertedRow;
        }
        public int Update(Guid id, TEntity entity)
        {
            string procName = Util.GenerateProcedureName<TEntity>(TypeName.Update);
            // Lấy danh sách các thuộc tính của thực thể
            var properties = typeof(TEntity).GetProperties();
            DynamicParameters parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propValue = property.GetValue(entity);
                var propName = property.Name;
                parameters.Add(propName, propValue);
            }
            parameters.Add(Common.Properties.Resources.EntityId, id);
            // Số bản ghi được cập nhật 
            int updatedRow = _dbConnection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);

            return updatedRow;
        }
        public int Delete(Guid id)
        {
            var propName = typeof(TEntity).GetProperties().First().Name;
            var procName = Util.GenerateProcedureName<TEntity>(TypeName.Delete);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(propName, id);

            int deleted = _dbConnection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
            return deleted;
        }
        #endregion
    }
}
