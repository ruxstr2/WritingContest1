using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingContest1.DAL.Entities
{
    public class StoryGenre
    {
        public int Id { get; set; }
        public int StoryId { get; set; }
        public int GenreId { get; set; }
        public virtual Story Story { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
