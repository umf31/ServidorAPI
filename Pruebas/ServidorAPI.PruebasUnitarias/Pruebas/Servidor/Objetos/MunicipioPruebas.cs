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
//                  MunicipioPruebas : Creado 14-06-2022
//=======================================================================

#endregion

using Bogus;
using Microsoft.AspNetCore.Http;
using ServidorAPI.Infraestructura.Filtros.FluentValidator.Utils;
using ServidorAPI.Infraestructura.Objetos.Servidor.Editar;
using ServidorAPI.Infraestructura.Objetos.Servidor.Insertar;
using ServidorAPI.PruebasUnitarias.Utils;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServidorAPI.PruebasUnitarias.Pruebas.Servidor.Objetos
{
    public class MunicipioPruebas
    {
        private readonly Faker entidadFalsa = new("es_MX");

        public MunicipioPruebas()
        { }

        #region => Pruebas Unitarias al Objeto de Transferencia MunicipioEditar propiedad EstadoId

        [Fact]
        public async Task MunicipioEditar_EstadoId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                EstadoId = 1
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_EstadoId_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                EstadoId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Estado Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_EstadoId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                EstadoId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_EstadoId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new MunicipioEditar { EstadoId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Estado Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia MunicipioEditar propiedad Nombre

        [Fact]
        public async void MunicipioEditar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new MunicipioEditar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new MunicipioEditar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new MunicipioEditar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new MunicipioEditar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new MunicipioEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new MunicipioEditar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new MunicipioEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new MunicipioEditar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia MunicipioEditar propiedad Latitud

        [Fact]
        public async Task MunicipioEditar_Latitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Latitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new MunicipioEditar { Latitud = null, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Latitud_SuperaPrueba_ValorEntre90yMenos90Grados()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new MunicipioEditar { Latitud = 25.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Latitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new MunicipioEditar { Latitud = -99.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe estar entre -90 <-> 90 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Latitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };

            var resultado = validador.Validate(new MunicipioEditar { Latitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Latitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new MunicipioEditar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Latitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new MunicipioEditar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia MunicipioEditar propiedad Longitud

        [Fact]
        public async Task MunicipioEditar_Longitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Longitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                Latitud = 23.325874M,
                Longitud = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Longitud_SuperaPrueba_ValorEntre180yMenos180Grados()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                Latitud = 25.325685M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Longitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                Latitud = 29.325685M,
                Longitud = -230.358061M
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe estar entre -180 <-> 180 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Longitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };

            var resultado = validador.Validate(new MunicipioEditar { Longitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Longitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new MunicipioEditar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Longitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new MunicipioEditar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia MunicipioEditar propiedad Descripcion

        [Fact]
        public async Task MunicipioEditar_Descripcion_SuperaPrueba_ContieneMenos750Caracteres()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new MunicipioEditar
            {
                Descripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Descripcion_SuperaPrueba_LanzaExcepcionSuperior750Caracteres()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                Descripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Descripcion_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new MunicipioEditar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Descripcion_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia MunicipioEditar propiedad Foto

        [Fact]
        public async Task MunicipioEditar_Foto_SuperaPrueba_FotoFormatoCorrecto()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Foto_SuperaPrueba_LanzaExcepcionFotoFormatoIncorrecto()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.json");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.json"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/json",
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("Típo de archivo no validoͺ los tipos permitidos son image/jpeg, image/jpg, image/pngͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Foto_SuperaPrueba_ArchivoMenor2Mb()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioEditar_Foto_SuperaPrueba_LanzaExepcionArchivoMayor2Mb()
        {
            var validador = new Validacion<MunicipioEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible2.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible2.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new MunicipioEditar
            {
                Foto = archivo
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El archivo de imágen seleccionado supera los 2 Mb.permitidosͺ");
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia MunicipioInsertar propiedad EstadoId

        [Fact]
        public async Task MunicipioInsertar_EstadoId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                EstadoId = 1
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_EstadoId_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                EstadoId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Estado Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_EstadoId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                EstadoId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_EstadoId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new MunicipioInsertar { EstadoId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Estado Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia MunicipioInsertar propiedad Nombre

        [Fact]
        public async void MunicipioInsertar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new MunicipioInsertar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new MunicipioInsertar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new MunicipioInsertar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new MunicipioInsertar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new MunicipioInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new MunicipioInsertar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new MunicipioInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new MunicipioInsertar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia MunicipioInsertar propiedad Latitud

        [Fact]
        public async Task MunicipioInsertar_Latitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Latitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new MunicipioInsertar { Latitud = null, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Latitud_SuperaPrueba_ValorEntre90yMenos90Grados()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new MunicipioInsertar { Latitud = 25.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Latitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new MunicipioInsertar { Latitud = -99.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe estar entre -90 <-> 90 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Latitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };

            var resultado = validador.Validate(new MunicipioInsertar { Latitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Latitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new MunicipioInsertar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Latitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new MunicipioInsertar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia MunicipioInsertar propiedad Longitud

        [Fact]
        public async Task MunicipioInsertar_Longitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Longitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                Latitud = 23.325874M,
                Longitud = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Longitud_SuperaPrueba_ValorEntre180yMenos180Grados()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                Latitud = 25.325685M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Longitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                Latitud = 29.325685M,
                Longitud = -230.358061M
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe estar entre -180 <-> 180 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Longitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };

            var resultado = validador.Validate(new MunicipioInsertar { Longitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Longitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new MunicipioInsertar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Longitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new MunicipioInsertar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia MunicipioInsertar propiedad Descripcion

        [Fact]
        public async Task MunicipioInsertar_Descripcion_SuperaPrueba_ContieneMenos750Caracteres()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new MunicipioInsertar
            {
                Descripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Descripcion_SuperaPrueba_LanzaExcepcionSuperior750Caracteres()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                Descripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Descripcion_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new MunicipioInsertar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Descripcion_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia MunicipioInsertar propiedad Foto

        [Fact]
        public async Task MunicipioInsertar_Foto_SuperaPrueba_FotoFormatoCorrecto()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Foto_SuperaPrueba_LanzaExcepcionFotoFormatoIncorrecto()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.json");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.json"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/json",
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("Típo de archivo no validoͺ los tipos permitidos son image/jpeg, image/jpg, image/pngͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Foto_SuperaPrueba_ArchivoMenor2Mb()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MunicipioInsertar_Foto_SuperaPrueba_LanzaExepcionArchivoMayor2Mb()
        {
            var validador = new Validacion<MunicipioInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible2.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible2.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new MunicipioInsertar
            {
                Foto = archivo
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El archivo de imágen seleccionado supera los 2 Mb.permitidosͺ");
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        #endregion
    }
}