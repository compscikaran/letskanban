using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace letskanban.Models
{
    public class DocFile
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
    }
}
