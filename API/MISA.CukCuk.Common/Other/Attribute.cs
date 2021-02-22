using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MISA.CukCuk.Common.Other
{
    /// <summary>
    /// Attribute để xác định kiểm tra bắt buộc nhập
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
        /// <summary>
        /// Câu cảnh báo 
        /// </summary>
        public string ErrorMessenger;
        /// <summary>
        /// Thêm thông tin 
        /// </summary>
        public string ErrorInfo;
        /// <summary>
        /// Khởi tạo custom attribute
        /// </summary>
        /// <param name="propertyName">tên thuộc tính</param>
        public Required(string propertyName)
        {
            this.ErrorMessenger = propertyName + Properties.Resources.RequiredMessage;
            this.ErrorInfo = Properties.Resources.RequiredError + propertyName;
        }
    }
    /// <summary>
    /// Attribute xác định các trường cần kiểm tra trùng lặp khi thêm mới thông tin thực thể
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class InsertCheckDuplicate : Attribute
    {
        /// <summary>
        /// Câu cảnh báo 
        /// </summary>
        public string ErrorMessenger;
        /// <summary>
        /// Thêm thông tin
        /// </summary>
        public string ErrorInfo;

        /// <summary>
        /// Khởi tạo custom attribute
        /// </summary>
        /// <param name="propertyName">tên thuộc tính</param>
        public InsertCheckDuplicate(string propertyName)
        {
            this.ErrorMessenger = propertyName + Properties.Resources.CheckDuplicateMessage;
            this.ErrorInfo = Properties.Resources.CheckDuplicateError + propertyName;
        }
    }
    /// <summary>
    /// Attribute xác định các trường cần kiểm tra trùng lặp khi cập nhật thông tin thực thể
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class UpdateCheckDuplicate : Attribute
    {
        /// <summary>
        /// Câu cảnh báo 
        /// </summary>
        public string ErrorMessenger;
        /// <summary>
        /// Thêm thông tin
        /// </summary>
        public string ErrorInfo;
        public UpdateCheckDuplicate(string propertyName)
        {
            this.ErrorMessenger = propertyName + Properties.Resources.CheckDuplicateMessage;
            this.ErrorInfo = Properties.Resources.CheckDuplicateError + propertyName;
        }
    }
    /// <summary>
    /// Attribute xác định các trường cần kiểm tra định dạng 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckEmailFormat : Attribute
    {
        /// <summary>
        /// Câu cảnh báo 
        /// </summary>
        public string ErrorMessenger;
        /// <summary>
        /// Thêm thông tin
        /// </summary>
        public string ErrorInfo;
        /// <summary>
        /// Biểu thức chính quy kiểm tra định dạng Email
        /// </summary>
        public CheckEmailFormat(string propertyName)
        {
            this.ErrorMessenger = propertyName + Properties.Resources.CheckEmailFormatMessage;
            this.ErrorInfo = Properties.Resources.CheckEmailFormatError + propertyName;
        }
    }
}
