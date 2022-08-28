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
    class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(p => p.Name)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);
        }
    }
}
