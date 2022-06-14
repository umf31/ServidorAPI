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
//                  ProcesoPruebas : Creado 14-06-2022
//=======================================================================

#endregion

using Bogus;
using Microsoft.AspNetCore.Http;
using ServidorAPI.Infraestructura.Filtros.FluentValidator.Utils;
using ServidorAPI.Infraestructura.Objetos.Sadim.Editar;
using ServidorAPI.Infraestructura.Objetos.Sadim.Insertar;
using ServidorAPI.PruebasUnitarias.Utils;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServidorAPI.PruebasUnitarias.Pruebas.Sadim.Objetos
{
    public class ProcesoPruebas
    {
        private readonly Faker entidadFalsa = new("es_MX");

        public ProcesoPruebas()
        { }

        #region => Pruebas Unitarias al objeto de transferencia ProcesoEditar propiedad Nombre

        [Fact]
        public async void ProcesoEditar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new ProcesoEditar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoEditar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoEditar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoEditar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoEditar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new ProcesoEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoEditar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new ProcesoEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoEditar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia ProcesoEditar propiedad NombreCorto

        [Fact]
        public async void ProcesoEditar_NombreCorto_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };
            var resultado = validador.Validate(new ProcesoEditar
            {
                NombreCorto = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_NombreCorto_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoEditar
            {
                NombreCorto = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Corto no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_NombreCorto_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoEditar
            {
                NombreCorto = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_NombreCorto_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoEditar
            {
                NombreCorto = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_NombreCorto_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoEditar
            {
                NombreCorto = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Corto solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_NombreCorto_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var result = validator.Validate(new ProcesoEditar { NombreCorto = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_NombreCorto_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoEditar
            {
                NombreCorto = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Corto contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_NombreCorto_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var result = validator.Validate(new ProcesoEditar { NombreCorto = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_NombreCorto_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoEditar
            {
                NombreCorto = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Corto contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia ProcesoEditar propiedad Descripcion

        [Fact]
        public async Task ProcesoEditar_Descripcion_SuperaPrueba_ContieneMenos750Caracteres()
        {
            var validador = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new ProcesoEditar
            {
                Descripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_Descripcion_SuperaPrueba_LanzaExcepcionSuperior750Caracteres()
        {
            var validador = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new ProcesoEditar
            {
                Descripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_Descripcion_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validador = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new ProcesoEditar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_Descripcion_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validador = new Validacion<ProcesoEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new ProcesoEditar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia ProcesoEditar propiedad Foto

        [Fact]
        public async Task ProcesoEditar_Foto_SuperaPrueba_FotoFormatoCorrecto()
        {
            var validador = new Validacion<ProcesoEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new ProcesoEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_Foto_SuperaPrueba_LanzaExcepcionFotoFormatoIncorrecto()
        {
            var validador = new Validacion<ProcesoEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.json");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.json"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/json",
            };
            var resultado = validador.Validate(new ProcesoEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("Típo de archivo no validoͺ los tipos permitidos son image/jpeg, image/jpg, image/pngͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_Foto_SuperaPrueba_ArchivoMenor2Mb()
        {
            var validador = new Validacion<ProcesoEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new ProcesoEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoEditar_Foto_SuperaPrueba_LanzaExepcionArchivoMayor2Mb()
        {
            var validador = new Validacion<ProcesoEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible2.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible2.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new ProcesoEditar
            {
                Foto = archivo
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El archivo de imágen seleccionado supera los 2 Mb.permitidosͺ");
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia ProcesoInsertar propiedad Nombre

        [Fact]
        public async void ProcesoInsertar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new ProcesoInsertar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoInsertar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoInsertar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoInsertar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoInsertar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new ProcesoInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoInsertar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new ProcesoInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoInsertar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia ProcesoInsertar propiedad NombreCorto

        [Fact]
        public async void ProcesoInsertar_NombreCorto_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };
            var resultado = validador.Validate(new ProcesoInsertar
            {
                NombreCorto = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_NombreCorto_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoInsertar
            {
                NombreCorto = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Corto no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_NombreCorto_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoInsertar
            {
                NombreCorto = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_NombreCorto_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoInsertar
            {
                NombreCorto = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_NombreCorto_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoInsertar
            {
                NombreCorto = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Corto solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_NombreCorto_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var result = validator.Validate(new ProcesoInsertar { NombreCorto = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_NombreCorto_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoInsertar
            {
                NombreCorto = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Corto contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_NombreCorto_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var result = validator.Validate(new ProcesoInsertar { NombreCorto = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_NombreCorto_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.NombreCorto!).NombreReq()
            };

            var resultado = validator.Validate(new ProcesoInsertar
            {
                NombreCorto = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Corto contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia ProcesoInsertar propiedad Descripcion

        [Fact]
        public async Task ProcesoInsertar_Descripcion_SuperaPrueba_ContieneMenos750Caracteres()
        {
            var validador = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new ProcesoInsertar
            {
                Descripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_Descripcion_SuperaPrueba_LanzaExcepcionSuperior750Caracteres()
        {
            var validador = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new ProcesoInsertar
            {
                Descripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_Descripcion_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validador = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new ProcesoInsertar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_Descripcion_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validador = new Validacion<ProcesoInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new ProcesoInsertar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia ProcesoInsertar propiedad Foto

        [Fact]
        public async Task ProcesoInsertar_Foto_SuperaPrueba_FotoFormatoCorrecto()
        {
            var validador = new Validacion<ProcesoInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new ProcesoInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_Foto_SuperaPrueba_LanzaExcepcionFotoFormatoIncorrecto()
        {
            var validador = new Validacion<ProcesoInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.json");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.json"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/json",
            };
            var resultado = validador.Validate(new ProcesoInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("Típo de archivo no validoͺ los tipos permitidos son image/jpeg, image/jpg, image/pngͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_Foto_SuperaPrueba_ArchivoMenor2Mb()
        {
            var validador = new Validacion<ProcesoInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new ProcesoInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ProcesoInsertar_Foto_SuperaPrueba_LanzaExepcionArchivoMayor2Mb()
        {
            var validador = new Validacion<ProcesoInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible2.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible2.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new ProcesoInsertar
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