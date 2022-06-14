#region ==> Licencia

//=======================================================================
//
//                 ░▒▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▒░
//               █████▓░▒▓███████████████████▓▒░▓████▓
//              █████       ▒████████████▓▒       ████▓
//              █████          ▒▓█████▓░          ▓████
//             ░██▓██  ░▒▒▒▒▒▒░░▓██▓░  ▒▒         ▓████
//             ▒████████▓▒▒▒▒▓███▒   ▓█▓          ▓████
//             ▒██▓█▒░▒▒             ██▓          █████░
//             ▒████▓▓▓▓█████▓▒▒░     ▒█▓         █████░
//             ▒██▓███      ░███████▒   █▓       ▓██▓██░
//             ▒███▓██▒       ▓▒▒▒▓▓▓█▓  █░      ██▓███░
//             ▒██▓▓███       ▓░   ▓▒ ▓█░▒█     ▒███▓██░
//             ▒███▓███▓      ▓█▒░  ▓▓ ▓█▒▓     ███▓███░
//             ░██▓█▓███░    ▒▓░    ▒█  ██░    ███▓▓▓██
//              ███▓█▓███    ░ ▒▒  ░█▓  ██    ▓██▓█████
//              ▓█████████▒   ▒▒████▒  ██░   █████████▒
//               ▒██████████▓▒░ ░▒▒░░▓██▓░▓██████████▒
//                   ░░░░░▒▓▓▓▓▓▒▒▒▒▓▓▒░▒▓▒▒░░
//              ▒██▓   ▓▓        ░▓▓  ░▓▓▓▓█▒  ▓▓▓███
//              ▒██▓   ███▒     ▒███ ███   ▓▒▓██   ░▓
//              ▒██▓  ▒████▒   ▒████░███▓▒   ▓███▒░
//              ░██▓  ██ ███▒ ▒█ ▒██▒ ▓█████▓ ░██████▒
//              ░██▓  █▓  ███▓█▒  ███     ▓███    ▒███▒
//              ▒███ ▒█▓   ███▒   ████▓░  ▓████▒  ░███░
//               ▒▒░ ░▓     ▒     ▒▒▒░▒▓▓▓▓▒  ░▓▓▓▓▒░
//
//               INSITUTO MEXICANO DEL SEGURO SOCIAL
//                 DELEGACION REGIONAL NUEVO LEON
// © TODOS LOS DERECHOS RESERVADOS 2021 REVELADO DE INVENCION R1-123-2020
//            Información y actualizaciones del proyecto en
//                https://github.com/umf31/ServidorAPI
//                  MetaFluentAPI: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Sadim;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Sadim
{
    public class MetaFluentAPI : IEntityTypeConfiguration<Meta>
    {
        public void Configure(EntityTypeBuilder<Meta> builder)
        {
            builder.ToTable("Metas", "sadim");
            builder.HasIndex(e => e.PeriodoId, "IX_Meta_PeriodoId");
            builder.HasIndex(e => e.DetallesId, "IX_Meta_DetallesId");
            builder.HasIndex(e => e.StatusId, "IX_Meta_StatusId");
            builder.HasOne(d => d.Periodo).WithMany(p => p.Metas).HasForeignKey(d => d.PeriodoId);
            builder.HasOne(d => d.Detalles).WithMany(p => p.Metas).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.DetallesId);
            builder.HasOne(d => d.Status).WithMany(p => p.Metas).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.StatusId);

            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.DetallesId).HasColumnOrder(1).IsRequired();
            builder.Property(e => e.PeriodoId).HasColumnOrder(2).IsRequired();
            builder.Property(e => e.RendimientoEsperado).HasColumnOrder(3).HasColumnType("decimal(5, 2)");
            builder.Property(e => e.RendimientoBajo).HasColumnOrder(4).HasColumnType("decimal(5, 2)");
            builder.Property(e => e.RendimientoLimite).HasColumnOrder(5).HasColumnType("decimal(5, 2)");
            builder.Property(e => e.RendimientoMedio).HasColumnOrder(6).HasColumnType("decimal(5, 2)");
            builder.Property(e => e.ValorReferencia).HasColumnOrder(7).IsRequired().IsUnicode(false);
            builder.Property(e => e.FechaCreacion).HasColumnOrder(8).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnOrder(9).HasColumnType("datetime");
            builder.Property(e => e.UsuarioMod).HasColumnOrder(10).IsUnicode(false);
            builder.Property(e => e.StatusId).HasColumnOrder(11).IsRequired();
            builder.Ignore(e => e.Nombre);
        }
    }
}