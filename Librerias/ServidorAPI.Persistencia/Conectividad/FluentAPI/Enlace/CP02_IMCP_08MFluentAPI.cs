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
//               CP02_IMCP_08MFluentAPI: Creado 25-05-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Enlace;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Enlace
{
    public class CP02_IMCP_08MFluentAPI : IEntityTypeConfiguration<CP02_IMCP_08M>
    {
        public void Configure(EntityTypeBuilder<CP02_IMCP_08M> entity)
        {
            entity.HasKey(e => new { e.CvePresup, e.Periodo, e.Consultorio, e.Turno });
            entity.ToTable("tb_IMCP_08_SM_UM");

            entity.Property(e => e.CvePresup).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.Periodo).HasMaxLength(6).IsUnicode(false);
            entity.Property(e => e.Consultorio).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.AdultosM2059).HasColumnType("numeric(18, 0)").HasColumnName("AdultosM_20_59");
            entity.Property(e => e.CaCuMes2564).HasColumnName("CaCu_Mes_25_64");
            entity.Property(e => e.CaCuMesSospecha2564).HasColumnName("CaCu_Mes_Sospecha_25_64");
            entity.Property(e => e.CaMamaMes2569).HasColumnName("CaMama_Mes_25_69");
            entity.Property(e => e.CaMamaMesSospecha2569).HasColumnName("CaMama_Mes_Sospecha_25_69");
            entity.Property(e => e.Cartilla2059M).HasColumnName("Cartilla_20_59_M");
            entity.Property(e => e.CobCartilla2059M).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Cartilla_20_59_M");
            entity.Property(e => e.CobDetCaCu2564).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_CaCu_25_64");
            entity.Property(e => e.CobDetCaMama2569).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_CaMama_25_69");
            entity.Property(e => e.CobDetColesterol4559M).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_Colesterol_45_59_M");
            entity.Property(e => e.CobDetDiabetes4559M).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_Diabetes_45_59_M");
            entity.Property(e => e.CobDetHipertension3059M).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_Hipertension_30_59_M");
            entity.Property(e => e.CobDetMastografia5069).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_Mastografia_50_69");
            entity.Property(e => e.CobDetTb2059M).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_Tb_20_59_M");
            entity.Property(e => e.CobInfluenza5059M).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Influenza_50_59_M");
            entity.Property(e => e.CobNeumo5059M).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Neumo_50_59_M");
            entity.Property(e => e.CobObesidad2059M).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Obesidad_20_59_M");
            entity.Property(e => e.CobObesidadCentral2059M).HasColumnType("decimal(10, 2)").HasColumnName("Cob_ObesidadCentral_20_59_M");
            entity.Property(e => e.CobPesoYtalla2059M).HasColumnType("decimal(10, 2)").HasColumnName("Cob_PesoYTalla_20_59_M");
            entity.Property(e => e.CobSobrePeso2059M).HasColumnType("decimal(10, 2)").HasColumnName("Cob_SobrePeso_20_59_M");
            entity.Property(e => e.CobSr2039M).HasColumnType("decimal(10, 2)").HasColumnName("Cob_SR_20_39_M");
            entity.Property(e => e.ColesterolMes3059M).HasColumnName("Colesterol_Mes_30_59_M");
            entity.Property(e => e.ColesterolMesSospecha3059M).HasColumnName("Colesterol_Mes_Sospecha_30_59_M");
            entity.Property(e => e.DetCaCu2564).HasColumnName("Det_CaCu_25_64");
            entity.Property(e => e.DetCaMama2569).HasColumnName("Det_CaMama_25_69");
            entity.Property(e => e.DetColesterol4559M).HasColumnName("Det_Colesterol_45_59_M");
            entity.Property(e => e.DetDiabetes4559M).HasColumnName("Det_Diabetes_45_59_M");
            entity.Property(e => e.DetHipertension3059M).HasColumnName("Det_Hipertension_30_59_M");
            entity.Property(e => e.DetMastografia5069).HasColumnName("Det_Mastografia_50_69");
            entity.Property(e => e.DetTb2059M).HasColumnName("Det_Tb_20_59_M");
            entity.Property(e => e.DiabetesMes4559M).HasColumnName("Diabetes_Mes_45_59_M");
            entity.Property(e => e.DiabetesMesSospecha4559M).HasColumnName("Diabetes_Mes_Sospecha_45_59_M");
            entity.Property(e => e.HipertensionMes3059M).HasColumnName("Hipertension_Mes_30_59_M");
            entity.Property(e => e.HipertensionMesSospecha3059M).HasColumnName("Hipertension_Mes_Sospecha_30_59_M");
            entity.Property(e => e.IndSosCaCu2564).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_CaCU_25_64");
            entity.Property(e => e.IndSosCaMama2569).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_CaMama_25_69");
            entity.Property(e => e.IndSosColesterol4559M).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_Colesterol_45_59_M");
            entity.Property(e => e.IndSosDiabetes4559M).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_Diabetes_45_59_M");
            entity.Property(e => e.IndSosHipertension3059M).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_Hipertension_30_59_M");
            entity.Property(e => e.IndSosMastografia5069).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_Mastografia_50_69");
            entity.Property(e => e.IndSosTb2059M).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_Tb_20_59_M");
            entity.Property(e => e.Influenza5059M).HasColumnName("Influenza_50_59_M");
            entity.Property(e => e.MastografiaMes5069).HasColumnName("Mastografia_Mes_50_69");
            entity.Property(e => e.MastografiaMesSospecha5069).HasColumnName("Mastografia_Mes_Sospecha_50_69");
            entity.Property(e => e.MedicionCintura2059M).HasColumnName("Medicion_Cintura_20_59_M");
            entity.Property(e => e.Neumo5059M).HasColumnName("Neumo_50_59_M");
            entity.Property(e => e.Obesidad2059M).HasColumnName("Obesidad_20_59_M");
            entity.Property(e => e.ObesidadCentral2059M).HasColumnName("Obesidad_Central_20_59_M");
            entity.Property(e => e.PesoYtalla2059M).HasColumnName("PesoYTalla_20_59_M");
            entity.Property(e => e.PobM2039).HasColumnType("numeric(21, 0)").HasColumnName("PobM_20_39");
            entity.Property(e => e.PobM2564).HasColumnType("numeric(20, 0)").HasColumnName("PobM_25_64");
            entity.Property(e => e.PobM2569).HasColumnType("numeric(21, 0)").HasColumnName("PobM_25_69");
            entity.Property(e => e.PobM3059).HasColumnType("numeric(18, 0)").HasColumnName("PobM_30_59");
            entity.Property(e => e.PobM4559).HasColumnType("numeric(20, 0)").HasColumnName("PobM_45_59");
            entity.Property(e => e.PobM5059).HasColumnType("numeric(19, 0)").HasColumnName("PobM_50_59");
            entity.Property(e => e.PobM5069).HasColumnType("numeric(21, 0)").HasColumnName("PobM_50_69");
            entity.Property(e => e.Prestador).HasMaxLength(150).IsUnicode(false);
            entity.Property(e => e.SobrePeso2059M).HasColumnName("SobrePeso_20_59_M");
            entity.Property(e => e.Sr2039M).HasColumnName("SR_20_39_M");
            entity.Property(e => e.TbMes2059M).HasColumnName("Tb_Mes_20_59_M");
            entity.Property(e => e.TbMesSospecha2059M).HasColumnName("Tb_Mes_Sospecha_20_59_M");
        }
    }
}