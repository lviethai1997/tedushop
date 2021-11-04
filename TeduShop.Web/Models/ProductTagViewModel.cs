namespace TeduShop.Web.Models
{
    public class ProductTagViewModel
    {
        public int ProductID { get; set; }

        public string TagID { get; set; }

        public virtual ProductViewModel ProductViewModel { get; set; }

        public virtual TagViewModel TagViewModel { get; set; }
    }
}