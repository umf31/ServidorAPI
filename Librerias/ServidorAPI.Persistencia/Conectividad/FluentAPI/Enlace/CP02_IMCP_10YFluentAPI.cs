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
//               CP02_IMCP_10YFluentAPI: Creado 25-05-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Enlace;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Enlace
{
    public class CP02_IMCP_10YFluentAPI : IEntityTypeConfiguration<CP02_IMCP_10Y>
    {
        public void Configure(EntityTypeBuilder<CP02_IMCP_10Y> entity)
        {
            entity.HasKey(e => new { e.CvePresup, e.Periodo, e.Consultorio, e.Turno });
            entity.ToTable("tb_IMCP_10_SY_UM");
            entity.Property(e => e.CvePresup).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.Periodo).HasMaxLength(6).IsUnicode(false);
            entity.Property(e => e.Consultorio).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.Adultos60).HasColumnType("numeric(18, 0)").HasColumnName("Adultos_60_");
            entity.Property(e => e.Cartilla60).HasColumnName("Cartilla_60_");
            entity.Property(e => e.CobCartilla60).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Cartilla_60_");
            entity.Property(e => e.CobDesnutricion60).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Desnutricion_60_");
            entity.Property(e => e.CobDetColesterol60).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_Colesterol_60_");
            entity.Property(e => e.CobDetDiabetes60).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_Diabetes_60_");
            entity.Property(e => e.CobDetHipertension60).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_Hipertension_60_");
            entity.Property(e => e.CobDetTb60H).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_Tb_60_H");
            entity.Property(e => e.CobInfluenza60).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Influenza_60_");
            entity.Property(e => e.CobNeumo60).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Neumo_60_");
            entity.Property(e => e.CobObesidad60).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Obesidad_60_");
            entity.Property(e => e.CobObesidadCentral60).HasColumnType("decimal(10, 2)").HasColumnName("Cob_ObesidadCentral_60_");
            entity.Property(e => e.CobPesoYtalla60).HasColumnType("decimal(10, 2)").HasColumnName("Cob_PesoYTalla_60_");
            entity.Property(e => e.CobSobrePeso60).HasColumnType("decimal(10, 2)").HasColumnName("Cob_SobrePeso_60_");
            entity.Property(e => e.ColesterolMes60).HasColumnName("Colesterol_Mes_60_");
            entity.Property(e => e.ColesterolMesSospecha60).HasColumnName("Colesterol_Mes_Sospecha_60_");
            entity.Property(e => e.Desnutricion60).HasColumnName("Desnutricion_60_");
            entity.Property(e => e.DetColesterol60).HasColumnName("Det_Colesterol_60_");
            entity.Property(e => e.DetDiabetes60).HasColumnName("Det_Diabetes_60_");
            entity.Property(e => e.DetHipertension60).HasColumnName("Det_Hipertension_60_");
            entity.Property(e => e.DetTb60H).HasColumnName("Det_Tb_60_H");
            entity.Property(e => e.DiabetesMes60).HasColumnName("Diabetes_Mes_60_");
            entity.Property(e => e.DiabetesMesSospecha60).HasColumnName("Diabetes_Mes_Sospecha_60_");
            entity.Property(e => e.HipertensionMes60).HasColumnName("Hipertension_Mes_60_");
            entity.Property(e => e.HipertensionMesSospecha60).HasColumnName("Hipertension_Mes_Sospecha_60_");
            entity.Property(e => e.IndSosColesterol60).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_Colesterol_60_");
            entity.Property(e => e.IndSosDiabetes60).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_Diabetes_60_");
            entity.Property(e => e.IndSosHipertension60).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_Hipertension_60_");
            entity.Property(e => e.IndSosTb60).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_Tb_60_");
            entity.Property(e => e.Influenza60).HasColumnName("Influenza_60_");
            entity.Property(e => e.MedicionCintura60).HasColumnName("Medicion_Cintura_60_");
            entity.Property(e => e.Neumo60).HasColumnName("Neumo_60_");
            entity.Property(e => e.Obesidad60).HasColumnName("Obesidad_60_");
            entity.Property(e => e.ObesidadCentral60).HasColumnName("Obesidad_Central_60_");
            entity.Property(e => e.PesoYtalla60).HasColumnName("PesoYTalla_60_");
            entity.Property(e => e.Prestador).HasMaxLength(150).IsUnicode(false);
            entity.Property(e => e.SobrePeso60).HasColumnName("SobrePeso_60_");
            entity.Property(e => e.TbMes60).HasColumnName("Tb_Mes_60_");
            entity.Property(e => e.TbMesSospecha60).HasColumnName("Tb_Mes_Sospecha_60_");
        }
    }
}