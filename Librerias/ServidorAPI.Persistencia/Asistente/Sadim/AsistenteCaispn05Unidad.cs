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
//              AsistenteCaispn05Unidad: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using ServidorAPI.Dominio.Entidades.Enlace;
using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Dominio.Interfaces.Asistente.Sadim;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Persistencia.Conectividad.Contexto;

namespace ServidorAPI.Persistencia.Asistente.Sadim
{
    public class AsistenteCaispn05Unidad : AsistenteIndicador<Caispn05Unidad>, IAsistenteCaispn05Unidad
    {
        private readonly SadimContexto dbs;
        public AsistenteCaispn05Unidad(SadimContexto _dbs, ServidorContexto db) : base(db, _dbs)
        {
            dbs = _dbs;
        }

        public async Task<IEnumerable<Caispn05Unidad>> ObtenerTodoFiltros()
        {
            var entidad = indicador.Where(x => x.StatusId == 1).Include(c => c.Periodos).AsEnumerable();
            return await Task.FromResult(entidad);
        }
        public async Task<IAP01_ProductividadAPI_EEMF> ObtenerIAP01_ProductividadAPI_EEMF(string periodo)
        {
            var iap_01Eemf = await dbs.IAP01_ProductividadAPI_EEMF
                .Where(x => x.Servicio == "TT" && Convert.ToInt32(x.Periodo) == Convert.ToInt32(periodo)).FirstOrDefaultAsync();
            if (iap_01Eemf != null)
            {
                return iap_01Eemf;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }
        public async Task<List<CP04_IMCP20>> ObtenerPeriodosCP04(string periodo)
        {
            return await dbs.CP04_IMCP20.Where(x => x.Consultorio == "9999" && Convert.ToInt32(x.Periodo) >= Convert.ToInt32(periodo)).ToListAsync();
        }
    }
}
