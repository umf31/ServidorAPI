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
//                AlimentadorPruebas: Creado 14-06-2022
//=======================================================================

#endregion

using Bogus;
using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Persistencia.Conectividad.Contexto;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ServidorAPI.PruebasIntegracion.Utils
{
    public static class Alimentador
    {
        public static void InyectarStatus(ServidorContexto db)
        {
            db.Status.RemoveRange(db.Status);

            var ids = 1;
            var entidadFalsa = new Faker<Status>("es_MX")
                .RuleFor(o => o.Nombre, f => $"Status {ids}")
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarCategorias(ServidorContexto db)
        {
            db.Categorias.RemoveRange(db.Categorias);

            var ids = 1;
            var entidadFalsa = new Faker<Categoria>("es_MX")
                .RuleFor(o => o.Nombre, f => $"Categoria {ids}")
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarServicios(ServidorContexto db)
        {
            db.Servicios.RemoveRange(db.Servicios);

            var ids = 1;
            var entidadFalsa = new Faker<Servicio>("es_MX")
                .RuleFor(o => o.Nombre, f => $"Servicio {ids}")
                .RuleFor(o => o.IdServicio, f => ids++)
                .RuleFor(o => o.ClaveServicio, f => f.Random.AlphaNumeric(2).ToUpper())
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarRoles(ServidorContexto db)
        {
            db.Roles.RemoveRange(db.Roles);

            var ids = 1;
            var entidadFalsa = new Faker<Roles>("es_MX")
                .RuleFor(o => o.Descripcion, f => $"Rol {ids}")
                .RuleFor(o => o.IdRol, f => ids++);
            var entidad = entidadFalsa.Generate(5);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarPaises(ServidorContexto db)
        {
            db.Paises.RemoveRange(db.Paises);

            var ids = 1;
            var entidadFalsa = new Faker<Pais>("es_MX")
                .RuleFor(o => o.Nombre, f => $"Pais {ids}")
                .RuleFor(o => o.NombreOficial, f => f.Random.RandomLocale())
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.Capital, f => f.Name.JobArea())
                .RuleFor(o => o.Latitud, f => f.Random.Decimal(-90.00000M, 90.000000M))
                .RuleFor(o => o.Longitud, f => f.Random.Decimal(-180.00000M, 180.000000M))
                .RuleFor(o => o.Geolocalizacion, f => f.Image.LoremFlickrUrl())
                .RuleFor(o => o.Imagen, f => f.Image.LoremFlickrUrl())
                .RuleFor(o => o.Descripcion, f => f.Random.Word())
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarEstados(ServidorContexto db)
        {
            db.Estados.RemoveRange(db.Estados);

            var ids = 1;
            var entidadFalsa = new Faker<Estado>("es_MX")
                .RuleFor(o => o.Nombre, f => $"Estado {ids}")
                .RuleFor(o => o.Abrev, f => f.Random.RandomLocale())
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.PaisId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.Latitud, f => f.Random.Decimal(-90.00000M, 90.000000M))
                .RuleFor(o => o.Longitud, f => f.Random.Decimal(-180.00000M, 180.000000M))
                .RuleFor(o => o.Geolocalizacion, f => f.Image.LoremFlickrUrl())
                .RuleFor(o => o.Imagen, f => f.Image.LoremFlickrUrl())
                .RuleFor(o => o.Descripcion, f => f.Random.Word())
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarMunicipios(ServidorContexto db)
        {
            db.Municipios.RemoveRange(db.Municipios);

            var ids = 1;
            var entidadFalsa = new Faker<Municipio>("es_MX")
                .RuleFor(o => o.Nombre, f => $"Municipio {ids}")
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.EstadoId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.Latitud, f => f.Random.Decimal(-90.00000M, 90.000000M))
                .RuleFor(o => o.Longitud, f => f.Random.Decimal(-180.00000M, 180.000000M))
                .RuleFor(o => o.Geolocalizacion, f => f.Image.LoremFlickrUrl())
                .RuleFor(o => o.Imagen, f => f.Image.LoremFlickrUrl())
                .RuleFor(o => o.Descripcion, f => f.Random.Word())
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarAsentamientos(ServidorContexto db)
        {
            db.Asentamientos.RemoveRange(db.Asentamientos);

            var ids = 1;
            var entidadFalsa = new Faker<Asentamiento>("es_MX")
                .RuleFor(o => o.Nombre, f => $"Asentamiento {ids}")
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarColonias(ServidorContexto db)
        {
            db.Colonias.RemoveRange(db.Colonias);

            var ids = 1;
            var incremento = 1;
            var codigoPostal = 63999;
            var entidadFalsa = new Faker<Colonia>("es_MX")
                .RuleFor(o => o.Nombre, f => $"Colonia {ids}")
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.CodigoPostal, f => codigoPostal + incremento++)
                .RuleFor(o => o.AsentamientoId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.MunicipioId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.Latitud, f => f.Random.Decimal(-90.00000M, 90.000000M))
                .RuleFor(o => o.Longitud, f => f.Random.Decimal(-180.00000M, 180.000000M))
                .RuleFor(o => o.Geolocalizacion, f => f.Image.LoremFlickrUrl())
                .RuleFor(o => o.Descripcion, f => f.Random.Word())
                .RuleFor(o => o.Imagen, f => f.Image.LoremFlickrUrl())
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarDelegaciones(ServidorContexto db)
        {
            db.Delegaciones.RemoveRange(db.Delegaciones);

            var ids = 1;
            var entidadFalsa = new Faker<Delegacion>("es_MX")
                .RuleFor(o => o.Nombre, f => $"Delegacion {ids}")
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.EstadoId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.Latitud, f => f.Random.Decimal(-90.00000M, 90.000000M))
                .RuleFor(o => o.Longitud, f => f.Random.Decimal(-180.00000M, 180.000000M))
                .RuleFor(o => o.Geolocalizacion, f => f.Image.LoremFlickrUrl())
                .RuleFor(o => o.Imagen, f => f.Image.LoremFlickrUrl())
                .RuleFor(o => o.Descripcion, f => f.Random.Word())
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarUnidadesTipo(ServidorContexto db)
        {
            db.UnidadesTipo.RemoveRange(db.UnidadesTipo);
            var ids = 1;
            var entidadFalsa = new Faker<UnidadTipo>("es_MX")
                .RuleFor(o => o.Nombre, f => $"UnidadTipo {ids}")
                .RuleFor(o => o.Abrev, f => f.Random.RandomLocale())
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarVialidades(ServidorContexto db)
        {
            db.Vialidades.RemoveRange(db.Vialidades);
            var ids = 1;
            var entidadFalsa = new Faker<Vialidad>("es_MX")
                .RuleFor(o => o.Nombre, f => $"UnidadTipo {ids}")
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarUnidad(ServidorContexto db)
        {
            db.Unidades.RemoveRange(db.Unidades);
            var ids = 1;
            var cp = 1;
            var entidadFalsa = new Faker<Unidad>("es_MX")
                .RuleFor(o => o.Nombre, f => $"Unidad {ids}")
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.DelegacionId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.NumUnidad, f => f.Random.Number(1, 50))
                .RuleFor(o => o.Localidad, f => $"Localidad {ids}")
                .RuleFor(o => o.ClavePresupuestal, f => f.Random.String2(12, 12))
                .RuleFor(o => o.ClavePresupuestal, f => (201710215110 + cp++).ToString())
                .RuleFor(o => o.UnidadTipoId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.VialidadId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.Calle, f => f.Random.String2(25, 25))
                .RuleFor(o => o.Numero, f => f.Random.String2(5, 5))
                .RuleFor(o => o.Telefono, f => f.Phone.PhoneNumber("(###) ###-####"))
                .RuleFor(o => o.ColoniaId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.MunicipioId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.Imagen, f => "")
                .RuleFor(o => o.Latitud, f => f.Random.Decimal(-90.00000M, 90.000000M))
                .RuleFor(o => o.Longitud, f => f.Random.Decimal(-180.00000M, 180.000000M))
                .RuleFor(o => o.Geolocalizacion, f => "")
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarCategoriaServicios(ServidorContexto db)
        {
            db.CategoriaServicios.RemoveRange(db.CategoriaServicios);
            var ids = 1;
            var entidadFalsa = new Faker<CategoriaServicio>("es_MX")
                .RuleFor(o => o.IdServicio, f => ids++)
                .RuleFor(o => o.IdCategoria, f => ids++);

            var entidad = entidadFalsa.Generate(5);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarEmpleados(ServidorContexto db)
        {
            db.Empleados.RemoveRange(db.Empleados);

            var ids = 1;
            var mat = 1;
            var cp = 1;
            var password = 123456.ToString();
            CrearPasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var entidadFalsa = new Faker<Empleado>("es_MX")
                .RuleFor(o => o.Nombre, f => $"Empleado {ids}")
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.Matricula, f => (10716075 + mat++).ToString())
                .RuleFor(o => o.Email, f => f.Random.String2(3, 5).ToLower() + f.Person.Email)
                .RuleFor(o => o.UnidadId, f => f.Random.Number(1, 1))
                .RuleFor(o => o.ClavePresupuestal, f => (201710215110 + cp++).ToString())
                .RuleFor(o => o.ApellidoPaterno, f => f.Person.LastName)
                .RuleFor(o => o.ApellidoMaterno, f => f.Person.UserName)
                .RuleFor(o => o.CategoriaId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.ServicioId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.Imagen, f => f.Image.LoremFlickrUrl())
                .RuleFor(o => o.PasswordHash, f => passwordHash)
                .RuleFor(o => o.PasswordSalt, f => passwordSalt)
                .RuleFor(o => o.CodigoSMS, f => null)
                .RuleFor(o => o.Telefono, f => f.Phone.PhoneNumber("(###) ###-####"))
                .RuleFor(o => o.VialidadId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.Calle, f => f.Random.String2(25, 25))
                .RuleFor(o => o.Numero, f => f.Random.String2(5, 5))
                .RuleFor(o => o.ColoniaId, f => f.Random.Number(1, 1))
                .RuleFor(o => o.Latitud, f => f.Random.Decimal(-90.00000M, 90.000000M))
                .RuleFor(o => o.Longitud, f => f.Random.Decimal(-180.00000M, 180.000000M))
                .RuleFor(o => o.Geolocalizacion, f => "")
                .RuleFor(o => o.Bloqueo, f => false)
                .RuleFor(o => o.Recordar, f => false)
                .RuleFor(o => o.Activo, f => false)
                .RuleFor(o => o.Soporte, f => false)
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarEmpleadosRol(ServidorContexto db)
        {
            db.EmpleadoRoles.RemoveRange(db.EmpleadoRoles);
            var entidadFalsa = new Faker<EmpleadoRol>("es_MX")
                .RuleFor(o => o.IdEmpleado, f => 1)
                .RuleFor(o => o.IdRol, f => 1);
            var entidad = entidadFalsa.Generate(1);
            db.AddRange(entidad);
            db.SaveChanges();
        }
        
        public static void InyectarProcesos(ServidorContexto db)
        {
            db.Procesos.RemoveRange(db.Procesos);
            var ids = 1;
            var entidadFalsa = new Faker<Proceso>("es_MX")
                .RuleFor(o => o.Nombre, f => $"Proceso {ids}")
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.NombreCorto, f => $"Pro {ids}")
                .RuleFor(o => o.Descripcion, f => f.Random.Word())
                .RuleFor(o => o.Imagen, f => f.Image.LoremFlickrUrl())
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarPeriodos(ServidorContexto db)
        {
            var ids = 1;
            db.Periodos.RemoveRange(db.Periodos);
            var año = "2021";
            var mes = 10;
            var entidadFalsa = new Faker<Periodos>("es_MX")
                .RuleFor(o => o.Periodo, f => $"2021{mes}")
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.Año, f => año)
                .RuleFor(o => o.Mes, f => mes++.ToString())
                .RuleFor(o => o.MesAbrev, f => f.Random.String2(3))
                .RuleFor(o => o.Nombre, f => f.Random.String2(5))
                .RuleFor(o => o.FechaInicio, f => DateTime.Now)
                .RuleFor(o => o.FechaTermino, f => DateTime.Now)
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(3);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarDetalles(ServidorContexto db)
        {
            db.Detalles.RemoveRange(db.Detalles);
            var ids = 1;
            var entidadFalsa = new Faker<Detalles>("es_MX")
                .RuleFor(o => o.Nombre, f => $"DetalleIndicador {ids}")
                .RuleFor(o => o.Descripcion, f => f.Random.Word())
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.DescripcionCorta, f => f.Random.Word())
                .RuleFor(o => o.Objetivo, f => f.Random.Word())
                .RuleFor(o => o.NumeradorDescripcion, f => f.Random.Word())
                .RuleFor(o => o.DenominadorDescripcion, f => f.Random.Word())
                .RuleFor(o => o.Multiplicador, f => f.Random.Number(100, 100))
                .RuleFor(o => o.Interpretacion, f => f.Random.Word())
                .RuleFor(o => o.Periocidad, f => f.Random.Word())
                .RuleFor(o => o.ProcesoId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void InyectarMetas(ServidorContexto db)
        {
            db.Metas.RemoveRange(db.Metas);
            var ids = 1;
            var entidadFalsa = new Faker<Meta>("es_MX")
                .RuleFor(o => o.Nombre, f => $"Meta {ids}")
                .RuleFor(o => o.Id, f => ids++)
                .RuleFor(o => o.DetallesId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.PeriodoId, f => f.Random.Number(1, 2))
                .RuleFor(o => o.RendimientoEsperado, f => f.Random.Decimal(100.00M, 100.00M))
                .RuleFor(o => o.RendimientoBajo, f => f.Random.Decimal(0.01M, 50.00M))
                .RuleFor(o => o.RendimientoLimite, f => f.Random.Decimal(100.00M, 100.00M))
                .RuleFor(o => o.RendimientoMedio, f => f.Random.Decimal(50.00M, 75.00M))
                .RuleFor(o => o.ValorReferencia, f => f.Random.String2(3, 7))
                .RuleFor(o => o.FechaCreacion, f => DateTime.Now)
                .RuleFor(o => o.FechaModificacion, f => DateTime.Now)
                .RuleFor(o => o.UsuarioMod, f => "10716076")
                .RuleFor(o => o.StatusId, f => f.Random.Number(1, 1));

            var entidad = entidadFalsa.Generate(51);
            db.AddRange(entidad);
            db.SaveChanges();
        }

        public static void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}