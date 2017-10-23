using System.Collections.Generic;

namespace letskanban.Models
{
    public class DetailViewModel 
    {
        public Review ViewReview { get; set; }
        public IEnumerable<Comment> ViewComments { get; set; }
    }
}