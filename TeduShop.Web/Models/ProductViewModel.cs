using System;
using System.Collections.Generic;

namespace TeduShop.Web.Models
{
    [Serializable]
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Alias { get; set; }

        public int CategoryID { get; set; }

        public string Image { get; set; }

        public string MoreImage { get; set; }

        public Decimal Price { get; set; }

        public Decimal Promotion { get; set; }
        public int Warranty { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool HomeFlag { get; set; }
        public bool HotFlag { get; set; }
        public int ViewCount { get; set; }

        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool Status { get; set; }

        public string Tags { get; set; }
        public int SellOut { get; set; }

        public int Quantity { get; set; }

        public virtual ProductCategoryViewModel ProductCategoryViewModel { get; set; }

        public virtual IEnumerable<ProductTagViewModel> ProductTagViewModel { get; set; }
    }
}