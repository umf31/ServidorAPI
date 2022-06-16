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
using ServidorAPI.Dominio.Interfaces.Asistente.Servidor;
using ServidorAPI.Dominio.Interfaces.UnidadTrabajo;
using ServidorAPI.Persistencia.Asistente.Sadim;
using ServidorAPI.Persistencia.Asistente.Servidor;
using ServidorAPI.Persistencia.Conectividad.Contexto;

namespace ServidorAPI.Persistencia.UnidadTrabajo
{
    public class SadimUT : ISadimUT
    {
        private readonly ServidorContexto db;
        private readonly SadimContexto dbs;
        internal readonly IAsistenteProceso asistenteProceso = null!;
        internal readonly IAsistenteEmpleado asistenteEmpleado = null!;
        internal readonly IAsistentePeriodo asistentePeriodo = null!;
        internal readonly IAsistenteDetalle asistenteDetalle = null!;
        internal readonly IAsistenteMeta asistenteMeta = null!;
        internal readonly IAsistenteDm01Unidad asistenteDm01Unidad = null!;
        internal readonly IAsistenteDm02Unidad asistenteDm02Unidad = null!;
        internal readonly IAsistenteDm04Unidad asistenteDm04Unidad = null!;
        internal readonly IAsistenteDm05Unidad asistenteDm05Unidad = null!;
        internal readonly IAsistenteEh01Unidad asistenteEh01Unidad = null!;
        internal readonly IAsistenteEh02Unidad asistenteEh02Unidad = null!;
        internal readonly IAsistenteEh04Unidad asistenteEh04Unidad = null!;
        internal readonly IAsistenteCaMama01Unidad asistenteCaMama01Unidad = null!;
        internal readonly IAsistenteCaMama02Unidad asistenteCaMama02Unidad = null!;
        internal readonly IAsistenteCaMama03Unidad asistenteCaMama03Unidad = null!;
        internal readonly IAsistenteCaCu01Unidad asistenteCaCu01Unidad = null!;
        internal readonly IAsistenteMaterna01Unidad asistenteMaterna01Unidad = null!;
        internal readonly IAsistenteMaterna02Unidad asistenteMaterna02Unidad = null!;
        internal readonly IAsistenteMaterna03Unidad asistenteMaterna03Unidad = null!;
        internal readonly IAsistenteMaterna04Unidad asistenteMaterna04Unidad = null!;
        internal readonly IAsistenteSOb01Unidad asistenteSOb01Unidad = null!;
        internal readonly IAsistenteCaispn01Unidad asistenteCaispn01Unidad = null!;
        internal readonly IAsistenteCaispn02Unidad asistenteCaispn02Unidad = null!;
        internal readonly IAsistenteCaispn04Unidad asistenteCaispn04Unidad = null!;
        internal readonly IAsistenteCaispn05Unidad asistenteCaispn05Unidad = null!;
        internal readonly IAsistenteCaispn08Unidad asistenteCaispn08Unidad = null!;
        internal readonly IAsistenteCaispn09Unidad asistenteCaispn09Unidad = null!;
        internal readonly IAsistenteCaispn14Unidad asistenteCaispn14Unidad = null!;

        public SadimUT(ServidorContexto _db, SadimContexto _dbs)
        {
            db = _db;
            dbs = _dbs;
        }

        public IAsistenteEmpleado AsistenteEmpleado => asistenteEmpleado ?? new AsistenteEmpleado(db);
        public IAsistenteProceso AsistenteProceso => asistenteProceso ?? new AsistenteProceso(db);
        public IAsistentePeriodo AsistentePeriodo => asistentePeriodo ?? new AsistentePeriodo(db);
        public IAsistenteDetalle AsistenteDetalle => asistenteDetalle ?? new AsistenteDetalle(db);
        public IAsistenteMeta AsistenteMeta => asistenteMeta ?? new AsistenteMeta(db);
        public IAsistenteDm01Unidad AsistenteDm01Unidad => asistenteDm01Unidad ?? new AsistenteDm01Unidad(dbs, db);
        public IAsistenteDm02Unidad AsistenteDm02Unidad => asistenteDm02Unidad ?? new AsistenteDm02Unidad(dbs, db);
        public IAsistenteDm04Unidad AsistenteDm04Unidad => asistenteDm04Unidad ?? new AsistenteDm04Unidad(dbs, db);
        public IAsistenteDm05Unidad AsistenteDm05Unidad => asistenteDm05Unidad ?? new AsistenteDm05Unidad(dbs, db);
        public IAsistenteEh01Unidad AsistenteEh01Unidad => asistenteEh01Unidad ?? new AsistenteEh01Unidad(dbs, db);
        public IAsistenteEh02Unidad AsistenteEh02Unidad => asistenteEh02Unidad ?? new AsistenteEh02Unidad(dbs, db);
        public IAsistenteEh04Unidad AsistenteEh04Unidad => asistenteEh04Unidad ?? new AsistenteEh04Unidad(dbs, db);
        public IAsistenteCaMama01Unidad AsistenteCaMama01Unidad => asistenteCaMama01Unidad ?? new AsistenteCaMama01Unidad(dbs, db);
        public IAsistenteCaMama02Unidad AsistenteCaMama02Unidad => asistenteCaMama02Unidad ?? new AsistenteCaMama02Unidad(dbs, db);
        public IAsistenteCaMama03Unidad AsistenteCaMama03Unidad => asistenteCaMama03Unidad ?? new AsistenteCaMama03Unidad(dbs, db);
        public IAsistenteCaCu01Unidad AsistenteCaCu01Unidad => asistenteCaCu01Unidad ?? new AsistenteCaCu01Unidad(dbs, db);
        public IAsistenteMaterna01Unidad AsistenteMaterna01Unidad => asistenteMaterna01Unidad ?? new AsistenteMaterna01Unidad(dbs, db);
        public IAsistenteMaterna02Unidad AsistenteMaterna02Unidad => asistenteMaterna02Unidad ?? new AsistenteMaterna02Unidad(dbs, db);
        public IAsistenteMaterna03Unidad AsistenteMaterna03Unidad => asistenteMaterna03Unidad ?? new AsistenteMaterna03Unidad(dbs, db);
        public IAsistenteMaterna04Unidad AsistenteMaterna04Unidad => asistenteMaterna04Unidad ?? new AsistenteMaterna04Unidad(dbs, db);
        public IAsistenteSOb01Unidad AsistenteSOb01Unidad => asistenteSOb01Unidad ?? new AsistenteSOb01Unidad(dbs, db);
        public IAsistenteCaispn01Unidad AsistenteCaispn01Unidad => asistenteCaispn01Unidad ?? new AsistenteCaispn01Unidad(dbs, db);
        public IAsistenteCaispn02Unidad AsistenteCaispn02Unidad => asistenteCaispn02Unidad ?? new AsistenteCaispn02Unidad(dbs, db);
        public IAsistenteCaispn04Unidad AsistenteCaispn04Unidad => asistenteCaispn04Unidad ?? new AsistenteCaispn04Unidad(dbs, db);
        public IAsistenteCaispn05Unidad AsistenteCaispn05Unidad => asistenteCaispn05Unidad ?? new AsistenteCaispn05Unidad(dbs, db);
        public IAsistenteCaispn08Unidad AsistenteCaispn08Unidad => asistenteCaispn08Unidad ?? new AsistenteCaispn08Unidad(dbs, db);
        public IAsistenteCaispn09Unidad AsistenteCaispn09Unidad => asistenteCaispn09Unidad ?? new AsistenteCaispn09Unidad(dbs, db);
        public IAsistenteCaispn14Unidad AsistenteCaispn14Unidad => asistenteCaispn14Unidad ?? new AsistenteCaispn14Unidad(dbs, db);

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