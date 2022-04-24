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
using Capa_Negocio;

namespace ProyectoFinal
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            Application.Exit();
        }

        private void txt_user_Enter(object sender, EventArgs e)
        {
            if(txtuser.Text == "Usuario") {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;



            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Usuario";
                txtuser.ForeColor = Color.LightGray;



            }

        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
             if( txtpass.Text == "Contraseña") {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;

            }

        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Contraseña";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = false;

            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtuser.Text != "Usuario")
            {

                if (txtpass.Text != "Contraseña")
                {
                    UserModel user = new UserModel();
                    var validLogin = user.LoginUser(txtuser.Text, txtpass.Text);

                    if(validLogin== true)
                    {
                        VentanaPrincipal mainMenu = new VentanaPrincipal();
                        mainMenu.Show();
                        mainMenu.FormClosed += Logout;
                        this.Hide();
                    }
                    else msgError("Usuario o contraseña incorrecto ");
                    txtpass.Text = "Contraseña";
                    txtpass.UseSystemPasswordChar = false;
                    txtuser.Focus();

                }
                else msgError("Por favor ingrese la Contraseña");


            }
            else msgError("Por favor ingrese el Usuario");



        }
        private void msgError(string msg)
        {
            lblErrorMessage.Text = "   " + msg;
            lblErrorMessage.Visible = true;

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtpass.Text = "Contraseña";
            txtpass.UseSystemPasswordChar = false;
            txtuser.Text = "Usuario";
            lblErrorMessage.Visible = false;
            this.Show();
            txtuser.Focus();
        }

        private void lblErrorMessage_Click(object sender, EventArgs e)
        {

        }
    }
}
