using SistemaCheques.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaCheques.Models.Datos
{
    public class ProveedoresDatos
    {
        // Para mostrar los datos
        public List<ProveedoresModel> Listar()
        {

            var Lista = new List<ProveedoresModel>();

            var conexion = new Conexion();

            // creando la cadena de conexion a SQL
            using (var connection = new SqlConnection(conexion.getCadenaSQL()))

            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarProveedores", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                // leer el resultado del sp_Listar (Procedimiento del CRUD en la DB)

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new ProveedoresModel()
                        {
                            idProveedor = Convert.ToInt32(dr["idProveedor"]),
                            Nombre = dr["Nombre"].ToString(),
                            TipoPersona = dr["TipoPersona"].ToString(),
                            Cedula = dr["Cedula"].ToString(),
                            Balance = Convert.ToDecimal(dr["Balance"]),
                            CuentaContable = Convert.ToInt32(dr["CuentaContable"]),
                            Estado = dr["Estado"].ToString()
                        });
                    }
                }
            }

            return Lista;
        }

        // Para obtener los datos
        public ProveedoresModel Obtener(int idProveedor)
        {
            // instancia de la conexion a la DB

            var Proveedores = new ProveedoresModel();

            var conexion = new Conexion();

            // creando la cadena de conexion a SQL
            using (var connection = new SqlConnection(conexion.getCadenaSQL()))

            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerProveedores", connection);
                cmd.Parameters.AddWithValue("idProveedor", idProveedor);
                cmd.CommandType = CommandType.StoredProcedure;

                // leer el resultado del sp_Obtener (Procedimiento del CRUD en la DB)

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())

                    {
                        Proveedores.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                        Proveedores.Nombre = dr["Nombre"].ToString();
                        Proveedores.TipoPersona = dr["TipoPersona"].ToString();
                        Proveedores.Cedula = dr["Cedula"].ToString();
                        Proveedores.Balance = Convert.ToDecimal(dr["Balance"]);
                        Proveedores.CuentaContable = Convert.ToInt32(dr["CuentaContable"]);
                        Proveedores.Estado = dr["Estado"].ToString();
                    }
                }
            }

            return Proveedores;
        }

        // Para el guardado de los datos 
        public bool Guardar(ProveedoresModel Proveedores)
        {
            // Se crea como boolean para la validacion segun la DB

            bool respuesta;

            try
            {
                // intancia de la conexion a la DB

                var conexion = new Conexion();

                using (var connection = new SqlConnection(conexion.getCadenaSQL()))

                {
                    connection.Open();
                    // leer el resultado del sp_Guardar (Procedimiento del CRUD en la DB)
                    SqlCommand cmd = new SqlCommand("sp_GuardarProveedores", connection);
                    //cmd.Parameters.AddWithValue("idConceptoPago", conceptoPago.idConceptoPago);
                    cmd.Parameters.AddWithValue("Nombre", Proveedores.Nombre);
                    cmd.Parameters.AddWithValue("TipoPersona", Proveedores.TipoPersona);
                    cmd.Parameters.AddWithValue("Cedula", Proveedores.Cedula);
                    cmd.Parameters.AddWithValue("Balance", Proveedores.Balance);
                    cmd.Parameters.AddWithValue("CuentaContable", Proveedores.CuentaContable);
                    cmd.Parameters.AddWithValue("Estado", Proveedores.Estado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                // En caso de que la validacion se realice correctamente

                respuesta = true;
            }
            // En caso de haber algun error 
            catch (Exception ex)

            {
                String error = ex.Message; // Mensaje de error
                respuesta = false;
            }

            return respuesta;
        }

        // Actualizar los datos
        public bool Editar(ProveedoresModel Proveedores)

        {
            // Se crea como boolean para la validacion segun la DB

            bool respuesta;

            try
            {
                // intancia de la conexion a la DB

                var conexion = new Conexion();

                using (var connection = new SqlConnection(conexion.getCadenaSQL()))

                {
                    connection.Open();
                    // leer el resultado del sp_Editar (Procedimiento del CRUD en la DB)
                    SqlCommand cmd = new SqlCommand("sp_EditarProveedores", connection);
                    cmd.Parameters.AddWithValue("idProveedor", Proveedores.idProveedor);
                    cmd.Parameters.AddWithValue("Nombre", Proveedores.Nombre);
                    cmd.Parameters.AddWithValue("TipoPersona", Proveedores.TipoPersona);
                    cmd.Parameters.AddWithValue("Cedula", Proveedores.Cedula);
                    cmd.Parameters.AddWithValue("Balance", Proveedores.Balance);
                    cmd.Parameters.AddWithValue("CuentaContable", Proveedores.CuentaContable);
                    cmd.Parameters.AddWithValue("Estado", Proveedores.Estado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                // En caso de que la validacion se realice correctamente

                respuesta = true;
            }
            // En caso de haber algun error 
            catch (Exception ex)

            {
                String error = ex.Message; // Mensaje de error
                respuesta = false;
            }

            return respuesta;
        }

        // Eliminar los datos
        public bool Eliminar(int idProveedor)

        {
            // Se crea como boolean para la validacion segun la DB

            bool respuesta;

            try
            {
                // intancia de la conexion a la DB

                var conexion = new Conexion();

                using (var connection = new SqlConnection(conexion.getCadenaSQL()))

                {
                    connection.Open();
                    // leer el resultado del sp_Eliminar (Procedimiento del CRUD en la DB)
                    SqlCommand cmd = new SqlCommand("sp_EliminarConceptoPago", connection);
                    cmd.Parameters.AddWithValue("idProveedor", idProveedor);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                // En caso de que la validacion se realice correctamente

                respuesta = true;
            }
            // En caso de haber algun error 
            catch (Exception ex)

            {
                String error = ex.Message; // Mensaje de error
                respuesta = false;
            }

            return respuesta;
        }

    }
}
