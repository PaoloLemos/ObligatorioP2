<%@ Page Title="Gestion de Orden" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionOrdenes.aspx.cs" Inherits="obligatorioP2.GestionOrdenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <title><%: Page.Title %>Gestion de Ordenes - Obligatorio</title>


 <label>Cliente Asociado: </label>
 &nbsp;<asp:DropDownList ID="cboClienteAsociado" runat="server" Width="146px"></asp:DropDownList> 
 <br><br />

 <label>Tecnico asociado: </label>
 &nbsp;<asp:DropDownList ID="cboTecnicoAsociado" runat="server" Width="146px" ></asp:DropDownList>
<br><br />


 <label>Descripcion del problema: </label>
  &nbsp;<asp:TextBox ID="TxtDescripcionProblema" runat="server" Height="140" Width="246px"></asp:TextBox> <asp:Label ID="lblErrorDireccion" runat="server" Text="" ForeColor="Red" Visible ="false"></asp:Label>
<br><br />

    <asp:Button ID="btnEnviar" runat="server" Text="Enviar Orden" OnClick="btnEnviar_Click" />


       <asp:GridView runat="server" ID="gvOrdenes" Width="90%"  AutoGenerateColumns="False"    OnRowEditing="gvOrdenes_RowEditing" OnRowUpdating="gvOrdenes_RowUpdating" OnRowCancelingEdit="gvOrdenes_RowCancelingEdit">
   <Columns>
       <asp:BoundField DataField="NumeroDeOrden" HeaderText="Numero de Orden:" ReadOnly ="true" />
       <asp:BoundField DataField="ClienteAsociadoNombre" HeaderText="Cliente:" ReadOnly ="true"  />
       <asp:BoundField DataField="TecnicoAsignadoNombre" HeaderText="Tecnico:" ReadOnly ="true"  />
       <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripcion del problema" ReadOnly ="true"  />
       <asp:BoundField DataField="FechaDeCreacion" HeaderText="Fecha de Creacion" ReadOnly ="true"  />
 <asp:TemplateField HeaderText="Estado">
            <ItemTemplate>
                <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlEstado" runat="server">
                    <asp:ListItem Text="Pendiente" Value="Pendiente"></asp:ListItem>
                    <asp:ListItem Text="En Proceso" Value="En Proceso"></asp:ListItem>
                    <asp:ListItem Text="Completada" Value="Completada"></asp:ListItem>
                </asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>       
       
  <asp:TemplateField HeaderText="Acciones">
    <ItemTemplate>
        <!-- Botón para agregar comentario -->
        <asp:LinkButton ID="btnAgregarComentario" runat="server" Text="Agregar Comentario"
            PostBackUrl='<%# "AgregarComentario.aspx?orden=" + Eval("NumeroDeOrden") %>'></asp:LinkButton>

        <!-- Botón para entrar en modo de edición -->
        <asp:LinkButton ID="btnEditMode" runat="server" CommandName="Edit" Text="Editar" />
    </ItemTemplate>
    <EditItemTemplate>
        <!-- Botones que aparecerán cuando se está editando la fila -->
        <asp:Button ID="btnSave" runat="server" CommandName="Update" Text="Guardar" />
        <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancelar" />
    </EditItemTemplate>
</asp:TemplateField>
   </Columns>
</asp:GridView>
    
    

</asp:Content>
