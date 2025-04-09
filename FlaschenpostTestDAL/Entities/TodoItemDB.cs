using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaschenpostTestDAL.Entities
{
  
    [Table("TodoItem")]
    public partial class TodoItemDB
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int? Priority { get; set; }
        public int CategoryId { get; set; }
    }
}
