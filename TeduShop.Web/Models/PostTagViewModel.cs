namespace TeduShop.Web.Models
{
    public class PostTagViewModel
    {
        public int PostID { get; set; }

        public string TagID { get; set; }

        public virtual PostViewModel PostViewModel { get; set; }

        public virtual TagViewModel TagViewModel { get; set; }
    }
}