using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.ApplicationCore.Interfaces;
using MISA.CukCuk.Common.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// service quản lý nhân viên
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee>
    {
        #region Declare
        /// <summary>
        /// đối tượng xử lý nghiệp vụ quản lý nhân viên 
        /// </summary>
        private readonly IEmployeeService _employeeService;
        #endregion
        #region Constructor
        public EmployeesController(IEmployeeService employeeService):base(employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion
        
        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/[controller]/Newcode")]
        public IActionResult GetEmployeeCode()
        {
            var res = _employeeService.GetNewCode();
            return Ok(res);
            //return StatusCode(res.MISACode, res.Data);
        }
        /// <summary>
        /// Lấy thông tin của đối tượng
        /// </summary>
        /// <param name="id">giá trị khóa chính trong bảng cơ sở dữ liệu</param>
        /// <returns>Thông tin thực thể có khóa chính trong bảng là id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var res = _employeeService.GetEmployeeById(id);
            return StatusCode(res.MISACode,res.Data);
        }
        /// <summary>
        /// Lấy danh sách các nhân viên theo tình trạng công việc
        /// </summary>
        /// <param name="status">tình trạng công việc</param>
        /// <returns></returns>
        [HttpGet("/api/v2/Employees")]
        public IActionResult GetByState([FromQuery]int status)
        {
            var res = _employeeService.GetEmployeesByStatus(status);
            return StatusCode(res.MISACode, res.Data);
        }

    }
}
