using MISA.CukCuk.Common.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Common.EntityModels
{
    /// <summary>
    /// Thông tin nhân viên 
    /// </summary>
    /// CreateBy: TKTHIEN (20/02/2021)
    public class Employee
    {
        #region Declare
        /// <summary>
        /// Trường lưu trữ giá trị EmployeeId
        /// </summary>
        private Guid _employeeId;
        #endregion
        #region Constructor
        #endregion
        #region Properties

        /// <summary>
        /// Khóa chính trong bảng cơ sở dữ liệu
        /// </summary>
        [Required("EmployeeId - Khóa chính trong bảng cơ sở dữ liệu")]
        [InsertCheckDuplicate("EmployeeId - Khóa chính trong bảng cơ sở dữ liệu")]
        public Guid EmployeeId
        {
            get
            {
                return _employeeId == Guid.Empty ? Guid.NewGuid() : _employeeId;
            }
            set
            {
                _employeeId = value;
            }
        }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required("Mã nhân viên")]
        [InsertCheckDuplicate("Mã nhân viên")]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [Required("Tên nhân viên")]
        public string FullName { get; set; }
        /// <summary>
        /// Giới tính ( 0 -  Nam, 1 - Nữ, 2- Khác)
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Giới tính dạng chữ ( Nam, Nữ, Khác)
        /// </summary>
        public string GenderName { 
            get
            {
                if (Gender == null) return null;
                var name = string.Empty;
                switch ((Enumeration.Gender)Gender)
                {
                    case Enumeration.Gender.Female:
                        name = Properties.Resources.Enum_Gender_Female;
                        break;
                    case Enumeration.Gender.Male:
                        name = Properties.Resources.Enum_Gender_Male;
                        break;
                    case Enumeration.Gender.Other:
                        name = Properties.Resources.Enum_Gender_Other;
                        break;
                    default:
                        break;
                }
                return name;
            } 
        }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Thư điện tử / Email
        /// </summary>
        [Required("Thư điện tử")]
        [CheckEmailFormat("Thư điện tử")]
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required("Số điện thoại")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Số Chứng minh thư nhân dân
        /// </summary>
        [Required("Số CMND")]
        [InsertCheckDuplicate("Số CMND")]
        [UpdateCheckDuplicate("Số CMND")]
        public string IdentifyNumber { get; set; }
        /// <summary>
        /// Nơi đăng ký CMND
        /// </summary>
        public string PlaceOfIssue { get; set; }
        /// <summary>
        /// Ngày cấp CMND
        /// </summary>
        public DateTime? DateOfIssue { get; set; }
        /// <summary>
        /// Trạng thái công việc ( 0- Thử việc, 1-Chính thức, 2- Nghỉ việc)
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        /// Trạng thái công việc dạng chữ
        /// </summary>
        public string StatusName { 
            get 
            {
                if (Status == null) return null;
                var status = string.Empty;
                switch ((Enumeration.Status)Status)
                {
                    case Enumeration.Status.Probationary:
                        status = Properties.Resources.Enum_Status_Probationary;
                        break;
                    case Enumeration.Status.Official:
                        status = Properties.Resources.Enum_Status_Official;
                        break;
                    case Enumeration.Status.Retired:
                        status = Properties.Resources.Enum_Status_Retired;
                        break;
                    default:
                        break;
                }
                return status;
            }
        }
        /// <summary>
        /// Khóa ngoại tham chiếu tới bảng phân quyền (Role)
        /// </summary>
        [Required("Mã phân quyền")]
        public Guid? RoleId { get; set; }

        /// <summary>
        /// Được phép sử dụng phần mềm
        /// </summary>
        public int? IsAllowUseSoftware { get; set; }
        #endregion
        #region Method
        #endregion
        #region Other
        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa đổi bản ghi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa đổi bản ghi
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
