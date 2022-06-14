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
//               https://github.com/umf31/ServidorAPI
//                ServicioSwaggerGen: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ServidorAPI.Infraestructura.Sistema
{
    public static class ServicioSwaggerGen
    {
        public static IServiceCollection AddSwaggerGen(this IServiceCollection services, string archivoDocumentacion)
        {
            services.AddSwaggerGen(opciones =>
            {
                opciones.SwaggerDoc("ServidorAPI", new OpenApiInfo()
                {
                    Title = " API Servidor-SADIM",
                    Version = "05.06.22",
                    Description = "Interfaz de programación de aplicaciones (API RESTful)",
                    Contact = new OpenApiContact()
                    {
                        Email = "aldair_1@hotmail.com",
                        Name = "Lic. Simón Pedro Meléndez Villarreal",
                        Url = new Uri("https://www.facebook.com/simonpedromelendez")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "MIT License",
                        Url = new Uri("https://es.wikipedia.org/wiki/MIT_License")
                    },
                });
                opciones.SwaggerDoc("SADIM", new OpenApiInfo()
                {
                    Title = "API-SADIM",
                    Version = "05.06.22",
                    Description = "Interfaz de programación de aplicaciones (API RESTful) para el cliente IMSS-SADIM",
                    Contact = new OpenApiContact()
                    {
                        Email = "aldair_1@hotmail.com",
                        Name = "Lic. Simón Pedro Meléndez Villarreal",
                        Url = new Uri("https://www.facebook.com/simonpedromelendez")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "MIT License",
                        Url = new Uri("https://es.wikipedia.org/wiki/MIT_License")
                    },
                });
                opciones.CustomSchemaIds(type => type.FullName);
                string archivoXmlComentarios = archivoDocumentacion;
                string rutaApiComentarios = Path.Combine(AppContext.BaseDirectory, archivoXmlComentarios);
                opciones.IncludeXmlComments(rutaApiComentarios);
                opciones.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Autenticación JWT (Bearer)",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });
                opciones.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });
            });
            return services;
        }
    }
}