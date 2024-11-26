using ENTITY;
using ProyectoAula;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormPagos : Form
    {MetodoPagosService metodoPagosService;

        public FormPagos()
        {
            InitializeComponent();
            metodoPagosService = new MetodoPagosService();
            CargarDatos();
        }

        private void CargarDatos()
        {
            List<MetodoPagos> pagos = metodoPagosService.ObtenerPagos();
            dgvPagos.AutoGenerateColumns = false;

            dgvPagos.Columns["IDPago"].DataPropertyName = "IDPago";
            dgvPagos.Columns["NombreMetodo"].DataPropertyName = "NombreMetodo";

            dgvPagos.DataSource = pagos;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormantPagos pagos = new FormantPagos();
            pagos.ShowDialog();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Insertar(); 
        }

        private void Insertar()
        {
            FormantPagos formant = new FormantPagos();
            if (dgvPagos.SelectedRows.Count > 0)
            {
                formant.txtid.Text = dgvPagos.CurrentRow.Cells[0].Value.ToString();
                formant.txtNombre.Text = dgvPagos.CurrentRow.Cells[1].Value.ToString();

                formant.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccion una fila por favor"); 
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvPagos.SelectedRows.Count > 0)
                {

                    string idmetodo = Convert.ToString(dgvPagos.SelectedRows[0].Cells["IDPago"].Value); //Consigo el id del pago desde la lista

                    //Primero confirmo de que si se se esta seguro de eliminar a el proveedor
                    DialogResult resultado = MessageBox.Show($"¿Está seguro de que desea eliminar este proveedor {idmetodo}?", "Confirmación de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                    if (resultado == DialogResult.Yes)
                    {
                        if (metodoPagosService.EliminarMetodo(idmetodo))
                        {
                            MessageBox.Show("El metodo ha sido eliminado exitosamente");
                            CargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("Ah ocurrido un error al eliminar el metodo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el metodo.");
                    }
                }
                else
                    MessageBox.Show("seleccione una fila por favor");
            }
            catch (ArgumentException xe)
            {
                MessageBox.Show(xe.Message);
            }
        }
    }
}
