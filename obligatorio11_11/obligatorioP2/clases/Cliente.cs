using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace obligatorioP2.clases
{
    public class Cliente : Persona
    {
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email {  get; set; }

        public Cliente(string nombre, string apellido, int ci, string direccion, string telefono, string email):base(nombre,apellido,ci)
        {
            Direccion = direccion; Telefono = telefono; Email = email;
        }

        public Cliente()
        {

        }

        public string GetDireccion()
        {
            return Direccion;
        }
        public string GetTelefono() { return Telefono; }
        public string GetEmail() { return Email; }

        public void SetDireccion(string direccion)
        {
            Direccion = direccion;
        }
        public void SetTelefono(string telefono)
        {
            Telefono = telefono;
        }
        public void SetEmail(string email)
        {
            Email = email;
        }

    }
}