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
    public class LogicaEh : ILogicaEh
    {
        internal readonly ILogicaEh01Unidad<Eh01Unidad> logicaEh01Unidad = null!;
        internal readonly ILogicaEh02Unidad<Eh02Unidad> logicaEh02Unidad = null!;
        internal readonly ILogicaEh04Unidad<Eh04Unidad> logicaEh04Unidad = null!;
        private readonly IMapper mapper;
        private readonly ISadimUT uts;
        private readonly IPagSadim lista;
        private readonly ICrearIndicador crear;
        public LogicaEh(IMapper _mapper, ISadimUT _uts, IPagSadim _lista, ICrearIndicador _crear)
        {
            mapper = _mapper;
            uts = _uts;
            lista = _lista;
            crear = _crear;
        }
        public ILogicaEh01Unidad<Eh01Unidad> LogicaEh01Unidad => logicaEh01Unidad ?? new LogicaEh01Unidad<Eh01Unidad>(mapper, uts, lista, crear);

        public ILogicaEh02Unidad<Eh02Unidad> LogicaEh02Unidad => logicaEh02Unidad ?? new LogicaEh02Unidad<Eh02Unidad>(mapper, uts, lista, crear);

        public ILogicaEh04Unidad<Eh04Unidad> LogicaEh04Unidad => logicaEh04Unidad ?? new LogicaEh04Unidad<Eh04Unidad>(mapper, uts, lista, crear);

    }
}
