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
//               CP02_IMCP_09HFluentAPI: Creado 25-05-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Enlace;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Enlace
{
    public class CP02_IMCP_09HFluentAPI : IEntityTypeConfiguration<CP02_IMCP_09H>
    {
        public void Configure(EntityTypeBuilder<CP02_IMCP_09H> entity)
        {
            entity.HasKey(e => new { e.CvePresup, e.Periodo, e.Consultorio, e.Turno });
            entity.ToTable("tb_IMCP_09_SH_UM");

            entity.Property(e => e.CvePresup).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.Periodo).HasMaxLength(6).IsUnicode(false);
            entity.Property(e => e.Consultorio).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.AdultosH2059).HasColumnType("numeric(18, 0)").HasColumnName("AdultosH_20_59");
            entity.Property(e => e.Cartilla2059H).HasColumnName("Cartilla_20_59_H");
            entity.Property(e => e.CobCartilla2059H).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Cartilla_20_59_H");
            entity.Property(e => e.CobDetColesterol4559H).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_Colesterol_45_59_H");
            entity.Property(e => e.CobDetDiabetes4559H).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_Diabetes_45_59_H");
            entity.Property(e => e.CobDetHipertension3059H).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_Hipertension_30_59_H");
            entity.Property(e => e.CobDetTb2059H).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Det_Tb_20_59_H");
            entity.Property(e => e.CobInfluenza5059H).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Influenza_50_59_H");
            entity.Property(e => e.CobNeumo5059H).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Neumo_50_59_H");
            entity.Property(e => e.CobObesidad2059H).HasColumnType("decimal(10, 2)").HasColumnName("Cob_Obesidad_20_59_H");
            entity.Property(e => e.CobObesidadCentral2059H).HasColumnType("decimal(10, 2)").HasColumnName("Cob_ObesidadCentral_20_59_H");
            entity.Property(e => e.CobPesoYtalla2059H).HasColumnType("decimal(10, 2)").HasColumnName("Cob_PesoYTalla_20_59_H");
            entity.Property(e => e.CobSobrePeso2059H).HasColumnType("decimal(10, 2)").HasColumnName("Cob_SobrePeso_20_59_H");
            entity.Property(e => e.CobSr2039H).HasColumnType("decimal(10, 2)").HasColumnName("Cob_SR_20_39_H");
            entity.Property(e => e.ColesterolMes3059H).HasColumnName("Colesterol_Mes_30_59_H");
            entity.Property(e => e.ColesterolMesSospecha3059H).HasColumnName("Colesterol_Mes_Sospecha_30_59_H");
            entity.Property(e => e.DetColesterol4559H).HasColumnName("Det_Colesterol_45_59_H");
            entity.Property(e => e.DetDiabetes4559H).HasColumnName("Det_Diabetes_45_59_H");
            entity.Property(e => e.DetHipertension3059H).HasColumnName("Det_Hipertension_30_59_H");
            entity.Property(e => e.DetTb2059H).HasColumnName("Det_Tb_20_59_H");
            entity.Property(e => e.DiabetesMes4559H).HasColumnName("Diabetes_Mes_45_59_H");
            entity.Property(e => e.DiabetesMesSospecha4559H).HasColumnName("Diabetes_Mes_Sospecha_45_59_H");
            entity.Property(e => e.HipertensionMes3059H).HasColumnName("Hipertension_Mes_30_59_H");
            entity.Property(e => e.HipertensionMesSospecha3059H).HasColumnName("Hipertension_Mes_Sospecha_30_59_H");
            entity.Property(e => e.IndSosColesterol4559H).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_Colesterol_45_59_H");
            entity.Property(e => e.IndSosDiabetes4559H).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_Diabetes_45_59_H");
            entity.Property(e => e.IndSosHipertension3059H).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_Hipertension_30_59_H");
            entity.Property(e => e.IndSosTb2059H).HasColumnType("decimal(10, 2)").HasColumnName("IndSos_Tb_20_59_H");
            entity.Property(e => e.Influenza5059H).HasColumnName("Influenza_50_59_H");
            entity.Property(e => e.MedicionCintura2059H).HasColumnName("Medicion_Cintura_20_59_H");
            entity.Property(e => e.Neumo5059H).HasColumnName("Neumo_50_59_H");
            entity.Property(e => e.Obesidad2059H).HasColumnName("Obesidad_20_59_H");
            entity.Property(e => e.ObesidadCentral2059H).HasColumnName("Obesidad_Central_20_59_H");
            entity.Property(e => e.PesoYtalla2059H).HasColumnName("PesoYTalla_20_59_H");
            entity.Property(e => e.PobH2039).HasColumnType("numeric(21, 0)").HasColumnName("PobH_20_39");
            entity.Property(e => e.PobH3059).HasColumnType("numeric(18, 0)").HasColumnName("PobH_30_59");
            entity.Property(e => e.PobH4559).HasColumnType("numeric(20, 0)").HasColumnName("PobH_45_59");
            entity.Property(e => e.PobH5059).HasColumnType("numeric(19, 0)").HasColumnName("PobH_50_59");
            entity.Property(e => e.Prestador).HasMaxLength(150).IsUnicode(false);
            entity.Property(e => e.SobrePeso2059H).HasColumnName("SobrePeso_20_59_H");
            entity.Property(e => e.Sr2039H).HasColumnName("SR_20_39_H");
            entity.Property(e => e.TbMes2059H).HasColumnName("Tb_Mes_20_59_H");
            entity.Property(e => e.TbMesSospecha2059H).HasColumnName("Tb_Mes_Sospecha_20_59_H");
        }
    }
}