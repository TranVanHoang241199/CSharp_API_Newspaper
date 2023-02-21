using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSharp_API_Newspaper.Data.Data.Entities
{
    [Table("Post")]
    public class NP_Post
    {

        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }
        public bool Permission { get; set; }
        public ICollection<NP_Comment> NP_Comments { get; set; }

        [ForeignKey("FK_Members")]
        public Guid? NP_MemberID { get; set; }
        public virtual NP_Member NP_Members { get; set; }

        [ForeignKey("FK_Categorys")]
        public Guid? NP_CategoryID { get; set; }
        public virtual NP_Category NP_Categorys { get; set; }

        [ForeignKey("FK_Admins")]
        public Guid? NP_AdminID { get; set; }
        public virtual NP_Admin NP_Admins { get; set; }

    }
}
