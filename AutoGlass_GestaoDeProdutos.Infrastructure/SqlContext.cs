using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AutoGlass_GestaoDeProdutos.Domain.Models
{
    public partial class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.CodigoProduto)
                    .HasName("produto_pk");

                entity.ToTable("produto", "autoglass");

                entity.Property(e => e.CodigoProduto).HasColumnName("codigo_produto");

                entity.Property(e => e.CnpjFornecedorProduto)
                    .HasMaxLength(15)
                    .HasColumnName("cnpj_fornecedor_produto");

                entity.Property(e => e.CodigoFornecedorProduto).HasColumnName("codigo_fornecedor_produto");

                entity.Property(e => e.DescricacaoFornecedorProduto)
                    .HasMaxLength(500)
                    .HasColumnName("descricacao_fornecedor_produto");

                entity.Property(e => e.DescricaoProduto)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("descricao_produto");

                entity.Property(e => e.FabricacaoProduto)
                    .HasColumnType("date")
                    .HasColumnName("fabricacao_produto");

                entity.Property(e => e.SituacaoProduto).HasColumnName("situacao_produto");

                entity.Property(e => e.ValidadeProduto)
                    .HasColumnType("date")
                    .HasColumnName("validade_produto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
