﻿using MISA.CukCuk.Common.EntityModels;
using MISA.CukCuk.Common.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        /// <summary>
        /// Lấy mã cho nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên (NV-XXXXXX)</returns>
        public ActionResult GetNewCode();
        /// <summary>
        /// Lấy thông tin của thực thể theo id (khóa chính trong bảng csdl)
        /// </summary>
        /// <param name="id">khóa chính trong bảng csdl</param>
        /// <returns>ActionResult có Data là thông tin của thực thể</returns>
        public ActionResult GetEmployeeById(Guid id);
        /// <summary>
        /// Lấy danh sách nhân viên theo trình trạng công việc
        /// </summary>
        /// <param name="status">trình trạng công việc</param>
        /// <returns></returns>
        public ActionResult GetEmployeesByStatus(int status);
    }
}
