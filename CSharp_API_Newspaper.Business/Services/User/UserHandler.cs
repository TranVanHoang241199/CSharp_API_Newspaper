using AutoMapper;
using CSharp_API_Newspaper.Data.Data;
using CSharp_API_Newspaper.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TimekeeperAPI.Common.Utils;

namespace CSharp_API_Newspaper.Business.Services
{
    public class UserHandler : IUserHandler
    {
        private readonly NPDBContext _context;
        private readonly IMapper _mapper;

        public UserHandler(NPDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<Response> AdminPermission(Guid id, AdminPermissionModel param)
        {
            try
            {
                var adminToGet = await _context.NP_Admins.FirstOrDefaultAsync(a => a.ID == id);

                if (!adminToGet.Permission)
                    return new ResponseError(HttpStatusCode.NotFound, "get admin failed.");

                // cap quyen cho admin lam quan tri vien
                if (param.PermissionAdmin)
                {
                    var adminToPermission = await _context.NP_Admins.FirstOrDefaultAsync(a => a.ID == param.ID);

                    if (adminToPermission == null)
                        return new ResponseError(HttpStatusCode.NotFound, "admin Permission failed.");

                    adminToPermission.Permission = true;
                }

                // cap quyen dang bai bao cho member
                if (param.PermissionMember)
                {
                    var memberToPermission = await _context.NP_Members.FirstOrDefaultAsync(a => a.ID == param.ID);

                    if (memberToPermission == null)
                        return new ResponseError(HttpStatusCode.NotFound, "member Permission failed.");

                    memberToPermission.Permission = true;
                }

                // cap quen bai bao duoc phat hanh
                if (param.PermissionPost)
                {
                    var postToPermission = await _context.NP_Posts.FirstOrDefaultAsync(a => a.ID == param.ID);

                    if (postToPermission == null)
                        return new ResponseError(HttpStatusCode.NotFound, "post Permission failed.");

                    postToPermission.Permission = true;
                }

                var status = await _context.SaveChangesAsync();

                if (status <= 0)
                    return new ResponseError(HttpStatusCode.NotFound, "create save failed.");


                return new Response("permission success.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                Log.Error("id: {@id}, param: {@param}", id, param);
                return new Response
                {
                    Message = ex.Message,
                    Code = HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<Response> AdminTransferRights(Guid id, Guid adminID)
        {
            try
            {
                var adminToPermission = await _context.NP_Admins.Include(a => a.ID == adminID).FirstOrDefaultAsync();

                if (adminToPermission == null)
                    return new ResponseError(HttpStatusCode.NotFound, "get failed.");

                // chuyển quyền quản lý member cho admin mới
                var memberToPermission = await _context.NP_Members.Where(a => a.NP_AdminID == id).ToListAsync();

                if (memberToPermission != null)
                    foreach (var member in memberToPermission)
                        member.NP_AdminID = adminID;

                // chuyển quền quản lý post cho admin mới
                var postToPermission = await _context.NP_Posts.Where(a => a.NP_AdminID == id).ToListAsync();

                if (postToPermission != null)
                    foreach (var post in postToPermission)
                        post.NP_AdminID = adminID;

                // xóa quyền admin cũ
                // var adminToDelPer = await _context.NP_Admins.Include(a => a.ID == adminID).FirstOrDefaultAsync();

                var status = await _context.SaveChangesAsync();

                if (status <= 0)
                    return new ResponseError(HttpStatusCode.NotFound, "update failed.");

                var data = _mapper.Map<NP_Admin, AdminViewModel>(adminToPermission);

                return new ResponseObject<AdminViewModel>(data, "transfer right successfully.");

            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                Log.Error("id: {@id}, adminID: {@AdminID}", id, adminID);
                return new Response<AdminViewModel>
                {
                    Data = null,
                    Message = ex.Message,
                    Code = HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// tạo mới một admin
        /// </summary>
        /// <param name="param">thông tin của admin</param>
        /// <returns></returns>
        public async Task<Response> CreateAdmin(AdminCreateUpdateModel param)
        {
            try
            {
                var adminToCreate = new NP_Admin()
                {
                    ID = Guid.NewGuid(),
                    Account = param.Account,
                    FullName = param.FullName,
                    Birth = param.Birth,
                    Address = param.Address,
                    Position = param.Position,
                    Permission = param.Permission,
                    Phone = param.Phone,
                    Email = param.Email
                };

                await _context.AddAsync(adminToCreate);

                var status = await _context.SaveChangesAsync();

                if (status <= 0)
                    return new ResponseError(HttpStatusCode.NotFound, "create save failed.");

                var data = _mapper.Map<AdminViewModel>(adminToCreate);

                return new ResponseObject<AdminViewModel>(data, "create success.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                Log.Error("Param: {@Param}", param);
                return new Response<AdminViewModel>
                {
                    Data = null,
                    Message = ex.Message,
                    Code = HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// tạo mới một member
        /// </summary>
        /// <param name="param">thông tin của member</param>
        /// <returns></returns>
        public async Task<Response> CreateMember(MemberCreateUpdateModel param)
        {
            try
            {
                var memberToCreate = new NP_Member()
                {
                    ID = Guid.NewGuid(),
                    LastName = param.LastName,
                    FirstName = param.FirstName,
                    Aliases = param.Aliases,
                    Account = param.Account,
                    Password = param.Password,
                    Birth = param.Birth,
                    Email = param.Email,
                    Phone = param.Phone,
                    Permission = false
                };

                await _context.AddAsync(memberToCreate);

                var status = await _context.SaveChangesAsync();

                if (status <= 0)
                    return new ResponseError(HttpStatusCode.NotFound, "create save failed.");

                var data = _mapper.Map<MemberViewModel>(memberToCreate);

                return new ResponseObject<MemberViewModel>(data, "create success.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                Log.Error("Param: {@Param}", param);
                return new Response<MemberViewModel>
                {
                    Data = null,
                    Message = ex.Message,
                    Code = HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// xóa admin 
        /// </summary>
        /// <param name="id">id admin cần xóa</param>
        /// <returns></returns>
        public async Task<Response> DeleteAdmin(Guid id)
        {
            try
            {
                var memberToCollection = await _context.NP_Members.Where(m => m.NP_AdminID == id).ToListAsync();

                if (memberToCollection.Count() > 0)
                    return new ResponseError(HttpStatusCode.NotFound, "exist Member.");

                var adminToDelete = await _context.NP_Admins.FirstOrDefaultAsync(a => a.ID == id);

                if (adminToDelete == null)
                    return new ResponseError(HttpStatusCode.NotFound, "Not Found.");

                _context.NP_Admins.Remove(adminToDelete);

                var status = await _context.SaveChangesAsync();

                if (status <= 0)
                    return new ResponseError(HttpStatusCode.NotFound, "delete save failed.");

                return new ResponseDelete(HttpStatusCode.OK, "successful delete.", id, adminToDelete.FullName);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong.");
                return new ResponseError(HttpStatusCode.InternalServerError, "Something went wrong: " + ex.Message);

            }
        }

        /// <summary>
        /// xóa một member cụ thể dựa vào id
        /// </summary>
        /// <param name="id">id member cần xóa</param>
        /// <returns></returns>
        public async Task<Response> DeleteMember(Guid id)
        {
            try
            {
                
                var memberToDelete = await _context.NP_Members.FirstOrDefaultAsync(a => a.ID == id);

                if (memberToDelete == null)
                    return new ResponseError(HttpStatusCode.NotFound, "Not Found.");

                _context.NP_Members.Remove(memberToDelete);

                var status = await _context.SaveChangesAsync();

                if (status <= 0)
                    return new ResponseError(HttpStatusCode.NotFound, "delete save failed.");

                return new ResponseDelete(HttpStatusCode.OK, "successful delete.", 
                    id, memberToDelete.LastName + " " + memberToDelete.FirstName);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong.");
                return new ResponseError(HttpStatusCode.InternalServerError, 
                    "Something went wrong: " + ex.Message);

            }
        }

        /// <summary>
        /// lấy ra admin có id cụ thẻ
        /// </summary>
        /// <param name="id">id của admin</param>
        /// <returns></returns>
        public async Task<Response> GetAdminById(Guid id)
        {
            try
            {
                var adminToGet = await _context.NP_Admins.Include(a => a.NP_Members).FirstOrDefaultAsync(a => a.ID == id);

                if(adminToGet == null)
                    return new Response(HttpStatusCode.NotFound, "Not Found");

                var adminToReturn = _mapper.Map<NP_Admin, AdminViewModel>(adminToGet);

                return new ResponseObject<AdminViewModel>(adminToReturn, "get success");
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                Log.Error("Id: {@Id}", id);
                return new ResponseError(HttpStatusCode.InternalServerError, "Something went wrong: " + ex.Message);
            }
        }

        /// <summary>
        /// lấy ra danh sách các admin có phân quyền
        /// </summary>
        /// <param name="adminQuery">thông tin truy vấn</param>
        /// <returns></returns>
        public async Task<Response> GetAllAdmin(UserQueryModel query)
        {
            try
            {
                var collection = _context.NP_Admins.Include(a => a.NP_Members) as IQueryable<NP_Admin>;

                if (!string.IsNullOrWhiteSpace(query.SearchQuery))
                {
                    var searchQuery = query.SearchQuery.Trim();
                    collection = collection.Where(c => c.FullName.Contains(searchQuery) || c.Phone.Contains(searchQuery)); 
                }   

                if (query.ID != Guid.Empty)
                {
                    collection.Where(c => c.ID == query.ID);
                }

                // phân trang
                collection = collection.Skip(query.PageSize * (query.PageNumber - 1))
                    .Take(query.PageSize);

                var result = await collection.ToListAsync();

                var adminToReturn = _mapper.Map<IEnumerable<NP_Admin>, IEnumerable<AdminViewModel>>(result);

                return new ResponseObject<IEnumerable<AdminViewModel>>(adminToReturn, "get success");
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                Log.Error("UserQueryModel: {@query}", query);
                return new ResponseError(HttpStatusCode.InternalServerError, "Something went wrong: " + ex.Message);
            }
        }

        /// <summary>
        /// lấy ra tất cả member
        /// </summary>
        /// <param name="query">thông tin truy vấn</param>
        /// <returns></returns>
        public async Task<Response> GetAllMember(UserQueryModel query)
        {
            try
            {
                var collection = _context.NP_Members as IQueryable<NP_Member>;

                if (!string.IsNullOrWhiteSpace(query.SearchQuery))
                {
                    var searchQuery = query.SearchQuery.Trim();

                    collection = collection.Where(c => c.LastName.Contains(searchQuery) 
                    || c.LastName.Contains(searchQuery) 
                    || c.Phone.Contains(searchQuery));
                }

                if (query.ID != Guid.Empty)
                {
                    collection.Where(c => c.ID == query.ID);
                }

                // phân trang
                collection = collection.Skip(query.PageSize * (query.PageNumber - 1))
                    .Take(query.PageSize);

                var result = await collection.ToListAsync();

                var memberToReturn = _mapper.Map<IEnumerable<NP_Member>, IEnumerable<MemberViewModel>>(result);

                return new ResponseObject<IEnumerable<MemberViewModel>>(memberToReturn, "get success");
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                Log.Error("UserQueryModel: {@query}", query);
                return new ResponseError(HttpStatusCode.InternalServerError, "Something went wrong: " + ex.Message);
            }
        }

        /// <summary>
        /// lấy ra một member cụ thể dựa vào id
        /// </summary>
        /// <param name="id">id member cần truy vấn</param>
        /// <returns></returns>
        public async Task<Response> GetMemberById(Guid id)
        {
            try
            {
                var memberToGet = await _context.NP_Members.FirstOrDefaultAsync(a => a.ID == id);

                if (memberToGet == null)
                    return new Response(HttpStatusCode.NotFound, "Not Found");

                var memberToReturn = _mapper.Map<NP_Member, MemberViewModel>(memberToGet);

                return new ResponseObject<MemberViewModel>(memberToReturn, "get success");
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                Log.Error("Id: {@Id}", id);
                return new ResponseError(HttpStatusCode.InternalServerError, "Something went wrong: " + ex.Message);
            }
        }

        /// <summary>
        /// cập nhật thông tin cho admin
        /// </summary>
        /// <param name="id">id của admin</param>
        /// <param name="param">thông tin admin</param>
        /// <returns></returns>
        public async Task<Response> UpdateAdmin(Guid id, AdminCreateUpdateModel param)
        {
            try
            {
                var adminToUpdate = await _context.NP_Admins.Include(a => a.NP_Members).FirstOrDefaultAsync(a => a.ID == id);

                if (adminToUpdate == null)
                    return new ResponseError(HttpStatusCode.NotFound, "Check id again");

                adminToUpdate.Account = param.Account;
                adminToUpdate.FullName = param.FullName;
                adminToUpdate.Birth = param.Birth;
                adminToUpdate.Address = param.Address;
                adminToUpdate.Position = param.Position;
                adminToUpdate.Permission = param.Permission;
                adminToUpdate.Phone = param.Phone;
                adminToUpdate.Email = param.Email;

                var status = await _context.SaveChangesAsync();

                if (status <= 0)
                    return new ResponseError(HttpStatusCode.NotFound, "update failed.");

                var data = _mapper.Map<NP_Admin, AdminViewModel>(adminToUpdate);

                return new ResponseObject<AdminViewModel>(data, "edit successfully");
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                Log.Error("Param: {@Param}, Id: {@Id}", param, id);
                return new Response<AdminViewModel>
                {
                    Data = null,
                    Message = ex.Message,
                    Code = HttpStatusCode.InternalServerError

                };
            }
        }

        /// <summary>
        /// chỉnh sửa một member dựa vào id
        /// </summary>
        /// <param name="id">id member cần chỉnh sửa</param>
        /// <param name="param">thông tin member chỉnh sửa</param>
        /// <returns></returns>
        public async Task<Response> UpdateMember(Guid id, MemberCreateUpdateModel param)
        {
            try
            {
                var memberToUpdate = await _context.NP_Members.FirstOrDefaultAsync(a => a.ID == id);

                if (memberToUpdate == null)
                    return new ResponseError(HttpStatusCode.NotFound, "Check id again");

                memberToUpdate.LastName = param.LastName;
                memberToUpdate.FirstName = param.FirstName;
                memberToUpdate.Aliases = param.Aliases;
                memberToUpdate.Account = param.Account;
                memberToUpdate.Password = param.Password;
                memberToUpdate.Birth = param.Birth;
                memberToUpdate.Email = param.Email;
                memberToUpdate.Phone = param.Phone;

                var status = await _context.SaveChangesAsync();

                if (status <= 0)
                    return new ResponseError(HttpStatusCode.NotFound, "update failed.");

                var data = _mapper.Map<NP_Member, MemberViewModel>(memberToUpdate);

                return new ResponseObject<MemberViewModel>(data, "edit successfully");
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                Log.Error("Param: {@Param}, Id: {@Id}", param, id);
                return new Response<MemberViewModel>
                {
                    Data = null,
                    Message = ex.Message,
                    Code = HttpStatusCode.InternalServerError

                };
            }
        }
    }
}
