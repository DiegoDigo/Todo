using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.TodoContext.Entities;

namespace Todo.Infra.Maps
{
    public class TodoMap : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("Todo");
            builder.HasKey("Id");
            builder.Property(x => x.Title).IsRequired().HasColumnType("varchar(20)");
            builder.Property(x => x.Description).HasColumnType("varchar(150)");
            builder.Property(x => x.Done).IsRequired().HasColumnType("boolean");
            builder.Property(x => x.Deadline).IsRequired().HasColumnType("boolean");
            builder.Property(x => x.CreateDate).IsRequired().HasColumnType("timestamp");
            builder.Property(x => x.EndingDate).IsRequired().HasColumnType("timestamp");
            builder.Property(x => x.CompletionDate).HasColumnType("timestamp");
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(150).HasColumnType("varchar(150)");
        }
    }
}