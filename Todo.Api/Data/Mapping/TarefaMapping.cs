using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Core.Models;

namespace Todo.Api.Data.Mapping
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Titulo)
                    .IsRequired(true)
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(80);

            builder.Property(t => t.Descricao)
                    .IsRequired(true)
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(255);

            builder.Property(t => t.DataCriacao)
                    .IsRequired(true);

            builder.Property(t => t.DataConclusao)
                    .IsRequired(false);

            builder.Property(t => t.IdUsuario)
                    .IsRequired(true);
        }
    }
}