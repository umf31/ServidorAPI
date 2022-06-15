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
//                CP04_IMCP20FluentAPI: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Enlace;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Enlace
{
    public class CP04_IMCP20FluentAPI : IEntityTypeConfiguration<CP04_IMCP20>
    {
        public void Configure(EntityTypeBuilder<CP04_IMCP20> builder)
        {
            builder.HasKey(e => new { e.CvePresup, e.Periodo, e.Consultorio, e.Turno });
            builder.ToTable("tb_IMCP_20_SP_UM");

            builder.Property(e => e.CvePresup).HasMaxLength(12).IsUnicode(false);
            builder.Property(e => e.Periodo).HasMaxLength(6).IsUnicode(false);
            builder.Property(e => e.Consultorio).HasMaxLength(4).IsUnicode(false);
            builder.Property(e => e.DetDiabetes20).HasColumnName("Det_Diabetes_20_");
            builder.Property(e => e.DetHipertension20).HasColumnName("Det_Hipertension_20_");
            builder.Property(e => e.DiabetesMes20).HasColumnName("Diabetes_Mes_20_");
            builder.Property(e => e.DiabetesMesSospecha20).HasColumnName("Diabetes_Mes_Sospecha_20_");
            builder.Property(e => e.DmSospechaConfirmados20).HasColumnName("DM_Sospecha_Confirmados_20_");
            builder.Property(e => e.HipertensionMes20).HasColumnName("Hipertension_Mes_20_");
            builder.Property(e => e.HipertensionMesSospecha20).HasColumnName("Hipertension_Mes_Sospecha_20_");
            builder.Property(e => e.HtaSospechaConfirmados20).HasColumnName("HTA_Sospecha_Confirmados_20_");
            builder.Property(e => e.IndCfmDm20).HasColumnType("decimal(10, 2)").HasColumnName("IndCfm_DM_20_");
            builder.Property(e => e.IndCfmHta20).HasColumnType("decimal(10, 2)").HasColumnName("IndCfm_HTA_20_");
        }
    }
}