using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSharp_API_Newspaper.Data.Data.Entities
{
    [Table("Member")]
    public class NP_Member
    {
        [Key]
        public Guid ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Aliases { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Permission { get; set; }

        public ICollection<NP_Post> NP_Posts { get; set; }
        public ICollection<NP_Comment> NP_Comments { get; set; }

        [ForeignKey("FK_Admins")]
        public Guid? NP_AdminID { get; set; }
        public virtual NP_Admin NP_Admins { get; set; }
    }
}
