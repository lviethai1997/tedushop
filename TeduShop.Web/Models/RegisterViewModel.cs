using System.ComponentModel.DataAnnotations;

namespace TeduShop.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Không được bỏ trống Họ và Tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống Tên Đăng Nhập")]
        [MinLength(6, ErrorMessage = "Tên đăng nhập Không được nhập ít hơn 6 ký tự "), MaxLength(30, ErrorMessage = "Tên đăng nhập Không được nhập lớn hơn 30 ký tự ")]
        public string UserName { get; set; }

        [MinLength(6, ErrorMessage = "Mật khẩu Không được nhập ít hơn 6 ký tự "), MaxLength(30, ErrorMessage = "Mật khẩu Không được nhập lớn hơn 30 ký tự ")]
        [Required(ErrorMessage = "Không được bỏ trống Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống Email")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không đúng.")]
        public string Email { get; set; }

        [MinLength(10, ErrorMessage = "Số Điện Thoại Không được nhập ít hơn 10 ký tự "), MaxLength(15, ErrorMessage = "Số Điện Thoại Không được nhập lớn hơn 15 ký tự ")]
        [Required(ErrorMessage = "Không được bỏ trống Số Điện Thoại")]
        public string Phone { get; set; }

        [MinLength(10, ErrorMessage = "Số Điện Thoại Không được nhập ít hơn 10 ký tự "), MaxLength(250, ErrorMessage = "Số Điện Thoại Không được nhập lớn hơn 250 ký tự ")]
        [Required(ErrorMessage = "Không được bỏ trống Địa chỉ nhà")]
        public string Address { get; set; }
    }
}