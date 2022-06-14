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
//                PaisSoporteFluentAPI: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Soporte;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Soporte
{
    public class PaisFluentAPI : IEntityTypeConfiguration<PaisSoporte>
    {
        public void Configure(EntityTypeBuilder<PaisSoporte> builder)
        {
            builder.ToTable("Paises");
            builder.HasIndex(e => e.StatusId, "IX_Paises_StatusId");
            builder.HasOne(d => d.Status).WithMany(p => p.Paises).HasForeignKey(d => d.StatusId);

            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.Nombre).HasColumnOrder(2).IsRequired().IsUnicode(false);
            builder.Property(e => e.NombreOficial).HasColumnOrder(3).IsRequired().IsUnicode(false);
            builder.Property(e => e.Capital).HasColumnOrder(4).IsRequired().IsUnicode(false);
            builder.Property(e => e.Latitud).HasColumnOrder(5).HasColumnType("decimal(9, 6)");
            builder.Property(e => e.Longitud).HasColumnOrder(6).HasColumnType("decimal(9, 6)");
            builder.Property(e => e.Geolocalizacion).HasColumnOrder(7).IsUnicode(false);
            builder.Property(e => e.Descripcion).HasColumnOrder(8).IsUnicode(false);
            builder.Property(e => e.Imagen).HasColumnOrder(9).IsUnicode(false);
            builder.Property(e => e.FechaCreacion).HasColumnOrder(10).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnOrder(11).HasColumnType("datetime");
            builder.Property(e => e.UsuarioMod).HasColumnOrder(12).IsUnicode(false);
            builder.Property(e => e.StatusId).HasColumnOrder(13).IsRequired();
        }
    }
}