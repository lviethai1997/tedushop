using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstract;

namespace TeduShop.Model.Models
{
    [Table("PostCategories")]
    public class PostCategory:Aiditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Alias { get; set; }
        [Required]
        public int ParentID { get; set; }
        public string Desciption { get; set; }
        public string DisplayOrder { get; set; }    
        public string Image { get; set; }
        public bool HomeFlag { get; set; }

        public virtual IEnumerable<PostCategory> PostCategories { get; set; }
    }
}