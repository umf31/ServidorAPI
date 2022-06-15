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
//              InyeccionDependecias: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.Extensions.DependencyInjection;
using ServidorAPI.Dominio.Interfaces.Logica.Sadim;
using ServidorAPI.Dominio.Interfaces.Logica.Servidor;
using ServidorAPI.Dominio.Interfaces.UnidadTrabajo;
using ServidorAPI.Dominio.Interfaces.Utils;
using ServidorAPI.Logica.Sadim;
using ServidorAPI.Logica.Servidor;
using ServidorAPI.Persistencia.Conectividad.Contexto;
using ServidorAPI.Persistencia.UnidadTrabajo;
using ServidorAPI.Persistencia.Utils;

namespace ServidorAPI.Logica.Utils;

public static class InyeccionDependecias
{
    public static IServiceCollection AddDependencias(this IServiceCollection services)
    {
        services
            .AddHttpContextAccessor()
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
            .AddTransient<SoporteContexto>()
            .AddTransient<ServidorContexto>()
            .AddScoped<ISadimUT, SadimUT>()
            .AddScoped<IServidorUT, ServidorUT>()
            .AddScoped<IAlimentador, Alimentador>()
            .AddScoped<IAlmacenamiento, Almacenamiento>()
            .AddScoped<IUtilerias, Utilerias>()
            .AddScoped<IPagServidor, PagServidor>()
            .AddScoped<IPagSadim, PagSadim>()
            .AddScoped<ILogicaAutorizacion, LogicaAutorizacion>()
            .AddScoped<ILogicaServicio, LogicaServicio>()
            .AddScoped(typeof(IPaginacion<>), typeof(Paginacion<>))
            .AddScoped(typeof(ILogicaStatus<>), typeof(LogicaStatus<>))
            .AddScoped(typeof(ILogicaCategoria<>), typeof(LogicaCategoria<>))
            .AddScoped(typeof(ILogicaPais<>), typeof(LogicaPais<>))
            .AddScoped(typeof(ILogicaEstado<>), typeof(LogicaEstado<>))
            .AddScoped(typeof(ILogicaMunicipio<>), typeof(LogicaMunicipio<>))
            .AddScoped(typeof(ILogicaAsentamiento<>), typeof(LogicaAsentamiento<>))
            .AddScoped(typeof(ILogicaColonia<>), typeof(LogicaColonia<>))
            .AddScoped(typeof(ILogicaDelegacion<>), typeof(LogicaDelegacion<>))
            .AddScoped(typeof(ILogicaUnidadTipo<>), typeof(LogicaUnidadTipo<>))
            .AddScoped(typeof(ILogicaVialidad<>), typeof(LogicaVialidad<>))
            .AddScoped(typeof(ILogicaUnidad<>), typeof(LogicaUnidad<>))
            .AddScoped(typeof(ILogicaEmpleado<>), typeof(LogicaEmpleado<>))
            .AddScoped(typeof(ILogicaProceso<>), typeof(LogicaProceso<>))
            .AddScoped(typeof(ILogicaPeriodo<>), typeof(LogicaPeriodo<>))
            .AddScoped(typeof(ILogicaDetalle<>), typeof(LogicaDetalle<>))
            .AddScoped(typeof(ILogicaMeta<>), typeof(LogicaMeta<>));
        return services;
    }
}