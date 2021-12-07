using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("FeedBacks")]
    public class FeedBack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(maximumLength: 150, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }

        [StringLength(maximumLength: 150, MinimumLength = 10)]
        [Required]
        public string Email { get; set; }

        [StringLength(maximumLength: 500, MinimumLength = 10)]
        [Required]
        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}