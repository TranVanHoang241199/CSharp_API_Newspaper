using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSharp_API_Newspaper.Data.Data.Entities
{

    [Table("Admin")]
    public class NP_Admin
    {
        [Key]
        public Guid ID { get; set; }
        
        public string Account {get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public DateTime Birth { get; set; }

        public string Address { get; set; }

        public string Position { get; set; } 

        public bool Permission { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ICollection<NP_Member> NP_Members { get; set; }
        public ICollection<NP_Post> NP_Posts { get; set; }
        public ICollection<NP_Interactive> NP_Interactives { get; set; }
    }
}
