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
//                  PaisPruebas : Creado 14-06-2022
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
    public class PaisPruebas
    {
        private readonly Faker entidadFalsa = new("es_MX");

        public PaisPruebas()
        { }

        #region => Pruebas Unitarias al objeto de transferencia PaisEditar propiedad Nombre

        [Fact]
        public async void PaisEditar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new PaisEditar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new PaisEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new PaisEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia PaisEditar propiedad NombreOficial

        [Fact]
        public async void PaisEditar_NombreOficial_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };
            var resultado = validador.Validate(new PaisEditar
            {
                NombreOficial = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_NombreOficial_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                NombreOficial = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Oficial no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_NombreOficial_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                NombreOficial = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_NombreOficial_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                NombreOficial = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_NombreOficial_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                NombreOficial = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Oficial solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_NombreOficial_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var result = validator.Validate(new PaisEditar { NombreOficial = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_NombreOficial_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                NombreOficial = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Oficial contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_NombreOficial_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var result = validator.Validate(new PaisEditar { NombreOficial = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_NombreOficial_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                NombreOficial = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Oficial contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia PaisEditar propiedad Capital

        [Fact]
        public async void PaisEditar_Capital_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };
            var resultado = validador.Validate(new PaisEditar
            {
                Capital = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Capital_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                Capital = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Capital no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Capital_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                Capital = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Capital_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                Capital = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Capital_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                Capital = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Capital solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Capital_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var result = validator.Validate(new PaisEditar { Capital = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Capital_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                Capital = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Capital contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Capital_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var result = validator.Validate(new PaisEditar { Capital = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Capital_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var resultado = validator.Validate(new PaisEditar
            {
                Capital = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Capital contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia PaisEditar propiedad Latitud

        [Fact]
        public async Task PaisEditar_Latitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new PaisEditar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Latitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new PaisEditar { Latitud = null, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Latitud_SuperaPrueba_ValorEntre90yMenos90Grados()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new PaisEditar { Latitud = 25.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Latitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new PaisEditar { Latitud = -99.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe estar entre -90 <-> 90 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Latitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };

            var resultado = validador.Validate(new PaisEditar { Latitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Latitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new PaisEditar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Latitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new PaisEditar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia PaisEditar propiedad Longitud

        [Fact]
        public async Task PaisEditar_Longitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new PaisEditar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Longitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new PaisEditar
            {
                Latitud = 23.325874M,
                Longitud = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Longitud_SuperaPrueba_ValorEntre180yMenos180Grados()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new PaisEditar
            {
                Latitud = 25.325685M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Longitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new PaisEditar
            {
                Latitud = 29.325685M,
                Longitud = -230.358061M
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe estar entre -180 <-> 180 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Longitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };

            var resultado = validador.Validate(new PaisEditar { Longitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Longitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new PaisEditar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Longitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new PaisEditar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia PaisEditar propiedad Descripcion

        [Fact]
        public async Task PaisEditar_Descripcion_SuperaPrueba_ContieneMenos750Caracteres()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new PaisEditar
            {
                Descripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Descripcion_SuperaPrueba_LanzaExcepcionSuperior750Caracteres()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new PaisEditar
            {
                Descripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Descripcion_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new PaisEditar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Descripcion_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validador = new Validacion<PaisEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new PaisEditar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia PaisEditar propiedad Foto

        [Fact]
        public async Task PaisEditar_Foto_SuperaPrueba_FotoFormatoCorrecto()
        {
            var validador = new Validacion<PaisEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new PaisEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Foto_SuperaPrueba_LanzaExcepcionFotoFormatoIncorrecto()
        {
            var validador = new Validacion<PaisEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.json");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.json"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/json",
            };
            var resultado = validador.Validate(new PaisEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("Típo de archivo no validoͺ los tipos permitidos son image/jpeg, image/jpg, image/pngͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Foto_SuperaPrueba_ArchivoMenor2Mb()
        {
            var validador = new Validacion<PaisEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new PaisEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisEditar_Foto_SuperaPrueba_LanzaExepcionArchivoMayor2Mb()
        {
            var validador = new Validacion<PaisEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible2.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible2.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new PaisEditar
            {
                Foto = archivo
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El archivo de imágen seleccionado supera los 2 Mb.permitidosͺ");
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia PaisInsertar propiedad Nombre

        [Fact]
        public async void PaisInsertar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new PaisInsertar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new PaisInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new PaisInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia PaisInsertar propiedad NombreOficial

        [Fact]
        public async void PaisInsertar_NombreOficial_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };
            var resultado = validador.Validate(new PaisInsertar
            {
                NombreOficial = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_NombreOficial_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                NombreOficial = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Oficial no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_NombreOficial_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                NombreOficial = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_NombreOficial_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                NombreOficial = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_NombreOficial_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                NombreOficial = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Oficial solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_NombreOficial_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var result = validator.Validate(new PaisInsertar { NombreOficial = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_NombreOficial_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                NombreOficial = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Oficial contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_NombreOficial_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var result = validator.Validate(new PaisInsertar { NombreOficial = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_NombreOficial_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.NombreOficial!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                NombreOficial = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre Oficial contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia PaisInsertar propiedad Capital

        [Fact]
        public async void PaisInsertar_Capital_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };
            var resultado = validador.Validate(new PaisInsertar
            {
                Capital = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Capital_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                Capital = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Capital no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Capital_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                Capital = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Capital_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                Capital = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Capital_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                Capital = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Capital solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Capital_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var result = validator.Validate(new PaisInsertar { Capital = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Capital_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                Capital = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Capital contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Capital_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var result = validator.Validate(new PaisInsertar { Capital = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Capital_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Capital!).NombreReq()
            };

            var resultado = validator.Validate(new PaisInsertar
            {
                Capital = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Capital contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia PaisInsertar propiedad Latitud

        [Fact]
        public async Task PaisInsertar_Latitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new PaisInsertar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Latitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new PaisInsertar { Latitud = null, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Latitud_SuperaPrueba_ValorEntre90yMenos90Grados()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new PaisInsertar { Latitud = 25.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Latitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new PaisInsertar { Latitud = -99.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe estar entre -90 <-> 90 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Latitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };

            var resultado = validador.Validate(new PaisInsertar { Latitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Latitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new PaisInsertar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Latitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new PaisInsertar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia PaisInsertar propiedad Longitud

        [Fact]
        public async Task PaisInsertar_Longitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new PaisInsertar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Longitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new PaisInsertar
            {
                Latitud = 23.325874M,
                Longitud = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Longitud_SuperaPrueba_ValorEntre180yMenos180Grados()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new PaisInsertar
            {
                Latitud = 25.325685M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Longitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new PaisInsertar
            {
                Latitud = 29.325685M,
                Longitud = -230.358061M
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe estar entre -180 <-> 180 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Longitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };

            var resultado = validador.Validate(new PaisInsertar { Longitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Longitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new PaisInsertar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Longitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new PaisInsertar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia PaisInsertar propiedad Descripcion

        [Fact]
        public async Task PaisInsertar_Descripcion_SuperaPrueba_ContieneMenos750Caracteres()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new PaisInsertar
            {
                Descripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Descripcion_SuperaPrueba_LanzaExcepcionSuperior750Caracteres()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new PaisInsertar
            {
                Descripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Descripcion_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new PaisInsertar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Descripcion_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validador = new Validacion<PaisInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new PaisInsertar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia PaisInsertar propiedad Foto

        [Fact]
        public async Task PaisInsertar_Foto_SuperaPrueba_FotoFormatoCorrecto()
        {
            var validador = new Validacion<PaisInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new PaisInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Foto_SuperaPrueba_LanzaExcepcionFotoFormatoIncorrecto()
        {
            var validador = new Validacion<PaisInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.json");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.json"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/json",
            };
            var resultado = validador.Validate(new PaisInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("Típo de archivo no validoͺ los tipos permitidos son image/jpeg, image/jpg, image/pngͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Foto_SuperaPrueba_ArchivoMenor2Mb()
        {
            var validador = new Validacion<PaisInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new PaisInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PaisInsertar_Foto_SuperaPrueba_LanzaExepcionArchivoMayor2Mb()
        {
            var validador = new Validacion<PaisInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible2.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible2.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new PaisInsertar
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