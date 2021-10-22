using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstract;

namespace TeduShop.Model.Models
{
    [Table("Posts")]
    public class Post : Aiditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Alias { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public string Image { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool HomeFlag { get; set; }
        public bool HotFlag { get; set; }
        public int ViewCount { get; set; }

        public virtual IEnumerable<PostTag> PostTag { get; set; }

        [ForeignKey("CategoryID")]
        public virtual PostCategory GetPostCategory { get; set; }
    }
}