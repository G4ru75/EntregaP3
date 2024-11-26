using ENTITY;
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
using System.Windows.Forms;

namespace GUI
{
    public partial class FormantPagos : Form
    {
        MetodoPagosService metodoPagosService;
        public FormantPagos()
        {
            InitializeComponent();
            metodoPagosService = new MetodoPagosService();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Guardar() && Validar())
            {
                MessageBox.Show("Todo ha salido bien");
            }
            else 
            {
                MessageBox.Show("Ah ocurrido un error"); 
            }
        }

        private bool Guardar()
        {
            try
            {
                MetodoPagos metodo = new MetodoPagos
                {
                   IDPago = txtid.Text,
                   NombreMetodo = txtNombre.Text,  
                };

                if (metodoPagosService.GuardarMetodos(metodo))
                {
                    MessageBox.Show("Metodo guardado con éxito.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al guardar el metodo.");
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

        public bool Validar()
        { 

            if (!string.IsNullOrEmpty(txtid.Text) && !Regex.IsMatch(txtid.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$") && txtid.Text.Length > 5)
            {
                MessageBox.Show("El id debe contener solo letras y menos de 5 caracteres.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtid.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtNombre.Text) && !Regex.IsMatch(txtNombre.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$") && txtNombre.Text.Length > 50)
            {
                MessageBox.Show("El nombre debe contener solo letras y menos de 50 caracteres.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            return true; 
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Modificar() && Validar())
            {
                MessageBox.Show("Todo ha salido bien");
            }
            else
            {
                MessageBox.Show("Ah ocurrido un error");
            }
        }

        private bool Modificar()
        {
            try
            {
                MetodoPagos metodo = new MetodoPagos
                {
                    IDPago = txtid.Text,
                    NombreMetodo = txtNombre.Text,
                };

                if (metodoPagosService.ModificarMetodo(metodo))
                {
                    MessageBox.Show("Metodo modificado con éxito.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al modificar el metodo.");
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

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
