using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSharp_API_Newspaper.Data.Data.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Category")]
    public class NP_Category
    {
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<NP_Post> NP_Posts { get; set; }
    }
}
