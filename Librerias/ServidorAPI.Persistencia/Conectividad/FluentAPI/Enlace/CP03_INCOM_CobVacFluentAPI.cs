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
//             CP03InComplDmHtaFluentAPI: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Enlace;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Enlace
{
    public class CP03_INCOM_CobVacFluentAPI : IEntityTypeConfiguration<CP03_INCOM_CobVac>
    {
        public void Configure(EntityTypeBuilder<CP03_INCOM_CobVac> entity)
        {
            entity.HasKey(e => new { e.CvePresup, e.Consultorio, e.Turno, e.Periodo });
            entity.ToTable("tb_INCompl_CobVac");

            entity.Property(e => e.CvePresup).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.Consultorio).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.Periodo).HasMaxLength(6).IsUnicode(false);
            entity.Property(e => e.CobMenor1).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.CobRotavirus).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.CobVph).HasColumnType("numeric(8, 2)").HasColumnName("CobVPH");
            entity.Property(e => e.Cobde1a4años).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.Cobde1año).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.Cobde6años).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.De0a1mes).HasColumnType("numeric(8, 0)").HasColumnName("de0a1mes");
            entity.Property(e => e.De14meses).HasColumnType("numeric(8, 0)").HasColumnName("de14meses");
            entity.Property(e => e.De1a4años).HasColumnType("numeric(8, 0)").HasColumnName("de1a4años");
            entity.Property(e => e.De1año).HasColumnType("numeric(8, 0)").HasColumnName("de1año");
            entity.Property(e => e.De23meses).HasColumnType("numeric(8, 0)").HasColumnName("de23meses");
            entity.Property(e => e.De2a3mes).HasColumnType("numeric(8, 0)").HasColumnName("de2a3mes");
            entity.Property(e => e.De2años).HasColumnType("numeric(8, 0)").HasColumnName("de2años");
            entity.Property(e => e.De3años).HasColumnType("numeric(8, 0)").HasColumnName("de3años");
            entity.Property(e => e.De4a5mes).HasColumnType("numeric(8, 0)").HasColumnName("de4a5mes");
            entity.Property(e => e.De4años).HasColumnType("numeric(8, 0)").HasColumnName("de4años");
            entity.Property(e => e.De6a8mes).HasColumnType("numeric(8, 0)").HasColumnName("de6a8mes");
            entity.Property(e => e.De6años).HasColumnType("numeric(8, 0)").HasColumnName("de6años");
            entity.Property(e => e.De9a11mes).HasColumnType("numeric(8, 0)").HasColumnName("de9a11mes");
            entity.Property(e => e.DeVph).HasColumnType("numeric(8, 0)").HasColumnName("deVPH");
            entity.Property(e => e.Menorde1).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.OfiMenor1).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.Ofide1a4).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.Ofide1año).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.Ofide6años).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.Pob5oPrim).HasColumnType("numeric(8, 0)").HasColumnName("Pob_5oPrim");
            entity.Property(e => e.Prestador).HasMaxLength(200).IsUnicode(false);
            entity.Property(e => e.Rotavirusde2a11mes).HasColumnType("numeric(8, 0)");
        }
    }
}