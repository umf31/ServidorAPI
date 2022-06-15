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
//             CP03_INCOM_OtrasCobFluentAPI: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Enlace;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Enlace
{
    public class CP03_INCOM_OtrasCobFluentAPI : IEntityTypeConfiguration<CP03_INCOM_OtrasCob>
    {
        public void Configure(EntityTypeBuilder<CP03_INCOM_OtrasCob> entity)
        {
            entity.HasKey(e => new { e.CvePresup, e.Consultorio, e.Turno, e.Periodo });
            entity.ToTable("tb_INCompl_OtrasCob");

            entity.Property(e => e.CvePresup).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.Consultorio).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.Periodo).HasMaxLength(6).IsUnicode(false);
            entity.Property(e => e.CobGeriatrimss70YMas).HasColumnType("numeric(8, 2)").HasColumnName("CobGeriatrimss_70_y_mas");
            entity.Property(e => e.CobMasto40A49).HasColumnType("numeric(8, 2)").HasColumnName("CobMasto_40_a_49");
            entity.Property(e => e.CobTamizNenoatal).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.Geriatrimss70YMas).HasColumnType("numeric(8, 0)").HasColumnName("Geriatrimss_70_y_mas");
            entity.Property(e => e.GeriatrimssMes70YMas).HasColumnType("numeric(8, 0)").HasColumnName("Geriatrimss_Mes_70_y_mas");
            entity.Property(e => e.Masto40A49).HasColumnType("numeric(8, 0)").HasColumnName("Masto_40_a_49");
            entity.Property(e => e.MastoMes40A49).HasColumnType("numeric(8, 0)").HasColumnName("Masto_Mes_40_a_49");
            entity.Property(e => e.Menores1).HasColumnType("numeric(8, 0)").HasColumnName("Menores_1");
            entity.Property(e => e.Pob40A49M).HasColumnType("numeric(8, 0)").HasColumnName("Pob_40_a_49_M");
            entity.Property(e => e.Pob70YMas).HasColumnType("numeric(8, 0)").HasColumnName("Pob_70_y_mas");
            entity.Property(e => e.Prestador).HasMaxLength(200).IsUnicode(false);
            entity.Property(e => e.SosCaidas).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.SosCaidasValor).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.SosCogniti).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.SosCognitiValor).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.SosDefi).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.SosDefiValor).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.SosFenil).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.SosFenilValor).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.SosGalacto).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.SosGalactoValor).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.SosHiper).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.SosHiperValor).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.SosHipo).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.SosHipoValor).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.SosInmovil).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.SosInmovilValor).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.SosMasto40A49).HasColumnType("numeric(8, 2)").HasColumnName("SosMasto_40_a_49");
            entity.Property(e => e.SosMastoValor40A49).HasColumnType("numeric(8, 0)").HasColumnName("SosMastoValor_40_a_49");
            entity.Property(e => e.SosUrinari).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.SosUrinariValor).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.TamizNenoatal).HasColumnType("numeric(8, 0)");
            entity.Property(e => e.TamizNenoatalMes).HasColumnType("numeric(8, 0)").HasColumnName("TamizNenoatal_Mes");
        }
    }
}