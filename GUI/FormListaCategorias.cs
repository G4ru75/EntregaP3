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
    public partial class FormListaCategorias : Form
    {
        CategoriaService categoriaService;
        public FormListaCategorias()
        {
            InitializeComponent();
            categoriaService  = new CategoriaService();
            CargarDatos(); 
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormantCategorias formantCategorias = new FormantCategorias();
            formantCategorias.ShowDialog();
        }

        private void CargarDatos()
        {
            List<Categoria> categorias = categoriaService.ObtenerCategorias();
            dgvTablaCategorias.AutoGenerateColumns = false;

            dgvTablaCategorias.Columns["IDCategoria"].DataPropertyName = "IDCategoria";
            dgvTablaCategorias.Columns["NombreCategoria"].DataPropertyName = "NombreCategoria";

            dgvTablaCategorias.DataSource = categorias;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Insertar();
        }

        private void Insertar()
        {
            FormantCategorias formant = new FormantCategorias();
            if (dgvTablaCategorias.SelectedRows.Count > 0)
            {
                formant.txtID.Text = dgvTablaCategorias.CurrentRow.Cells[0].Value.ToString();
                formant.txtNombre.Text = dgvTablaCategorias.CurrentRow.Cells[1].Value.ToString();

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

                if (dgvTablaCategorias.SelectedRows.Count > 0)
                {

                    string idcategoria = Convert.ToString(dgvTablaCategorias.SelectedRows[0].Cells["IDCategoria"].Value); //Consigo el id del pago desde la lista

                    //Primero confirmo de que si se se esta seguro de eliminar a el proveedor
                    DialogResult resultado = MessageBox.Show($"¿Está seguro de que desea eliminar este proveedor {idcategoria}?", "Confirmación de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                    if (resultado == DialogResult.Yes)
                    {
                        if (categoriaService.Eliminar(idcategoria))
                        {
                            MessageBox.Show("La categoria ha sido eliminado exitosamente");
                            CargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("Ah ocurrido un error al eliminar la categoria");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la categoria.");
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

        private void FormListaCategorias_Load(object sender, EventArgs e)
        {

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
