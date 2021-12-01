using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstract;

namespace TeduShop.Model.Models
{
    [Table("Products")]
    public class Product : Aiditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string Alias { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Size { get; set; }

        [Required]
        [MaxLength(256)]
        public string Image { get; set; }

        [Required]
        [Column(TypeName = "XML")]
        public string MoreImage { get; set; }

        [Required]
        public Decimal Price { get; set; }

        public Decimal Promotion { get; set; }
        public int Warranty { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        [MaxLength(int.MaxValue)]
        public string Content { get; set; }

        public bool HomeFlag { get; set; }
        public bool HotFlag { get; set; }
        public int ViewCount { get; set; }

        public int SellOut { get; set; }

        public string Tags { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual IEnumerable<ProductTag> ProductTags { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}