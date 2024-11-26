using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using ENTITY;
using ProyectoAula;

namespace GUI
{
    public partial class FormListaProveedores : Form
    {
        ProveedorService ProveedorService;
        public FormListaProveedores()
        {
            InitializeComponent();
            ProveedorService = new ProveedorService();
            //Service.ProveedorGuardado += ProveedorGuardado;
            CargarDatos();
        }  
        private void CargarDatos()
        {
            List<Proveedor> Proveedores = ProveedorService.ObtenerProveedores();
            dgvTablaProveedores.AutoGenerateColumns = false;

            dgvTablaProveedores.Columns["IDProveedor"].DataPropertyName = "IDProveedor";
            dgvTablaProveedores.Columns["TipoId"].DataPropertyName = "IDTipo";
            dgvTablaProveedores.Columns["Nombre1"].DataPropertyName = "Nombre1";
            dgvTablaProveedores.Columns["Nombre2"].DataPropertyName = "Nombre2";
            dgvTablaProveedores.Columns["Apellido1"].DataPropertyName = "Apellido1";
            dgvTablaProveedores.Columns["Apellido2"].DataPropertyName = "Apellido2";
            dgvTablaProveedores.Columns["Telefono"].DataPropertyName = "Telefono";
            dgvTablaProveedores.Columns["Email"].DataPropertyName = "Email";

            dgvTablaProveedores.DataSource = Proveedores;
        }

        private void ProveedorGuardado(Proveedor proveedor)
        {
            //dgvTablaProveedores.Rows.Add(proveedor.IDProveedor, proveedor.TipoID ,proveedor.Nombre, proveedor.Telefono, proveedor.Email);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormMantProveedor frm = new FormMantProveedor();
            frm.ShowDialog();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTablaProveedores.SelectedRows.Count > 0)
            {
                Insertar();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
        private void Insertar()
        {
            FormMantProveedor frm = new FormMantProveedor();
            frm.txtIDProveedor.Text = dgvTablaProveedores.CurrentRow.Cells[0].Value.ToString();
            frm.txtNombre.Text = dgvTablaProveedores.CurrentRow.Cells[2].Value.ToString();
            frm.txtSegundoNombre.Text = dgvTablaProveedores.CurrentRow.Cells[3].Value.ToString();
            frm.txtApellido.Text = dgvTablaProveedores.CurrentRow.Cells[4].Value.ToString();
            frm.txtSegundoApellido.Text = dgvTablaProveedores.CurrentRow.Cells[5].Value.ToString();
            frm.txtTelefono.Text = dgvTablaProveedores.CurrentRow.Cells[6].Value.ToString();
            frm.txtEmail.Text = dgvTablaProveedores.CurrentRow.Cells[7].Value.ToString();

            frm.txtIDProveedor.ReadOnly = true;
            frm.txtIDProveedor.BackColor = SystemColors.Control;
            frm.txtIDProveedor.ForeColor = SystemColors.GrayText;

            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormListaProveedores_Load(object sender, EventArgs e)
        {
            RefrescarDataGridView();
        }

        private void RefrescarDataGridView()
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Boton para eliminar
            try
            {


                if (dgvTablaProveedores.SelectedRows.Count > 0)
                {

                    int idproveedor = Convert.ToInt32(dgvTablaProveedores.SelectedRows[0].Cells["IDProveedor"].Value); //Consigo el id del provedor desde la lista

                    //Primero confirmo de que si se se esta seguro de eliminar a el proveedor
                    DialogResult resultado = MessageBox.Show($"¿Está seguro de que desea eliminar este proveedor {idproveedor}?", "Confirmación de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                    if (resultado == DialogResult.Yes)
                    {
                        if (ProveedorService.EliminarProveedor(idproveedor))
                        {
                            MessageBox.Show("El proveedor ha sido eliminado exitosamente");
                            CargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("Ah ocurrido un error al eliminar el proveedor");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el proveedor.");
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

        public delegate void ProveedorSeleccionadoDelegate(string idProveedor);
        public event ProveedorSeleccionadoDelegate ProveedorSeleccionado;

        private void dgvTablaProveedores_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener el id del proveedor seleccionado
                string idProveedor = dgvTablaProveedores.Rows[e.RowIndex].Cells["IDProveedor"].Value.ToString();

                ProveedorSeleccionado?.Invoke(idProveedor);

                this.Close();
            }
        }
    }
}
