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
//           UnidadMedicaSoporteFluentAPI: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Soporte;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Soporte
{
    public class UnidadMedicaFluentAPI : IEntityTypeConfiguration<UnidadMedicaSoporte>
    {
        public void Configure(EntityTypeBuilder<UnidadMedicaSoporte> builder)
        {
            builder.ToTable("UnidadesMedicas");
            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.Nombre).HasColumnOrder(1).IsRequired().IsUnicode(false);
            builder.Property(e => e.DelegacionId).HasColumnOrder(2).IsRequired();
            builder.Property(e => e.NumUnidad).HasColumnOrder(3).IsRequired();
            builder.Property(e => e.Localidad).HasColumnOrder(4).IsRequired().IsUnicode(false);
            builder.Property(e => e.ClavePresupuestal).HasColumnOrder(5).IsRequired().HasMaxLength(12).IsUnicode(false);
            builder.Property(e => e.UnidadTipoId).HasColumnOrder(6).IsRequired();
            builder.Property(e => e.VialidadId).HasColumnOrder(7).IsRequired();
            builder.Property(e => e.Calle).HasColumnOrder(8).IsRequired().IsUnicode(false);
            builder.Property(e => e.Numero).HasColumnOrder(9).IsRequired().HasMaxLength(10).IsUnicode(false);
            builder.Property(e => e.Telefono).HasColumnOrder(10).HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.ColoniaId).HasColumnOrder(11).IsRequired();
            builder.Property(e => e.MunicipioId).HasColumnOrder(12).IsRequired();
            builder.Property(e => e.Latitud).HasColumnOrder(13).HasColumnType("decimal(9, 6)");
            builder.Property(e => e.Longitud).HasColumnOrder(14).HasColumnType("decimal(9, 6)");
            builder.Property(e => e.Geolocalizacion).HasColumnOrder(15).IsUnicode(false);
            builder.Property(e => e.Imagen).HasColumnOrder(16).IsUnicode(false);
            builder.Property(e => e.FechaCreacion).HasColumnOrder(17).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnOrder(18).HasColumnType("datetime");
            builder.Property(e => e.UsuarioMod).HasColumnOrder(19).IsUnicode(false);
            builder.Property(e => e.StatusId).HasColumnOrder(20).IsRequired();
        }
    }
}