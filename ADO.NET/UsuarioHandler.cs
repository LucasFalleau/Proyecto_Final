using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioEntregable
{
    public class UsuarioHandler : DbHandler
    {
        public List<Usuario> GetUsuarios(string nombreUsuario, string contraseña)
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contraseña";

                    sqlCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    sqlCommand.Parameters.AddWithValue("@contraseña", contraseña);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    sqlConnection.Close();

                    foreach (DataRow oDr in table.Rows)
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(oDr["Id"]);
                        usuario.Nombre = oDr["Nombre"]?.ToString();
                        usuario.Apellido = oDr["Apellido"]?.ToString();
                        usuario.NombreUsuario = oDr["NombreUsuario"]?.ToString();
                        usuario.Contraseña = oDr["Contraseña"]?.ToString();
                        usuario.Mail = oDr["Mail"]?.ToString();

                        usuarios.Add(usuario);
                    }
                }
            }

            return usuarios;
        }
    }
}
