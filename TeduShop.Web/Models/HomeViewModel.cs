using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<ProductViewModel> productsSale { set; get; }
        public IEnumerable<ProductViewModel> productsNew { set; get; }
    }
}