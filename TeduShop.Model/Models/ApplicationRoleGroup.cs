﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("ApplicationRoleGroups")]
    public class ApplicationRoleGroup
    {
        [Key]
        [Column(Order =1)]
        public int GroupId { get; set; }

        [StringLength(128)]
        [Key]
        [Column(Order = 2)]
        public string RoleId { set; get; }

        [ForeignKey("RoleId")]
        public virtual ApplicationRole ApplicationRole { get; set; }

        [ForeignKey("GroupId")]
        public virtual ApplicationGroup ApplicationGroup { get; set; }
    }
}