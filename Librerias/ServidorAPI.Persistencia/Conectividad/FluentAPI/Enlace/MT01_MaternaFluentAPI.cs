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
//              MT01_MaternaFluentAPI: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Enlace;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Enlace
{
    public class MT01_MaternaFluentAPI : IEntityTypeConfiguration<MT01_Materna>
    {
        public void Configure(EntityTypeBuilder<MT01_Materna> entity)
        {
            entity.HasKey(e => new { e.Deleg, e.CvePresup, e.Periodo, e.Parte, e.SubT, e.Gpo, e.Cat, e.SubC, e.OcaServ, e.Orden });
            entity.ToTable("tb_Materna_UM");

            entity.Property(e => e.Deleg).HasMaxLength(2).IsUnicode(false);
            entity.Property(e => e.CvePresup).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.Periodo).HasMaxLength(6).IsUnicode(false);
            entity.Property(e => e.Parte).HasMaxLength(1).IsUnicode(false);
            entity.Property(e => e.SubT).HasMaxLength(1).IsUnicode(false);
            entity.Property(e => e.Gpo).HasMaxLength(2).IsUnicode(false);
            entity.Property(e => e.Cat).HasMaxLength(3).IsUnicode(false);
            entity.Property(e => e.SubC).HasMaxLength(1).IsUnicode(false);
            entity.Property(e => e.OcaServ).HasMaxLength(3).IsUnicode(false);
            entity.Property(e => e.Orden).HasMaxLength(1).IsUnicode(false);
            entity.Property(e => e.Gpo1014).HasColumnName("Gpo10_14");
            entity.Property(e => e.Gpo1519).HasColumnName("Gpo15_19");
            entity.Property(e => e.Gpo2029).HasColumnName("Gpo20_29");
            entity.Property(e => e.Gpo3034).HasColumnName("Gpo30_34");
            entity.Property(e => e.Gpo3539).HasColumnName("Gpo35_39");
            entity.Property(e => e.Gpo40).HasColumnName("Gpo40_");
        }
    }
}