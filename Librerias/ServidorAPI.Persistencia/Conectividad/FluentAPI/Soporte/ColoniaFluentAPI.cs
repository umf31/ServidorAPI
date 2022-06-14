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
//              ColoniaSoporteFluentAPI: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Soporte;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Soporte
{
    public class ColoniaFluentAPI : IEntityTypeConfiguration<ColoniaSoporte>
    {
        public void Configure(EntityTypeBuilder<ColoniaSoporte> builder)
        {
            builder.ToTable("Colonias");
            builder.HasIndex(e => e.MunicipioId, "IX_Colonias_MunicipioId");
            builder.HasIndex(e => e.AsentamientoId, "IX_Colonias_AsentamientoId");
            builder.HasIndex(e => e.StatusId, "IX_Colonias_StatusId");
            builder.HasOne(d => d.Municipio).WithMany(p => p.Colonias).HasForeignKey(d => d.MunicipioId);
            builder.HasOne(d => d.Asentamiento).WithMany(p => p.Colonias).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.AsentamientoId);
            builder.HasOne(d => d.Status).WithMany(p => p.Colonias).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.StatusId);

            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.Nombre).HasColumnOrder(1).IsRequired().IsUnicode(false);
            builder.Property(e => e.CodigoPostal).HasColumnOrder(2).IsRequired();
            builder.Property(e => e.AsentamientoId).HasColumnOrder(3).IsRequired();
            builder.Property(e => e.MunicipioId).HasColumnOrder(4).IsRequired();
            builder.Property(e => e.Latitud).HasColumnOrder(5).HasColumnType("decimal(9, 6)");
            builder.Property(e => e.Longitud).HasColumnOrder(6).HasColumnType("decimal(9, 6)");
            builder.Property(e => e.Geolocalizacion).HasColumnOrder(7).IsUnicode(false);
            builder.Property(e => e.Descripcion).HasColumnOrder(8).IsUnicode(false).HasDefaultValue(null);
            builder.Property(e => e.Imagen).HasColumnOrder(10).IsUnicode(false);
            builder.Property(e => e.FechaCreacion).HasColumnOrder(11).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnOrder(12).HasColumnType("datetime");
            builder.Property(e => e.UsuarioMod).HasColumnOrder(13).IsUnicode(false);
        }
    }
}