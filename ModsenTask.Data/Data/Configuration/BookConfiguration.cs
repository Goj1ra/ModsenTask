using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModsenTask.Data.Entities;

namespace ModsenTask.Data.Data
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.UserId);

           builder.Property(x => x.Id).HasConversion<string>();
        }
    }
}
