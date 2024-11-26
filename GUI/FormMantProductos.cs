using ENTITY;
using ProyectoAula;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;

namespace GUI
{
    public partial class FormMantProductos : Form
    {
        CategoriaService CategoriaS;
        ProductosServices ProductosS;
        public FormMantProductos()
        {
            InitializeComponent();
            CategoriaS = new CategoriaService();
            ProductosS = new ProductosServices();
            CargarCategorias(); 
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void CargarCategorias()
        {
            List<Categoria> Categorias = CategoriaS.ObtenerCategorias();
            cboCategoria.DataSource = Categorias;
            cboCategoria.DisplayMember = "NombreCategoria";
            cboCategoria.ValueMember = "IDCategoria";
        }

        private void btnCerra_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Boton para modificar 

            if (!ValidarModificacion())
            {
                MessageBox.Show("Favor de revisar los datos");
            }
            else
            {
                if (ModificarProducto())
                {
                    Limpiar();
                }               
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                MessageBox.Show("Verifique los datos ingresados por favor");
            }
            else
            {
                GuardarProductos();
                Limpiar();
            }
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private bool Validar()
        {
            if (txtid.Text.Length != 5)
            {
                MessageBox.Show("El ID debe tener exactamente 5 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtid.Focus();
                return false;
            }

            if (txtNombre.Text.Length > 50 || txtNombre.Text.Length < 3 )
            {
                MessageBox.Show("El nombre no puede exceder los 50 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            
            return true;
        }

        private bool ValidarModificacion()
        {
                if (txtNombre.Text.Length > 50 || txtNombre.Text.Length < 3)
                {
                    MessageBox.Show("El nombre no puede exceder los 50 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return false;
                }

                if (!decimal.TryParse(txtPrecio.Text, out decimal precioVenta) || precioVenta < 0)
                {
                    MessageBox.Show("El precio de venta debe ser un número mayor o igual a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrecio.Focus();
                    return false;
                }

                if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad) || cantidad < 0)
                {
                    MessageBox.Show("La cantidad debe ser un número mayor o igual a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidad.Focus();
                    return false;
                }

            return true;
            
        }

        private bool GuardarProductos()
        {
            try
            {
                Productos producto = new Productos
                {
                    IDProducto = txtid.Text,
                    IDCategoria = new Categoria(cboCategoria.SelectedValue.ToString(), cboCategoria.Text),
                    NombreProducto = txtNombre.Text,
                 
                };

                if (ProductosS.GuardarProducto(producto))
                {
                    MessageBox.Show("Producto guardado con éxito.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al guardar el producto.");
                    return false;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ModificarProducto()
        {
            Productos producto = new Productos
            {
                IDProducto = txtid.Text,
                IDCategoria = new Categoria(cboCategoria.SelectedValue.ToString(), cboCategoria.Text),
                NombreProducto = txtNombre.Text,
                PrecioVenta = decimal.Parse(txtPrecio.Text),
                Cantidad = decimal.Parse(txtCantidad.Text)
            };

            bool resultado = ProductosS.ModificarProducto(producto);

            if (resultado)
            {
                MessageBox.Show("Producto modificado con éxito.");
                return true;
            }
            else
            {
                MessageBox.Show("Error al modificar el producto.");
                return false;
            }
        }

        private void Limpiar()
        {
            txtid.Text = "";
            cboCategoria.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";

        }
    }
}
