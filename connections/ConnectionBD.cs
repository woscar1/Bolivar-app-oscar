using API.Entities;
using Microsoft.Data.SqlClient;

namespace API.connectionsBD
{
    public class ConnectionBD
    {
        private readonly ILogger<ConnectionBD> _logger;

        public ConnectionBD(ILogger<ConnectionBD> logger)
        {
            _logger = logger;
        }

        public static string cadena = "Data Source=Casa;Initial Catalog=Estudio; integrated security=True; TrustServerCertificate=True";
       
        /// <summary>
        /// conexion a la base de datos
        /// </summary>
        /// <param name="query">consulta de bd</param>
        /// <returns></returns>
        public static List<Users> conexionBD(string query)
        {
            var user = new List<Users>();
            
            using(SqlConnection cnx = new SqlConnection(cadena))
            {
                
                using (SqlCommand command = new SqlCommand(query, cnx))
                {
                    cnx.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var datos = new Users
                            {
                                Id = dataReader.GetInt32(0),
                                Nombre = dataReader.GetString(1),
                                Password = dataReader.GetString(2)
                            };

                            user.Add(datos);
                        }
                        return user;
                    }
                }
            }
        }

    }
}