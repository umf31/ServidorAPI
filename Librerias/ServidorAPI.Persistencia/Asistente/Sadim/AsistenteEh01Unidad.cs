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
//                AsistenteEh01Unidad: Creado 15-06-2022
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
    public class AsistenteEh01Unidad : AsistenteIndicador<Eh01Unidad>, IAsistenteEh01Unidad
    {
        private readonly SadimContexto dbs;

        public AsistenteEh01Unidad(SadimContexto _dbs, ServidorContexto db) : base(db, _dbs)
        {
            dbs = _dbs;
        }

        public async Task<IEnumerable<Eh01Unidad>> ObtenerTodoFiltros()
        {
            var entidad = indicador.Where(x => x.StatusId == 1).Include(c => c.Periodos).AsEnumerable();
            return await Task.FromResult(entidad);
        }

        public async Task<CP02_IMCP_08M> ObtenerCP02_IMCP_08M(string periodo)
        {
            var cp02_08m = await dbs.CP02_IMCP_08M
                .Where(x => x.Consultorio == "9999" && Convert.ToInt32(x.Periodo) == Convert.ToInt32(periodo)).FirstOrDefaultAsync();
            if (cp02_08m != null)
            {
                return cp02_08m;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<CP02_IMCP_09H> ObtenerCP02_IMCP_09H(string periodo)
        {
            var cp02_09h = await dbs.CP02_IMCP_09H
                .Where(x => x.Consultorio == "9999" && Convert.ToInt32(x.Periodo) == Convert.ToInt32(periodo)).FirstOrDefaultAsync();
            if (cp02_09h != null)
            {
                return cp02_09h;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<CP02_IMCP_10Y> ObtenerCP02_IMCP_10Y(string periodo)
        {
            var cp02_10y = await dbs.CP02_IMCP_10Y
                .Where(x => x.Consultorio == "9999" && Convert.ToInt32(x.Periodo) == Convert.ToInt32(periodo)).FirstOrDefaultAsync();
            if (cp02_10y != null)
            {
                return cp02_10y;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<CP03_INCOM_DMHTA> ObtenerCP03_INCOM_DMHTA(string periodo)
        {
            var cp03Incon_DmHta = await dbs.CP03_INCOM_DMHTA
                .Where(x => x.Consultorio == "9999" && Convert.ToInt32(x.Periodo) >= Convert.ToInt32(periodo)).FirstOrDefaultAsync();
            if (cp03Incon_DmHta != null)
            {
                return cp03Incon_DmHta;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<List<CP04_IMCP20>> ObtenerListaCP04(string periodo)
        {
            return await dbs.CP04_IMCP20.Where(x => x.Consultorio == "9999" && Convert.ToInt32(x.Periodo) >= Convert.ToInt32(periodo)).ToListAsync();
        }
    }
}