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
//               DelegacionPruebas : Creado 14-06-2022
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
    public class DelegacionPruebas
    {
        private readonly Faker entidadFalsa = new("es_MX");

        public DelegacionPruebas()
        { }

        #region => Pruebas Unitarias al Objeto de Transferencia DelegacionEditar propiedad EstadoId

        [Fact]
        public async Task DelegacionEditar_EstadoId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                EstadoId = 1
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_EstadoId_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                EstadoId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Estado Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_EstadoId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                EstadoId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_EstadoId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new DelegacionEditar { EstadoId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Estado Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia DelegacionEditar propiedad Nombre

        [Fact]
        public async void DelegacionEditar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new DelegacionEditar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new DelegacionEditar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new DelegacionEditar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new DelegacionEditar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new DelegacionEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new DelegacionEditar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new DelegacionEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new DelegacionEditar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia DelegacionEditar propiedad Latitud

        [Fact]
        public async Task DelegacionEditar_Latitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Latitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new DelegacionEditar { Latitud = null, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Latitud_SuperaPrueba_ValorEntre90yMenos90Grados()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new DelegacionEditar { Latitud = 25.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Latitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new DelegacionEditar { Latitud = -99.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe estar entre -90 <-> 90 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Latitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };

            var resultado = validador.Validate(new DelegacionEditar { Latitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Latitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new DelegacionEditar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Latitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new DelegacionEditar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia DelegacionEditar propiedad Longitud

        [Fact]
        public async Task DelegacionEditar_Longitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Longitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                Latitud = 23.325874M,
                Longitud = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Longitud_SuperaPrueba_ValorEntre180yMenos180Grados()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                Latitud = 25.325685M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Longitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                Latitud = 29.325685M,
                Longitud = -230.358061M
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe estar entre -180 <-> 180 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Longitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };

            var resultado = validador.Validate(new DelegacionEditar { Longitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Longitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new DelegacionEditar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Longitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new DelegacionEditar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia DelegacionEditar propiedad Descripcion

        [Fact]
        public async Task DelegacionEditar_Descripcion_SuperaPrueba_ContieneMenos750Caracteres()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DelegacionEditar
            {
                Descripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Descripcion_SuperaPrueba_LanzaExcepcionSuperior750Caracteres()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                Descripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Descripcion_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DelegacionEditar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Descripcion_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia DelegacionEditar propiedad Foto

        [Fact]
        public async Task DelegacionEditar_Foto_SuperaPrueba_FotoFormatoCorrecto()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Foto_SuperaPrueba_LanzaExcepcionFotoFormatoIncorrecto()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.json");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.json"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/json",
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("Típo de archivo no validoͺ los tipos permitidos son image/jpeg, image/jpg, image/pngͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Foto_SuperaPrueba_ArchivoMenor2Mb()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionEditar_Foto_SuperaPrueba_LanzaExepcionArchivoMayor2Mb()
        {
            var validador = new Validacion<DelegacionEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible2.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible2.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new DelegacionEditar
            {
                Foto = archivo
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El archivo de imágen seleccionado supera los 2 Mb.permitidosͺ");
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DelegacionInsertar propiedad EstadoId

        [Fact]
        public async Task DelegacionInsertar_EstadoId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new DelegacionInsertar
            {
                EstadoId = 1
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_EstadoId_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new DelegacionInsertar
            {
                EstadoId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Estado Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_EstadoId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new DelegacionInsertar
            {
                EstadoId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_EstadoId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.EstadoId!).Requerido()
            };
            var resultado = validador.Validate(new DelegacionInsertar { EstadoId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Estado Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia DelegacionInsertar propiedad Nombre

        [Fact]
        public async void DelegacionInsertar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new DelegacionInsertar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new DelegacionInsertar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new DelegacionInsertar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new DelegacionInsertar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new DelegacionInsertar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new DelegacionInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new DelegacionInsertar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new DelegacionInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new DelegacionInsertar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia DelegacionInsertar propiedad Latitud

        [Fact]
        public async Task DelegacionInsertar_Latitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new DelegacionInsertar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Latitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new DelegacionInsertar { Latitud = null, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Latitud_SuperaPrueba_ValorEntre90yMenos90Grados()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new DelegacionInsertar { Latitud = 25.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Latitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new DelegacionInsertar { Latitud = -99.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe estar entre -90 <-> 90 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Latitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };

            var resultado = validador.Validate(new DelegacionInsertar { Latitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Latitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new DelegacionInsertar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Latitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new DelegacionInsertar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia DelegacionInsertar propiedad Longitud

        [Fact]
        public async Task DelegacionInsertar_Longitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new DelegacionInsertar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Longitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new DelegacionInsertar
            {
                Latitud = 23.325874M,
                Longitud = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Longitud_SuperaPrueba_ValorEntre180yMenos180Grados()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new DelegacionInsertar
            {
                Latitud = 25.325685M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Longitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new DelegacionInsertar
            {
                Latitud = 29.325685M,
                Longitud = -230.358061M
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe estar entre -180 <-> 180 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Longitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };

            var resultado = validador.Validate(new DelegacionInsertar { Longitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Longitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new DelegacionInsertar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Longitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new DelegacionInsertar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia DelegacionInsertar propiedad Descripcion

        [Fact]
        public async Task DelegacionInsertar_Descripcion_SuperaPrueba_ContieneMenos750Caracteres()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DelegacionInsertar
            {
                Descripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Descripcion_SuperaPrueba_LanzaExcepcionSuperior750Caracteres()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DelegacionInsertar
            {
                Descripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Descripcion_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DelegacionInsertar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Descripcion_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DelegacionInsertar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia DelegacionInsertar propiedad Foto

        [Fact]
        public async Task DelegacionInsertar_Foto_SuperaPrueba_FotoFormatoCorrecto()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new DelegacionInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Foto_SuperaPrueba_LanzaExcepcionFotoFormatoIncorrecto()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.json");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.json"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/json",
            };
            var resultado = validador.Validate(new DelegacionInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("Típo de archivo no validoͺ los tipos permitidos son image/jpeg, image/jpg, image/pngͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Foto_SuperaPrueba_ArchivoMenor2Mb()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new DelegacionInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DelegacionInsertar_Foto_SuperaPrueba_LanzaExepcionArchivoMayor2Mb()
        {
            var validador = new Validacion<DelegacionInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible2.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible2.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new DelegacionInsertar
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