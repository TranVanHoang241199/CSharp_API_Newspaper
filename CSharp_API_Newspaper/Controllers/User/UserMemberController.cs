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
    /// controler của member
    /// </summary>
    [Route("api/v1/user")]
    [ApiExplorerSettings(GroupName = "member")]
    [ApiController]
    public class UserMemberController : ControllerBase
    {
        private readonly IUserHandler _userHandler;

        /// <summary>
        /// ctr của member
        /// </summary>
        /// <param name="userHandler"></param>
        public UserMemberController(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        #region CRUD

        /// <summary>
        /// lấy ra danh sách member
        /// </summary>
        /// <param name="param">nhập thông tin cần tìm kiếm</param>
        /// <response code="200">Thành công</response>
        [AllowAnonymous, HttpGet(), Route("members")]
        [ProducesResponseType(typeof(ResponseList<MemberViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMembers([FromQuery] UserQueryModel query)
        {
            var result = await _userHandler.GetAllMember(query);

            return Helper.TransformData(result);
        }

        /// <summary>
        /// lấy ra một member cụ thể theo id
        /// </summary>
        /// <param name="id">nhập id của admin</param>
        /// <response code="200">Thành công</response>
        [AllowAnonymous, HttpGet(), Route("member/{id}")]
        [ProducesResponseType(typeof(ResponseObject<MemberViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMember(Guid id)
        {
            var result = await _userHandler.GetMemberById(id);

            return Helper.TransformData(result);
        }

        /// <summary>
        /// tạo mới một member
        /// </summary>
        /// <param name="param">Nhập thông tin admin</param>
        /// <response code="200">Thành công</response>
        [AllowAnonymous, HttpPost(), Route("member")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMember([FromBody] MemberCreateUpdateModel param)
        {
            var result = await _userHandler.CreateMember(param);

            return Helper.TransformData(result);
        }

        /// <summary>
        /// chỉnh sửa một member dựa vào id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="param"></param>
        /// <response code="200">Thành công</response>
        [AllowAnonymous, HttpPut(), Route("member/{id}")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateMember(Guid id, [FromBody] MemberCreateUpdateModel param)
        {
            var result = await _userHandler.UpdateMember(id, param);

            return Helper.TransformData(result);
        }

        /// <summary>
        /// xóa một member dựa vào id
        /// </summary>
        /// <param name="id">Nhập id của admin</param>
        /// <response code="200">Thành công</response>
        [AllowAnonymous, HttpDelete(), Route("member/{id}")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteMember(Guid id)
        {
            var result = await _userHandler.DeleteMember(id);

            return Helper.TransformData(result);
        }

        #endregion CRUD
    }
}
