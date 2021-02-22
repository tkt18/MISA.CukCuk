using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Common.EntityModels
{
    public class Role
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
