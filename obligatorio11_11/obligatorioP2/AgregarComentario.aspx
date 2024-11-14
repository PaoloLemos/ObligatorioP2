<%@ Page Title="Agregar Comentario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarComentario.aspx.cs" Inherits="obligatorioP2.AgregarComentario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    


    <asp:TextBox ID="TxtComentario" runat="server"></asp:TextBox>
    <asp:Button ID="BtnAgregarComentario" runat="server" OnClick="btnAgregarComentario_Click" Text ="Agregar Comentario" />   <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
     <asp:Label ID="lblComentario" runat ="server"  Visible="false" Text ="Debe Completar este casillero" ForeColor ="Red" ></asp:Label>
</asp:Content>
