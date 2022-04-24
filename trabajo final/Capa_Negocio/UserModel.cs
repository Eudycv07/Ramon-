using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad.Cache;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class UserModel
    {
        UserDao userDao = new UserDao();

        //Atributos 
        private int idUser;
        private string loginName;
        private string password;
        private string firstName;
        private string lastName;
        private string position;
        private string email;
        private string Position;
        private object position1;

        public UserModel(int idUser, string loginName, string password, string firstName, string lastName, string position, string email)
        {
            this.idUser = idUser;
            this.loginName = loginName;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.position = position;
            this.email = email;
            
        }

      

        public UserModel()
        {

        }

        public UserModel(string loginName, string password, string firstName, string lastName, object position, string email)
        {
            this.loginName = loginName;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            position1 = position;
            this.email = email;
        }

        public string insertarusuario()
        {

            try
            {
                userDao.insertarusuario(loginName, password, firstName, lastName, email, Position);

                return "El usuario se agrego con exito";
            }
            catch (Exception ex)
            {
                return "El nombre de usuario ya existe, por favor intente con otro ";

            }

        }
        public string ediUserProfile()
        {
            
            try {
                userDao.editProfile(idUser, loginName, password, firstName, lastName, email);
                LoginUser(loginName, password);
                return "El usuario actualizado con exito";
            } 
            catch(Exception ex)
            {
                return "El nombre de usuario ya existe, por favor intente con otro ";
 
            }
        }

        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }
        public void privilegio()
        {
            if (UserLoginCache.Position == Cargo.Administrador)
            {
                button4.
            }
            if (UserLoginCache.Position == Cargo.CFO || UserLoginCache.Position == Cargo.Manager)
            {

            }
            
        }
    }
}
