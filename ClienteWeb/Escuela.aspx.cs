using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWeb
{
    public partial class Escuela : System.Web.UI.Page
    {
        // acceder al servicio web
        private static ServiceReference1.WebService1SoapClient servicio = new ServiceReference1.WebService1SoapClient();

        private void Listar()
        {
            gvEscuela.DataSource = servicio.ListarEscuela().Tables[0];
            gvEscuela.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Listar();
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            servicio.AgregarEscuela(txtCodEscuela.Text, txtEscuela.Text, txtFacultad.Text);
            Listar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            servicio.EliminarEscuela(txtCodEscuela.Text);
            Listar();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            servicio.ActualizarEscuela(txtCodEscuela.Text, txtEscuela.Text, txtFacultad.Text);
            Listar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvEscuela.DataSource = servicio.BuscarEscuela(Buscar.Text).Tables[0];
            gvEscuela.DataBind();
        }
    }
}