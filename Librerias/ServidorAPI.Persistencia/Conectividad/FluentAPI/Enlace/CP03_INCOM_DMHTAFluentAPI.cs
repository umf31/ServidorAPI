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
    public class CP03_INCOM_DMHTAFluentAPI : IEntityTypeConfiguration<CP03_INCOM_DMHTA>
    {
        public void Configure(EntityTypeBuilder<CP03_INCOM_DMHTA> builder)
        {
            builder.ToTable("tb_INCompl_DMHTACol");
            builder.HasKey(e => new { e.CvePresup, e.Consultorio, e.Turno, e.Periodo });

            builder.Property(e => e.CvePresup).HasMaxLength(12).IsUnicode(false);
            builder.Property(e => e.Consultorio).HasMaxLength(4).IsUnicode(false);
            builder.Property(e => e.Periodo).HasMaxLength(6).IsUnicode(false);
            builder.Property(e => e.CobColesterol20A44H).HasColumnType("numeric(8, 2)").HasColumnName("CobColesterol_20_a_44_H");
            builder.Property(e => e.CobColesterol20A44M).HasColumnType("numeric(8, 2)").HasColumnName("CobColesterol_20_a_44_M");
            builder.Property(e => e.CobColesterol45A74).HasColumnType("numeric(8, 2)").HasColumnName("CobColesterol_45_a_74");
            builder.Property(e => e.CobDiabetes20A44H).HasColumnType("numeric(8, 2)").HasColumnName("CobDiabetes_20_a_44_H");
            builder.Property(e => e.CobDiabetes20A44M).HasColumnType("numeric(8, 2)").HasColumnName("CobDiabetes_20_a_44_M");
            builder.Property(e => e.CobDiabetes20YMas).HasColumnType("numeric(8, 2)").HasColumnName("CobDiabetes_20_y_mas");
            builder.Property(e => e.CobHipertension20A29H).HasColumnType("numeric(8, 2)").HasColumnName("CobHipertension_20_a_29_H");
            builder.Property(e => e.CobHipertension20A29M).HasColumnType("numeric(8, 2)").HasColumnName("CobHipertension_20_a_29_M");
            builder.Property(e => e.CobHipertension20YMas).HasColumnType("numeric(8, 2)").HasColumnName("CobHipertension_20_y_mas");
            builder.Property(e => e.Colesterol20A44H).HasColumnType("numeric(8, 0)").HasColumnName("Colesterol_20_a_44_H");
            builder.Property(e => e.Colesterol20A44M).HasColumnType("numeric(8, 0)").HasColumnName("Colesterol_20_a_44_M");
            builder.Property(e => e.Colesterol45A74).HasColumnType("numeric(8, 0)").HasColumnName("Colesterol_45_a_74");
            builder.Property(e => e.ColesterolMes20A44H).HasColumnType("numeric(8, 0)").HasColumnName("Colesterol_Mes_20_a_44_H");
            builder.Property(e => e.ColesterolMes20A44M).HasColumnType("numeric(8, 0)").HasColumnName("Colesterol_Mes_20_a_44_M");
            builder.Property(e => e.ColesterolMes45A74).HasColumnType("numeric(8, 0)").HasColumnName("Colesterol_Mes_45_a_74");
            builder.Property(e => e.ColesterolMesSospecha20A44H).HasColumnType("numeric(8, 0)").HasColumnName("Colesterol_Mes_Sospecha_20_a_44_H");
            builder.Property(e => e.ColesterolMesSospecha20A44M).HasColumnType("numeric(8, 0)").HasColumnName("Colesterol_Mes_Sospecha_20_a_44_M");
            builder.Property(e => e.ColesterolMesSospecha45A74).HasColumnType("numeric(8, 0)").HasColumnName("Colesterol_Mes_Sospecha_45_a_74");
            builder.Property(e => e.Diabetes20A44H).HasColumnType("numeric(8, 0)").HasColumnName("Diabetes_20_a_44_H");
            builder.Property(e => e.Diabetes20A44M).HasColumnType("numeric(8, 0)").HasColumnName("Diabetes_20_a_44_M");
            builder.Property(e => e.Diabetes20YMas).HasColumnType("numeric(8, 0)").HasColumnName("Diabetes_20_y_mas");
            builder.Property(e => e.Diabetes20YMas2).HasColumnType("numeric(8, 0)").HasColumnName("Diabetes_20_y_mas_2");
            builder.Property(e => e.DiabetesMes20A44H).HasColumnType("numeric(8, 0)").HasColumnName("Diabetes_Mes_20_a_44_H");
            builder.Property(e => e.DiabetesMes20A44M).HasColumnType("numeric(8, 0)").HasColumnName("Diabetes_Mes_20_a_44_M");
            builder.Property(e => e.DiabetesMesSospecha20A44H).HasColumnType("numeric(8, 0)").HasColumnName("Diabetes_Mes_Sospecha_20_a_44_H");
            builder.Property(e => e.DiabetesMesSospecha20A44M).HasColumnType("numeric(8, 0)").HasColumnName("Diabetes_Mes_Sospecha_20_a_44_M");
            builder.Property(e => e.Hipertension20A29H).HasColumnType("numeric(8, 0)").HasColumnName("Hipertension_20_a_29_H");
            builder.Property(e => e.Hipertension20A29M).HasColumnType("numeric(8, 0)").HasColumnName("Hipertension_20_a_29_M");
            builder.Property(e => e.Hipertension20YMas).HasColumnType("numeric(8, 0)").HasColumnName("Hipertension_20_y_mas");
            builder.Property(e => e.Hipertension20YMas2).HasColumnType("numeric(8, 0)").HasColumnName("Hipertension_20_y_mas_2");
            builder.Property(e => e.HipertensionMes20A29H).HasColumnType("numeric(8, 0)").HasColumnName("Hipertension_Mes_20_a_29_H");
            builder.Property(e => e.HipertensionMes20A29M).HasColumnType("numeric(8, 0)").HasColumnName("Hipertension_Mes_20_a_29_M");
            builder.Property(e => e.HipertensionMesSospecha20A29H).HasColumnType("numeric(8, 0)").HasColumnName("Hipertension_Mes_Sospecha_20_a_29_H");
            builder.Property(e => e.HipertensionMesSospecha20A29M).HasColumnType("numeric(8, 0)").HasColumnName("Hipertension_Mes_Sospecha_20_a_29_M");
            builder.Property(e => e.Pob20A29H).HasColumnType("numeric(8, 0)").HasColumnName("Pob_20_a_29_H");
            builder.Property(e => e.Pob20A29M).HasColumnType("numeric(8, 0)").HasColumnName("Pob_20_a_29_M");
            builder.Property(e => e.Pob20A44H).HasColumnType("numeric(8, 0)").HasColumnName("Pob_20_a_44_H");
            builder.Property(e => e.Pob20A44M).HasColumnType("numeric(8, 0)").HasColumnName("Pob_20_a_44_M");
            builder.Property(e => e.Pob20YMas).HasColumnType("numeric(8, 0)").HasColumnName("Pob_20_y_mas");
            builder.Property(e => e.Pob45A74).HasColumnType("numeric(8, 0)").HasColumnName("Pob_45_a_74");
            builder.Property(e => e.PobH2044).HasColumnType("numeric(8, 0)").HasColumnName("PobH_20_44");
            builder.Property(e => e.PobM2044).HasColumnType("numeric(8, 0)").HasColumnName("PobM_20_44");
            builder.Property(e => e.Prestador).HasMaxLength(200).IsUnicode(false);
            builder.Property(e => e.SosColesterol20A44H).HasColumnType("numeric(8, 2)").HasColumnName("SosColesterol_20_a_44_H");
            builder.Property(e => e.SosColesterol20A44M).HasColumnType("numeric(8, 2)").HasColumnName("SosColesterol_20_a_44_M");
            builder.Property(e => e.SosColesterol45A74).HasColumnType("numeric(8, 2)").HasColumnName("SosColesterol_45_a_74");
            builder.Property(e => e.SosDiabetes20A44H).HasColumnType("numeric(8, 2)").HasColumnName("SosDiabetes_20_a_44_H");
            builder.Property(e => e.SosDiabetes20A44M).HasColumnType("numeric(8, 2)").HasColumnName("SosDiabetes_20_a_44_M");
            builder.Property(e => e.SosHipertension20A29H).HasColumnType("numeric(8, 2)").HasColumnName("SosHipertension_20_a_29_H");
            builder.Property(e => e.SosHipertension20A29M).HasColumnType("numeric(8, 2)").HasColumnName("SosHipertension_20_a_29_M");
        }
    }
}