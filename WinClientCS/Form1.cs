using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinClientCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static ServiceReference1.WebService2SoapClient servicio;
        private void button1_Click(object sender, EventArgs e)
        {
            servicio = new ServiceReference1.WebService2SoapClient();
            
            string[] res = servicio.AgregarEscuela(txtCodEscuela.Text, txtEscuela.Text, txtFacultad.Text);
            if (res[0] == "0")
            {
                MessageBox.Show(res[1]);
                Listar();
            }
            else
            {
                MessageBox.Show(res[1]);
            }
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void Listar()
        {
            servicio = new ServiceReference1.WebService2SoapClient();
            gridBuscarView.DataSource = servicio.Listar().Tables[0];
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            servicio = new ServiceReference1.WebService2SoapClient();
            string[] res =servicio.EliminarEscuela(txtCodEscuela.Text);
            if (res[0] == "0")
            {
                MessageBox.Show(res[1]);
                Listar();
            }
            else
            {
                MessageBox.Show(res[1]);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            servicio = new ServiceReference1.WebService2SoapClient();
            string[] res = servicio.ActualizarEscuela(txtCodEscuela.Text,txtEscuela.Text,txtFacultad.Text);
            if (res[0] == "0")
            {
                MessageBox.Show(res[1]);
                Listar();
            }
            else
            {
                MessageBox.Show(res[1]);

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            servicio = new ServiceReference1.WebService2SoapClient();
            gridBuscarView.DataSource = servicio.BuscarEscuela(txtSearchBox.Text);
        }
    }
}
