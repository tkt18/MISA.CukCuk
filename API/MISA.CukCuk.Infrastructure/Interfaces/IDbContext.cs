using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Infrastructure.Interfaces
{
    /// <summary>
    /// Giao diện lớp giao tiếp với database
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDbContext<TEntity>
    {
        /// <summary>
        /// Lấy danh sách các thực thể
        /// </summary>
        /// <returns>Danh sách các bản ghi chứa thông tin thực thể</returns>
        public IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Thêm thông tin của thực thể mới vào cơ sở dữ liệu
        /// </summary>
        /// <param name="entity">Thực thể cần thêm mới</param>
        /// <returns>Số bản ghi thêm mới vào cơ sở dữ liệu</returns>
        public int Insert(TEntity entity);
        /// <summary>
        /// Sửa một bản ghi có trong cơ sở dữ liệu
        /// </summary>
        /// <param name="entity">Thực thể cần cập nhật thông tin</param>
        /// <returns>Số bản ghi được cập nhật</returns>
        public int Update(Guid id, TEntity entity );
        /// <summary>
        /// Xóa một bản ghi trong cơ sở dữ liệu có Id bằng Id truyền vào
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Số bản ghi bị xóa</returns>
        public int Delete(Guid id);
    }
}
