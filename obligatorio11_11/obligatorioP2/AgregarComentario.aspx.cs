using obligatorioP2.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace obligatorioP2
{
    public partial class AgregarComentario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAgregarComentario_Click(object sender, EventArgs e)
        {

            if (IsValidInput())
            {
                string NumeroDeOrden = Request.QueryString["NumeroDeOrden"];
                int NumeroDeOrdenInt = Convert.ToInt32(NumeroDeOrden);

                Orden OrdenComentada = BaseDeDatos.Ordenes[NumeroDeOrdenInt];
                OrdenComentada.GetComentariosDelTecnico().Add(TxtComentario.Text);

                lblComentario.Visible = true;
                lblComentario.ForeColor = System.Drawing.Color.Green;
                lblComentario.Text = "Comentario enviado con éxito.";
                TxtComentario.Text = string.Empty;
            }
            else
            {
                lblComentario.Visible = true;
                lblComentario.ForeColor = System.Drawing.Color.Red;
                lblComentario.Text = "Debe completar el UNICO campo.";
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionOrdenes.aspx");

        }
        bool IsValidInput()
        {
            if (string.IsNullOrEmpty(TxtComentario.Text))
            {
                return false;
            }
            return true;
        }
    }
}