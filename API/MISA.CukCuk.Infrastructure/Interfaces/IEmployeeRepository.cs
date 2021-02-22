using MISA.CukCuk.Common.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Infrastructure.Interfaces
{
    public interface IEmployeeRepository:IDbContext<Employee>
    {
        /// <summary>
        /// Lấy thông tin của thực thể theo Id
        /// </summary>
        /// <param name="id">Khóa chính của bản ghi chứa thông tin thực thể trong bảng cơ sở dữ liệu</param>
        /// <returns>Thông tin thực thể cần tìm</returns>
        public Employee GetById(Guid id);
        /// <summary>
        /// Lấy thông tin của thực thể theo thuộc tính cho trước
        /// </summary>
        /// <param name="propName">Tên trường trong bảng csdl</param>
        /// <param name="propValue">Giá trị của trường</param>
        /// <returns>Trả về true nếu tồn tại bản ghi cần tìm, ngược lại trả về false</returns>
        public Guid? GetByProp(string propName, string propValue);

        /// <summary>
        /// Lấy mã số cho thực thể mới
        /// </summary>
        /// <returns>Mã số của thực thể</returns>
        public string GetNewEntityCode();
    }
}
