using obligatorioP2.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace obligatorioP2.clases
{
    public class BaseDeDatos
    {
        public static int UltimoNumeroDeOrden = 0;
        public static List<Cliente> Clientes = new List<Cliente>();
        public static List<Tecnico> Tecnicos = new List<Tecnico>();
        public static List<Orden> Ordenes = new List<Orden>();




        static BaseDeDatos()
        {
            Clientes.Add(new Cliente { CI = 27142550, Nombre = "Juan", Apellido ="Gonzales", NombreCompleto ="Juan Gonzales", Direccion = "Aigua,Maldonado", Telefono ="097766402", Email = "juanixd@gmail.com" });
            Clientes.Add(new Cliente { CI = 55925532, Nombre = "Ana", Apellido = "Garcia", NombreCompleto = "Ana Garcia", Direccion = "Las Piedras,Canelones", Telefono = "091092231", Email = "anacasillas@gmail.com" });
            Clientes.Add(new Cliente { CI = 56710229, Nombre = "Pedro", Apellido = "Balderrana" , NombreCompleto = "Pedro Balderrana", Direccion = "LA Rioja,Melo" , Telefono = "896492281", Email = "pedro777@gna11.com" });
            Clientes.Add(new Cliente { CI = 56404511, Nombre = "Ramiro", Apellido = "Lopez", NombreCompleto = "Ramiro Lopez", Direccion = "18 de Julio, Montevideo", Telefono = "091092231", Email = "RamiDelBolso@gmail.com" });





            Tecnicos.Add(new Tecnico { CI = 56044076, Nombre = "Juana", Apellido = "Sardella", NombreCompleto = "Juana Sardella", Especialidad = "Electrónica" });
            Tecnicos.Add(new Tecnico { CI = 55925532, Nombre = "Tomas ", Apellido = "Amarrilla", NombreCompleto = "Tomas Amarilla", Especialidad = "Informática" });
            Tecnicos.Add(new Tecnico { CI = 56710229, Nombre = "Milo", Apellido = "J", NombreCompleto = "Milo J", Especialidad = "Herramientas" });
            Tecnicos.Add(new Tecnico { CI = 56404511, Nombre = "Bruno", Apellido = "Sanchez", NombreCompleto = "Bruno Sanchez", Especialidad = "Ciencia" });
        }







    }
}