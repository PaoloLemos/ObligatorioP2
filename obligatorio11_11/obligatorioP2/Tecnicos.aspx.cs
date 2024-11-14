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
                lblMessage.Text = $"Técnicos cargados: {BaseDeDatos.Tecnicos.Count}   .";
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {




            if (IsValidInput() )
            {
                try
                {

                    if (!BaseDeDatos.Tecnicos.Any(t => t.CI == Convert.ToInt32(TxtCiTecnico.Text)))
                    {
                        Tecnico miTecnico = new Tecnico();
                        miTecnico.SetNombre(this.TxtNombreTecnico.Text);
                        miTecnico.SetApellido(this.TxtApellidoTecnico.Text);
                        miTecnico.SetCI(Convert.ToInt32(TxtCiTecnico.Text));
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


            bool esnumericoCI = true;
            int numero = 0;
            bool CIValida = true;
            int suma = 0;

            if (!(int.TryParse(TxtCiTecnico.Text, out numero)))
            {
                esnumericoCI = false;

            }

            for (int i = 0; i < TxtCiTecnico.Text.Length; i++)
            {
                if (char.IsDigit(TxtCiTecnico.Text[i]))
                {
                    if (i == 0)
                    {
                        suma += 2 * int.Parse(TxtCiTecnico.Text[i].ToString());
                    }
                    if (i == 1)
                    {
                        suma += 9 * int.Parse(TxtCiTecnico.Text[i].ToString());
                    }
                    if (i == 2)
                    {
                        suma += 8 * int.Parse(TxtCiTecnico.Text[i].ToString());
                    }
                    if (i == 3)
                    {
                        suma += 7 * int.Parse(TxtCiTecnico.Text[i].ToString());
                    }
                    if (i == 4)
                    {
                        suma += 6 * int.Parse(TxtCiTecnico.Text[i].ToString());
                    }
                    if (i == 5)
                    {
                        suma += 3 * int.Parse(TxtCiTecnico.Text[i].ToString());
                    }

                    if (i == 6)
                    {
                        suma += 4 * int.Parse(TxtCiTecnico.Text[i].ToString());
                    }
                }
            }

            int digitoValido = suma % 10;

            digitoValido = (10 - digitoValido) % 10;

            if (TxtCiTecnico.Text.Length == 8)
            {
                if (digitoValido != int.Parse(TxtCiTecnico.Text[7].ToString()))
                {
                    CIValida = false;
                }
            }





            if (string.IsNullOrEmpty(TxtNombreTecnico.Text))
            {
                lblErrorNombre.Visible = true;
                lblErrorNombre.Text = "Debe Completar este campo.";
            }
            else if (!IsAllLetters(TxtNombreTecnico.Text))
            {
                lblErrorNombre.Visible = true;
                lblErrorNombre.Text = "Solo puede contener letras.";
            }
            else if (TxtNombreTecnico.Text.Length > 30 )
            {
                lblErrorNombre.Visible = true;
                lblErrorNombre.Text = "Excede el limite de longitud. (30)";
            }
            else { lblErrorNombre.Visible = false; }


            if (string.IsNullOrEmpty(TxtApellidoTecnico.Text))
            {
                lblApellidoError.Visible = true;
                lblApellidoError.Text = "Debe Completar este campo.";
            }
            else if (!IsAllLetters(TxtApellidoTecnico.Text))
            {
                lblApellidoError.Visible = true;
                lblApellidoError.Text = "Solo puede contener letras.";
            }
            else if (TxtApellidoTecnico.Text.Length > 30 )
            {
                lblApellidoError.Visible = true;
                lblApellidoError.Text = "Excede el limite de longitud. (30)";
            }
            else { lblApellidoError.Visible = false; }


            if (string.IsNullOrEmpty(TxtEspecialidad.Text))
            {
                lblErrorEspecialidad.Visible = true;
                lblErrorEspecialidad.Text = "Debe Completar este campo.";
            }
            else if (!IsAllLetters(TxtEspecialidad.Text))
            {
                lblErrorEspecialidad.Visible = true;
                lblErrorEspecialidad.Text = "Solo puede contener letras.";
            }
            else if (TxtEspecialidad.Text.Length > 20)
            {
                lblErrorEspecialidad.Visible = true;
                lblErrorEspecialidad.Text = "Excede el limite de longitud. (20)";

            }
            else { lblErrorEspecialidad.Visible = false; }


            if (numero == 0)
            {
                lblErrorCI.Text = "Debe Completar este campo.";
                lblErrorCI.Visible = true;
            }
            else if (esnumericoCI == false)
            {
                lblErrorCI.Text = "Solo puede poner Numeros.";
                lblErrorCI.Visible = true;
            }
            else if (TxtCiTecnico.Text.Length != 8)
            {
                lblErrorCI.Text = "Cedula Invalida. Verifique cantidad de digitos.";
                lblErrorCI.Visible = true;
            }
            else if (CIValida == false)
            {
                lblErrorCI.Text = "Cedula Invalida.";
                lblErrorCI.Visible = true;
            }
            else { lblErrorCI.Visible = false; }





            if (!IsAllLetters(TxtNombreTecnico.Text) || !IsAllLetters(TxtApellidoTecnico.Text) || !IsAllLetters(TxtEspecialidad.Text) || string.IsNullOrEmpty(TxtNombreTecnico.Text) || string.IsNullOrEmpty(TxtApellidoTecnico.Text) || string.IsNullOrEmpty(TxtEspecialidad.Text) || TxtNombreTecnico.Text.Length > 30 || TxtApellidoTecnico.Text.Length > 30 || TxtEspecialidad.Text.Length > 20  || numero == 0  || esnumericoCI == false  || CIValida == false || TxtCiTecnico.Text.Length != 8  )
            {
                {

                    return false;
                }
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
                lblMessage.Text = $"Técnicos cargados {BaseDeDatos.Tecnicos.Count}   .";
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
                lblCedulaEditar.Text = row.Cells[2].Text;
                TxtEspecialidad.Text = row.Cells[3].Text;
                
                ViewState["EditIndex"] = index;
                Button btnEliminar = (Button)row.FindControl("btnEliminar");

                if (btnEliminar != null)
                {
                    btnEliminar.Visible = false;
                }
                TxtCiTecnico.Visible = false;
                lblCedulaEditar.Visible = true;
                Button2.Visible = false;
                btnGuardar.Visible = true;
 
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
           

            if (ViewState["EditIndex"] != null)
            {
                int index = (int)ViewState["EditIndex"];


                TxtCiTecnico.Text = lblCedulaEditar.Text;

                if (IsValidInput())
                {
                    Tecnico tecnicoActualizado = BaseDeDatos.Tecnicos[index];
                    tecnicoActualizado.SetNombre(TxtNombreTecnico.Text);
                    tecnicoActualizado.SetApellido(TxtApellidoTecnico.Text);
                    tecnicoActualizado.SetEspecialidad(TxtEspecialidad.Text);    

                    lblMessage.Text = "Técnico actualizado con éxito!";



                    CargarGridView(); 
             
                ClearForm();
                ViewState["EditIndex"] = null; 


                TxtCiTecnico.Visible = true;
                lblCedulaEditar.Visible = false; 
                btnGuardar.Visible = false;
                Button2.Visible = true;
                }
                else { lblMessage.Text = "error, no se pudo editar"; }
            }
        }


    }
}