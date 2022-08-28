using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingContest1.DAL.Entities;

namespace WritingContest1.DAL.Configurations
{
    class StoryGenreConfiguration : IEntityTypeConfiguration<StoryGenre>
    {
        public void Configure(EntityTypeBuilder<StoryGenre> builder)
        {
            builder.HasOne(p => p.Story)
                .WithMany(p => p.StoryGenres)
                .HasForeignKey(p => p.StoryId);

            builder.HasOne(p => p.Genre)
                .WithMany(p => p.StoryGenres)
                .HasForeignKey(p => p.GenreId);
        }
    }
}
