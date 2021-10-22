using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using TeduShop.Model.Abstract;

namespace TeduShop.Model.Models
{
    [Table("Products")]
    public class Product : Aiditable
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Alias { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public XElement MoreImage { get; set; }

        public Decimal Price { get; set; }
        public Decimal Promotion { get; set; }
        public int Warranty { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool HomeFlag { get; set; }
        public bool HotFlag { get; set; }
        public int ViewCountP { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual IEnumerable<ProductTag> ProductTags { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}