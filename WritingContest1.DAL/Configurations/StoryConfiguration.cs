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
    class StoryConfiguration : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.Property(p => p.Title)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(p => p.WordCount)
                .HasColumnType("int");
        }
    }
}
