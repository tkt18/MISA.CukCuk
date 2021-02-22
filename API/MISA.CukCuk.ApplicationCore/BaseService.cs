using MISA.CukCuk.ApplicationCore.Interfaces;
using MISA.CukCuk.Common.Enumeration;
using MISA.CukCuk.Common.Other;
using MISA.CukCuk.Infrastructure;
using MISA.CukCuk.Infrastructure.Interfaces;
using System;

namespace MISA.CukCuk.ApplicationCore
{
    /// <summary>
    /// Lớp cơ sở xử lý nghiệp vụ 
    /// </summary>
    /// <typeparam name="TEntity">Kiểu thực thể</typeparam>
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        #region Declare
        /// <summary>
        /// Đối tượng giao tiếp với CSDL
        /// </summary>
        private readonly IDbContext<TEntity> _dbContext;
        #endregion
        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="dbContext"></param>
        public BaseService(IDbContext<TEntity> dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
        #region Method
        /// <summary>
        /// Lấy danh sách tất cả thực thể
        /// </summary>
        /// <returns></returns>
        public ActionResult GetEntities()
        {
            var _actionResult = new ActionResult();
            _actionResult.Data = new { entities = _dbContext.GetAll() };
            return _actionResult;
        }

        /// <summary>
        /// Thêm mới thực thể
        /// </summary>
        /// <param name="entity">Đối tượng thực thể</param>
        /// <returns></returns>
        public ActionResult InsertEntity(TEntity entity)
        {
            // Kiểm tra dữ liệu vào
            var _actionResult = ValidateData(entity, TypeName.Insert);
            int insertedRows = _actionResult.Success ? _dbContext.Insert(entity) : 0;
            _actionResult.Data = new { insertedRows };
            return _actionResult;
        }

        /// <summary>
        /// Cập nhật thực thể
        /// </summary>
        /// <param name="id">Khóa chính của thực thể trong CSDL</param>
        /// <param name="entity">Đối tượng thực thể</param>
        /// <returns></returns>
        public ActionResult UpdateEntity(Guid id, TEntity entity)
        {
            var _actionResult = ValidateData(entity, TypeName.Update, id);
            int updatedRows = _actionResult.Success ? _dbContext.Update(id, entity) : 0;
            _actionResult.Data = new { updatedRows };
            return _actionResult;
        }
        /// <summary>
        /// Xóa thực thể
        /// </summary>
        /// <param name="id">Khóa chính của thực thể trong csdl</param>
        /// <returns></returns>
        public ActionResult DeleteEntity(Guid id)
        {
            var _actionResult = new ActionResult();
            int deletedRows = _actionResult.Success ? _dbContext.Delete(id) : 0;
            _actionResult.Data = new { deletedRows };
            return _actionResult;
        }
        /// <summary>
        /// Kiểm tra dữ liệu trước khi cất
        /// </summary>
        protected virtual ActionResult ValidateData(TEntity entity, TypeName typeName, Guid? entityId = null)
        {

            return new ActionResult();
        }
        #endregion
    }
}
