using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;

namespace ProyectoFinal
{
    public partial class Crearusuario : UserControl
    {
        public Crearusuario()
        {
            InitializeComponent();
        }

        private void Crearusuario_Load(object sender, EventArgs e)
        {
           
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (txtPassword1.Text.Length >= 5)
            {
                if (txtPassword1.Text == txtConfirmPass1.Text)
                {
                    
                    
                        var UserModel = new UserModel(
                  
                             
                            loginName: txtUsuario1.Text,
                            password: txtPassword1.Text,
                            firstName: txtNombre1.Text,
                            lastName: txtApellido1.Text,
                            position: null,
                            email: txtEmail1.Text);
                           
                        var result = UserModel.insertarusuario();
                        MessageBox.Show(result);
                       

                  

                }
                else MessageBox.Show("Las contraseñas no coinsiden /n Por favor intente de nuevo");

            }
            else
                MessageBox.Show("La contraseñas debe ser mayor a 5 digitos ");
        }
    }

    

}
