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
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarGridView();
                lblErrorClientes.Text = $"Clientes cargados: {BaseDeDatos.Clientes.Count}   .";
            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           

            if (IsValidInput())
            {
                try
                {

                    if (!BaseDeDatos.Clientes.Any(t => t.CI == Convert.ToInt32(TxtCiCliente.Text)))
                    {
                        Cliente micliente = new Cliente();
                        micliente.SetNombre(this.TxtNombreCliente.Text);
                        micliente.SetApellido(this.TxtApellidoCliente.Text);
                        micliente.SetCI(Convert.ToInt32(TxtCiCliente.Text));
                        micliente.SetDireccion(this.TxtDireccion.Text);
                        micliente.SetTelefono(this.TxtTelefono.Text);
                        micliente.SetEmail(this.TxtEmail.Text);

                        BaseDeDatos.Clientes.Add(micliente);

                        CargarGridView();
                        lblErrorClientes.Text = "Cliente guardado con éxito!";

                        ClearForm();
                    }
                    else
                    {
                        CargarGridView();
                        if (!IsPostBack)
                        {
                            lblErrorClientes.Visible = false;
                        }
                        else { lblErrorClientes.Text = "El Cliente con este CI ya existe."; }
                    }

                    ClearForm();

                }
                catch (Exception ex)
                {
                    lblErrorClientes.Text = "Error: " + ex.Message;
                }

            }
            else
            {
                lblErrorClientes.Text = "Por favor, complete todos los campos correctamente.";
            }

        }
        bool IsValidInput()
        {
            bool esnumericoCI = true;
            bool esnumericoTelefono = true;
            int numero = 0;
            bool CIValida = true;
            int suma = 0;

            foreach(char c in TxtTelefono.Text)
            {
                if (!char.IsDigit(c))
                {
                    esnumericoTelefono = false;
                }

            }

            if (!(int.TryParse(TxtCiCliente.Text, out numero )))
            {
                esnumericoCI = false;
             
            }
           
            for(int i = 0; i <  TxtCiCliente.Text.Length; i++)
            {
                if (char.IsDigit(TxtCiCliente.Text[i])){ 
                    if (i == 0)
                    {
                        suma += 2 * int.Parse(TxtCiCliente.Text[i].ToString());
                    }
                    if (i == 1)
                    {
                        suma += 9 * int.Parse(TxtCiCliente.Text[i].ToString());
                    }
                    if (i == 2)
                    {
                        suma += 8 * int.Parse(TxtCiCliente.Text[i].ToString());
                    }
                    if (i == 3)
                    {
                        suma += 7 * int.Parse(TxtCiCliente.Text[i].ToString());
                    }
                    if (i == 4)
                    {
                        suma += 6 * int.Parse(TxtCiCliente.Text[i].ToString());
                    }
                    if (i == 5)
                    {
                        suma += 3 * int.Parse(TxtCiCliente.Text[i].ToString());
                    }

                    if (i == 6)
                    {
                        suma += 4 * int.Parse(TxtCiCliente.Text[i].ToString());
                    }
                }
            }

            int digitoValido = suma % 10;

            digitoValido = (10  - digitoValido) % 10;

            if (TxtCiCliente.Text.Length == 8)
            {
                if (digitoValido != int.Parse(TxtCiCliente.Text[7].ToString()))
                {
                    CIValida = false;
                }
            }








            if (string.IsNullOrEmpty(TxtNombreCliente.Text))
            {
                lblErrorNombre.Visible = true;
                lblErrorNombre.Text = "Debe Completar este campo.";
            }
            else if (!IsAllLetters(TxtNombreCliente.Text))
            {
                lblErrorNombre.Visible = true;
                lblErrorNombre.Text = "Solo puede contener letras.";
            }
            else if(TxtNombreCliente.Text.Length > 30)
            {
                lblErrorNombre.Visible = true;
                lblErrorNombre.Text = "Excede el limite de longitud. (30)";
            }
            else { lblErrorNombre.Visible = false; }

            if (string.IsNullOrEmpty(TxtApellidoCliente.Text))
            {
                lblApellidoError.Visible = true;
                lblApellidoError.Text = "Debe Completar este campo.";
            }
            else if (!IsAllLetters(TxtApellidoCliente.Text))
            {
                lblApellidoError.Visible = true;
                lblApellidoError.Text = "Solo puede contener letras.";
            }
            else if(TxtApellidoCliente.Text.Length > 30)
            {
                lblApellidoError.Visible = true;
                lblApellidoError.Text = "Excede el limite de longitud. (30)";
            }
            else { lblApellidoError.Visible = false; }

            if (string.IsNullOrEmpty(TxtDireccion.Text))
            {
                lblErrorDireccion.Visible = true;
                lblErrorDireccion.Text = "Debe Completar este campo.";
            }
            else { lblErrorDireccion.Visible = false; }

            if (string.IsNullOrEmpty(TxtEmail.Text))
            {
                lblErorEmail.Visible = true;
                lblErorEmail.Text = "Debe Completar este campo.";
            }
            
            else { lblErorEmail.Visible = false; }

            if (string.IsNullOrEmpty(TxtTelefono.Text))
            {
                lblErrorTelefono.Text = "Debe Completar este campo.";
                lblErrorTelefono.Visible = true;
            }
            else if (esnumericoTelefono == false )
            {
                lblErrorTelefono.Text = "Solo puede poner Numeros.";
                lblErrorTelefono.Visible = true;
            }
            else if(TxtTelefono.Text.Length > 20)
            {
                lblErrorTelefono.Text = "Excede el limite de longitud. (20)";
                lblErrorTelefono.Visible = true;
            }
            else { lblErrorTelefono.Visible = false;   }

            if(numero == 0)
            {
                lblErrorCI.Text = "Debe Completar este campo.";
                lblErrorCI.Visible = true;
            }
            else if (esnumericoCI == false)
            {
                lblErrorCI.Text = "Solo puede poner Numeros.";
                lblErrorCI.Visible= true;
            }
            else if(TxtCiCliente.Text.Length != 8)
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










            if (string.IsNullOrEmpty(TxtEmail.Text) || string.IsNullOrEmpty(TxtNombreCliente.Text) || string.IsNullOrEmpty(TxtApellidoCliente.Text) || string.IsNullOrEmpty(TxtDireccion.Text) || string.IsNullOrEmpty(TxtTelefono.Text)  || numero == 0 || !IsAllLetters(TxtNombreCliente.Text) || !IsAllLetters(TxtApellidoCliente.Text) || TxtNombreCliente.Text.Length > 30 || TxtApellidoCliente.Text.Length > 30 || TxtTelefono.Text.Length > 20 ||  esnumericoTelefono == false   || esnumericoCI == false  || CIValida == false || TxtCiCliente.Text.Length != 8  )
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
            TxtNombreCliente.Text = string.Empty;
            TxtApellidoCliente.Text = string.Empty;
            TxtCiCliente.Text = string.Empty;
            TxtDireccion.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            TxtTelefono.Text = string.Empty;
        }

        private void CargarGridView()
        {


            if (BaseDeDatos.Clientes.Count > 0)
            {
                lblErrorClientes.Visible = true;
                lblErrorClientes.Text = $"Técnicos cargados {BaseDeDatos.Clientes.Count}   .";
            }

            gvClientes.DataSource = BaseDeDatos.Clientes;
            gvClientes.DataBind();
        }

        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                BaseDeDatos.Clientes.RemoveAt(index);

                gvClientes.DataSource = BaseDeDatos.Clientes;
                gvClientes.DataBind();
            }

            if (e.CommandName == "Editar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvClientes.Rows[index];

                TxtNombreCliente.Text = row.Cells[0].Text; ;
                TxtApellidoCliente.Text = row.Cells[1].Text;
                lblCedulaEditar.Text = row.Cells[2].Text;
                TxtDireccion.Text = row.Cells[3].Text;
                TxtTelefono.Text = row.Cells[4].Text;
                TxtEmail.Text = row.Cells[5].Text;

                ViewState["EditIndex"] = index;
                Button btnEliminar = (Button)row.FindControl("btnEliminar");

                if (btnEliminar != null)
                {
                    btnEliminar.Visible = false;
                }
                TxtCiCliente.Visible = false;
                lblCedulaEditar.Visible = true;
                Button1.Visible = false;
                btnGuardar.Visible = true;

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {


            if (ViewState["EditIndex"] != null)
            {
                int index = (int)ViewState["EditIndex"];


                TxtCiCliente.Text = lblCedulaEditar.Text;

                if (IsValidInput())
                {
                    Cliente clienteActualizado = BaseDeDatos.Clientes[index];
                    clienteActualizado.SetNombre(TxtNombreCliente.Text);
                    clienteActualizado.SetApellido(TxtApellidoCliente.Text);
                    clienteActualizado.SetDireccion(TxtDireccion.Text);
                    clienteActualizado.SetTelefono(TxtTelefono.Text);
                    clienteActualizado.SetEmail(TxtEmail.Text);

                    lblErrorClientes.Text = "Técnico actualizado con éxito!";



                    CargarGridView(); // Recargar el GridView

                    ClearForm();
                    ViewState["EditIndex"] = null; // Resetear el índice de edición


                    TxtCiCliente.Visible = true;
                    lblCedulaEditar.Visible = false;
                    btnGuardar.Visible = false;
                    Button1.Visible = true;
                }
                else { lblErrorClientes.Text = "error, no se pudo editar"; }
            }
        }


    }
}