using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_API_Newspaper.Business.Services
{
    public class UserQueryModel
    {
        public Guid ID { get; set; }
        public string SearchQuery { get; set; }

        // paging
        const int maxPageSize = 1;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value < maxPageSize) ? maxPageSize : value;
        }
    }

    #region Admin
    public class AdminCreateUpdateModel
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime Birth { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public bool Permission { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class AdminViewModel
    {
        public Guid ID { get; set; }
        public string Account { get; set; }
        public string FullName { get; set; }
        public string Birth { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public bool Permission { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<MemberViewModel> Members { get; set; }

    }

    public class AdminPermissionModel
    {
        // ID ban can phan quyen
        public Guid ID { get; set; }
        public bool PermissionMember { get; set; } = false;
        public bool PermissionPost { get; set; } = false;
        public bool PermissionAdmin { get; set; } = false;

    }
    #endregion Admin


    #region Member
    public class MemberCreateUpdateModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Aliases { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class MemberViewModel
    {
        public Guid ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Aliases { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Birth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Permission { get; set; }
    }
    #endregion Member

}
