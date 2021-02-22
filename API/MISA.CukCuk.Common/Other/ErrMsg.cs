﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Common.Other
{
    /// <summary>
    /// Thông tin lỗi 
    /// </summary>
    /// CreateBy: TKTHIEN (20/02/2021)
    public class ErrMsg
    {
        #region Constructor
        public ErrMsg()
        {
            UserMsg = new List<string>();
            DevMsg = new List<string>();
        }
        #endregion
        #region Property
        /// <summary>
        /// Thông báo cho Dev
        /// </summary>
        public List<string> DevMsg { get; set; }
        /// <summary>
        /// Thông báo cho người dùng cuối
        /// </summary>
        public List<string> UserMsg { get; set; }
        /// <summary>
        /// Mã lỗi nội bộ
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// Thêm thông tin về lỗi
        /// </summary>
        public string MoreInfo { get; set; }
        /// <summary>
        /// TraceId
        /// </summary>
        public string TraceId { get; set; }
        #endregion
    }
}
