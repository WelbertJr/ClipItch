﻿using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Mappings
{
  public class CuratorMap : IEntityTypeConfiguration<Curator>
  {
    public void Configure(EntityTypeBuilder<Curator> builder)
    {
      // Tabela
      builder.ToTable("Curator");

      // Chave primária
      builder.HasKey(x => x.Id);

      // Propriedades
      builder.Property(x => x.Id)
       .HasColumnName("Id")
       .HasColumnType("INTEGER")
       .HasMaxLength(32);

      builder.Property(x => x.Name)
        .HasColumnName("Name")
        .HasColumnType("TEXT")
        .HasMaxLength(120);

      builder.Property(x => x.DisplayName)
        .HasColumnName("DisplayName")
        .HasColumnType("TEXT")
        .HasMaxLength(120);

      builder.Property(x => x.ChannelUrl)
        .HasColumnName("ChannelUrl")
        .HasColumnType("TEXT")
        .HasMaxLength(120);

      builder.Property(x => x.Logo)
        .HasColumnName("Logo")
        .HasColumnType("TEXT")
        .HasMaxLength(120);
    }
  }
}