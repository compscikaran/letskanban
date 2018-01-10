using System.ComponentModel.DataAnnotations;

namespace letskanban.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string  Message { get; set; }

        
        public int CodeId { get; set; }
    }
}