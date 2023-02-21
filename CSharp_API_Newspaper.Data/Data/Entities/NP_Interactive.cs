using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSharp_API_Newspaper.Data.Data.Entities
{
    [Table("Interactive")]
    public class NP_Interactive
    {
        [Key]
        public Guid ID { get; set; }
        public bool Like { get; set; }
        public long NumberShare { get; set; }
        public bool StatusSeen { get; set; }
        public DateTime DateSeen { get; set; }
        public long Numberseen { get; set; }
        public int Star { get; set; }

        [ForeignKey("FK_Members")]
        public Guid? NP_MemberID { get; set; }
        public virtual NP_Member NP_Members { get; set; }

        [ForeignKey("FK_Posts")]
        public Guid? NP_PostID { get; set; }
        public virtual NP_Post NP_Posts { get; set; }

    }
}
