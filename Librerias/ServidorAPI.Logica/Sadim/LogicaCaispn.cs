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
    public class LogicaCaispn : ILogicaCaispn
    {
        internal readonly ILogicaCaispn01Unidad<Caispn01Unidad> logicaCaispn01Unidad = null!;
        internal readonly ILogicaCaispn02Unidad<Caispn02Unidad> logicaCaispn02Unidad = null!;
        internal readonly ILogicaCaispn04Unidad<Caispn04Unidad> logicaCaispn04Unidad = null!;
        internal readonly ILogicaCaispn05Unidad<Caispn05Unidad> logicaCaispn05Unidad = null!;
        internal readonly ILogicaCaispn08Unidad<Caispn08Unidad> logicaCaispn08Unidad = null!;
        internal readonly ILogicaCaispn09Unidad<Caispn09Unidad> logicaCaispn09Unidad = null!;
        internal readonly ILogicaCaispn14Unidad<Caispn14Unidad> logicaCaispn14Unidad = null!;
        private readonly IMapper mapper;
        private readonly ISadimUT uts;
        private readonly IPagSadim lista;
        private readonly ICrearIndicador crear;
        public LogicaCaispn(IMapper _mapper, ISadimUT _uts, IPagSadim _lista, ICrearIndicador _crear)
        {
            mapper = _mapper;
            uts = _uts;
            lista = _lista;
            crear = _crear;
        }

        public ILogicaCaispn01Unidad<Caispn01Unidad> LogicaCaispn01Unidad => logicaCaispn01Unidad ?? new LogicaCaispn01Unidad<Caispn01Unidad>(mapper, uts, lista, crear);
        public ILogicaCaispn02Unidad<Caispn02Unidad> LogicaCaispn02Unidad => logicaCaispn02Unidad ?? new LogicaCaispn02Unidad<Caispn02Unidad>(mapper, uts, lista, crear);
        public ILogicaCaispn04Unidad<Caispn04Unidad> LogicaCaispn04Unidad => logicaCaispn04Unidad ?? new LogicaCaispn04Unidad<Caispn04Unidad>(mapper, uts, lista, crear);
        public ILogicaCaispn05Unidad<Caispn05Unidad> LogicaCaispn05Unidad => logicaCaispn05Unidad ?? new LogicaCaispn05Unidad<Caispn05Unidad>(mapper, uts, lista, crear);
        public ILogicaCaispn08Unidad<Caispn08Unidad> LogicaCaispn08Unidad => logicaCaispn08Unidad ?? new LogicaCaispn08Unidad<Caispn08Unidad>(mapper, uts, lista, crear);
        public ILogicaCaispn09Unidad<Caispn09Unidad> LogicaCaispn09Unidad => logicaCaispn09Unidad ?? new LogicaCaispn09Unidad<Caispn09Unidad>(mapper, uts, lista, crear);
        public ILogicaCaispn14Unidad<Caispn14Unidad> LogicaCaispn14Unidad => logicaCaispn14Unidad ?? new LogicaCaispn14Unidad<Caispn14Unidad>(mapper, uts, lista, crear);
    }
}
