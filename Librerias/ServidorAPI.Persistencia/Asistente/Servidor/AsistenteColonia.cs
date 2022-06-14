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
//                  AsistenteColonia: Creado 14-06-2022
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
    public class AsistenteColonia : ServidorAsistente<Colonia>, IAsistenteColonia
    {
        public AsistenteColonia(ServidorContexto db) : base(db)
        {
        }

        public async Task<IEnumerable<Colonia>> ObtenerTodoFiltros()
        {
            await Task.Yield();
            var entidad = entidades.Where(x => x.StatusId == 1).AsNoTracking().AsEnumerable();
            return await Task.FromResult(entidad);
        }

        public async Task<Colonia> ObtenerPorCodigoPostal(int codigoPostal)
        {
            var entidad = await entidades.FirstOrDefaultAsync(x => x.CodigoPostal == codigoPostal && x.StatusId == 1);
            if (entidad != null)
            {
                return entidad;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<bool> ExisteColoniaPorCodigoPostal(int? codigoPostal)
        {
            var colonia = await entidades.FirstOrDefaultAsync(x => x.CodigoPostal == codigoPostal && x.StatusId == 1);
            if (colonia != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ExisteColoniaPorNombre(int? codigoPostal, string? nombre)
        {
            var colonia = await entidades.FirstOrDefaultAsync(x => x.CodigoPostal == codigoPostal && x.StatusId == 1 && x.Nombre == nombre);
            if (colonia != null)
            {
                return true;
            }
            return false;
        }
    }
}