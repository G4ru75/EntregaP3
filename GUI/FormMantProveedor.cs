using ENTITY;
using GUI.Modales;
using ProyectoAula;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI
{
    public partial class FormMantProveedor : Form
    {
        ProveedorService ProveedorService;
        TipoIDService TipoIDService;
        public FormMantProveedor()
        {
            InitializeComponent();
            ProveedorService = new ProveedorService();
            TipoIDService = new TipoIDService();
            CargarTipos(); 
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCerrar1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnguardar_Click(object sender, EventArgs e)
        {
            
            if (!Validar())
            {
                MessageBox.Show("Por favor revisar los datos");
            }
            else
            {
                if (GuardarProveedor())
                {
                     Limpiar();
                }
                
            }

        }

        private bool GuardarProveedor()
        {
            try

            {
                Proveedor proveedor = new Proveedor
                {
                    IDProveedor = int.Parse(txtIDProveedor.Text),
                    TipoID = new TipoID(cboTipoID.SelectedValue.ToString(), cboTipoID.Text),
                    Nombre1 = txtNombre.Text,
                    Nombre2 = txtSegundoNombre.Text,
                    Apellido1 = txtApellido.Text,
                    Apellido2 = txtSegundoApellido.Text,
                    Telefono = double.Parse(txtTelefono.Text),
                    Email = txtEmail.Text
                };

                if (ProveedorService.GuardarProveedor(proveedor))
                {
                    MessageBox.Show("Proveedor guardado con éxito.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al guardar el proveedor.");
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


        private bool Validar()
        {
            txtEmail.Text = txtEmail.Text.Trim();
            if (!Regex.IsMatch(txtIDProveedor.Text, @"^\d{7,12}$") || (txtIDProveedor.Text == ""))
            {
                MessageBox.Show("El ID debe ser numérico y tener entre 7 y 12 dígitos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cboTipoID.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un valor valido en el tipo de id.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }

            if (!Regex.IsMatch(txtNombre.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$") || (txtNombre.Text == ""))
            {
                MessageBox.Show("El nombre debe contener solo letras.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }

            if (!string.IsNullOrEmpty(txtSegundoNombre.Text) && !Regex.IsMatch(txtSegundoNombre.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$"))
            {
                MessageBox.Show("El segundo nombre debe contener solo letras.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Regex.IsMatch(txtApellido.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$") || (txtApellido.Text == ""))
            {
                MessageBox.Show("El apellido debe contener solo letras.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }

            if (!string.IsNullOrEmpty(txtSegundoApellido.Text) && !Regex.IsMatch(txtSegundoApellido.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$"))
            {
                MessageBox.Show("El segundo apellido debe contener solo letras.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }

            if (!Regex.IsMatch(txtTelefono.Text, @"^\d{10}$"))
            {
                MessageBox.Show("El número de teléfono debe contener exactamente 10 dígitos numéricos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$") && !string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Por favor, ingresa un email válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        private void Limpiar()
        {
            txtIDProveedor.Text = "";
            cboTipoID.Text = "";
            txtNombre.Text = "";
            txtSegundoNombre.Text = "";
            txtApellido.Text = "";
            txtSegundoApellido.Text = ""; 
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }
        private void FormMantProveedor_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                MessageBox.Show("Por favor revisar los datos");
            }
            else
            {
                if (ModificarProveedor())
                {
                    Limpiar();
                }
               
            }
        }

        private bool ModificarProveedor()
        {
            Proveedor proveedor = new Proveedor
            {
                IDProveedor = int.Parse(txtIDProveedor.Text),
                TipoID = new TipoID(cboTipoID.SelectedValue.ToString(), cboTipoID.Text), // Aqui se Captura tipoid y nombre del tipo
                Nombre1 = txtNombre.Text,
                Nombre2 = txtSegundoNombre.Text,
                Apellido1 = txtApellido.Text,
                Apellido2 = txtSegundoApellido.Text,
                Telefono = double.Parse(txtTelefono.Text),
                Email = txtEmail.Text
            };

            bool resultado = ProveedorService.ModificarProveedor(proveedor);

            if (resultado)
            {
                MessageBox.Show("Proveedor modificado con éxito.");
                return true;
            }
            else
            {
                MessageBox.Show("Error al modificar el proveedor.");
                return false;
            }
        }

        private void CargarTipos()
        {
            List<TipoID> Tipos = TipoIDService.ObtenerTiposID();
            cboTipoID.DataSource = Tipos;
            cboTipoID.DisplayMember = "Nombre";
            cboTipoID.ValueMember = "IDTipo";
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void txtIDProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboTipoID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}