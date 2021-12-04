using System.ComponentModel.DataAnnotations;

namespace TeduShop.Web.Models
{
    public class ContactDetailViewModel
    {
        public int ID { get; set; }

        [MaxLength(250, ErrorMessage = "Tên quá dài, không được quá 250 ký tự")]
        public string Name { get; set; }

        [MaxLength(30, ErrorMessage = "Số điện thoại quá dài, không được quá 30 ký tự")]
        public string Phone { get; set; }

        [MaxLength(250, ErrorMessage = "Email quá dài, không được quá 250 ký tự")]
        public string Email { get; set; }

        [MaxLength(250, ErrorMessage = "Địa chỉ quá dài, không được quá 250 ký tự")]
        public string Address { get; set; }

        public string Website { get; set; }

        public string Other { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public bool Status { get; set; }
    }
}