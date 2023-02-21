using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSharp_API_Newspaper.Data.Data.Entities
{
    [Table("Comment")]
    public class NP_Comment
    {
        [Key]
        public Guid ID { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }


        [ForeignKey("FK_Posts")]
        public Guid? NP_PostID { get; set; }
        public virtual NP_Post NP_Posts { get; set; }

        [ForeignKey("FK_Members")]
        public Guid? NP_MemberID { get; set; }
        public virtual NP_Member NP_Members { get; set; }

    }
}
