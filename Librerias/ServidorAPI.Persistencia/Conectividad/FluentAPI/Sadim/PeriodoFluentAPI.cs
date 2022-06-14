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
//                 PeriodoFluentAPI: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Sadim;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Sadim
{
    public class PeriodoFluentAPI : IEntityTypeConfiguration<Periodos>
    {
        public void Configure(EntityTypeBuilder<Periodos> builder)
        {
            builder.ToTable("Periodos", "sadim");
            builder.HasIndex(e => e.StatusId, "IX_Periodos_StatusId");
            builder.HasOne(d => d.Status).WithMany(p => p.Periodos).HasForeignKey(d => d.StatusId);

            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.Año).HasColumnOrder(1).IsRequired().HasColumnType("varchar(4)").IsUnicode(false);
            builder.Property(e => e.Mes).HasColumnOrder(2).IsRequired().HasColumnType("varchar(2)").IsUnicode(false);
            builder.Property(e => e.Periodo).HasColumnOrder(3).IsRequired().HasColumnType("varchar(6)").IsUnicode(false);
            builder.Property(e => e.Nombre).HasColumnOrder(4).IsRequired().HasColumnType("varchar(5)").IsUnicode(false);
            builder.Property(e => e.MesAbrev).HasColumnOrder(5).IsRequired().HasColumnType("varchar(3)").IsUnicode(false);
            builder.Property(e => e.FechaInicio).HasColumnOrder(6).HasColumnType("datetime");
            builder.Property(e => e.FechaTermino).HasColumnOrder(7).HasColumnType("datetime");
            builder.Property(e => e.FechaCreacion).HasColumnOrder(8).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnOrder(9).HasColumnType("datetime");
            builder.Property(e => e.UsuarioMod).HasColumnOrder(10).IsUnicode(false);
            builder.Property(e => e.StatusId).HasColumnOrder(11).IsRequired();
        }
    }
}