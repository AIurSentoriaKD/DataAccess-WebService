<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="ClienteWeb.Alumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Mantenimiento de Alumno</h3>
    <p>
        CodAlumno : <asp:TextBox runat="server" ID="txtCodAlumno" />
    </p>
    <p>
        Apellidos : <asp:TextBox runat="server" ID="txtApellidos" />
    </p>
    <p>
        Nombres : <asp:TextBox runat="server" ID="txtNombres" />
    </p>
    <p>
        Lugar Nacimiento : <asp:TextBox runat="server" ID="txtLugarNac" />
    </p>
    <p>
        Fecha Nacimiento : <asp:TextBox runat="server" ID="txtFecha"/>
    </p>
    <p>
        CodEscuela : <asp:TextBox runat="server" ID="txtCodEscuelaA"/>
    </p>
    <p>
        <asp:Button Text="Agregar" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" />
        <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" OnClick="btnEliminar_Click" />
        <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" OnClick="btnActualizar_Click" />
    </p>
    <p>
        Buscar: <asp:TextBox runat="server" Id="BuscarAlumno"/>
        <asp:Button Text="Buscar" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" />
    </p>
    <p>
        <asp:GridView runat="server" ID="gvAlumnos" ></asp:GridView>
    </p>
</asp:Content>
