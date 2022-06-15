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
//                Eh04UnidadFluentAPI: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Sadim;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Sadim
{
    public class Eh04UnidadFluentAPI : IEntityTypeConfiguration<Eh04Unidad>
    {
        public void Configure(EntityTypeBuilder<Eh04Unidad> builder)
        {
            builder.ToTable("Eh04Unidad", "sadim");
            builder.HasIndex(e => e.StatusId, "IX_Eh04Unidad_StatusId");
            builder.HasIndex(e => e.PeriodoId, "IX_Eh04Unidad_PeriodoId");
            builder.HasOne(d => d.Periodos).WithMany(p => p.Eh04Unidad).HasForeignKey(d => d.PeriodoId);
            builder.HasOne(d => d.Status).WithMany(p => p.Eh04Unidad).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.StatusId);

            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.PeriodoId).HasColumnOrder(1).IsRequired();
            builder.Property(e => e.Periodo).HasColumnOrder(2).IsRequired().HasMaxLength(6).IsUnicode(false);
            builder.Property(e => e.ClavePresupuestal).HasColumnOrder(3).IsRequired().HasMaxLength(12).IsUnicode(false);
            builder.Property(e => e.Nombre).HasColumnOrder(4).IsRequired().IsUnicode(false);
            builder.Property(e => e.FechaInicio).HasColumnOrder(5).HasColumnType("datetime");
            builder.Property(e => e.FechaTermino).HasColumnOrder(6).HasColumnType("datetime");
            builder.Property(e => e.FechaCorte).HasColumnOrder(7).HasColumnType("datetime");
            builder.Property(e => e.Numerador).HasColumnOrder(9).HasColumnType("decimal(12, 0)");
            builder.Property(e => e.Denominador).HasColumnOrder(10).HasColumnType("decimal(12, 0)");
            builder.Property(e => e.Multiplicador).HasColumnOrder(11).IsRequired();
            builder.Property(e => e.ValorReferencia).HasColumnOrder(12).HasColumnType("decimal(12, 2)");
            builder.Property(e => e.Total).HasColumnOrder(13).HasColumnType("decimal(12, 2)");
            builder.Property(e => e.Meta).HasColumnOrder(14).HasColumnType("decimal(12, 0)");
            builder.Property(e => e.DiferenciaMeta).HasColumnOrder(15).HasColumnType("decimal(12, 0)");
            builder.Property(e => e.Rendimiento).HasColumnOrder(16).IsRequired().IsUnicode(false);
            builder.Property(e => e.FechaCreacion).HasColumnOrder(17).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnOrder(18).HasColumnType("datetime");
            builder.Property(e => e.UsuarioMod).HasColumnOrder(19).IsUnicode(false);
            builder.Property(e => e.StatusId).HasColumnOrder(20).IsRequired();
        }
    }
}