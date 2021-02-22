using MISA.CukCuk.Common.Enumeration;
using System;

namespace MISA.CukCuk.Common.Util
{
    public class Util
    {
        /// <summary>
        /// Hàm tạo ra tên stored procedure 
        /// </summary>
        /// <typeparam name="TEntity">Kiểu đối tượng thực thể</typeparam>
        /// <param name="procdureTypeName">Kiểu SP</param>
        /// <returns></returns>
        public static string GenerateProcedureName<TEntity>(TypeName procdureTypeName)
        {
            string procName = string.Empty;
            var tableName = typeof(TEntity).Name;
            switch (procdureTypeName)
            {
                case TypeName.Get:
                    procName = $"Proc_Get{tableName}s";
                    break;
                case TypeName.GetById:
                    procName = $"Proc_Get{tableName}ByID";
                    break;
                case TypeName.GetByProp:
                    procName = $"Proc_Get{tableName}sByProp";
                    break;
                case TypeName.GetByProps:
                    procName = $"Proc_Get{tableName}sByProps";
                    break;
                case TypeName.GetEntityCode:
                    procName = $"Proc_Get{tableName}Code";
                    break;
                case TypeName.Insert:
                    procName = $"Proc_Insert{tableName}";
                    break;
                case TypeName.Update:
                    procName = $"Proc_Update{tableName}";
                    break;
                case TypeName.Delete:
                    procName = $"Proc_Delete{tableName}";
                    break;
                default:
                    break;
            }
            return procName;
        }
    }
}
