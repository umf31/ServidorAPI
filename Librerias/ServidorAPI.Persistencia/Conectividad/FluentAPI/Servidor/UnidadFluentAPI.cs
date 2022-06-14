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
//                  UnidadFluentAPI: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Servidor;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Servidor
{
    public class UnidadFluentAPI : IEntityTypeConfiguration<Unidad>
    {
        public void Configure(EntityTypeBuilder<Unidad> builder)
        {
            builder.ToTable("Unidades", "catalogo");
            builder.HasIndex(e => e.DelegacionId, "IX_Unidades_DelegacionId");
            builder.HasIndex(e => e.ColoniaId, "IX_Unidades_ColoniaId");
            builder.HasIndex(e => e.MunicipioId, "IX_Unidades_MunicipioId");
            builder.HasIndex(e => e.UnidadTipoId, "IX_Unidades_UnidadTipoId");
            builder.HasIndex(e => e.VialidadId, "IX_Unidades_VialidadId");
            builder.HasIndex(e => e.StatusId, "IX_Unidades_StatusId");

            builder.HasOne(d => d.Delegacion).WithMany(p => p.Unidades).HasForeignKey(d => d.DelegacionId);
            builder.HasOne(d => d.Colonia).WithMany(p => p.Unidades).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.ColoniaId);
            builder.HasOne(d => d.Municipio).WithMany(p => p.Unidades).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.MunicipioId);
            builder.HasOne(d => d.UnidadTipo).WithMany(p => p.Unidades).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.UnidadTipoId);
            builder.HasOne(d => d.Vialidad).WithMany(p => p.Unidades).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.VialidadId);
            builder.HasOne(d => d.Status).WithMany(p => p.Unidades).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.StatusId);

            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.Nombre).HasColumnOrder(1).IsRequired().IsUnicode(false);
            builder.Property(e => e.DelegacionId).HasColumnOrder(2).IsRequired();
            builder.Property(e => e.NumUnidad).HasColumnOrder(3).IsRequired();
            builder.Property(e => e.Localidad).HasColumnOrder(4).IsRequired().IsUnicode(false);
            builder.Property(e => e.ClavePresupuestal).HasColumnOrder(5).IsRequired().HasMaxLength(12).IsUnicode(false);
            builder.Property(e => e.UnidadTipoId).HasColumnOrder(6).IsRequired();
            builder.Property(e => e.VialidadId).HasColumnOrder(7).IsRequired();
            builder.Property(e => e.Calle).HasColumnOrder(8).IsRequired().IsUnicode(false);
            builder.Property(e => e.Numero).HasColumnOrder(9).IsRequired().HasMaxLength(10).IsUnicode(false);
            builder.Property(e => e.Telefono).HasColumnOrder(10).HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.ColoniaId).HasColumnOrder(11).IsRequired();
            builder.Property(e => e.MunicipioId).HasColumnOrder(12).IsRequired();
            builder.Property(e => e.Latitud).HasColumnOrder(13).HasColumnType("decimal(9, 6)");
            builder.Property(e => e.Longitud).HasColumnOrder(14).HasColumnType("decimal(9, 6)");
            builder.Property(e => e.Geolocalizacion).HasColumnOrder(15).IsUnicode(false);
            builder.Property(e => e.Imagen).HasColumnOrder(16).IsUnicode(false);
            builder.Property(e => e.FechaCreacion).HasColumnOrder(17).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnOrder(18).HasColumnType("datetime");
            builder.Property(e => e.UsuarioMod).HasColumnOrder(19).IsUnicode(false);
            builder.Property(e => e.StatusId).HasColumnOrder(20).IsRequired();
        }
    }
}