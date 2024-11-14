using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace obligatorioP2.clases
{
    public class Orden
    {
        public int NumeroDeOrden { get; set; }
        public Cliente ClienteAsociado { get; set; }
        public string ClienteAsociadoNombre { get; set; }
        public Tecnico TecnicoAsignado { get; set; }
        public string TecnicoAsignadoNombre { get; set; }
        public string DescripcionProblema { get; set; }
        public string FechaDeCreacion { get; set; }
        public string Estado { get; set; }
        public List<string> ComentariosDelTecnico { get; set; }

        public Orden()
        {

        }

        public Orden(Cliente clienteAsociado, Tecnico tecnicoAsignado, string descripcionProblema)
        {
            NumeroDeOrden = GeneradorNumeroOrden();
            ClienteAsociado = clienteAsociado;
            TecnicoAsignado = tecnicoAsignado;
            DescripcionProblema = descripcionProblema;
            FechaDeCreacion = ObtenerFechaActual();
            Estado = "Pendiente";
            ComentariosDelTecnico = new List<string>();
            ClienteAsociadoNombre = GenerarNombreCliente();
            TecnicoAsignadoNombre = GenerarNombreTecnico();

        }



        public int GetNumeroDeOrden() { return NumeroDeOrden; }
        public Cliente GetClienteAsociado() { return ClienteAsociado; }

        public Tecnico GetTecnicoAsignado() { return TecnicoAsignado; }
        public string GetDescripcionProblema() { return DescripcionProblema; }
        public string GetFechaDeCreacion() { return FechaDeCreacion; }
        public string GetEstado() { return Estado; }
        public List<string> GetComentariosDelTecnico() { return ComentariosDelTecnico; }


        public void SetNumeroDeOrden(int numeroDeOrden)
        {
            NumeroDeOrden = numeroDeOrden;
        }

        public void SetCLienteAsociado(Cliente clienteAsociado)
        {
            ClienteAsociado = clienteAsociado;
        }

        public void SetTecnicoAsignado(Tecnico tecnicoAsignado)
        {
            TecnicoAsignado = tecnicoAsignado;
        }

        public void SetDescripcionProblema(string descripcionProblema)
        {
            DescripcionProblema = descripcionProblema;
        }
        public void SetComentariosDelTecnico(List<string> comentariosDeltecnico)
        {
            ComentariosDelTecnico = comentariosDeltecnico;
        }
        public void SetEstado(string estado)
        { Estado = estado; }

        public int GeneradorNumeroOrden()
        {

            int nuemeroOrden = BaseDeDatos.UltimoNumeroDeOrden + 1;

            BaseDeDatos.UltimoNumeroDeOrden = nuemeroOrden;

            return nuemeroOrden;

        }
        public string ObtenerFechaActual()
        {
            DateTime fechaActual = DateTime.Now;
            return fechaActual.ToString("dd/MM/yyyy HH:mm");
        }

        public string GenerarNombreCliente()
        {
            return $"{ClienteAsociado.GetNombre()} {ClienteAsociado.GetApellido()} ";
        }
        public string GenerarNombreTecnico()
        {
            return $"{TecnicoAsignado.GetNombre()} {TecnicoAsignado.GetApellido()} ";
        }

    }
}