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
    class AuthorContactConfiguration : IEntityTypeConfiguration<AuthorContact>
    {
        public void Configure(EntityTypeBuilder<AuthorContact> builder)
        {
            builder.Property(x => x.Email)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Phone)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            /*            builder.HasOne(p => p.Student)
                            .WithOne(p => p.StudentAddress)
                            .HasForeignKey<StudentAddress>(p => p.StudentId);*/
        }
    }
}
