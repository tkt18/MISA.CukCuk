using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Lớp cơ sở
    /// </summary>
    /// <typeparam name="TEntity">Kiểu dữ liệu của thực thể</typeparam>
    /// CreateBy: TKTHIEN (20/02/2021)
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase
    {
        #region Declare
        /// <summary>
        /// Interface tham chiếu tới BaseService
        /// </summary>
        private readonly IBaseService<TEntity> _baseService;
        #endregion
        #region Constructor
        public BaseController(IBaseService<TEntity> baseService){
            _baseService = baseService;
        }
        #endregion
        #region Method
        /// <summary>
        /// Lấy toàn bộ danh sách thực thể
        /// </summary>
        /// <returns>Danh sách các thực thể</returns>
        // GET: api/<BaseController>
        [HttpGet]
        public IActionResult Get()
        {
            var res = _baseService.GetEntities();
            return StatusCode(res.MISACode, new { res.Data, res.Messenge });
        }
        /// <summary>
        /// Thêm thông tin thực thể
        /// </summary>
        /// <param name="entity">thực thể đối tượng</param>
        // POST api/<BaseController>
        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {
            var res = _baseService.InsertEntity(entity);
            return StatusCode(res.MISACode, new { res.Data, res.Messenge });
        }

        /// <summary>
        /// Sửa thông tin thực thể
        /// </summary>
        /// <param name="id">Khóa chính của thực thể trong csdl</param>
        /// <param name="entity">đối tượng chứa thông tin thực thể</param>
        /// <returns></returns>
        // PUT api/<BaseController>/141eea25-7b62-62de-8832-6a1673ffca7c
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TEntity entity)
        {
            var res = _baseService.UpdateEntity(id, entity);
            return StatusCode(res.MISACode, new { res.Data, res.Messenge });
        }

        /// <summary>
        /// Xóa thực thể
        /// </summary>
        /// <param name="id">Khóa chính của thực thể trong csdl</param>
        /// <returns></returns>
        // DELETE api/<BaseController>/141eea25-7b62-62de-8832-6a1673ffca7c
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var res = _baseService.DeleteEntity(id);
            return StatusCode(res.MISACode, new { res.Data, res.Messenge });
        }
        #endregion
    }
}
