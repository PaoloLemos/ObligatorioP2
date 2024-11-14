<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="obligatorioP2.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Clientes
    </p>
  

        <label>Nombre: </label>
        &nbsp;<asp:TextBox ID="TxtNombreCliente" runat="server" Width="146px"></asp:TextBox>   <asp:Label ID="lblErrorNombre" runat="server" Text="" ForeColor="Red" Visible ="false"></asp:Label>
        <br><br />


        <label>Apellido: </label>
        &nbsp;<asp:TextBox ID="TxtApellidoCliente" runat="server" Width="146px"></asp:TextBox> <asp:Label ID="lblApellidoError" runat="server" Text="" ForeColor="Red" Visible ="false"></asp:Label>
        <br><br />

        <label>CI: </label>
        &nbsp;<asp:TextBox ID="TxtCiCliente" runat="server" Width="146px" Textmode ="Number" MaxLength ="8" ></asp:TextBox> <asp:Label ID="lblCedulaEditar" runat="server" Text="Debe Completar este campo." Visible= "false" ForeColor="Red"></asp:Label> <asp:Label ID="lblErrorCI" runat="server" Text="" ForeColor="Red" Visible ="false"></asp:Label> 
       <br><br />


        <label>Direccion: </label>
         &nbsp;<asp:TextBox ID="TxtDireccion" runat="server" Width="146px"></asp:TextBox> <asp:Label ID="lblErrorDireccion" runat="server" Text="" ForeColor="Red" Visible ="false"></asp:Label>
       <br><br />

     
        <label>Telefono: </label>
        &nbsp;<asp:TextBox ID="TxtTelefono" runat="server" Width="146px" TextMode="Number"></asp:TextBox> <asp:Label ID="lblErrorTelefono" runat="server" Text="" ForeColor="Red" Visible ="false"></asp:Label>
               <br><br />

        <label>Email: </label>
        &nbsp;<asp:TextBox ID="TxtEmail" runat="server" Width="146px" TextMode="Email"></asp:TextBox> <asp:Label ID="lblErorEmail" runat="server" Text="" ForeColor="Red" Visible ="false"></asp:Label>
        
        <br>
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" Visible="false"/>
        <asp:Button ID="Button1" runat="server" Text="Enviar" OnClick="Button1_Click" /> 

        <br />

        <asp:Label ID="lblErrorClientes" runat="server" Text="" ForeColor="Red"></asp:Label>

        &nbsp;
    

    <asp:GridView runat="server" ID="gvClientes" Width="90%" OnRowCommand="gvClientes_RowCommand" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
        <asp:BoundField DataField="CI" HeaderText="CI" />
        <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
        <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
        <asp:BoundField DataField="Email" HeaderText="Email" />

        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                    CommandName="Eliminar" CommandArgument='<%# Container.DataItemIndex %>' />

                <asp:Button ID="btnEditar" runat="server" Text="Editar"
                    CommandName="Editar" CommandArgument='<%# Container.DataItemIndex %>' />
            </ItemTemplate>
    
        </asp:TemplateField>
    </Columns>

</asp:GridView>





</asp:Content>


