using System.ComponentModel.DataAnnotations;

namespace TeduShop.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Không được bỏ trống ô Tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống ô Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}