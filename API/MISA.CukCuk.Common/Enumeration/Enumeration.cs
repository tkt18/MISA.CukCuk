using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Common.Enumeration
{
    /// <summary>
    /// Mã trạng thái
    /// </summary>
    /// CreatedBy: TKTHIEN (20/02/2021)
    public enum MISACode
    {
        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,

        /// <summary>
        /// Thêm thành công dữ liệu
        /// </summary>
        Created = 201,

        /// <summary>
        /// Lỗi validate dữ liệu chung
        /// </summary>
        Validate = 400,

        /// <summary>
        /// Lỗi validate dữ liệu không hợp lệ
        /// </summary>
        ValidateEntity = 401,

        /// <summary>
        /// Lỗi validate dữ liệu do không đúng nghiệp vụ
        /// </summary>
        ValidateBussiness = 402,

        /// <summary>
        /// Lỗi Exception
        /// </summary>
        Exception = 500,

    }
    /// <summary>
    /// Giới tính
    /// </summary>
    /// CreatedBy: TKTHIEN (20/02/2021)
    public enum Gender
    {
        /// <summary>
        /// Nam
        /// </summary>
        Male = 1,

        /// <summary>
        /// Nữ
        /// </summary>
        Female = 0,

        /// <summary>
        /// Không xác định
        /// </summary>
        Other = 2
    }
    /// <summary>
    /// Trạng thái công việc
    /// </summary>
    /// CreatedBy: TKTHIEN (20/02/2021)
    public enum Status
    {
        /// <summary>
        /// Thử việc
        /// </summary>
        Probationary = 0,

        /// <summary>
        /// Chính thức
        /// </summary>
        Official = 1,

        /// <summary>
        /// Nghỉ việc
        /// </summary>
        Retired = 2
    }
    /// <summary>
    /// Tên kiểu store sẽ thực thi
    /// </summary>
    /// CreatedBy: NVMANH (14/04/2020)
    public enum TypeName
    {
        /// <summary>
        ///  Lấy tất cả dữ liệu
        /// </summary>
        Get,

        /// <summary>
        /// Lấy dữ liệu theo khóa chính
        /// </summary>
        GetById,
        
        /// <summary>
        /// Lấy dữ liệu theo giá trị thuộc tính
        /// </summary>
        GetByProp,
        
        /// <summary>
        /// Lấy dữ liệu theo giá trị nhiều thuộc tính
        /// </summary>
        GetByProps,

        /// <summary>
        /// Lấy mã số thực thể mới
        /// </summary>
        GetEntityCode,

        /// <summary>
        /// Thêm mới
        /// </summary>
        Insert,

        /// <summary>
        /// Sửa/ cập nhật dữ liệu
        /// </summary>
        Update,

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        Delete,
        GetByStatus
    }
}
