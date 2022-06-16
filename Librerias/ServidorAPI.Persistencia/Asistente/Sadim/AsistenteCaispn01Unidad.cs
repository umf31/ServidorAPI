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
//              AsistenteCaispn01Unidad: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using ServidorAPI.Dominio.Entidades.Enlace;
using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Dominio.Interfaces.Asistente.Sadim;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Dominio.Servicios.Sadim;
using ServidorAPI.Persistencia.Conectividad.Contexto;

namespace ServidorAPI.Persistencia.Asistente.Sadim
{
    public class AsistenteCaispn01Unidad : AsistenteIndicador<Caispn01Unidad>, IAsistenteCaispn01Unidad
    {
        private readonly SadimContexto dbs;
        public AsistenteCaispn01Unidad(SadimContexto _dbs, ServidorContexto db) : base(db, _dbs)
        {
            dbs = _dbs;
        }

        public async Task<IEnumerable<Caispn01Unidad>> ObtenerTodoFiltros()
        {
            var entidad = indicador.Where(x => x.StatusId == 1).Include(c => c.Periodos).AsEnumerable();
            return await Task.FromResult(entidad);
        }

        public async Task<CoberturaPrevenIMSS> ObtenerCIP01_PrevenIMSS(string periodo)
        {
            var cip01_PrevenIMSS = await dbs.CIP01_PrevenIMSS.Where(x => x.Consultorio == "9999" && x.Periodo == periodo).ToListAsync();
            var cip = new CoberturaPrevenIMSS();
            if (cip01_PrevenIMSS != null)
            {
                cip.Periodo= cip01_PrevenIMSS.Select(x => x.Periodo).FirstOrDefaultDynamic();
                cip.CvePresup = cip01_PrevenIMSS.Select(x => x.CvePresup).FirstOrDefaultDynamic();
                cip.TotalPob = cip01_PrevenIMSS.Where(t => t.Periodo == periodo).Sum(i => i.TotalPob);
                cip.DhAip = cip01_PrevenIMSS.Where(t => t.Periodo == periodo).Sum(i => i.DhAip);
                cip.CobAip = cip.Total;
                return cip;
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
