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
//               LogicaCaMama03Unidad: Creado 16-06-2022
//=======================================================================

#endregion

using AutoMapper;
using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Dominio.Interfaces.Logica.Sadim;
using ServidorAPI.Dominio.Interfaces.UnidadTrabajo;
using ServidorAPI.Dominio.Interfaces.Utils;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Dominio.Servicios.Servidor;
using ServidorAPI.Infraestructura.Objetos.Sadim.Consulta;

namespace ServidorAPI.Logica.Sadim
{
    public class LogicaCaMama03Unidad<Indicador> : ILogicaCaMama03Unidad<CaMama03Unidad>
    {
        private readonly IMapper mapper;
        private readonly ISadimUT uts;
        private readonly IPagSadim lista;
        private readonly ICrearIndicador crear;
        public LogicaCaMama03Unidad(IMapper _mapper, ISadimUT _uts, IPagSadim _lista, ICrearIndicador _crear)
        {
            mapper = _mapper;
            uts = _uts;
            lista = _lista;
            crear = _crear;
        }

        public async Task<Lista<CaMama03Unidad>> ObtenerTodo(dynamic dynConsulta)
        {
            var consulta = (IndicadorConsulta)dynConsulta;
            consulta.NumeroPagina = consulta.NumeroPagina == 0 ? Paginacion.DefaultNumeroPagina : consulta.NumeroPagina;
            consulta.NumeroRegistros = consulta.NumeroRegistros == 0 ? Paginacion.DefaultNumeroRegistros : consulta.NumeroRegistros;
            var entidad = await uts.AsistenteCaMama03Unidad.ObtenerTodoFiltros();
            if (consulta.Id != null)
            {
                entidad = entidad.Where(x => x.Id == consulta.Id);
            }
            if (consulta.Periodo != null)
            {
                entidad = entidad.Where(x => x.Periodo.ToLower().Contains(consulta.Periodo.ToLower()));
            }
            if (consulta.Mes != null)
            {
                entidad = entidad.Where(x => x.Periodos.Mes.ToLower().Contains(consulta.Mes.ToLower()));
            }
            if (consulta.Año != null)
            {
                entidad = entidad.Where(x => x.Periodos.Año.ToLower().Contains(consulta.Año.ToLower()));
            }
            if (consulta.Rendimiento != null)
            {
                entidad = entidad.Where(x => x.Rendimiento.ToLower().Contains(consulta.Rendimiento.ToLower()));
            }
            if (!entidad.Any())
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            var entidadPaginada = await lista.CaMama03Unidad.CrearLista(entidad, consulta.NumeroPagina, consulta.NumeroRegistros);
            if (!entidadPaginada.Any())
            {
                throw new NotFound(Mensaje.Detalle.NumPaginaNoExiste);
            }
            return entidadPaginada;
        }
        public async Task<bool> Actualizar(string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.CaMama03;
            var existe = await uts.AsistenteCaMama03Unidad.ExisteEntidadPorNombre(indicadorNombre);
            if (existe != false)
            {
                var ultimoRegistro = await uts.AsistenteCaMama03Unidad.ObtenerUltimoRegistro(indicadorNombre);
                var cp02 = await uts.AsistenteCaMama03Unidad.ObtenerCP02_Periodos(ultimoRegistro.Periodo);
                var crearIndicador = mapper.Map<List<CaMama03Unidad>>(cp02);
                var indicador = await crear.CrearCAMA03(crearIndicador, matricula);

                await uts.AsistenteCaMama03Unidad.Eliminar(ultimoRegistro.Id);
                await uts.AsistenteCaMama03Unidad.InsertarLista(indicador);
            }
            else
            {
                var cp02 = await uts.AsistenteCaMama03Unidad.ObtenerCP02_Periodos(Indicadores.Periodo.Inicio);
                var crearIndicador = mapper.Map<List<CaMama03Unidad>>(cp02);
                var indicador = await crear.CrearCAMA03(crearIndicador, matricula);
                await uts.AsistenteCaMama03Unidad.InsertarLista(indicador);
            }
            await uts.GuardarServidorAPI();
            return true;
        }
    }
}
