using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace obligatorioP2.clases
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido {  get; set; }
        public int CI {  get; set; }
        public string NombreCompleto { get; set; }

        public Persona(string nombre, string apellido, int cI)
        {
            Nombre = nombre;
            Apellido = apellido;
            CI = cI;
            NombreCompleto = NombreCompletoCreacion();

        }
        public Persona() { }

        public string GetNombre() {  return Nombre; }
        public string GetApellido() { return Apellido; }
        public int GetCI() { return CI; }    

        public void SetNombre(string nombre) { Nombre = nombre;
            NombreCompleto = NombreCompletoCreacion();

        }
        public void SetApellido(string apellido) { Apellido = apellido;
            NombreCompleto = NombreCompletoCreacion();

        }
        public void SetCI(int ci) { CI = ci; }

        public string NombreCompletoCreacion()
        {
            string nombreCompleto = GetNombre() + " " + GetApellido();

            return nombreCompleto;
        }
    }
}