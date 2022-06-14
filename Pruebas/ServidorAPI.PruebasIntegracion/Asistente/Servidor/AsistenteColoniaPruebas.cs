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
//             AsistenteColoniaPruebas: Creado 14-06-2022
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
    public class AsistenteColoniaPruebas : IClassFixture<SimuladorBaseDatos>
    {
        private SimuladorBaseDatos Simulador { get; }

        public AsistenteColoniaPruebas(SimuladorBaseDatos simulador)
        {
            Simulador = simulador;
        }

        #region => Pruebas de Integración Colonia AsistenteBase

        [Fact]
        public async Task ObtenerTodo_ColoniaBase_SuperaPrueba_SiRetornaTodosLosDatos()
        {
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteColonia(db);

            var entidad = await asistente.ObtenerTodo();
            Assert.Equal(51, entidad.Count());
        }

        [Fact]
        public async Task ObtenerPorId_ColoniaBase_SuperaPrueba_SiRetornaElementoSeleccionado()
        {
            using var db = Simulador.CrearContexto();
            var id = 1;
            var asistente = new AsistenteColonia(db);

            var entidad = await asistente.ObtenerPorId(id);
            Assert.Equal(entidad.Id, id);
        }

        [Fact]
        public async Task ObtenerPorId_ColoniaBase_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var id = 52;
            var asistente = new AsistenteColonia(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(id));
        }

        [Fact]
        public async Task Insertar_ColoniaBase_SuperaPrueba_InsertaEntidad()
        {
            using (var transaction = Simulador.Conexion.BeginTransaction())
            {
                var entidadId = 0;
                var entidadInsertar = new Colonia
                {
                    Nombre = "Colonia 101",
                    CodigoPostal = 66420,
                    AsentamientoId = 1,
                    MunicipioId = 1,
                    Latitud = 23.986525M,
                    Longitud = -108.986525M,
                    Geolocalizacion = "",
                    Descripcion = "",
                    Imagen = "",
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    UsuarioMod = "10716076",
                    StatusId = 1
                };
                using (var db = Simulador.CrearContexto(transaction))
                {
                    var asistente = new AsistenteColonia(db);

                    await asistente.Insertar(entidadInsertar);
                    await db.SaveChangesAsync();
                    entidadId = entidadInsertar.Id;
                }
                using (var db = Simulador.CrearContexto(transaction))
                {
                    var asistente = new AsistenteColonia(db);

                    var entidad = await asistente.ObtenerPorId(entidadId);

                    Assert.NotNull(entidad);
                    Assert.Equal(entidadInsertar.Nombre, entidad.Nombre);
                    Assert.Equal(entidadInsertar.CodigoPostal, entidad.CodigoPostal);
                    Assert.Equal(entidadInsertar.AsentamientoId, entidad.AsentamientoId);
                    Assert.Equal(entidadInsertar.MunicipioId, entidad.MunicipioId);
                    Assert.Equal(entidadInsertar.Latitud, entidad.Latitud);
                    Assert.Equal(entidadInsertar.Longitud, entidad.Longitud);
                    Assert.Equal(entidadInsertar.Geolocalizacion, entidad.Geolocalizacion);
                    Assert.Equal(entidadInsertar.Imagen, entidad.Imagen);
                    Assert.Equal(entidadInsertar.FechaCreacion, entidad.FechaCreacion);
                    Assert.Equal(entidadInsertar.FechaModificacion, entidad.FechaModificacion);
                    Assert.Equal(entidadInsertar.UsuarioMod, entidad.UsuarioMod);
                    Assert.Equal(entidadInsertar.StatusId, entidad.StatusId);
                }
            }
        }

        [Fact]
        public async Task Actualizar_ColoniaBase_SuperaPrueba_ActualizaEstado()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 1;
            var matricula = "10716076";

            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteColonia(db);

                await asistente.Actualizar(entidadId, matricula);
                await db.SaveChangesAsync();
                entidadId = 1;
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteColonia(db);

                var entidad = await asistente.ObtenerPorId(entidadId);

                Assert.NotNull(entidad);
                Assert.Equal(2, entidad.StatusId);
            }
        }

        [Fact]
        public async Task Editar_ColoniaBase_SuperaPrueba_EditaEntidad()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 1;
            var entidadEditar = new Colonia
            {
                Nombre = "Editar 101",
                CodigoPostal = 66420,
                AsentamientoId = 1,
                MunicipioId = 1,
                Latitud = 23.986525M,
                Longitud = -108.986525M,
                Geolocalizacion = "",
                Descripcion = "",
                Imagen = "",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                UsuarioMod = "10716076",
                StatusId = 1
            };
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteColonia(db);

                await asistente.Editar(entidadEditar);
                await db.SaveChangesAsync();
                entidadId = entidadEditar.Id;
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteColonia(db);

                var entidad = await asistente.ObtenerPorId(entidadId);

                Assert.NotNull(entidad);
                Assert.Equal(entidadEditar.Nombre, entidad.Nombre);
                Assert.Equal(entidadEditar.CodigoPostal, entidad.CodigoPostal);
                Assert.Equal(entidadEditar.AsentamientoId, entidad.AsentamientoId);
                Assert.Equal(entidadEditar.MunicipioId, entidad.MunicipioId);
                Assert.Equal(entidadEditar.Latitud, entidad.Latitud);
                Assert.Equal(entidadEditar.Longitud, entidad.Longitud);
                Assert.Equal(entidadEditar.Geolocalizacion, entidad.Geolocalizacion);
                Assert.Equal(entidadEditar.Imagen, entidad.Imagen);
                Assert.Equal(entidadEditar.FechaCreacion, entidad.FechaCreacion);
                Assert.Equal(entidadEditar.FechaModificacion, entidad.FechaModificacion);
                Assert.Equal(entidadEditar.UsuarioMod, entidad.UsuarioMod);
                Assert.Equal(entidadEditar.StatusId, entidad.StatusId);
            }
        }

        [Fact]
        public async Task Eliminar_ColoniaBase_SuperaPrueba_EliminaCuentaMaestra()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 51;
            var matricula = "10716076";
            var empleadoRol = "SadimMaster";
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteColonia(db);
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
                var asistente = new AsistenteColonia(db);
                await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(entidadId));
            }
        }

        [Fact]
        public async Task Eliminar_ColoniaBase_SuperaPrueba_ActualizaEntidad()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 51;
            var matricula = "10716076";
            var empleadoRol = "Directivo";
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteColonia(db);
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
                var asistente = new AsistenteColonia(db);
                await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(entidadId));
            }
        }

        [Fact]
        public async Task Eliminar_ColoniaBase_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var id = 52;
            var asistente = new AsistenteColonia(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.Eliminar(id));
        }

        [Fact]
        public async Task ExisteEntidadPorId_ColoniaBase_SuperaPrueba_SiExisteEntidad()
        {
            var entidadId = 1;
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteColonia(db);

            var entidad = await asistente.ExisteEntidadPorId(entidadId);
            Assert.True(entidad != false);
        }

        [Fact]
        public async Task ExisteEntidadPorNombre_ColoniaBase_SuperaPrueba_SiExisteEntidad()
        {
            var nombre = "Colonia 1";
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteColonia(db);

            var entidad = await asistente.ExisteEntidadPorNombre(nombre);
            Assert.True(entidad != false);
        }

        #endregion

        #region=> Pruebas de Integración AsistenteColonia

        [Fact]
        public async Task ObtenerTodoFiltros_ColoniaBase_SuperaPrueba_SiRetornaDatosFiltrados()
        {
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteColonia(db);

            var entidad = await asistente.ObtenerTodoFiltros();
            Assert.NotEmpty(entidad);
        }

        [Fact]
        public async Task ObtenerPorCodigoPostal_ColoniaBase_SuperaPrueba_SiRetornaElementoSeleccionado()
        {
            using var db = Simulador.CrearContexto();
            var codigoPostal = 64001;
            var asistente = new AsistenteColonia(db);

            var entidad = await asistente.ObtenerPorCodigoPostal(codigoPostal);
            Assert.Equal(entidad.CodigoPostal, codigoPostal);
        }

        [Fact]
        public async Task ExisteColoniaPorCodigoPostal_ColoniaBase_SuperaPrueba_ExisteEntidad()
        {
            using var db = Simulador.CrearContexto();
            var codigoPostal = 64001;
            var asistente = new AsistenteColonia(db);
            var entidad = await asistente.ExisteColoniaPorCodigoPostal(codigoPostal);
            Assert.True(entidad != false);
        }

        [Fact]
        public async Task ExisteColoniaPorNombre_ColoniaBase_SuperaPrueba_ExisteEntidad()
        {
            var nombre = "Colonia 1";
            using var db = Simulador.CrearContexto();
            var codigoPostal = 64000;
            var asistente = new AsistenteColonia(db);
            var entidad = await asistente.ExisteColoniaPorNombre(codigoPostal, nombre);
            Assert.True(entidad != false);
        }

        #endregion
    }
}