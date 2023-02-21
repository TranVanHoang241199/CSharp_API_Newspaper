using CSharp_API_Newspaper.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimekeeperAPI.Common.Utils;

namespace CSharp_API_Newspaper.Controllers
{
    /// <summary>
    /// Controler của admin
    /// </summary>
    [Route("api/v1/user")]
    [ApiExplorerSettings(GroupName = "Admin")]
    [ApiController]
    public class UserAdminController : ControllerBase
    {
        private readonly IUserHandler _userHandler;

        /// <summary>
        /// ctr của UserAdminController
        /// </summary>
        /// <param name="userHandler"></param>
        public UserAdminController(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        #region CRUD

        /// <summary>
        /// lấy tất cả admin
        /// </summary>
        /// <param name="query">nhập thông tin cần tìm kiếm</param>
        /// <response code="200">Thành công</response>
        [AllowAnonymous, HttpGet(), Route("admins")]
        [ProducesResponseType(typeof(ResponseList<AdminViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAdmins([FromQuery] UserQueryModel query)
        {
            var result = await _userHandler.GetAllAdmin(query);

            return Helper.TransformData(result);
        }

        /// <summary>
        /// lấy ra một admin cụ thể theo id
        /// </summary>
        /// <param name="id">nhập id của admin</param>
        /// <response code="200">Thành công</response>
        [AllowAnonymous, HttpGet(), Route("admin/{id}")]
        [ProducesResponseType(typeof(ResponseObject<AdminViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAdmin(Guid id)
        {
            var result = await _userHandler.GetAdminById(id);

            return Helper.TransformData(result);
        }

        /// <summary>
        /// tạo mới admin
        /// </summary>
        /// <param name="param">Nhập thông tin admin</param>
        /// <response code="200">Thành công</response>
        [AllowAnonymous, HttpPost(), Route("admin")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAdmin([FromBody] AdminCreateUpdateModel param)
        {
            var result = await _userHandler.CreateAdmin(param);

            return Helper.TransformData(result);
        }

        /// <summary>
        /// chỉnh sửa admin 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="param"></param>
        /// <response code="200">Thành công</response>
        [AllowAnonymous, HttpPut(), Route("admin/{id}")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAdmin(Guid id, [FromBody] AdminCreateUpdateModel param)
        {
            var result = await _userHandler.UpdateAdmin(id, param);

            return Helper.TransformData(result);
        }

        /// <summary>
        /// xóa một admin dựa vào id
        /// </summary>
        /// <param name="id">Nhập id của admin</param>
        /// <response code="200">Thành công</response>
        [AllowAnonymous, HttpDelete(), Route("admin/{id}")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAdmin(Guid id)
        {
            var result = await _userHandler.DeleteAdmin(id);

            return Helper.TransformData(result);
        }

        #endregion CRUD
    }
}
