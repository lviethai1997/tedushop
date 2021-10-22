using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Model.Abstract;

namespace TeduShop.Model.Models
{
    [Table("ProductCategories")]
    public class ProductCategory:Aiditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Alias { get; set; }
        [Required]
        public int ParentID { get; set; }
        public string Description { get; set; }
        public string DisplayOrder { get; set; }
        public string Image { get; set; }
        public bool HomeFlag { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}
