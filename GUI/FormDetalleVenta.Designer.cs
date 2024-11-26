namespace GUI
{
    partial class FormDetalleVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetalleVenta));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTablaDetallesVentas = new System.Windows.Forms.DataGridView();
            this.IDVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadLibras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioLibra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vueltos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MetodoDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDescargaPDF = new FontAwesome.Sharp.IconButton();
            this.BtnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaDetallesVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1323, 589);
            this.label1.TabIndex = 3;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Detalle Venta";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvTablaDetallesVentas
            // 
            this.dgvTablaDetallesVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTablaDetallesVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTablaDetallesVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTablaDetallesVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaDetallesVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDVenta,
            this.NombreProducto,
            this.CantidadLibras,
            this.PrecioLibra,
            this.TotalVenta,
            this.Monto,
            this.Vueltos,
            this.NombreCliente,
            this.ApellidoCliente,
            this.FechaFactura,
            this.MetodoDePago});
            this.dgvTablaDetallesVentas.Location = new System.Drawing.Point(12, 103);
            this.dgvTablaDetallesVentas.Name = "dgvTablaDetallesVentas";
            this.dgvTablaDetallesVentas.RowHeadersWidth = 51;
            this.dgvTablaDetallesVentas.RowTemplate.Height = 24;
            this.dgvTablaDetallesVentas.Size = new System.Drawing.Size(1272, 341);
            this.dgvTablaDetallesVentas.TabIndex = 11;
            // 
            // IDVenta
            // 
            this.IDVenta.HeaderText = "N-Compra";
            this.IDVenta.MinimumWidth = 6;
            this.IDVenta.Name = "IDVenta";
            // 
            // NombreProducto
            // 
            this.NombreProducto.HeaderText = "Producto";
            this.NombreProducto.MinimumWidth = 6;
            this.NombreProducto.Name = "NombreProducto";
            // 
            // CantidadLibras
            // 
            this.CantidadLibras.HeaderText = "Cantidad";
            this.CantidadLibras.MinimumWidth = 6;
            this.CantidadLibras.Name = "CantidadLibras";
            // 
            // PrecioLibra
            // 
            this.PrecioLibra.HeaderText = "Precio";
            this.PrecioLibra.MinimumWidth = 6;
            this.PrecioLibra.Name = "PrecioLibra";
            // 
            // TotalVenta
            // 
            this.TotalVenta.HeaderText = "Total";
            this.TotalVenta.MinimumWidth = 6;
            this.TotalVenta.Name = "TotalVenta";
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.MinimumWidth = 6;
            this.Monto.Name = "Monto";
            // 
            // Vueltos
            // 
            this.Vueltos.HeaderText = "Vueltos";
            this.Vueltos.MinimumWidth = 6;
            this.Vueltos.Name = "Vueltos";
            // 
            // NombreCliente
            // 
            this.NombreCliente.HeaderText = "Nombre";
            this.NombreCliente.MinimumWidth = 6;
            this.NombreCliente.Name = "NombreCliente";
            // 
            // ApellidoCliente
            // 
            this.ApellidoCliente.HeaderText = "Apellido";
            this.ApellidoCliente.MinimumWidth = 6;
            this.ApellidoCliente.Name = "ApellidoCliente";
            // 
            // FechaFactura
            // 
            this.FechaFactura.HeaderText = "Fecha";
            this.FechaFactura.MinimumWidth = 6;
            this.FechaFactura.Name = "FechaFactura";
            // 
            // MetodoDePago
            // 
            this.MetodoDePago.HeaderText = "Forma de pago";
            this.MetodoDePago.MinimumWidth = 6;
            this.MetodoDePago.Name = "MetodoDePago";
            // 
            // btnDescargaPDF
            // 
            this.btnDescargaPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDescargaPDF.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnDescargaPDF.IconChar = FontAwesome.Sharp.IconChar.FileArchive;
            this.btnDescargaPDF.IconColor = System.Drawing.Color.Black;
            this.btnDescargaPDF.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDescargaPDF.IconSize = 20;
            this.btnDescargaPDF.Location = new System.Drawing.Point(1119, 504);
            this.btnDescargaPDF.Name = "btnDescargaPDF";
            this.btnDescargaPDF.Size = new System.Drawing.Size(151, 45);
            this.btnDescargaPDF.TabIndex = 18;
            this.btnDescargaPDF.Text = "Descargar PDF";
            this.btnDescargaPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDescargaPDF.UseVisualStyleBackColor = false;
            this.btnDescargaPDF.Click += new System.EventHandler(this.btnDescargaPDF_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrar.FlatAppearance.BorderSize = 0;
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BtnCerrar.Image")));
            this.BtnCerrar.Location = new System.Drawing.Point(13, 54);
            this.BtnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(32, 28);
            this.BtnCerrar.TabIndex = 19;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // FormDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1296, 740);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.btnDescargaPDF);
            this.Controls.Add(this.dgvTablaDetallesVentas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDetalleVenta";
            this.Text = "FormDetalleVenta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaDetallesVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTablaDetallesVentas;
        private FontAwesome.Sharp.IconButton btnDescargaPDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadLibras;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioLibra;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vueltos;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn MetodoDePago;
        private System.Windows.Forms.Button BtnCerrar;
    }
}