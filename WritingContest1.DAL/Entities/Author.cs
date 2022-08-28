using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingContest1.DAL.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public virtual AuthorContact AuthorContact { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
}
