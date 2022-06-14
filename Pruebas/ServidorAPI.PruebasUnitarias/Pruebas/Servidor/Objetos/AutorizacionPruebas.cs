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
//               AutorizacionPruebas : Creado 14-06-2022
//=======================================================================

#endregion

using Bogus;
using ServidorAPI.Infraestructura.Filtros.FluentValidator.Utils;
using ServidorAPI.Infraestructura.Objetos.Servidor.Insertar;
using ServidorAPI.PruebasUnitarias.Utils;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServidorAPI.PruebasUnitarias.Pruebas.Servidor.Objetos
{
    public class AutorizacionPruebas
    {
        private readonly Faker entidadFalsa = new("es_MX");

        public AutorizacionPruebas()
        { }

        #region=> Pruebas Unitarias al Objeto de Transferencia LoginInsertar

        [Fact]
        public async void UsuarioLogin_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<LoginInsertar>
            {
                v => v.RuleFor(x => x.Usuario!).NombreReq()
            };
            var resultado = validador.Validate(new LoginInsertar
            {
                Usuario = entidadFalsa.Name.FirstName()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task UsuarioLogin_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<LoginInsertar>
            {
                v => v.RuleFor(x => x.Usuario!).NombreReq()
            };

            var resultado = validator.Validate(new LoginInsertar
            {
                Usuario = null!
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Usuario no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia RecuperacionInsertar

        [Fact]
        public async void EmailRecuperacion_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<RecuperacionInsertar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };
            var resultado = validador.Validate(new RecuperacionInsertar
            {
                Email = entidadFalsa.Person.Email
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmailRecuperacion_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<RecuperacionInsertar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };

            var resultado = validator.Validate(new RecuperacionInsertar
            {
                Email = null!
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Email no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async void EmailRecuperacion_SuperaPrueba_DistintoVacio()
        {
            var validador = new Validacion<RecuperacionInsertar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };
            var resultado = validador.Validate(new RecuperacionInsertar
            {
                Email = entidadFalsa.Person.Email
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmailRecuperacion_SuperaPrueba_EnviaExcepcionVacio()
        {
            var validator = new Validacion<RecuperacionInsertar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };

            var resultado = validator.Validate(new RecuperacionInsertar
            {
                Email = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Email no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async void EmailRecuperacion_SuperaPrueba_FormatoCorrecto()
        {
            var validador = new Validacion<RecuperacionInsertar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };
            var resultado = validador.Validate(new RecuperacionInsertar
            {
                Email = entidadFalsa.Person.Email
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmailRecuperacion_SuperaPrueba_EnviaExcepcionFormatoIncorrecto()
        {
            var validator = new Validacion<RecuperacionInsertar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };

            var resultado = validator.Validate(new RecuperacionInsertar
            {
                Email = entidadFalsa.Person.FullName
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Email tiene un formato de correo electronico invalidoͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task TelefonoRecuperacion_SuperaPrueba_FormatoCorrecto()
        {
            var validator = new Validacion<RecuperacionInsertar>
            {
                v => v.RuleFor(x => x.Telefono!).TelefonoReq()
            };

            var resultado = validator.Validate(new RecuperacionInsertar
            {
                Telefono = entidadFalsa.Phone.PhoneNumber("(###) ###-####")
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task TelefonoRecuperacion_SuperaPrueba_EnviaExcepcionFormatoIncorrecto()
        {
            var validator = new Validacion<RecuperacionInsertar>
            {
                v => v.RuleFor(x => x.Telefono!).TelefonoReq()
            };

            var resultado = validator.Validate(new RecuperacionInsertar
            {
                Telefono = entidadFalsa.Phone.PhoneNumber("#########")
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Telefono debe tener un formato (XXX) XXX-XXXX donde X es un dígito de 0-9ͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region=> Pruebas Unitarias al Objeto de Transferencia CambiarPasswordInsertar

        [Fact]
        public async Task CodigoSMS_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<CambiarPasswordInsertar>
            {
                v => v.RuleFor(x => x.CodigoSMS!).CodigoSMS()
            };
            var resultado = validador.Validate(new CambiarPasswordInsertar
            {
                CodigoSMS = entidadFalsa.Random.Number(111111, 999999)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task CodigoSMS_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<CambiarPasswordInsertar>
            {
                v => v.RuleFor(x => x.CodigoSMS!).CodigoSMS()
            };

            var resultado = validator.Validate(new CambiarPasswordInsertar
            {
                CodigoSMS = null!
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Codigo SMS no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task CodigoSMS_SuperaPrueba_IgualSeisDigitos()
        {
            var validador = new Validacion<CambiarPasswordInsertar>
            {
                v => v.RuleFor(x => x.CodigoSMS!).CodigoSMS()
            };
            var resultado = validador.Validate(new CambiarPasswordInsertar
            {
                CodigoSMS = entidadFalsa.Random.Number(111111, 999999)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task CodigoSMS_SuperaPrueba_EnviaExcepcionDistintoSeisDigitos()
        {
            var validator = new Validacion<CambiarPasswordInsertar>
            {
                v => v.RuleFor(x => x.CodigoSMS!).CodigoSMS()
            };

            var resultado = validator.Validate(new CambiarPasswordInsertar
            {
                CodigoSMS = entidadFalsa.Random.Number(11111, 99999)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Codigo SMS se conforma obligatoriamente de 6 digitosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region=> Pruebas Unitarias al Objeto de Transferencia UnidadActivaInsertar

        [Fact]
        public async void UrlUnidadActiva_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<UnidadActivaInsertar>
            {
                v => v.RuleFor(x => x.UrlUnidad!).UrlReq()
            };
            var resultado = validador.Validate(new UnidadActivaInsertar
            {
                UrlUnidad = entidadFalsa.Internet.Url()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task UrlUnidadActiva_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<UnidadActivaInsertar>
            {
                v => v.RuleFor(x => x.UrlUnidad!).UrlReq()
            };

            var resultado = validator.Validate(new UnidadActivaInsertar
            {
                UrlUnidad = entidadFalsa.Internet.Url()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task UrlUnidadActiva_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<UnidadActivaInsertar>
            {
                v => v.RuleFor(x => x.UrlUnidad!).UrlReq()
            };

            var resultado = validator.Validate(new UnidadActivaInsertar
            {
                UrlUnidad = null!
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Url Unidad no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task UrlUnidadActiva_SuperaPrueba_FormatoCorrecto()
        {
            var validator = new Validacion<UnidadActivaInsertar>
            {
                v => v.RuleFor(x => x.UrlUnidad!).UrlReq()
            };

            var resultado = validator.Validate(new UnidadActivaInsertar
            {
                UrlUnidad = entidadFalsa.Internet.Url()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task UrlUnidadActiva_SuperaPrueba_EnviaExcepcionFormatoIncorrecto()
        {
            var validator = new Validacion<UnidadActivaInsertar>
            {
                v => v.RuleFor(x => x.UrlUnidad!).UrlReq()
            };

            var resultado = validator.Validate(new UnidadActivaInsertar
            {
                UrlUnidad = entidadFalsa.Random.String2(10, 10)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Url Unidad tiene un formato URL incorrectoͺ");

            await Task.CompletedTask;
        }

        #endregion
    }
}