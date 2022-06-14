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
//             AsistenteUnidadPruebas: Creado 14-06-2022
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
    public class AsistenteUnidadPruebas : IClassFixture<SimuladorBaseDatos>
    {
        private SimuladorBaseDatos Simulador { get; }

        public AsistenteUnidadPruebas(SimuladorBaseDatos simulador)
        {
            Simulador = simulador;
        }

        #region => Pruebas de Integración Unidad AsistenteBase

        [Fact]
        public async Task ObtenerTodo_UnidadBase_SuperaPrueba_SiRetornaTodosLosDatos()
        {
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteUnidad(db);

            var entidad = await asistente.ObtenerTodo();
            Assert.Equal(51, entidad.Count());
        }

        [Fact]
        public async Task ObtenerPorId_UnidadBase_SuperaPrueba_SiRetornaElementoSeleccionado()
        {
            using var db = Simulador.CrearContexto();
            var id = 1;
            var asistente = new AsistenteUnidad(db);

            var entidad = await asistente.ObtenerPorId(id);
            Assert.Equal(entidad.Id, id);
        }

        [Fact]
        public async Task ObtenerPorId_UnidadBase_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var id = 52;
            var asistente = new AsistenteUnidad(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(id));
        }

        [Fact]
        public async Task Insertar_UnidadBase_SuperaPrueba_InsertaEntidad()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 0;
            var entidadInsertar = new Unidad
            {
                Nombre = "Unidad 101",
                DelegacionId = 1,
                NumUnidad = 52,
                Localidad = "AquiEs",
                ClavePresupuestal = "2017A0215108",
                UnidadTipoId = 1,
                VialidadId = 1,
                Calle = "Juarez",
                Numero = "101",
                Telefono = "(818) 356-2134",
                ColoniaId = 1,
                MunicipioId = 1,
                Imagen = "",
                Latitud = 23.986525M,
                Longitud = -108.986525M,
                Geolocalizacion = "",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                UsuarioMod = "10716076",
                StatusId = 1
            };
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteUnidad(db);

                await asistente.Insertar(entidadInsertar);
                await db.SaveChangesAsync();
                entidadId = entidadInsertar.Id;
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteUnidad(db);

                var entidad = await asistente.ObtenerPorId(entidadId);

                Assert.NotNull(entidad);
                Assert.Equal(entidadInsertar.Nombre, entidad.Nombre);
                Assert.Equal(entidadInsertar.DelegacionId, entidad.DelegacionId);
                Assert.Equal(entidadInsertar.NumUnidad, entidad.NumUnidad);
                Assert.Equal(entidadInsertar.Localidad, entidad.Localidad);
                Assert.Equal(entidadInsertar.ClavePresupuestal, entidad.ClavePresupuestal);
                Assert.Equal(entidadInsertar.UnidadTipoId, entidad.UnidadTipoId);
                Assert.Equal(entidadInsertar.VialidadId, entidad.VialidadId);
                Assert.Equal(entidadInsertar.Calle, entidad.Calle);
                Assert.Equal(entidadInsertar.Numero, entidad.Numero);
                Assert.Equal(entidadInsertar.Telefono, entidad.Telefono);
                Assert.Equal(entidadInsertar.ColoniaId, entidad.ColoniaId);
                Assert.Equal(entidadInsertar.MunicipioId, entidad.MunicipioId);
                Assert.Equal(entidadInsertar.Imagen, entidad.Imagen);
                Assert.Equal(entidadInsertar.Latitud, entidad.Latitud);
                Assert.Equal(entidadInsertar.Longitud, entidad.Longitud);
                Assert.Equal(entidadInsertar.Geolocalizacion, entidad.Geolocalizacion);
                Assert.Equal(entidadInsertar.FechaCreacion, entidad.FechaCreacion);
                Assert.Equal(entidadInsertar.FechaModificacion, entidad.FechaModificacion);
                Assert.Equal(entidadInsertar.UsuarioMod, entidad.UsuarioMod);
                Assert.Equal(entidadInsertar.StatusId, entidad.StatusId);
            }
        }

        [Fact]
        public async Task Actualizar_UnidadBase_SuperaPrueba_ActualizaEstado()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 1;
            var matricula = "10716076";

            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteUnidad(db);

                await asistente.Actualizar(entidadId, matricula);
                await db.SaveChangesAsync();
                entidadId = 1;
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteUnidad(db);

                var entidad = await asistente.ObtenerPorId(entidadId);

                Assert.NotNull(entidad);
                Assert.Equal(2, entidad.StatusId);
            }
        }

        [Fact]
        public async Task Editar_UnidadBase_SuperaPrueba_EditaEntidad()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 1;
            var entidadEditar = new Unidad
            {
                Nombre = "Editar 101",
                DelegacionId = 1,
                NumUnidad = 52,
                Localidad = "AquiEs",
                ClavePresupuestal = "2017A0215108",
                UnidadTipoId = 1,
                VialidadId = 1,
                Calle = "Juarez",
                Numero = "101",
                Telefono = "(818) 356-2134",
                ColoniaId = 1,
                MunicipioId = 1,
                Imagen = "",
                Latitud = 23.986525M,
                Longitud = -108.986525M,
                Geolocalizacion = "",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                UsuarioMod = "10716076",
                StatusId = 1
            };
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteUnidad(db);

                await asistente.Editar(entidadEditar);
                await db.SaveChangesAsync();
                entidadId = entidadEditar.Id;
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteUnidad(db);

                var entidad = await asistente.ObtenerPorId(entidadId);

                Assert.NotNull(entidad);
                Assert.Equal(entidadEditar.Nombre, entidad.Nombre);
                Assert.Equal(entidadEditar.DelegacionId, entidad.DelegacionId);
                Assert.Equal(entidadEditar.NumUnidad, entidad.NumUnidad);
                Assert.Equal(entidadEditar.Localidad, entidad.Localidad);
                Assert.Equal(entidadEditar.ClavePresupuestal, entidad.ClavePresupuestal);
                Assert.Equal(entidadEditar.UnidadTipoId, entidad.UnidadTipoId);
                Assert.Equal(entidadEditar.VialidadId, entidad.VialidadId);
                Assert.Equal(entidadEditar.Calle, entidad.Calle);
                Assert.Equal(entidadEditar.Numero, entidad.Numero);
                Assert.Equal(entidadEditar.Telefono, entidad.Telefono);
                Assert.Equal(entidadEditar.ColoniaId, entidad.ColoniaId);
                Assert.Equal(entidadEditar.MunicipioId, entidad.MunicipioId);
                Assert.Equal(entidadEditar.Imagen, entidad.Imagen);
                Assert.Equal(entidadEditar.Latitud, entidad.Latitud);
                Assert.Equal(entidadEditar.Longitud, entidad.Longitud);
                Assert.Equal(entidadEditar.Geolocalizacion, entidad.Geolocalizacion);
                Assert.Equal(entidadEditar.FechaCreacion, entidad.FechaCreacion);
                Assert.Equal(entidadEditar.FechaModificacion, entidad.FechaModificacion);
                Assert.Equal(entidadEditar.UsuarioMod, entidad.UsuarioMod);
                Assert.Equal(entidadEditar.StatusId, entidad.StatusId);
            }
        }

        [Fact]
        public async Task Eliminar_UnidadBase_SuperaPrueba_EliminaCuentaMaestra()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 51;
            var matricula = "10716076";
            var empleadoRol = "SadimMaster";
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteUnidad(db);
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
                var asistente = new AsistenteUnidad(db);
                await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(entidadId));
            }
        }

        [Fact]
        public async Task Eliminar_UnidadBase_SuperaPrueba_ActualizaEntidad()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 51;
            var matricula = "10716076";
            var empleadoRol = "Directivo";
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteUnidad(db);
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
                var asistente = new AsistenteUnidad(db);
                await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(entidadId));
            }
        }

        [Fact]
        public async Task Eliminar_UnidadBase_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var id = 52;
            var asistente = new AsistenteUnidad(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.Eliminar(id));
        }

        [Fact]
        public async Task ExisteEntidadPorId_UnidadBase_SuperaPrueba_SiExisteEntidad()
        {
            var entidadId = 1;
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteUnidad(db);

            var entidad = await asistente.ExisteEntidadPorId(entidadId);
            Assert.True(entidad != false);
        }

        [Fact]
        public async Task ExisteEntidadPorNombre_UnidadBase_SuperaPrueba_SiExisteEntidad()
        {
            var nombre = "Unidad 1";
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteUnidad(db);

            var entidad = await asistente.ExisteEntidadPorNombre(nombre);
            Assert.True(entidad != false);
        }

        #endregion

        #region=> Pruebas de Integración AsistenteUnidad

        [Fact]
        public async Task ObtenerTodoFiltros_AsistenteUnidad_SuperaPrueba_SiRetornaDatosFiltrados()
        {
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteUnidad(db);

            var entidad = await asistente.ObtenerTodoFiltros();
            foreach (var items in entidad)
            {
                Assert.True(items.Delegacion != null);
                Assert.True(items.Colonia != null);
            }
        }

        [Fact]
        public async Task ObtenerPorIdFiltros_AsistenteUnidad_SuperaPrueba_SiRetornaDatosFiltrados()
        {
            var entidadId = 1;
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteUnidad(db);

            var entidad = await asistente.ObtenerPorIdFiltros(entidadId);
            Assert.True(entidad.UnidadTipo != null);
        }

        [Fact]
        public async Task ObtenerPorIdFiltros_AsistenteUnidad_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var entidadId = 52;
            var asistente = new AsistenteUnidad(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorIdFiltros(entidadId));
        }

        [Fact]
        public async Task ObtenerPorClavePresupuestal_UnidadBase_SuperaPrueba_SiRetornaElementoSeleccionado()
        {
            using var db = Simulador.CrearContexto();
            var id = 1;
            string clavePresupuestal = "201710215111";
            var asistente = new AsistenteUnidad(db);
            var entidad = await asistente.ObtenerPorClavePresupuestal(clavePresupuestal);
            Assert.Equal(entidad.Id, id);
        }

        [Fact]
        public async Task ObtenerPorClavePresupuestal_UnidadBase_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            string clavePresupuestal = "301710215111";
            var asistente = new AsistenteUnidad(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorClavePresupuestal(clavePresupuestal));
        }

        #endregion
    }
}