using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionGUI
{
    public partial class Form1 : Form
    {
        private ConexionBDService conexionBDService;
        private List<Factura> facturas;
        private List<Servicio> servicios;
        private ManejoDeArchivosService manejoDeArchivosService;
        private int opcion = 0;
        public Form1()
        {
            InitializeComponent();
            manejoDeArchivosService = new ManejoDeArchivosService();
            conexionBDService = new ConexionBDService(ExtraccionCadena.Conexion);
            facturas = new List<Factura>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK && openFile.FileName != null)
            {   string file = openFile.FileName;
                txtRuta.Text = file;
                if (manejoDeArchivosService.Consultar(file).MensajeDeError == null)
                {
                    facturas = manejoDeArchivosService.Consultar(file).Ventas;
                    servicios = conexionBDService.ConsultarProductos().productos;
                    MessageBox.Show("secargo el archivo");
                    foreach (var item in facturas)
                    {
                        foreach (var item2 in servicios)
                        {
                            if (item.Valor == item2.Valor && item.CodigoServicio == item2.Codigo)
                            {
                                conexionBDService.GuardarVentas(item);
                            }
                        }
                    }
                }
                else
                {
                    facturas = null;
                    MessageBox.Show("Archivo invalido");
                }
            }
            ConsultaDataGrid();
        }

        private void ConsultaDataGrid()
        {
            dataGridView1.DataSource = conexionBDService.ConsultarProductos();
        }

    }
}
