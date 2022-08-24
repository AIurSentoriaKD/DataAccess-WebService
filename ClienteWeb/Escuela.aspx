<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Escuela.aspx.cs" Inherits="ClienteWeb.Escuela" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3>Mantenimiento para Escuela</h3>
    
    <p>
        CodEscuela : <asp:TextBox runat="server" ID="txtCodEscuela" />
    </p>
    <p>
        Escuela : <asp:TextBox runat="server" ID="txtEscuela" />
    </p>
    <p>
        Facultad : <asp:TextBox runat="server" ID="txtFacultad" />
    </p>
    <p>
        <asp:Button Text="Agregar" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" />
        <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" OnClick="btnEliminar_Click" />
        <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" OnClick="btnActualizar_Click" />
    </p>
    <p>
        Buscar: <asp:TextBox runat="server" Id="Buscar"/>
        <asp:DropDownList runat="server" ID="cmbArgumento">
            <asp:ListItem Text="codEscuela" />
            <asp:ListItem Text="escuela" />
        </asp:DropDownList>
        <asp:Button Text="Buscar" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" />
    </p>
    <p>
        <asp:GridView runat="server" ID="gvEscuela" ></asp:GridView>
    </p>
</asp:Content>
