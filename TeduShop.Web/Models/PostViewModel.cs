using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class PostViewModel
    {
        public int ID { get; set; }

      
        public string Name { get; set; }

     
        public string Alias { get; set; }

      
        public int CategoryID { get; set; }

       
        public string Image { get; set; }

       
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

        public virtual IEnumerable<PostTagViewModel> PostTagViewModel { get; set; }

        
        public virtual PostCategoryViewModel PostCategoryViewModel { get; set; }
    }
}