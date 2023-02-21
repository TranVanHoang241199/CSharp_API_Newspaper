using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimekeeperAPI.Common.Utils;

namespace CSharp_API_Newspaper.Business.Services
{
    public interface IUserHandler
    {

        #region admin
        Task<Response> GetAllAdmin(UserQueryModel query);
        Task<Response> GetAdminById(Guid id);
        Task<Response> CreateAdmin(AdminCreateUpdateModel param);
        Task<Response> UpdateAdmin(Guid id, AdminCreateUpdateModel param);
        Task<Response> DeleteAdmin(Guid id);
        Task<Response> AdminPermission(Guid id, AdminPermissionModel param);
        Task<Response> AdminTransferRights(Guid id, Guid adminID);
        #endregion admin

        #region Member
        Task<Response> GetAllMember(UserQueryModel query);
        Task<Response> GetMemberById(Guid id);
        Task<Response> CreateMember(MemberCreateUpdateModel param);
        Task<Response> UpdateMember(Guid id, MemberCreateUpdateModel param);
        Task<Response> DeleteMember(Guid id);
        #endregion Member

    }
}
