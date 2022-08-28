﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingContest1.DAL.Entities
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int WordCount { get; set; }
        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<StoryGenre> StoryGenres { get; set; }
    }
}
