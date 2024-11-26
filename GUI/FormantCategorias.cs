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
    public partial class FormantCategorias : Form
    {
        CategoriaService categoriasService;
        public FormantCategorias()
        {
            InitializeComponent();
            categoriasService = new CategoriaService();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validar()
        {
            if (!string.IsNullOrEmpty(txtID.Text) && !Regex.IsMatch(txtID.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$") && txtID.Text.Length > 5)
            {
                MessageBox.Show("El ID debe contener solo letras y menos a 5 caracteres.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtNombre.Text) && !Regex.IsMatch(txtNombre.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$") && txtNombre.Text.Length > 50)
            {
                MessageBox.Show("El segundo nombre debe contener solo letras y menor a 50 caracteres.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private void Limpiar()
        {
            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(Validar() && Guardar())
            {
                MessageBox.Show("Nueva categoria guardada correctamente");
                Limpiar(); 
            }
            else
            {
                MessageBox.Show("Ah ocurrido un error al guardar la categoria"); 
            }
        }

        private bool Guardar()
        {
            try
            {
                Categoria categoria = new Categoria
                {
                    IDCategoria = txtID.Text,
                    NombreCategoria = txtNombre.Text,
                };

                if (categoriasService.GuardarCategoria(categoria))
                {
                    MessageBox.Show("Categoria guardado con éxito.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al guardar la categoria.");
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Validar() && Modificar())
            {
                MessageBox.Show("Categoria modificada exitosamente");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Ah ocurrido un error al modificar la categoria"); 
            }
        }

        private bool Modificar()
        {
            try
            {
                Categoria categoria = new Categoria 
                {
                    IDCategoria = txtID.Text,
                    NombreCategoria = txtNombre.Text,
                };

                if (categoriasService.ModificarCatgoria(categoria))
                {
                    MessageBox.Show("Categoria modificada con éxito.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al modificar la categoria.");
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
