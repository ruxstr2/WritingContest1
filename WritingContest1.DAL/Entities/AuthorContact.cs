using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingContest1.DAL.Entities
{
    public class AuthorContact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
