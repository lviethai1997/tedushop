using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model
{
    [Table("SystemConfigs")]
    public class SystemConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Code { get; set; }
        public string ValueString { get; set; }
        public int ValueInt { get; set; }
    }
}