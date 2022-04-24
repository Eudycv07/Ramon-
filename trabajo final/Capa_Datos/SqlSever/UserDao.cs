using System.Data.SqlClient;
using System.Data;
using Capa_Entidad;
using Capa_Entidad.Cache;



namespace Capa_Datos
{
    public class UserDao: ConnectionToSql
    {
        public bool Login(string user, string pass)
        {
            using(var connection= GetConnection())
            {
                connection.Open();
                using(var command = new SqlCommand()) {
                    command.Connection = connection;
                    command.CommandText = ("SP_Login");
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@Pass", pass);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            UserLoginCache.idUser = reader.GetInt32(0);
                            UserLoginCache.LoginName = reader.GetString(1);
                            UserLoginCache.Password = reader.GetString(2);
                            UserLoginCache.FirstName = reader.GetString(3);
                            UserLoginCache.LastName = reader.GetString(4);
                            UserLoginCache.Position = reader.GetString(5);
                            UserLoginCache.Email = reader.GetString(6);


                        }
                        return true;
                    }
                    else
                        return false;


                }
            }
        }

        public void editProfile(int id, string userName, string password, string name, string lastName, string email)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = ("SP_actualizar");
                    command.Parameters.AddWithValue("@userName", userName);
                    command.Parameters.AddWithValue("@Pass", password);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@mail",email);
                    command.Parameters.AddWithValue("@id", id);

                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                }
            }
        }
        public void insertarusuario(string userName, string password, string name, string lastName, string email, string Posicion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    
                    command.CommandText = ("SP_insertar");
                    command.Parameters.AddWithValue("@userName", userName);
                    command.Parameters.AddWithValue("@Pass", password);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@mail", email);
                    command.Parameters.AddWithValue("@Position", Posicion);



                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();


                  

                }
            }
        }
        public void privilegio()
        {
            if (UserLoginCache.Position == Cargo.Administrador)
            {

            }
            if(UserLoginCache.Position == Cargo.CFO || UserLoginCache.Position == Cargo.Manager)
            {

            }
            
        }
    }

}
