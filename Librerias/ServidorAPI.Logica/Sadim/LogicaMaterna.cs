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
//                 IDiabetesUnidad: Creado 16-06-2022
//=======================================================================

#endregion

using AutoMapper;
using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Interfaces.Logica.Sadim;
using ServidorAPI.Dominio.Interfaces.UnidadTrabajo;
using ServidorAPI.Dominio.Interfaces.Utils;

namespace ServidorAPI.Logica.Sadim
{
    public class LogicaMaterna : ILogicaMaterna
    {
        internal readonly ILogicaMaterna01Unidad<Materna01Unidad> logicaMaterna01Unidad = null!;
        internal readonly ILogicaMaterna02Unidad<Materna02Unidad> logicaMaterna02Unidad = null!;
        internal readonly ILogicaMaterna03Unidad<Materna03Unidad> logicaMaterna03Unidad = null!;
        internal readonly ILogicaMaterna04Unidad<Materna04Unidad> logicaMaterna04Unidad = null!;
        private readonly IMapper mapper;
        private readonly ISadimUT uts;
        private readonly IPagSadim lista;
        private readonly ICrearIndicador crear;
        public LogicaMaterna(IMapper _mapper, ISadimUT _uts, IPagSadim _lista, ICrearIndicador _crear)
        {
            mapper = _mapper;
            uts = _uts;
            lista = _lista;
            crear = _crear;
        }
        public ILogicaMaterna01Unidad<Materna01Unidad> LogicaMaterna01Unidad => logicaMaterna01Unidad ?? new LogicaMaterna01Unidad<Materna01Unidad>(mapper, uts, lista, crear);

        public ILogicaMaterna02Unidad<Materna02Unidad> LogicaMaterna02Unidad => logicaMaterna02Unidad ?? new LogicaMaterna02Unidad<Materna02Unidad>(mapper, uts, lista, crear);

        public ILogicaMaterna03Unidad<Materna03Unidad> LogicaMaterna03Unidad => logicaMaterna03Unidad ?? new LogicaMaterna03Unidad<Materna03Unidad>(mapper, uts, lista, crear);

        public ILogicaMaterna04Unidad<Materna04Unidad> LogicaMaterna04Unidad => logicaMaterna04Unidad ?? new LogicaMaterna04Unidad<Materna04Unidad>(mapper, uts, lista, crear);
    }
}
