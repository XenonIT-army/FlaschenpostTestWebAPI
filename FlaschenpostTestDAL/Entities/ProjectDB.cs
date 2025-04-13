using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaschenpostTestDAL.Entities
{
    [Table("Project")]
    public partial class ProjectDB
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string? Title { get; set; }
        [Required]
        [StringLength(100)]
        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public string? Icon { get; set; }

    }
}
