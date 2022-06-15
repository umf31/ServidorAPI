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
//            MT03_VigilanciaMaternaFluentAPI: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Enlace;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Enlace
{
    public class MT03_VigilanciaMaternaFluentAPI : IEntityTypeConfiguration<MT03_VigilanciaMaterna>
    {
        public void Configure(EntityTypeBuilder<MT03_VigilanciaMaterna> entity)
        {
            entity.HasKey(e => new { e.CvePresup, e.Periodo, e.Vez, e.Gesta, e.Concepto });
            entity.ToTable("tbVigilanciaMaterna_UM");

            entity.Property(e => e.CvePresup).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.Periodo).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.Vez).HasMaxLength(1).IsUnicode(false);
            entity.Property(e => e.Concepto).HasMaxLength(2).IsUnicode(false);
            entity.Property(e => e.Gpo1014).HasColumnType("decimal(10, 2)").HasColumnName("Gpo10_14");
            entity.Property(e => e.Gpo1014acum).HasColumnType("decimal(10, 2)").HasColumnName("Gpo10_14Acum");
            entity.Property(e => e.Gpo1519).HasColumnType("decimal(10, 2)").HasColumnName("Gpo15_19");
            entity.Property(e => e.Gpo1519acum).HasColumnType("decimal(10, 2)").HasColumnName("Gpo15_19Acum");
            entity.Property(e => e.Gpo2029).HasColumnType("decimal(10, 2)").HasColumnName("Gpo20_29");
            entity.Property(e => e.Gpo2029acum).HasColumnType("decimal(10, 2)").HasColumnName("Gpo20_29Acum");
            entity.Property(e => e.Gpo3034).HasColumnType("decimal(10, 2)").HasColumnName("Gpo30_34");
            entity.Property(e => e.Gpo3034acum).HasColumnType("decimal(10, 2)").HasColumnName("Gpo30_34Acum");
            entity.Property(e => e.Gpo3539).HasColumnType("decimal(10, 2)").HasColumnName("Gpo35_39");
            entity.Property(e => e.Gpo3539acum).HasColumnType("decimal(10, 2)").HasColumnName("Gpo35_39Acum");
            entity.Property(e => e.Gpo40).HasColumnType("decimal(10, 2)").HasColumnName("Gpo40_");
            entity.Property(e => e.Gpo40Acum).HasColumnType("decimal(10, 2)").HasColumnName("Gpo40_Acum");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalAcum).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalAcumulado).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalPeriodo).HasColumnType("decimal(10, 2)");
        }
    }
}