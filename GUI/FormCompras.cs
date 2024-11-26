using ENTITY;
using GUI.Modales;
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
    public partial class FormCompras : Form
    {
        MetodoPagosService PagosService;
        CompraService CompraService;
        public FormCompras()
        {
            InitializeComponent();
            PagosService = new MetodoPagosService();
            CompraService = new CompraService();
            CargarPagos();
            CargarDatos();
            nudCantidad.ValueChanged += cboCantidad_ValueChanged;
            txtpreciocaja.TextChanged += txtpreciocaja_TextChanged;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            txtidproducto.ReadOnly = true;
            txtidproveedor.ReadOnly = true;
            txtproducto.ReadOnly = true;
            txtFecha.ReadOnly = true;
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidproducto.Text = "Clik para seleccionar";
            txtidproveedor.Text = "Clik para seleccionar";
        }

        private void CargarPagos()
        {
            List<MetodoPagos> Pagos = PagosService.ObtenerPagos();
            cboPagos.DataSource = Pagos;
            cboPagos.DisplayMember = "NombreMetodo";
            cboPagos.ValueMember = "IDPago";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txttotalpagar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (Guardar())
            {
                MessageBox.Show("Compra realizada con exito");
                Limpiar();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al hacer la compra por favor revise los datos digitados");
            }
            
        }

        private bool Guardar()
        {
            if (!decimal.TryParse(txtpreciocaja.Text, out decimal precioCaja))
            {
                MessageBox.Show("Por favor revise los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Compra compra = new Compra
            {
                Proveedor = new Proveedor { IDProveedor = int.Parse(txtidproveedor.Text) },
                Productos = new Productos { IDProducto = txtidproducto.Text },
                CantidadCajas = (int)nudCantidad.Value,
                PrecioCaja = precioCaja,
                FechaCompra = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null),
                PagoID = new MetodoPagos(cboPagos.SelectedValue.ToString(), cboPagos.Text),
            };

            if (CompraService.InsertarCompra(compra))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Limpiar()
        {
            txtidproveedor.Text = "";
            txtidproducto.Text = "";
            txtproducto.Text = "";
            txtpreciocaja.Text = "";
            nudCantidad.Value = 1;

        }

        private void txtidproveedor_MouseClick(object sender, MouseEventArgs e)
        {
            FormListaProveedores listaProveedores = new FormListaProveedores();

            listaProveedores.ProveedorSeleccionado += listaproveedores_ProveedorSeleccionado;

            listaProveedores.ShowDialog();

        }

        private void listaproveedores_ProveedorSeleccionado(string idProveedor)
        {
            txtidproveedor.Text = idProveedor;
        }

        private void txtidproducto_MouseClick(object sender, MouseEventArgs e)
        {
            FormListaProductos listaProductos = new FormListaProductos();

            listaProductos.ProductoSeleccionado += listaproductos_productoseleccionado;

            listaProductos.ShowDialog();
        }

        private void listaproductos_productoseleccionado(string idProducto, string nombreProducto)
        {
            txtidproducto.Text = idProducto;
            txtproducto.Text = nombreProducto; // Asignar el nombre al campo correspondiente
        }

        private void CargarDatos()
        {
            List<Compra> compras = CompraService.ObtenerCompras();
            dgvTablaCompra.AutoGenerateColumns = false;

            dgvTablaCompra.Columns["IDCompra"].DataPropertyName = "IDCompra";
            dgvTablaCompra.Columns["IDProveedor"].DataPropertyName = "IDProveedor";
            dgvTablaCompra.Columns["IDProducto"].DataPropertyName = "IDProducto";
            dgvTablaCompra.Columns["Cantidad"].DataPropertyName = "CantidadCajas";
            dgvTablaCompra.Columns["Precio"].DataPropertyName = "PrecioCaja";
            dgvTablaCompra.Columns["Total"].DataPropertyName = "TotalCompra";

            dgvTablaCompra.DataSource = compras;
        }

        private void ActualizarTotal()
        {
            // Validar que ambos campos tengan valores válidos
            if (nudCantidad.Value > 0 && decimal.TryParse(txtpreciocaja.Text, out decimal precioCaja))
            {
                
                decimal precioTotal = (int)nudCantidad.Value * precioCaja;

                txttotalpagar.Text = precioTotal.ToString("N2"); // Formato numérico con dos decimales
            }
            else
            {
                
                txttotalpagar.Text = string.Empty;
            }
        }

        private void txtpreciocaja_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void cboCantidad_ValueChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }
    }
}
