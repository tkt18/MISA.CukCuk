using System.Collections.Generic;

namespace MISA.CukCuk.Common.Other
{
    /// <summary>
    /// Kết quả trả về của thao tác nghiệp vụ
    /// </summary>
    /// CreatedBy: TKTHIEN (20/02/2021)
    public class ActionResult
    {
        #region Constructor
        public ActionResult()
        {
            Success = true;
            Messenge = new ErrMsg();
            MISACode = (int)Enumeration.MISACode.Success;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Trạng thái xử lý
        /// </summary>
        public bool Success { get; set; } 
        /// <summary>
        /// Thông báo kết quả / Danh sách các lỗi
        /// </summary>
        public ErrMsg Messenge { get; set; }
        /// <summary>
        /// Mã trạng thái trả về
        /// </summary>
        public int MISACode { get; set; }
        /// <summary>
        /// Dữ liệu trả về 
        /// </summary>
        public object Data { get; set; }
        #endregion
    }
}
