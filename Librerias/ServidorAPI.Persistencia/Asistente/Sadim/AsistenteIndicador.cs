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
//                AsistenteIndicador: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using ServidorAPI.Dominio.Entidades.Enlace;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Dominio.Interfaces.Asistente.Sadim;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Dominio.Servicios.Sadim;
using ServidorAPI.Persistencia.Conectividad.Contexto;

namespace ServidorAPI.Persistencia.Asistente.Sadim
{
    public class AsistenteIndicador<Indicador> : IAsistenteIndicador<Indicador> where Indicador : IndicadorBase
    {
        private readonly ServidorContexto db;
        private readonly SadimContexto dbs;
        protected readonly DbSet<Indicador> indicador;

        public AsistenteIndicador(ServidorContexto _db, SadimContexto _dbs)
        {
            db = _db;
            dbs = _dbs;
            indicador = db.Set<Indicador>();
        }

        public async Task<Indicador> ObtenerPorId(int? id)
        {
            var entidad = await indicador.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entidad != null)
            {
                return entidad;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<Indicador> ObtenerUltimoRegistro(string? nombre)
        {
            var entidad = await indicador.Where(x => x.Nombre == nombre).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            if (entidad != null)
            {
                return entidad;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task InsertarLista(List<Indicador> entidad)
        {
            await indicador.AddRangeAsync(entidad);
        }

        public async Task Eliminar(int id)
        {
            var entidad = await ObtenerPorId(id);
            if (entidad != null)
            {
                indicador.Remove(entidad);
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<bool> ExisteEntidadPorNombre(string? nombre)
        {
            var existe = await indicador.Where(x => x.Nombre == nombre).FirstOrDefaultAsync();
            if (existe != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<SysConfigUnidadDm> ObtenerFechaCorte()
        {
            var obtenerFecha = await dbs.SysConfigUnidadDm.MaxAsync(x => x.FechaMovSistema);
            var fechaCorte = await dbs.SysConfigUnidadDm.Where(x => x.FechaMovSistema == obtenerFecha).FirstOrDefaultAsync();
            return fechaCorte!;
        }
    }
}