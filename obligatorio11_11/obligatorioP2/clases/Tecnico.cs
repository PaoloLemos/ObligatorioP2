using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace obligatorioP2.clases
{
    public class Tecnico:Persona
    {
        public string Especialidad {  get; set; }

        public Tecnico()
        {
        }

        public Tecnico(string nombre, string apellido, int ci, string especialidad) : base(nombre, apellido, ci)
        {
            Especialidad = especialidad;
        }

            public string GetEspecialidad()
        {
            return Especialidad;
        }

        public void SetEspecialidad(string especialidad)
        {
            Especialidad = especialidad;
        }

        public override string ToString()
        {
            return $"Nombre {GetNombre()} Apellido: {GetApellido()} CI: {GetCI()} Especialidad; {Especialidad} ";
        }
    }
}