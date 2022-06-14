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
//              AsistenteRolPruebas: Creado 14-06-2022
//=======================================================================
#endregion

using ServidorAPI.Persistencia.Asistente.Servidor;
using ServidorAPI.PruebasIntegracion.Utils;
using System.Threading.Tasks;
using Xunit;

namespace ServidorAPI.PruebasIntegracion.Asistente.Servidor
{
    public class AsistenteRolPruebas : IClassFixture<SimuladorBaseDatos>
    {
        private SimuladorBaseDatos Simulador { get; }

        public AsistenteRolPruebas(SimuladorBaseDatos simulador)
        {
            Simulador = simulador;
        }

        #region=> Pruebas de Integración AsistenteRol

        [Fact]
        public async Task ObtenerTodo_AsistenteRol_SuperaPrueba_SiRetornaTodosLosDatos()
        {
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteRol(db);
            int empleadoId = 1;

            var roles = await asistente.ObtenerTodo(empleadoId);
            foreach (var items in roles)
            {
                Assert.True(items != null);
            }
        }

        [Fact]
        public async Task AgregarRol_AsistenteRol_SuperaPrueba_SiAgregaRol()
        {
            int empleadoId = 1;
            int idRol = 1;
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteRol(db);
            var entidad = await asistente.AgregarRol(empleadoId, idRol);

            Assert.True(entidad != false);
        }

        [Fact]
        public async Task ElimiarRol_AsistenteRol_SuperaPrueba_SiEliminaRol()
        {
            int empleadoId = 1;
            int idRol = 1;
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteRol(db);
            var entidad = await asistente.EliminarRol(empleadoId, idRol);

            Assert.True(entidad != false);
        }

        [Fact]
        public async Task AgregarRolInicio_AsistenteRol_SuperaPrueba_SiAgregaRol()
        {
            using var db = Simulador.CrearContexto();
            int empleadoId = 1;
            var asistente = new AsistenteRol(db);
            var entidad = await asistente.AgregarRolInicio(empleadoId);

            Assert.True(entidad != false);
        }

        #endregion
    }
}