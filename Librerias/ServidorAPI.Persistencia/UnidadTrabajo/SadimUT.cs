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
//                    SadimUT: Creado 14-06-2022
//=======================================================================

#endregion

using ServidorAPI.Dominio.Interfaces.Asistente.Sadim;
using ServidorAPI.Dominio.Interfaces.UnidadTrabajo;
using ServidorAPI.Persistencia.Asistente.Sadim;
using ServidorAPI.Persistencia.Conectividad.Contexto;

namespace ServidorAPI.Persistencia.UnidadTrabajo
{
    public class SadimUT : ISadimUT
    {
        private readonly ServidorContexto db;
        internal readonly IAsistenteProceso asistenteProceso = null!;
        internal readonly IAsistentePeriodo asistentePeriodo = null!;
        internal readonly IAsistenteDetalle asistenteDetalle = null!;
        internal readonly IAsistenteMeta asistenteMeta = null!;

        public SadimUT(ServidorContexto _db)
        {
            db = _db;
        }

        public IAsistenteProceso AsistenteProceso => asistenteProceso ?? new AsistenteProceso(db);
        public IAsistentePeriodo AsistentePeriodo => asistentePeriodo ?? new AsistentePeriodo(db);
        public IAsistenteDetalle AsistenteDetalle => asistenteDetalle ?? new AsistenteDetalle(db);
        public IAsistenteMeta AsistenteMeta => asistenteMeta ?? new AsistenteMeta(db);

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
    }
}