using obligatorioP2.clases;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace obligatorioP2
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridView();
                lblMessage.Visible = false;
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {




            if (IsValidInput() )
            {
                try
                {

                    if (!BaseDeDatos.Tecnicos.Any(t => t.CI == TxtCiTecnico.Text))
                    {
                        Tecnico miTecnico = new Tecnico();
                        miTecnico.SetNombre(this.TxtNombreTecnico.Text);
                        miTecnico.SetApellido(this.TxtApellidoTecnico.Text);
                        miTecnico.SetCI(this.TxtCiTecnico.Text);
                        miTecnico.SetEspecialidad(this.TxtEspecialidad.Text);

                        BaseDeDatos.Tecnicos.Add(miTecnico);

                        CargarGridView();
                        lblMessage.Text = "Técnico guardado con éxito!";

                        ClearForm();
                    }
                    else
                    {
                        CargarGridView();
                        if (!IsPostBack)
                        {
                            lblMessage.Visible = false;
                        }
                        else { lblMessage.Text = "El técnico con este CI ya existe."; }
                    }

                    ClearForm();

                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }

            }
            else
            {
                lblMessage.Text = "Por favor, complete todos los campos correctamente.";
            }
        }

        bool IsValidInput()
        {

            if (!IsAllLetters(TxtNombreTecnico.Text) || !IsAllLetters(TxtApellidoTecnico.Text) || !IsAllLetters(TxtEspecialidad.Text) || string.IsNullOrEmpty(TxtNombreTecnico.Text) || string.IsNullOrEmpty(TxtApellidoTecnico.Text) || string.IsNullOrEmpty(TxtEspecialidad.Text))
            {
                return false;
            }
            
            return true;
        }

        private bool IsAllLetters(string input)
        {
            return input.All(char.IsLetter);
        }

        private void ClearForm()
        {
            TxtNombreTecnico.Text = string.Empty;
            TxtApellidoTecnico.Text = string.Empty;
            TxtCiTecnico.Text = string.Empty;
            TxtEspecialidad.Text = string.Empty;
        }

        private void CargarGridView()
        {
         

            if (BaseDeDatos.Tecnicos.Count > 0)
            {
                lblMessage.Visible = true; 
                lblMessage.Text = "Técnicos cargados."; 
            }
            else
            {
                lblMessage.Visible = false; 
            }


            gvTecnicos.DataSource = BaseDeDatos.Tecnicos;
            gvTecnicos.DataBind();
        }

        protected void gvTecnicos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Eliminar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                BaseDeDatos.Tecnicos.RemoveAt(index);

                gvTecnicos.DataSource = BaseDeDatos.Tecnicos;
                gvTecnicos.DataBind();
            }

            if (e.CommandName == "Editar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvTecnicos.Rows[index];

                TxtNombreTecnico.Text = row.Cells[0].Text; ;
                TxtApellidoTecnico.Text = row.Cells[1].Text;
                TxtCiTecnico.Text = row.Cells[2].Text;
                TxtEspecialidad.Text = row.Cells[3].Text;
                
                ViewState["EditIndex"] = index;

                btnGuardar.Visible = true;
 
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ViewState["EditIndex"] != null)
            {
                int index = (int)ViewState["EditIndex"];


                if (!BaseDeDatos.Tecnicos.Any(t => t.CI == TxtCiTecnico.Text))
                {
                    Tecnico tecnicoActualizado = BaseDeDatos.Tecnicos[index];
                    tecnicoActualizado.SetNombre(TxtNombreTecnico.Text);
                    tecnicoActualizado.SetApellido(TxtApellidoTecnico.Text);
                    tecnicoActualizado.SetCI(TxtCiTecnico.Text);
                    tecnicoActualizado.SetEspecialidad(TxtEspecialidad.Text);
                }
                else
                {
                    lblMessage.Visible = true;
                     lblMessage.Text = "El técnico con este CI ya existe."; 
                }

                lblMessage.Text = "Técnico actualizado con éxito!";
                CargarGridView(); // Recargar el GridView

             
                ClearForm();
                ViewState["EditIndex"] = null; // Resetear el índice de edición

                btnGuardar.Visible = false;
            }
        }


    }
}