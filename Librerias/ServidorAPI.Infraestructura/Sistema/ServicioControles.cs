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
//               AgregarControladores: Creado 05-06-2022
//=======================================================================

#endregion

using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ServidorAPI.Infraestructura.Filtros.ControlExcepciones;
using ServidorAPI.Infraestructura.Filtros.FluentValidator.Utils;
using System.Text.Json.Serialization;

namespace ServidorAPI.Infraestructura.Sistema
{
    public static class ServicioControles
    {
        public static IServiceCollection AddController(this IServiceCollection services)
        {
            services.AddControllers(opciones =>
            {
                opciones.Filters.Add<ExcepcionBloqueado>();
                opciones.Filters.Add<ExcepcionConflicto>();
                opciones.Filters.Add<ExcepcionErrorInterno>();
                opciones.Filters.Add<ExcepcionNoAceptable>();
                opciones.Filters.Add<ExcepcionNoEncontrado>();
                opciones.Filters.Add<ExcepcionSolicitudInvalida>();
                opciones.Filters.Add<ExcepcionBase>();
            })
            .AddMvcOptions(options =>
            {
                options.Filters.Add<ExcepcionModelState>();
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            })
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                options.ValidatorOptions.DisplayNameResolver = (type, memberInfo, expression) =>
                options.ValidatorOptions.PropertyNameResolver(type, memberInfo, expression);
                options.ValidatorOptions.PropertyNameResolver = ConfiguracionValidacion.ModificarNombrePropiedad;
            });
            return services;
        }
    }
}