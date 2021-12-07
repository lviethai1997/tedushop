using System;
using System.ComponentModel.DataAnnotations;

namespace TeduShop.Web.Models
{
    public class FeedBackViewModel
    {
        public int ID { get; set; }

        [MaxLength(150, ErrorMessage = "Tên không được dài hơn 150 ký tự")]
        [Required(ErrorMessage = "Không được bỏ trống ô Họ Và Tên")]
        public string Name { get; set; }

        [MaxLength(150, ErrorMessage = "Email không được dài hơn 150 ký tự")]
        [Required(ErrorMessage = "Không được bỏ trống ô Email")]
        public string Email { get; set; }

        [MaxLength(500, ErrorMessage = "Lời nhắn không được dài hơn 500 ký tự")]
        [Required(ErrorMessage = "Không được bỏ trống ô Nội Dung")]
        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

        public ContactDetailViewModel contactDetailViewModel { get; set; }
    }
}