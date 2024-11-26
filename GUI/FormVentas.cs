using ENTITY;
using ProyectoAula;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormVentas : Form
    {
        MetodoPagosService PagosService;
        VentasService VentasService;
        public FormVentas()
        {
            InitializeComponent();
            PagosService = new MetodoPagosService();
            VentasService = new VentasService();
            CargarPagos();
            CargarDatos();
            nudCantidad.Minimum = 1; 
            txtprecio.TextChanged += txtprecio_TextChanged;
            nudCantidad.ValueChanged += txtcantidad_ValueChanged;
            txtpago.TextChanged += txtpago_TextChanged;
        }

        private void txttotalpagar_TextChanged(object sender, EventArgs e)
        {

        }
        private void CargarPagos()
        {
            List<MetodoPagos> Pagos = PagosService.ObtenerPagos();
            cboPagos.DataSource = Pagos;
            cboPagos.DisplayMember = "NombreMetodo";
            cboPagos.ValueMember = "IDPago";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            txtidproducto.ReadOnly = true;
            txtproducto.ReadOnly = true;
            txtFecha.ReadOnly = true;
            txtprecio.ReadOnly = true;
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidproducto.Text = "Clik para seleccionar";
        }

        private void txtidproducto_MouseClick(object sender, MouseEventArgs e)
        {
            FormListaProductos listaProductos = new FormListaProductos();

            listaProductos.ProductoSeleccionadov += listaproductos_productoseleccionado;

            listaProductos.ShowDialog(); 

        }

        private void listaproductos_productoseleccionado(string idProducto, string nombreProducto, decimal precioProducto)
        {
            txtidproducto.Text = idProducto;
            txtproducto.Text = nombreProducto;
            txtprecio.Text = precioProducto.ToString("0.00"); //("0.00") para el formato para dos decimales

        }

        private void CargarDatos()
        {
            List<Venta> Ventas = VentasService.ObtenerVentas();
            dgvTablaVentas.AutoGenerateColumns = false;

            dgvTablaVentas.Columns["IDVenta"].DataPropertyName = "IDVenta";
            dgvTablaVentas.Columns["IDProducto"].DataPropertyName = "IDProducto";
            dgvTablaVentas.Columns["Cantidad"].DataPropertyName = "Cantidad";
            dgvTablaVentas.Columns["Precio"].DataPropertyName = "PrecioLibra";

            dgvTablaVentas.DataSource = Ventas;
        }

        private void txtprecio_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotal(); 
        }

        private void txtcantidad_ValueChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            if (decimal.TryParse(txtprecio.Text, out decimal precio) && nudCantidad.Value > 0)
            {
                // Calcular el total
                decimal cantidad = nudCantidad.Value;
                decimal total = precio * cantidad;

                txtTotal.Text = total.ToString("N2");
            }
            else
            {
                txtTotal.Text = "";
            }
        }

        private void txtpago_TextChanged(object sender, EventArgs e)
        {
            ActualizarVueltos(); 
        }

        private void ActualizarVueltos()
        {
            if (decimal.TryParse(txtTotal.Text, out decimal total) && decimal.TryParse(txtpago.Text, out decimal pago))
            {
                decimal vueltos = pago - total;
                txtVueltos.Text = vueltos.ToString("N2");
            }
            else
            {
                txtVueltos.Text = ""; 
            }
        }

        private bool Validar()
        {
            if (!Regex.IsMatch(txtNombreCliente.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El nombre del cliente solo puede contener letras.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Regex.IsMatch(txtApellidoCliente.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El apellido del cliente solo puede contener letras.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (Validar() && Guardar())
            {
                MessageBox.Show("Venta hecha con exito");
                Limpiar(); 
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error: Algo ha salido mal"); 
            }
        }


        public bool Guardar()
        {
            Venta ventas = new Venta
            {
                IDProductos = new Productos { IDProducto = txtidproducto.Text },
                Cantidad = (int)nudCantidad.Value,
                NombreCliente = txtNombreCliente.Text,
                ApellidoCliente = txtApellidoCliente.Text,
            };
            
            decimal monto = decimal.Parse(txtpago.Text); 
            string metodo = cboPagos.SelectedValue.ToString();

            if (VentasService.Vender(ventas, monto, metodo))
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public void Limpiar() 
        {
            txtApellidoCliente.Text = "";
            txtNombreCliente.Text = "";
            txtidproducto.Text = "";
            txtproducto.Text = "";
            nudCantidad.Value = 1;
            txtpago.Text = "";
            txtprecio.Text = "";
            txtTotal.Text = "";
            txtVueltos.Text = ""; 
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 
