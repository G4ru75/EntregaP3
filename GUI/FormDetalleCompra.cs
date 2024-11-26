using ENTITY;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
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
using iText.Layout;
using System.IO;
using iText.Bouncycastle;
using iText.Bouncycastleconnector;

namespace GUI
{
    public partial class FormDetalleCompra : Form
    {
        MetodoPagosService PagosService;
        DetalleComprasService DetallesService; 
        public FormDetalleCompra()
        {
            InitializeComponent();
            PagosService = new MetodoPagosService();
            DetallesService = new DetalleComprasService();
            //CargarPagos();
            CargarDatos();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void CargarPagos()
        //{
        //    List<MetodoPagos> Pagos = PagosService.ObtenerPagos();
        //    cboPagos.DataSource = Pagos;
        //    cboPagos.DisplayMember = "NombreMetodo";
        //    cboPagos.ValueMember = "IDPago";
        //}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CargarDatos()
        {
            List<DetalleCompras> Detalles = DetallesService.ObtenerDetalles();
            dgvTablaDetallesCompra.AutoGenerateColumns = false;

            dgvTablaDetallesCompra.Columns["NumeroCompra"].DataPropertyName = "NumeroCompra";
            dgvTablaDetallesCompra.Columns["IDProveedor"].DataPropertyName = "IDProveedor";
            dgvTablaDetallesCompra.Columns["NombreProveedor"].DataPropertyName = "NombreProveedor";
            dgvTablaDetallesCompra.Columns["ApellidoProveedor"].DataPropertyName = "ApellidoProveedor";
            dgvTablaDetallesCompra.Columns["Producto"].DataPropertyName = "NombreProducto";
            dgvTablaDetallesCompra.Columns["Cantidad"].DataPropertyName = "Cantidad";
            dgvTablaDetallesCompra.Columns["Precio"].DataPropertyName = "Precio";
            dgvTablaDetallesCompra.Columns["Total"].DataPropertyName = "Total";
            dgvTablaDetallesCompra.Columns["MetodoPago"].DataPropertyName = "MetodoPago";

            dgvTablaDetallesCompra.DataSource = Detalles; 
        }

        private void dgvTablaDetallesCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCrearPDF_Click(object sender, EventArgs e)
        {
            if (dgvTablaDetallesCompra.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una fila para exportar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf",
                Title = "Guardar Detalle de Venta",
                FileName = "DetalleCompra.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var writer = new PdfWriter(saveFileDialog.FileName))
                    using (var pdf = new PdfDocument(writer))
                    using (var document = new Document(pdf, PageSize.A4.Rotate())) // Formato horizontal
                    {
                        document.SetMargins(20, 20, 20, 20);

                        // Título
                        var boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                        document.Add(new Paragraph("__________Detalle de Compra__________\n")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(16)
                            .SetFont(boldFont)
                            .SetMarginBottom(20));

                        var normalfont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                        document.Add(new Paragraph("Detalle de compras hecha por el negocio rico aroma a los proveedores registrados por el negocio")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(14)
                            .SetFont(boldFont)
                            .SetMarginBottom(20));

                        // Crear tabla
                        Table table = new Table(dgvTablaDetallesCompra.Columns.Count);
                        table.SetWidth(UnitValue.CreatePercentValue(100));

                        // Estilo para encabezados
                        Cell headerCell = new Cell()
                            .SetBackgroundColor(new DeviceRgb(210, 210, 210))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetPadding(5)
                            .SetFont(boldFont);

                        // Agregar encabezados
                        foreach (DataGridViewColumn column in dgvTablaDetallesCompra.Columns)
                        {
                            table.AddCell(headerCell.Clone(true)
                                .Add(new Paragraph(column.HeaderText)));
                        }

                        // Estilo para celdas de contenido
                        var normalFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                        Cell contentCell = new Cell()
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetPadding(5)
                            .SetFont(normalFont);

                        // Agregar datos de la fila seleccionada
                        DataGridViewRow filaSeleccionada = dgvTablaDetallesCompra.SelectedRows[0];
                        foreach (DataGridViewCell cell in filaSeleccionada.Cells)
                        {
                            string valor = cell.Value?.ToString() ?? "";

                            // Formato especial según el tipo de dato
                            if (cell.ValueType == typeof(decimal) || cell.ValueType == typeof(double))
                            {
                                if (decimal.TryParse(valor, out decimal numericValue))
                                {
                                    valor = numericValue.ToString("C2");
                                }
                            }
                            else if (cell.ValueType == typeof(DateTime))
                            {
                                if (DateTime.TryParse(valor, out DateTime dateValue))
                                {
                                    valor = dateValue.ToString("dd/MM/yyyy");
                                }
                            }

                            table.AddCell(contentCell.Clone(true)
                                .Add(new Paragraph(valor)));
                        }

                        document.Add(table);

                        //Informacion despues de la tabla
                        document.Add(new Paragraph($"Documento generado el {DateTime.Now:dd/MM/yyyy HH:mm:ss}" +
                                                    $"\n \n Por el negocio Rico Aroma ubicado en el mercado de valledpar\n \n" +
                                                    $"Dueño: Ciro Peñuela ")
                            .SetTextAlignment(TextAlignment.JUSTIFIED)
                            .SetFontSize(10)
                            .SetFont(normalFont)
                            .SetMarginTop(10));
                    }

                    MessageBox.Show("PDF creado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("¿Desea abrir el PDF?", "Confirmación",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveFileDialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al crear el PDF: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
