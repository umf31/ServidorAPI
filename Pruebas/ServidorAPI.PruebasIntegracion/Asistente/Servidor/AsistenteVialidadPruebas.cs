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
//               https://github.com/umf31/ServidorAPI
//             AsistenteVialidadPruebas: Creado 14-06-2022
//=======================================================================

#endregion

using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Persistencia.Asistente.Servidor;
using ServidorAPI.PruebasIntegracion.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServidorAPI.PruebasIntegracion.Asistente.Servidor
{
    public class AsistenteVialidadPruebas : IClassFixture<SimuladorBaseDatos>
    {
        private SimuladorBaseDatos Simulador { get; }

        public AsistenteVialidadPruebas(SimuladorBaseDatos simulador)
        {
            Simulador = simulador;
        }

        #region => Pruebas de Integración Vialidad AsistenteBase

        [Fact]
        public async Task ObtenerTodo_VialidadBase_SuperaPrueba_SiRetornaTodosLosDatos()
        {
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteVialidad(db);

            var entidad = await asistente.ObtenerTodo();
            Assert.Equal(51, entidad.Count());
        }

        [Fact]
        public async Task ObtenerPorId_VialidadBase_SuperaPrueba_SiRetornaElementoSeleccionado()
        {
            using var db = Simulador.CrearContexto();
            var id = 1;
            var asistente = new AsistenteVialidad(db);

            var entidad = await asistente.ObtenerPorId(id);
            Assert.Equal(entidad.Id, id);
        }

        [Fact]
        public async Task ObtenerPorId_VialidadBase_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var id = 52;
            var asistente = new AsistenteVialidad(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(id));
        }

        [Fact]
        public async Task Insertar_VialidadBase_SuperaPrueba_InsertaEntidad()
        {
            using (var transaction = Simulador.Conexion.BeginTransaction())
            {
                var entidadId = 0;
                var entidadInsertar = new Vialidad
                {
                    Nombre = "Vialidad 101",
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    UsuarioMod = "10716076",
                    StatusId = 1
                };
                using (var db = Simulador.CrearContexto(transaction))
                {
                    var asistente = new AsistenteVialidad(db);

                    await asistente.Insertar(entidadInsertar);
                    await db.SaveChangesAsync();
                    entidadId = entidadInsertar.Id;
                }
                using (var db = Simulador.CrearContexto(transaction))
                {
                    var asistente = new AsistenteVialidad(db);

                    var entidad = await asistente.ObtenerPorId(entidadId);

                    Assert.NotNull(entidad);
                    Assert.Equal(entidadInsertar.Nombre, entidad.Nombre);
                    Assert.Equal(entidadInsertar.FechaCreacion, entidad.FechaCreacion);
                    Assert.Equal(entidadInsertar.FechaModificacion, entidad.FechaModificacion);
                    Assert.Equal(entidadInsertar.UsuarioMod, entidad.UsuarioMod);
                    Assert.Equal(entidadInsertar.StatusId, entidad.StatusId);
                }
            }
        }

        [Fact]
        public async Task Actualizar_VialidadBase_SuperaPrueba_ActualizaEstado()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 1;
            var matricula = "10716076";

            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteVialidad(db);

                await asistente.Actualizar(entidadId, matricula);
                await db.SaveChangesAsync();
                entidadId = 1;
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteVialidad(db);

                var entidad = await asistente.ObtenerPorId(entidadId);

                Assert.NotNull(entidad);
                Assert.Equal(2, entidad.StatusId);
            }
        }

        [Fact]
        public async Task Editar_VialidadBase_SuperaPrueba_EditaEntidad()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 1;
            var entidadEditar = new Vialidad
            {
                Nombre = "Editar 1",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                UsuarioMod = "1706411",
                StatusId = 1
            };
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteVialidad(db);

                await asistente.Editar(entidadEditar);
                await db.SaveChangesAsync();
                entidadId = entidadEditar.Id;
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteVialidad(db);

                var entidad = await asistente.ObtenerPorId(entidadId);

                Assert.NotNull(entidad);
                Assert.Equal(entidadEditar.Nombre, entidad.Nombre);
                Assert.Equal(entidadEditar.FechaCreacion, entidad.FechaCreacion);
                Assert.Equal(entidadEditar.FechaModificacion, entidad.FechaModificacion);
                Assert.Equal(entidadEditar.UsuarioMod, entidad.UsuarioMod);
                Assert.Equal(entidadEditar.StatusId, entidad.StatusId);
            }
        }

        [Fact]
        public async Task Eliminar_VialidadBase_SuperaPrueba_EliminaCuentaMaestra()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 51;
            var matricula = "10716076";
            var empleadoRol = "SadimMaster";
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteVialidad(db);
                if (empleadoRol == "SadimMaster")
                {
                    await asistente.Eliminar(entidadId);
                    await db.SaveChangesAsync();
                }
                else
                {
                    await asistente.Actualizar(entidadId, matricula);
                    await db.SaveChangesAsync();
                    entidadId = 1;
                }
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteVialidad(db);
                await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(entidadId));
            }
        }

        [Fact]
        public async Task Eliminar_VialidadBase_SuperaPrueba_ActualizaEntidad()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 51;
            var matricula = "10716076";
            var empleadoRol = "Directivo";
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteVialidad(db);
                if (empleadoRol == "Directivo")
                {
                    await asistente.Eliminar(entidadId);
                    await db.SaveChangesAsync();
                }
                else
                {
                    await asistente.Actualizar(entidadId, matricula);
                    await db.SaveChangesAsync();
                    entidadId = 1;
                }
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteVialidad(db);
                await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(entidadId));
            }
        }

        [Fact]
        public async Task Eliminar_VialidadBase_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var id = 52;
            var asistente = new AsistenteVialidad(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.Eliminar(id));
        }

        [Fact]
        public async Task ExisteEntidadPorId_VialidadBase_SuperaPrueba_SiExisteEntidad()
        {
            var entidadId = 1;
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteVialidad(db);

            var entidad = await asistente.ExisteEntidadPorId(entidadId);
            Assert.True(entidad != false);
        }

        #endregion
    }
}