using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad.Cache;
using System.Runtime.InteropServices;
using Capa_Entidad;
using Capa_Negocio;

namespace ProyectoFinal
{
    public partial class FormperfilUsuario : Form
    {
        public FormperfilUsuario()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            editarperfil.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            editarperfil.Visible = false;
            Datosdeusuario();
        }

        private void FormperfilUsuario_Load(object sender, EventArgs e)
        {
            Datosdeusuario();
            passEdit();
        }
         private void Datosdeusuario()
        {
             //ver
            lblUsuario.Text = UserLoginCache.LoginName;
            lblNombre.Text = UserLoginCache.FirstName;
            lblApellido.Text= UserLoginCache.LastName;
            lblEmail.Text = UserLoginCache.Email;
            lblPosicion.Text = UserLoginCache.Position;

            //editar perfil 

            txtUsuario.Text = UserLoginCache.LoginName;
            txtNombre.Text = UserLoginCache.FirstName;
            txtApellido.Text = UserLoginCache.LastName;
            txtEmail.Text = UserLoginCache.Email;
            txtPassword.Text = UserLoginCache.Password;
            txtConfirmPass.Text = UserLoginCache.Password;
            txtCurrentPassword.Text = "";

        }

        private void passEdit()
        {
            LinkEditPass.Text = "Editar";
            txtPassword.Enabled = false;
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPass.Enabled = false;
            txtConfirmPass.UseSystemPasswordChar = true;


        }

        private void reset()
        {
            Datosdeusuario();
            passEdit();

        }

        private void LinkEditPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LinkEditPass.Text == "Editar")
            {
                LinkEditPass.Text = "Cancel";
                txtPassword.Enabled = true;
                txtPassword.Text = "";
                txtConfirmPass.Enabled = true;
                txtConfirmPass.Text = "";
            

            }
            else if (LinkEditPass.Text == "Cancel")

            {
                reset();
            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length >= 5)
            {
                if (txtPassword.Text == txtConfirmPass.Text)
                {
                    if (txtCurrentPassword.Text == UserLoginCache.Password)
                    {
                        var UserModel = new UserModel(
                            idUser: UserLoginCache.idUser,
                            loginName: txtUsuario.Text,
                            password: txtPassword.Text,
                            firstName: txtNombre.Text,
                            lastName: txtApellido.Text,
                            position: null,
                            email: txtEmail.Text);
                        var result = UserModel.ediUserProfile();
                        MessageBox.Show(result);
                        reset();
                        editarperfil.Visible = false;


                    }else
                    MessageBox.Show("Usted ha ingresado una contraseña incorrecta /n Por favor intente de nuevo");


                }else
                MessageBox.Show("Las contraseñas no coinsiden /n Por favor intente de nuevo");

            }else
            MessageBox.Show("La contraseñas debe ser mayor a 5 digitos ");
        }

        private void FormperfilUsuario_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void editarperfil_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void editarperfil_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
