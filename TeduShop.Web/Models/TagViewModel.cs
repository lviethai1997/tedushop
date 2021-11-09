using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class TagViewModel
    {
        public string ID { get; set; }
      
        public string Name { get; set; }

        public string Type { get; set; }

        public virtual IEnumerable<PostTagViewModel> PostTagViewModels { set; get; }

        public virtual IEnumerable<ProductTagViewModel> ProductTagViewModels { set; get; }
    }
}