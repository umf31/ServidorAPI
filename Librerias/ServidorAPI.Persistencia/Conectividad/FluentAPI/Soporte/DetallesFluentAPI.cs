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
//            DetalleIndicadorSoporteFluentAPI: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Soporte;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Soporte
{
    public class DetallesFluentAPI : IEntityTypeConfiguration<DetallesSoporte>
    {
        public void Configure(EntityTypeBuilder<DetallesSoporte> builder)
        {
            builder.ToTable("Detalles");
            builder.HasIndex(e => e.StatusId, "IX_Detalles_StatusId");
            builder.HasIndex(e => e.ProcesoId, "IX_Detalles_ProcesoId");
            builder.HasOne(d => d.Proceso).WithMany(p => p.Detalles).HasForeignKey(d => d.ProcesoId);
            builder.HasOne(d => d.Status).WithMany(p => p.Detalles).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.StatusId);

            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.ProcesoId).HasColumnOrder(1).IsRequired();
            builder.Property(e => e.Nombre).HasColumnOrder(2).IsRequired().IsUnicode(false);
            builder.Property(e => e.Descripcion).HasColumnOrder(3).IsRequired().IsUnicode(false);
            builder.Property(e => e.DescripcionCorta).HasColumnOrder(4).IsRequired().IsUnicode(false);
            builder.Property(e => e.Objetivo).HasColumnOrder(5).IsRequired().IsUnicode(false);
            builder.Property(e => e.NumeradorDescripcion).HasColumnOrder(6).IsRequired().IsUnicode(false);
            builder.Property(e => e.DenominadorDescripcion).HasColumnOrder(7).IsRequired().IsUnicode(false);
            builder.Property(e => e.Multiplicador).HasColumnOrder(8).IsRequired();
            builder.Property(e => e.Interpretacion).HasColumnOrder(9).IsRequired().IsUnicode(false);
            builder.Property(e => e.Periocidad).HasColumnOrder(10).IsRequired().IsUnicode(false);
            builder.Property(e => e.FechaCreacion).HasColumnOrder(11).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnOrder(12).HasColumnType("datetime");
            builder.Property(e => e.UsuarioMod).HasColumnOrder(13).IsUnicode(false);
            builder.Property(e => e.StatusId).HasColumnOrder(14).IsRequired();
        }
    }
}