using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual IEnumerable<PostTag> PostTags { set; get; }

        public virtual IEnumerable<ProductTag> ProductTags { set; get; }
    }
}