using MISA.CukCuk.ApplicationCore.Interfaces;
using MISA.CukCuk.Common.EntityModels;
using MISA.CukCuk.Common.Enumeration;
using MISA.CukCuk.Common.Other;
using MISA.CukCuk.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MISA.CukCuk.ApplicationCore.Services
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ quản lý nhân viên
    /// CreateBy: TKThien (21/02/2021)
    /// </summary>
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Declare
        /// <summary>
        /// Đối tượng giao tiếp với csdl
        /// </summary>
        private readonly IEmployeeRepository _employeeRepository;
        #endregion
        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion
        #region Method
        public ActionResult GetEmployeeById(Guid id)
        {
            var res = new ActionResult();
            res.Data = new { Employee = _employeeRepository.GetById(id) };
            return res;
        }
        public ActionResult GetNewCode()
        {
            var res = new ActionResult();
            res.Data = new { newEmployeeCode = FormatEmployeeCode(_employeeRepository.GetNewEntityCode()) };
            return res;
        }
        /// <summary>
        /// Thực hiện định dạng Mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>Mã nhân viên</returns>
        private string FormatEmployeeCode(string employeeCode)
        {
            // Lấy mã nhân viên lớn nhất để sinh ra mã tiếp theo
            var newEmployeeCode = "NV-";
            // Thêm 0 vào để đủ số chữ số (NV-000000)
            for (int i = 0; i < 6 - employeeCode.Length; i++)
            {
                newEmployeeCode += "0";
            }
            newEmployeeCode += employeeCode;

            return newEmployeeCode;
        }
        protected override ActionResult ValidateData(Employee employee, TypeName typeName, Guid? employeeId)
        {
            var res = new ActionResult();
            // Lấy danh sách các thuộc tính của đối tượng nhân viên
            var properties = typeof(Employee).GetProperties();
            //Duyệt danh sách các thuộc tính
            foreach (var property in properties)
            {
                var propName = property.Name; // Tên thuộc tính
                var propValue = property.GetValue(employee); // Giá trị
                // Thực hiện kiểm tra bắt buộc nhập nếu có attribute là [Required] 
                if (property.IsDefined(typeof(Required), true) && (propValue == null || propValue.ToString() == string.Empty))
                {
                    Required requiredAttribute = (Required)property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    CheckRequired(res, propValue.ToString(), requiredAttribute);
                }
                // Thực hiện kiểm tra trùng lặp các trường có attribute là [InsertCheckDuplicate] khi thực hiện Insert
                if (property.IsDefined(typeof(InsertCheckDuplicate), true) && typeName == TypeName.Insert)
                {
                    InsertCheckDuplicate insertCheckDuplicateAttribute = (InsertCheckDuplicate)property.GetCustomAttributes(typeof(InsertCheckDuplicate), true).FirstOrDefault();
                    CheckInsertDupplicate(res, propName, propValue.ToString(), insertCheckDuplicateAttribute);
                }
                // Thực hiện kiểm tra trùng lặp các trường có attribute là [UpdateCheckDuplicate] khi thực hiện Update
                if (property.IsDefined(typeof(UpdateCheckDuplicate), true) && typeName == TypeName.Update)
                {
                    UpdateCheckDuplicate requiredAttribute = (UpdateCheckDuplicate)property.GetCustomAttributes(typeof(UpdateCheckDuplicate), true).FirstOrDefault();
                    CheckUpdateDupplicate(res, propName, propValue.ToString(), requiredAttribute, (Guid)employeeId);
                }
                // Nếu có attribute là [CheckEmailFormat] thì thực hiện kiểm tra dữ liệu định dạng số
                if (property.IsDefined(typeof(CheckEmailFormat), true) && (propValue != null && propValue.ToString() != string.Empty))
                {
                    CheckEmailFormat checkEmailFormatAttribute = (CheckEmailFormat)property.GetCustomAttributes(typeof(CheckEmailFormat), true).FirstOrDefault();
                    CheckEmailFormat(res, propValue.ToString(), checkEmailFormatAttribute);
                }

            }
            if (res.Success)
            {
                res.Messenge.UserMsg.Add(Common.Properties.Resources.ValidateSuccess);
                res.Messenge.DevMsg.Add(Common.Properties.Resources.ValidateSuccess);
            }
            return res;
        }
        /// <summary>
        /// Hàm kiểm tra bắt buộc nhập
        /// </summary>
        /// <param name="_res">ActionRessult</param>
        /// <param name="_propValue">Giá trị thuộc tính</param>
        /// <param name="_requiredAttribute">Custom Attribute</param>
        private void CheckRequired(ActionResult _res, string _propValue, Required _requiredAttribute)
        {
            if (_propValue == null || _propValue == string.Empty)
            {
                if (_requiredAttribute != null)
                {
                    _res.Messenge.UserMsg.Add(_requiredAttribute.ErrorMessenger);
                    _res.Messenge.DevMsg.Add(_requiredAttribute.ErrorInfo);
                }
                _res.Success = false;
                _res.MISACode = (int)MISACode.ValidateEntity;
            }
        }
        /// <summary>
        /// Hàm kiểm tra trùng khi thêm mới
        /// </summary>
        /// <param name="_res">ActionRessult</param>
        /// <param name="_propName">Tên thuộc tính</param>
        /// <param name="_propValue">Giá trị thuộc tính</param>
        /// <param name="_requiredAttribute">Custom Attribute</param>
        private void CheckInsertDupplicate(ActionResult _res,string _propName, string _propValue, InsertCheckDuplicate _insertCheckDuplicateAttribute)
        {
            if (_employeeRepository.GetByProp(_propName, _propValue.ToString()) != null)
            {
                if (_insertCheckDuplicateAttribute != null)
                {
                    _res.Messenge.UserMsg.Add(_insertCheckDuplicateAttribute.ErrorMessenger);
                    _res.Messenge.DevMsg.Add(_insertCheckDuplicateAttribute.ErrorInfo);

                }
                _res.Success = false;
                _res.MISACode = (int)MISACode.ValidateEntity;
            }

        }
        /// <summary>
        /// Hàm kiểm tra trùng khi chỉnh sửa
        /// </summary>
        /// <param name="_res">ActionRessult</param>
        /// <param name="_propName">Tên thuộc tính</param>
        /// <param name="_propValue">Giá trị thuộc tính</param>
        /// <param name="_requiredAttribute">Custom Attribute</param>
        private void CheckUpdateDupplicate(ActionResult _res,string _propName, string _propValue, UpdateCheckDuplicate _updateCheckDuplicateAttribute,Guid id)
        {
            if (_employeeRepository.GetByProp(_propName, _propValue.ToString()) != null && _employeeRepository.GetByProp(_propName, _propValue.ToString()) != id )
            {
                if (_updateCheckDuplicateAttribute != null)
                {
                    _res.Messenge.UserMsg.Add(_updateCheckDuplicateAttribute.ErrorMessenger);
                    _res.Messenge.DevMsg.Add(_updateCheckDuplicateAttribute.ErrorInfo);

                }
                _res.Success = false;
                _res.MISACode = (int)MISACode.ValidateEntity;
            }

        }
        /// <summary>
        /// Kiểm tra định dạng Email
        /// </summary>
        /// <param name="_res">ActionRessult</param>
        /// <param name="_propValue">Giá trị thuộc tính</param>
        /// <param name="_requiredAttribute">Custom Attribute</param>
        private void CheckEmailFormat(ActionResult _res, string _propValue, CheckEmailFormat _updateCheckDuplicateAttribute)
        {
            //Biểu thức chính quy kiểm tra định dạng Email
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.IsMatch(_propValue))
            {
                if (_updateCheckDuplicateAttribute != null)
                {
                    _res.Messenge.UserMsg.Add(_updateCheckDuplicateAttribute.ErrorMessenger);
                    _res.Messenge.DevMsg.Add(_updateCheckDuplicateAttribute.ErrorInfo);

                }
                _res.Success = false;
                _res.MISACode = (int)MISACode.ValidateEntity;
            }
        }

        public ActionResult GetEmployeesByStatus(int status)
        {
            var res = new ActionResult();
            res.Data = new { Employees = _employeeRepository.GetByStatus(status) };
            return res;
        }
        #endregion
    }

}
