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
//                  ICrearIndicador: Creado 16-06-2022
//=======================================================================

#endregion


using ServidorAPI.Dominio.Entidades.Sadim;

namespace ServidorAPI.Dominio.Interfaces.Utils
{
    public interface ICrearIndicador
    {
        Task<List<Dm01Unidad>> CrearDM01(List<Dm01Unidad> indicador, string matricula);
        Task<List<Dm02Unidad>> CrearDM02(List<Dm02Unidad> indicador, string matricula);
        Task<List<Dm04Unidad>> CrearDM04(List<Dm04Unidad> indicador, string matricula);
        Task<List<Dm05Unidad>> CrearDM05(List<Dm05Unidad> indicador, string matricula);
        Task<List<Eh01Unidad>> CrearEH01(List<Eh01Unidad> indicador, string matricula);
        Task<List<Eh02Unidad>> CrearEH02(List<Eh02Unidad> indicador, string matricula);
        Task<List<Eh04Unidad>> CrearEH04(List<Eh04Unidad> indicador, string matricula);
        Task<List<CaMama01Unidad>> CrearCAMA01(List<CaMama01Unidad> indicador, string matricula);
        Task<List<CaMama02Unidad>> CrearCAMA02(List<CaMama02Unidad> indicador, string matricula);
        Task<List<CaMama03Unidad>> CrearCAMA03(List<CaMama03Unidad> indicador, string matricula);
        Task<List<CaCu01Unidad>> CrearCACU01(List<CaCu01Unidad> indicador, string matricula);
        Task<List<Materna01Unidad>> CrearMaterna01(List<Materna01Unidad> indicador, string matricula);
        Task<List<Materna02Unidad>> CrearMaterna02(List<Materna02Unidad> indicador, string matricula);
        Task<List<Materna03Unidad>> CrearMaterna03(List<Materna03Unidad> indicador, string matricula);
        Task<List<Materna04Unidad>> CrearMaterna04(List<Materna04Unidad> indicador, string matricula);
        Task<List<SOb01Unidad>> CrearSOb01(List<SOb01Unidad> indicador, string matricula);
        Task<List<Caispn01Unidad>> CrearCAISPN01(List<Caispn01Unidad> indicador, string matricula);
        Task<List<Caispn02Unidad>> CrearCAISPN02(List<Caispn02Unidad> indicador, string matricula);
        Task<List<Caispn04Unidad>> CrearCAISPN04(List<Caispn04Unidad> indicador, string matricula);
        Task<List<Caispn05Unidad>> CrearCAISPN05(List<Caispn05Unidad> indicador, string matricula);
        Task<List<Caispn08Unidad>> CrearCAISPN08(List<Caispn08Unidad> indicador, string matricula);
        Task<List<Caispn09Unidad>> CrearCAISPN09(List<Caispn09Unidad> indicador, string matricula);
        Task<List<Caispn14Unidad>> CrearCAISPN14(List<Caispn14Unidad> indicador, string matricula);

    }
}