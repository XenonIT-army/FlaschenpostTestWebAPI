using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaschenpostTestDAL.Entities
{
    [Table("Category")]
    public partial class CategoryDB
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string? Description { get; set; }
      
    }
}
