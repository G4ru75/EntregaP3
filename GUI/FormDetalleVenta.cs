using DAL;
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
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Layout.Properties;
using System.IO;
using iText.Bouncycastle;
using iText.Bouncycastleconnector;


namespace GUI
{
    public partial class FormDetalleVenta : Form
    {
        MetodoPagosService PagosService;
        DetallesVentasService DetallesVentasService;
        public FormDetalleVenta()
        {
            InitializeComponent();
            PagosService = new MetodoPagosService();
            DetallesVentasService = new DetallesVentasService();
            //CargarPagos();
            CargarDatos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CargarPagos()
        {
            //List<MetodoPagos> Pagos = PagosService.ObtenerPagos();
            //cboPagos.DataSource = Pagos;
            //cboPagos.DisplayMember = "NombreMetodo";
            //cboPagos.ValueMember = "IDPago";
        }

        private void CargarDatos()
        {
            List<DetallesVentas> Detalles = DetallesVentasService.ObtenerDetallesVentas();
            dgvTablaDetallesVentas.AutoGenerateColumns = false;

            dgvTablaDetallesVentas.Columns["IDVenta"].DataPropertyName = "IDVenta";
            dgvTablaDetallesVentas.Columns["NombreProducto"].DataPropertyName = "NombreProducto";
            dgvTablaDetallesVentas.Columns["CantidadLibras"].DataPropertyName = "CantidadLibras";
            dgvTablaDetallesVentas.Columns["PrecioLibra"].DataPropertyName = "PrecioLibra";
            dgvTablaDetallesVentas.Columns["TotalVenta"].DataPropertyName = "TotalVenta";
            dgvTablaDetallesVentas.Columns["Monto"].DataPropertyName = "Monto";
            dgvTablaDetallesVentas.Columns["Vueltos"].DataPropertyName = "Vueltos";
            dgvTablaDetallesVentas.Columns["NombreCliente"].DataPropertyName = "NombreCliente";
            dgvTablaDetallesVentas.Columns["ApellidoCliente"].DataPropertyName = "ApellidoCliente";
            dgvTablaDetallesVentas.Columns["FechaFactura"].DataPropertyName = "FechaFactura";
            dgvTablaDetallesVentas.Columns["MetodoDePago"].DataPropertyName = "MetodoDePago";
            //dgvTablaDetallesVentas.Columns["IDFactura"].DataPropertyName = "IDFactura";

            dgvTablaDetallesVentas.DataSource = Detalles;
        }

        private void btnDescargaPDF_Click(object sender, EventArgs e)
        {
            if (dgvTablaDetallesVentas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una fila para exportar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf",
                Title = "Guardar Detalle de Venta",
                FileName = "DetalleVenta.pdf"
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
                        document.Add(new Paragraph("..........Detalle de Venta..........\n")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(16)
                            .SetFont(boldFont)
                            .SetMarginBottom(20));

                        var normalfont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                        document.Add(new Paragraph("Detalle de venta hecha por el negocio rico aroma")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(14)
                            .SetFont(boldFont)
                            .SetMarginBottom(20));

                        // Crear tabla
                        Table table = new Table(dgvTablaDetallesVentas.Columns.Count);
                        table.SetWidth(UnitValue.CreatePercentValue(100));

                        // Estilo para encabezados
                        Cell headerCell = new Cell()
                            .SetBackgroundColor(new DeviceRgb(210, 210, 210))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetPadding(5)
                            .SetFont(boldFont);

                        // Agregar encabezados
                        foreach (DataGridViewColumn column in dgvTablaDetallesVentas.Columns)
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
                        DataGridViewRow filaSeleccionada = dgvTablaDetallesVentas.SelectedRows[0];
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

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
 }

