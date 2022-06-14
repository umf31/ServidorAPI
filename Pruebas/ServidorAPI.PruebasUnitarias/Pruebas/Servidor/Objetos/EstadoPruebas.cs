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
//                  EstadoPruebas : Creado 14-06-2022
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
    public class EstadoPruebas
    {
        private readonly Faker entidadFalsa = new("es_MX");

        public EstadoPruebas()
        { }

        #region => Pruebas Unitarias al Objeto de Transferencia EstadoEditar propiedad PaisId

        [Fact]
        public async Task EstadoEditar_PaisId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.PaisId!).Requerido()
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                PaisId = 1
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_PaisId_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.PaisId!).Requerido()
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                PaisId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Pais Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_PaisId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.PaisId!).Requerido()
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                PaisId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_PaisId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.PaisId!).Requerido()
            };
            var resultado = validador.Validate(new EstadoEditar { PaisId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Pais Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EstadoEditar propiedad Nombre

        [Fact]
        public async void EstadoEditar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EstadoEditar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EstadoEditar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EstadoEditar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EstadoEditar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new EstadoEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EstadoEditar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new EstadoEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EstadoEditar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EstadoEditar propiedad Abrev

        [Fact]
        public async Task EstadoEditar_Abrev_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Abrev!).AbrevReq()
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                Abrev = "Mex"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Abrev_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Abrev!).AbrevReq()
            };

            var resultado = validador.Validate(new EstadoEditar
            {
                Abrev = ""
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Abrev no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Abrev_SuperaPrueba_Menor6Caracteres()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Abrev!).AbrevReq()
            };

            var resultado = validador.Validate(new EstadoEditar
            {
                Abrev = entidadFalsa.Random.String2(3, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Abrev_SuperaPrueba_EnviaExcepcionMayor6Caracteres()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Abrev!).AbrevReq()
            };

            var resultado = validador.Validate(new EstadoEditar
            {
                Abrev = entidadFalsa.Random.String2(7, 7)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Abrev debe tener entre 2 y 6 caracteresͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EstadoEditar propiedad Latitud

        [Fact]
        public async Task EstadoEditar_Latitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Latitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EstadoEditar { Latitud = null, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Latitud_SuperaPrueba_ValorEntre90yMenos90Grados()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EstadoEditar { Latitud = 25.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Latitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EstadoEditar { Latitud = -99.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe estar entre -90 <-> 90 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Latitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };

            var resultado = validador.Validate(new EstadoEditar { Latitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Latitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EstadoEditar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Latitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EstadoEditar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EstadoEditar propiedad Longitud

        [Fact]
        public async Task EstadoEditar_Longitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Longitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                Latitud = 23.325874M,
                Longitud = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Longitud_SuperaPrueba_ValorEntre180yMenos180Grados()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                Latitud = 25.325685M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Longitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                Latitud = 29.325685M,
                Longitud = -230.358061M
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe estar entre -180 <-> 180 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Longitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };

            var resultado = validador.Validate(new EstadoEditar { Longitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Longitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EstadoEditar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Longitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EstadoEditar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EstadoEditar propiedad Descripcion

        [Fact]
        public async Task EstadoEditar_Descripcion_SuperaPrueba_ContieneMenos750Caracteres()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new EstadoEditar
            {
                Descripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Descripcion_SuperaPrueba_LanzaExcepcionSuperior750Caracteres()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                Descripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Descripcion_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new EstadoEditar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Descripcion_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validador = new Validacion<EstadoEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EstadoEditar propiedad Foto

        [Fact]
        public async Task EstadoEditar_Foto_SuperaPrueba_FotoFormatoCorrecto()
        {
            var validador = new Validacion<EstadoEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Foto_SuperaPrueba_LanzaExcepcionFotoFormatoIncorrecto()
        {
            var validador = new Validacion<EstadoEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.json");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.json"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/json",
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("Típo de archivo no validoͺ los tipos permitidos son image/jpeg, image/jpg, image/pngͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Foto_SuperaPrueba_ArchivoMenor2Mb()
        {
            var validador = new Validacion<EstadoEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoEditar_Foto_SuperaPrueba_LanzaExepcionArchivoMayor2Mb()
        {
            var validador = new Validacion<EstadoEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible2.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible2.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new EstadoEditar
            {
                Foto = archivo
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El archivo de imágen seleccionado supera los 2 Mb.permitidosͺ");
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EstadoInsertar propiedad PaisId

        [Fact]
        public async Task EstadoInsertar_PaisId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.PaisId!).Requerido()
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                PaisId = 1
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_PaisId_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.PaisId!).Requerido()
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                PaisId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Pais Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_PaisId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.PaisId!).Requerido()
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                PaisId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_PaisId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.PaisId!).Requerido()
            };
            var resultado = validador.Validate(new EstadoInsertar { PaisId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Pais Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EstadoInsertar propiedad Nombre

        [Fact]
        public async void EstadoInsertar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EstadoInsertar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EstadoInsertar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EstadoInsertar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EstadoInsertar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new EstadoInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EstadoInsertar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new EstadoInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EstadoInsertar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EstadoInsertar propiedad Abrev

        [Fact]
        public async Task EstadoInsertar_Abrev_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Abrev!).AbrevReq()
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                Abrev = "Mex"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Abrev_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Abrev!).AbrevReq()
            };

            var resultado = validador.Validate(new EstadoInsertar
            {
                Abrev = ""
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Abrev no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Abrev_SuperaPrueba_Menor6Caracteres()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Abrev!).AbrevReq()
            };

            var resultado = validador.Validate(new EstadoInsertar
            {
                Abrev = entidadFalsa.Random.String2(3, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Abrev_SuperaPrueba_EnviaExcepcionMayor6Caracteres()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Abrev!).AbrevReq()
            };

            var resultado = validador.Validate(new EstadoInsertar
            {
                Abrev = entidadFalsa.Random.String2(7, 7)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Abrev debe tener entre 2 y 6 caracteresͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EstadoInsertar propiedad Latitud

        [Fact]
        public async Task EstadoInsertar_Latitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Latitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EstadoInsertar { Latitud = null, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Latitud_SuperaPrueba_ValorEntre90yMenos90Grados()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EstadoInsertar { Latitud = 25.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Latitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EstadoInsertar { Latitud = -99.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe estar entre -90 <-> 90 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Latitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };

            var resultado = validador.Validate(new EstadoInsertar { Latitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Latitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EstadoInsertar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Latitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EstadoInsertar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EstadoInsertar propiedad Longitud

        [Fact]
        public async Task EstadoInsertar_Longitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Longitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                Latitud = 23.325874M,
                Longitud = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Longitud_SuperaPrueba_ValorEntre180yMenos180Grados()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                Latitud = 25.325685M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Longitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                Latitud = 29.325685M,
                Longitud = -230.358061M
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe estar entre -180 <-> 180 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Longitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };

            var resultado = validador.Validate(new EstadoInsertar { Longitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Longitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EstadoInsertar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Longitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EstadoInsertar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EstadoInsertar propiedad Descripcion

        [Fact]
        public async Task EstadoInsertar_Descripcion_SuperaPrueba_ContieneMenos750Caracteres()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new EstadoInsertar
            {
                Descripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Descripcion_SuperaPrueba_LanzaExcepcionSuperior750Caracteres()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                Descripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Descripcion_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new EstadoInsertar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Descripcion_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EstadoInsertar propiedad Foto

        [Fact]
        public async Task EstadoInsertar_Foto_SuperaPrueba_FotoFormatoCorrecto()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Foto_SuperaPrueba_LanzaExcepcionFotoFormatoIncorrecto()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.json");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.json"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/json",
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("Típo de archivo no validoͺ los tipos permitidos son image/jpeg, image/jpg, image/pngͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Foto_SuperaPrueba_ArchivoMenor2Mb()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new EstadoInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EstadoInsertar_Foto_SuperaPrueba_LanzaExepcionArchivoMayor2Mb()
        {
            var validador = new Validacion<EstadoInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible2.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible2.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new EstadoInsertar
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