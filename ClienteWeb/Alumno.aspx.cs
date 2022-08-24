using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWeb
{
    public partial class Alumno : System.Web.UI.Page
    {
        private static ServiceReference1.WebService1SoapClient servicio = new ServiceReference1.WebService1SoapClient();

        private void Listar()
        {
            gvAlumnos.DataSource = servicio.ListarAlumnos().Tables[0];
            gvAlumnos.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Listar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            servicio.AgregarAlumno(txtCodAlumno.Text, txtApellidos.Text, txtNombres.Text, txtLugarNac.Text, txtFecha.Text, txtCodEscuelaA.Text);
            Listar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            servicio.EliminarAlumno(txtCodAlumno.Text);
            Listar();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            servicio.ActualizarAlumno(txtCodAlumno.Text, txtApellidos.Text, txtNombres.Text, txtLugarNac.Text, txtFecha.Text, txtCodEscuelaA.Text);
            Listar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvAlumnos.DataSource = servicio.BuscarAlumno(BuscarAlumno.Text).Tables[0];
            gvAlumnos.DataBind();
        }
    }
}