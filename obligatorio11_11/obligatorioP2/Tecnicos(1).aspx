<%@ Page Title="Tecnicos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="obligatorioP2.Tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<p> Tecnicos </p>

 <label>Nombre: </label>
 &nbsp;<asp:TextBox ID="TxtNombreTecnico" runat="server" Width="146px"></asp:TextBox>
 <br><br />


 <label>Apellido: </label>
 &nbsp;<asp:TextBox ID="TxtApellidoTecnico" runat="server" Width="146px"></asp:TextBox>
 <br><br />

 <label>CI: </label>
 &nbsp;<asp:TextBox ID="TxtCiTecnico" runat="server" Width="146px" TextMode ="Number"></asp:TextBox>
<br><br />

<label>Especialidad: </label>
 &nbsp;<asp:TextBox ID="TxtEspecialidad" runat="server" Width="146px"></asp:TextBox>
<br><br />



<br><br />


 



<asp:GridView runat="server" ID="gvTecnicos" Width="90%" BorderWidth="1" BorderColor="Black" OnRowCommand="gvTecnicos_RowCommand" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
        <asp:BoundField DataField="CI" HeaderText="CI" />
        <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
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

<asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
  
<asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" Visible="false"/>

<br><br />



  <br>

  <asp:Button ID="Button2" runat="server" Text="Enviar" OnClick="Button2_Click" />
  <br />



</asp:Content>

