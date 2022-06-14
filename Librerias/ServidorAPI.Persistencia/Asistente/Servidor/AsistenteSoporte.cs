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
//                 AsistenteSoporte: Creado 14-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using ServidorAPI.Dominio.Entidades.Soporte;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Dominio.Interfaces.Asistente.Servidor;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Persistencia.Conectividad.Contexto;

namespace ServidorAPI.Persistencia.Asistente.Servidor
{
    public class AsistenteSoporte : IAsistenteSoporte
    {
        private readonly SoporteContexto dba;

        public AsistenteSoporte(SoporteContexto _dba)
        {
            dba = _dba;
        }

        public async Task<EmpleadoSoporte> ObtenerEmpleadoPorMatricula(string? matricula)
        {
            var entidad = await dba.Empleados.Include("Roles.Rol").Include(c => c.Categoria).FirstOrDefaultAsync(x => x.Matricula == matricula);
            if (entidad != null)
            {
                return entidad;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<UnidadSoporte> ObtenerUnidadPorId(int id)
        {
            var entidad = await dba.Unidades.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entidad != null)
            {
                return entidad;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<UnidadSoporte> ObtenerUnidadActiva()
        {
            var entidad = await dba.Unidades.Where(x => x.StatusId == 4).FirstOrDefaultAsync();
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
            var entidadActualizada = await dba.UnidadesMedicas.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entidadActualizada != null)
            {
                entidadActualizada.FechaModificacion = DateTime.Now;
                entidadActualizada.UsuarioMod = matricula;
                entidadActualizada.StatusId = 1;
                dba.Update(entidadActualizada);
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task CambiarUnidadSoporte(UnidadSoporte unidad)
        {
            await Task.Run(() =>
            {
                dba.Unidades.Update(unidad);
            });
        }

        public async Task<MensajeriaSoporte> ObtenerOpcionesSMS()
        {
            var mensajeria = await dba.Mensajeria.FirstOrDefaultAsync();
            if (mensajeria != null)
            {
                return mensajeria;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<bool> ExisteEmpleadoPorMatricula(string? matricula)
        {
            var empleado = await dba.Empleados.FirstOrDefaultAsync(x => x.Matricula == matricula);
            if (empleado != null) { return true; }
            return false;
        }
    }
}