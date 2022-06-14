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
//                  AsistenteUnidad: Creado 14-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Dominio.Interfaces.Asistente.Servidor;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Persistencia.Conectividad.Contexto;
using ServidorAPI.Persistencia.Utils;

namespace ServidorAPI.Persistencia.Asistente.Servidor
{
    public class AsistenteUnidad : ServidorAsistente<Unidad>, IAsistenteUnidad
    {
        public AsistenteUnidad(ServidorContexto db) : base(db)
        {
        }

        public async Task<Unidad> ObtenerUnidadActiva()
        {
            var entidad = await entidades.Where(x => x.StatusId == 4).FirstOrDefaultAsync();
            if (entidad != null)
            {
                return entidad;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<IEnumerable<Unidad>> ObtenerTodoFiltros()
        {
            var entidad = entidades.Where(x => x.StatusId == 1).Include(x => x.Delegacion).Include(x => x.Colonia).ThenInclude(x => x.Municipio).AsEnumerable();
            return await Task.FromResult(entidad);
        }

        public async Task<Unidad> ObtenerPorIdFiltros(int unidadId)
        {
            var entidad = await entidades.Where(x => x.Id == unidadId).Include(x => x.UnidadTipo).FirstOrDefaultAsync();
            if (entidad != null)
            {
                return entidad;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<Unidad> ObtenerPorClavePresupuestal(string clavePresupuestal)
        {
            var entidad = await entidades.FirstOrDefaultAsync(x => x.ClavePresupuestal == clavePresupuestal);
            if (entidad != null)
            {
                return entidad;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task CambiarStatusUnidadAnterior(int id, string matricula)
        {
            var entidadSadim = await entidades.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entidadSadim != null)
            {
                entidadSadim.FechaModificacion = DateTime.Now;
                entidadSadim.UsuarioMod = matricula;
                entidadSadim.StatusId = 1;
                entidades.Update(entidadSadim);
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task CambiarUnidadActiva(Unidad unidad)
        {
            await Task.Run(() =>
            {
                entidades.Update(unidad);
            });
        }

        public async Task<bool> ExisteUnidadPorClavePresupuestal(string? clavePresupuestal)
        {
            var existeUnidad = await entidades.Where(x => x.ClavePresupuestal.ToLower() == clavePresupuestal!.ToLower() && x.StatusId == 1).FirstOrDefaultAsync();
            if (existeUnidad == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ExistePorNumeroUnidad(int? numeroUnidad, int? delegacionId)
        {
            var existeUnidad = await entidades.Where(x => x.NumUnidad == numeroUnidad! && x.DelegacionId == delegacionId).FirstOrDefaultAsync();
            if (existeUnidad == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}