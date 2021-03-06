using System;
using System.Collections.Generic;

namespace TeduShop.Web.Models
{
    public class PostCategoryViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public int ParentID { get; set; }

        public string Desciption { get; set; }

        public int? DisplayOrder { get; set; }

        public string Image { get; set; }

        public bool HomeFlag { get; set; }

        public virtual IEnumerable<PostViewModel> PostViewModels { get; set; }

        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool Status { get; set; }
    }
}