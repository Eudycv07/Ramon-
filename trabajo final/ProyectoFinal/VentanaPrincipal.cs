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
using Capa_Entidad;
using Capa_Entidad.Cache;

namespace ProyectoFinal
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
            Sidepanel.Height = button1.Height;
            Sidepanel.Top = button1.Top;
            crearusuario1.Visible = false;
            visita1.Visible = false;
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void button1_Click(object sender, EventArgs e)
        {
            visita1.Visible = false;
            crearusuario1.Visible = false;
            Sidepanel.Height = button1.Height;
            Sidepanel.Top = button1.Top;
            



        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            visita1.Visible = false;
            crearusuario1.Visible = true;
            Sidepanel.Height = button2.Height;
            Sidepanel.Top = button2.Top;
            crearusuario1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            visita1.Visible = true;
            crearusuario1.Visible = false;
            Sidepanel.Height = button3.Height;
            Sidepanel.Top = button3.Top;
            visita1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            visita1.Visible = false;
            Sidepanel.Height = button4.Height;
            Sidepanel.Top = button4.Top;
        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            Loaduserdata();
            //Privilegio de usuario//
            privilegios();


        }
        private void Loaduserdata()
        {
            lblNombre.Text = UserLoginCache.FirstName + " " + UserLoginCache.LastName;
            lblPosicion.Text = UserLoginCache.Position;
            lblEmail.Text = UserLoginCache.Email;
        }

        private void VentanaPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Esta seguro que desea salir?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }
        private void privilegios()
        {
            if (UserLoginCache.Position == Cargo.Administrador)
            {
               
            }
            if (UserLoginCache.Position == Cargo.CFO || UserLoginCache.Position == Cargo.Manager)
            {
                button4.Visible = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormperfilUsuario mainMenu = new FormperfilUsuario();
            mainMenu.Show();
        }

        private void crearusuario1_Load(object sender, EventArgs e)
        {

        }

        private void visita1_Load(object sender, EventArgs e)
        {

        }
    }
}
