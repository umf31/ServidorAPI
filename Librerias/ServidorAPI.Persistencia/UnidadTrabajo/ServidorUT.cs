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
//                  ServidorUT: Creado 14-06-2022
//=======================================================================

#endregion

using ServidorAPI.Dominio.Interfaces.Asistente.Servidor;
using ServidorAPI.Dominio.Interfaces.UnidadTrabajo;
using ServidorAPI.Persistencia.Asistente.Servidor;
using ServidorAPI.Persistencia.Conectividad.Contexto;

namespace ServidorAPI.Persistencia.UnidadTrabajo
{
    public class ServidorUT : IServidorUT
    {
        private readonly ServidorContexto db;
        private readonly SoporteContexto dba;
        internal readonly IAsistenteRol asistenteRol = null!;
        internal readonly IAsistenteEmpleado asistenteEmpleado = null!;
        internal readonly IAsistenteStatus asistenteStatus = null!;
        internal readonly IAsistenteCategoria asistenteCategoria = null!;
        internal readonly IAsistenteServicio asistenteServicio = null!;
        internal readonly IAsistentePais asistentePais = null!;
        internal readonly IAsistenteEstado asistenteEstado = null!;
        internal readonly IAsistenteMunicipio asistenteMunicipio = null!;
        internal readonly IAsistenteAsentamiento asistenteAsentamiento = null!;
        internal readonly IAsistenteColonia asistenteColonia = null!;
        internal readonly IAsistenteDelegacion asistenteDelegacion = null!;
        internal readonly IAsistenteUnidadTipo asistenteUnidadTipo = null!;
        internal readonly IAsistenteVialidad asistenteVialidad = null!;
        internal readonly IAsistenteUnidad asistenteUnidad = null!;
        internal readonly IAsistenteSoporte asistenteSoporte = null!;

        public ServidorUT(ServidorContexto _db, SoporteContexto _dba)
        {
            db = _db;
            dba = _dba;
        }

        public IAsistenteRol AsistenteRol => asistenteRol ?? new AsistenteRol(db);
        public IAsistenteEmpleado AsistenteEmpleado => asistenteEmpleado ?? new AsistenteEmpleado(db);
        public IAsistenteStatus AsistenteStatus => asistenteStatus ?? new AsistenteStatus(db);
        public IAsistenteCategoria AsistenteCategoria => asistenteCategoria ?? new AsistenteCategoria(db);
        public IAsistenteServicio AsistenteServicio => asistenteServicio ?? new AsistenteServicio(db);
        public IAsistentePais AsistentePais => asistentePais ?? new AsistentePais(db);
        public IAsistenteEstado AsistenteEstado => asistenteEstado ?? new AsistenteEstado(db);
        public IAsistenteMunicipio AsistenteMunicipio => asistenteMunicipio ?? new AsistenteMunicipio(db);
        public IAsistenteAsentamiento AsistenteAsentamiento => asistenteAsentamiento ?? new AsistenteAsentamiento(db);
        public IAsistenteColonia AsistenteColonia => asistenteColonia ?? new AsistenteColonia(db);
        public IAsistenteDelegacion AsistenteDelegacion => asistenteDelegacion ?? new AsistenteDelegacion(db);
        public IAsistenteUnidadTipo AsistenteUnidadTipo => asistenteUnidadTipo ?? new AsistenteUnidadTipo(db);
        public IAsistenteVialidad AsistenteVialidad => asistenteVialidad ?? new AsistenteVialidad(db);
        public IAsistenteUnidad AsistenteUnidad => asistenteUnidad ?? new AsistenteUnidad(db);
        public IAsistenteSoporte AsistenteSoporte => asistenteSoporte ?? new AsistenteSoporte(dba);

        public void Dispose()
        {
            DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        public async void DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    await db.DisposeAsync();
                }
            }
        }

        public async Task GuardarServidorAPI()
        {
            await db.BulkSaveChangesAsync();
        }

        public async Task GuardarSoporte()
        {
            await dba.BulkSaveChangesAsync();
        }
    }
}