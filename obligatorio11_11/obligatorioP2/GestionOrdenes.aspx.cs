using obligatorioP2.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace obligatorioP2
{
    public partial class GestionOrdenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridView();

                cboTecnicoAsociado.DataSource = BaseDeDatos.Tecnicos;
                cboTecnicoAsociado.DataTextField = "NombreCompleto";
                cboTecnicoAsociado.DataValueField = "CI";
                cboTecnicoAsociado.DataBind();

                cboClienteAsociado.DataSource = BaseDeDatos.Clientes;
                cboClienteAsociado.DataTextField = "NombreCompleto";
                cboClienteAsociado.DataValueField = "CI";
                cboClienteAsociado.DataBind();





            }

        }



        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            int clienteId = int.Parse(cboClienteAsociado.SelectedValue);
            Cliente clienteAsociado = BaseDeDatos.Clientes.FirstOrDefault(c => c.CI == clienteId);

            int tecnicoId = int.Parse(cboTecnicoAsociado.SelectedValue);
            Tecnico tecnicoAsociado = BaseDeDatos.Tecnicos.FirstOrDefault(t => t.CI == tecnicoId);



            if (clienteAsociado != null && tecnicoAsociado != null)
            {
                // Crear la nueva orden
                Orden nuevaOrden = new Orden(clienteAsociado, tecnicoAsociado, TxtDescripcionProblema.Text);
                BaseDeDatos.Ordenes.Add(nuevaOrden);
            }
            CargarGridView();

        }


        protected void gvOrdenes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvOrdenes.EditIndex = e.NewEditIndex;

            CargarGridView();

            foreach (GridViewRow row in gvOrdenes.Rows)
            {
                LinkButton btnAgregarComentario = (LinkButton)row.FindControl("btnAgregarComentario");
                if (btnAgregarComentario != null)
                {
                    btnAgregarComentario.Visible = false;
                }
            }

        }

        protected void gvOrdenes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;

            DropDownList ddlEstado = (DropDownList)gvOrdenes.Rows[index].FindControl("ddlEstado");

            string nuevoEstado = ddlEstado.SelectedValue;

            int numeroDeOrden = Convert.ToInt32(index);
            BaseDeDatos.Ordenes[numeroDeOrden].SetEstado(nuevoEstado);



            gvOrdenes.EditIndex = -1;
            CargarGridView();

            foreach (GridViewRow row in gvOrdenes.Rows)
            {
                LinkButton btnAgregarComentario = (LinkButton)row.FindControl("btnAgregarComentario");
                if (btnAgregarComentario != null)
                {
                    btnAgregarComentario.Visible = true;
                }
            }

        }

        protected void gvOrdenes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvOrdenes.EditIndex = -1;
            CargarGridView();
            foreach (GridViewRow row in gvOrdenes.Rows)
            {
                LinkButton btnAgregarComentario = (LinkButton)row.FindControl("btnAgregarComentario");
                if (btnAgregarComentario != null)
                {
                    btnAgregarComentario.Visible = true;
                }
            }
        }




        private void CargarGridView()
        {

            gvOrdenes.DataSource = BaseDeDatos.Ordenes;
            gvOrdenes.DataBind();
        }
    }
}