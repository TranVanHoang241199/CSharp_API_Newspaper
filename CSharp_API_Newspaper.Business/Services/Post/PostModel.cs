using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_API_Newspaper.Business.Services
{
    public class PostQueryModel
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

    #region Post
    public class PostViewModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }
        public bool Permission { get; set; }
        public ICollection<CommentViewModel> NP_Comments { get; set; }
        public Guid? NP_MemberID { get; set; }
        public Guid? NP_CategoryID { get; set; }
        public Guid? NP_AdminID { get; set; }
    }

    public class PostCreateUpdateModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }
        public bool Permission { get; set; }
    }
    #endregion Post


    #region Comment
    public class CommentViewModel
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Guid? NP_PostID { get; set; }
        public Guid? NP_MemberID { get; set; }
    }

    public class CommentCreateUpdateModel
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Guid? PostID { get; set; }
        public Guid? MemberID { get; set; }
    }
    #endregion Commet


    #region Interactive
    public class InteractiveViewModel
    {
        public Guid ID { get; set; }
        public bool Like { get; set; }
        public long NumberShare { get; set; }
        public bool StatusSeen { get; set; }
        public DateTime DateSeen { get; set; }
        public long Numberseen { get; set; }
        public int Star { get; set; }
        public Guid? MemberID { get; set; }
        public Guid? PostID { get; set; }
    }

    public class InteractiveCreateUpdateModel
    {

    }
    #endregion Interactive

}
