using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioEntregable
{
    public class ProductoVendidoHandler : DbHandler
    {
        public List<ProductoVendido> GetProductosVendidos()
        {
            List<ProductoVendido>productosvendidos = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM ProductoVendido", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productovendido = new ProductoVendido();

                                productovendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productovendido.Stock = Convert.ToInt32(dataReader["Id"]);
                                productovendido.IdProducto = Convert.ToInt32(dataReader["Id"]);
                                productovendido.IdVenta = Convert.ToInt32(dataReader["Id"]);

                                productosvendidos.Add(productovendido);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return productosvendidos;
        }
    }
}
