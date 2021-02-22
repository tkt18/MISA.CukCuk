using MISA.CukCuk.Common.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Interfaces
{
    /// <summary>
    /// Base interface
    /// </summary>
    /// CreateBy: TKTHIEN (20/02/2021)
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy danh sách các thực thể
        /// </summary>
        /// <returns>ActionResult có Data là danh sách các thưc thể lấy được</returns>
        public ActionResult GetEntities();
        
        /// <summary>
        /// Thêm thực thể mới
        /// </summary>
        /// <param name="entity">Thực thể mới</param>
        /// <returns>ActionResult</returns>
        public ActionResult InsertEntity(TEntity entity);
        /// <summary>
        /// Sửa thực thể
        /// </summary>
        /// <param name="id">Khóa chính của bản ghi chứa thông tin thực thể trong csdl</param>
        /// <param name="entity">Thực thể mới</param>
        /// <returns>ActionResult</returns>
        public ActionResult UpdateEntity(Guid id,TEntity entity);
        /// <summary>
        /// Xóa thực thể
        /// </summary>
        /// <param name="id">Khóa chính của bản ghi chứa thông tin thực thể trong csdl</param>
        /// <returns>ActionResult</returns>
        public ActionResult DeleteEntity(Guid id);
        
    }
}
