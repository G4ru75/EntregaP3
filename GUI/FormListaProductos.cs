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
    public partial class FormListaProductos : Form
    {
        ProductosServices ProductoS;
        public FormListaProductos()
        {
            InitializeComponent();
            ProductoS = new ProductosServices();  
            CargarDatos(); 
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
                FormMantProductos frm = new FormMantProductos();
            if (dgvTablaProductos.SelectedRows.Count > 0)
            {
                frm.txtid.Text= dgvTablaProductos.CurrentRow.Cells[0].Value.ToString();
                //frm.textDescripcion.Text = dgvListaProductos.CurrentRow.Cells[1].Value.ToString();
                frm.txtNombre.Text = dgvTablaProductos.CurrentRow.Cells[2].Value.ToString();
                frm.txtPrecio.Text = dgvTablaProductos.CurrentRow.Cells[3].Value.ToString();
                frm.txtCantidad.Text = dgvTablaProductos.CurrentRow.Cells[4].Value.ToString();

                frm.txtid.ReadOnly = true;
                frm.txtid.BackColor = SystemColors.Control;
                frm.txtid.ForeColor = SystemColors.GrayText;

                frm.ShowDialog();

            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void CargarDatos()
        {
            List<Productos> Productos = ProductoS.ObtenerProductos();

            dgvTablaProductos.AutoGenerateColumns = false;

            dgvTablaProductos.Columns["IDProducto"].DataPropertyName = "IDProducto"; 
            dgvTablaProductos.Columns["IDCategoria"].DataPropertyName = "CategoriaID";
            dgvTablaProductos.Columns["NombreProducto"].DataPropertyName = "NombreProducto"; 
            dgvTablaProductos.Columns["PrecioVenta"].DataPropertyName = "PrecioVenta"; 
            dgvTablaProductos.Columns["Cantidad"].DataPropertyName = "Cantidad";

            dgvTablaProductos.DataSource = Productos;
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            //Boton para eliminar 
            try
            {

                if (dgvTablaProductos.SelectedRows.Count > 0)
                {

                    string idproducto = Convert.ToString(dgvTablaProductos.SelectedRows[0].Cells["IDProducto"].Value); //Consigo el id del producto desde la lista

                    //Primero confirmo de que si se se esta seguro de eliminar a el proveedor
                    DialogResult resultado = MessageBox.Show($"¿Está seguro de que desea eliminar este producto {idproducto}?", "Confirmación de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                    if (resultado == DialogResult.Yes)
                    {
                        if (ProductoS.EliminarProducto(idproducto))
                        {
                            MessageBox.Show("El producto ha sido eliminado exitosamente");
                            CargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("Ah ocurrido un error al eliminar el producto");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el producto.");
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
           FormMantProductos form = new FormMantProductos();

            form.txtCantidad.ReadOnly = true;
            form.txtCantidad.BackColor = SystemColors.Control;
            form.txtPrecio.ReadOnly = true;
            form.txtPrecio.BackColor = SystemColors.Control;
            form.ShowDialog();
            
        }


        // Para seleccionar en las compras 
        public delegate void ProductoSeleccionadoDelegate(string idProducto, string nombreProducto);
        public event ProductoSeleccionadoDelegate ProductoSeleccionado; // el evento que se va a disparar cuando se seleccione

        // Para seleccioonar en ventas
        public delegate void ProductoSeleccionadoHandler(string idProducto, string nombreProducto, decimal precioProducto);
        public event ProductoSeleccionadoHandler ProductoSeleccionadov;

        private void FormListaProductos_DoubleClick(object sender, EventArgs e)
            {
            }

        private void dgvTablaProductos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvTablaProductos.SelectedRows.Count >= 0)
            {
                // Obtener el id del producto seleccionado
                string idProducto = dgvTablaProductos.CurrentRow.Cells[0].Value.ToString();
                string nombreProducto = dgvTablaProductos.CurrentRow.Cells[2].Value.ToString();
                decimal precioProducto = Convert.ToDecimal(dgvTablaProductos.CurrentRow.Cells[3].Value);

                ProductoSeleccionado?.Invoke(idProducto, nombreProducto);
                ProductoSeleccionadov?.Invoke(idProducto,nombreProducto,precioProducto);
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

    }
}

