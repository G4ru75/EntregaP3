using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GUI
{
    public partial class gui : Form
    {
        private int borderSize = 2;
        public gui()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint ="SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void btnslide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else 
                MenuVertical.Width = 250;
        }

        int lx, ly;
        int sw, sh;
        private void iconcerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            iconmaximizar.Visible = false;
            iconrestaurar.Visible = true;
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            iconrestaurar.Visible = false;
            iconmaximizar.Visible = true;

        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012,0);
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);

            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();
        }

       

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnproducto_Click(object sender, EventArgs e)
        {

            FormListaProductos frm = new FormListaProductos();
            frm.FormClosed += new FormClosedEventHandler(MostrarLogoAlcerrarForm);
            AbrirFormInPanel(frm);
        }

        


        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        private void MostrarLogo()
        {
            AbrirFormInPanel(new FormLogo());
        }

        private void MostrarLogoAlcerrarForm(object sender, FormClosedEventArgs e)
        {
            MostrarLogo();
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void gui_Load(object sender, EventArgs e)
        {
            MostrarLogo();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormPagos pagos = new FormPagos();
            AbrirFormInPanel(pagos);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void submenuregistrarventa_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormVentas());
        }

        private void submenuverdetalleventa_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormDetalleVenta());
        }

        private void submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            FormCompras frm = new FormCompras();
            frm.FormClosed += new FormClosedEventHandler(MostrarLogoAlcerrarForm);
            AbrirFormInPanel(frm);
        }

        private void submenuverdetallecompra_Click(object sender, EventArgs e)
        {
            FormDetalleCompra frm = new FormDetalleCompra();
            frm.FormClosed += new FormClosedEventHandler(MostrarLogoAlcerrarForm);
            AbrirFormInPanel(frm);
        }

        private void MenuCompras_Click(object sender, EventArgs e)
        {

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FormListaCategorias frm = new FormListaCategorias();
            AbrirFormInPanel(frm);        
        }

        private void btnListaProveedores_Click(object sender, EventArgs e)
        {
            FormListaProveedores frm = new FormListaProveedores ();
            frm.FormClosed += new FormClosedEventHandler(MostrarLogoAlcerrarForm);
            AbrirFormInPanel(frm);
        }
        protected override void WndProc(ref Message msj)
        {
            const int CoordenadaWFP = 0x84; //ubicacion de la parte derecha inferior del form
            const int DesIzquierda = 16;
            const int DesDerecha = 17;
            if (msj.Msg == CoordenadaWFP)
            {
                int x = (int)(msj.LParam.ToInt64() & 0xFFFF);
                int y = (int)((msj.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point CoordenadaArea = PointToClient(new Point(x, y));
                Size TamañoAreaForm = ClientSize;
                if (CoordenadaArea.X >= TamañoAreaForm.Width - 16 &&
                    CoordenadaArea.Y >= TamañoAreaForm.Height - 16 &&
                    TamañoAreaForm.Height >= 16)
                {
                    msj.Result = (IntPtr)(IsMirrored ? DesIzquierda : DesDerecha);
                    return;
                }
            }
            base.WndProc(ref msj);
        }


    }
}
