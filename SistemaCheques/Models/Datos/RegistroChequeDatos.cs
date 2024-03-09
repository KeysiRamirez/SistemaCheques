using System.Data.SqlClient;
using System.Data;
using System;

namespace SistemaCheques.Models.Datos
{
    public class RegistroChequeDatos
    {
        public List<RegistroChequeModel> Listar()
        {

            var Lista = new List<RegistroChequeModel>();

            var conexion = new Conexion();

            // creando la cadena de conexion a SQL
            using (var connection = new SqlConnection(conexion.getCadenaSQL()))

            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarRegistroCheque", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                // leer el resultado del sp_Listar (Procedimiento del CRUD en la DB)

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new RegistroChequeModel()
                        {
                            idRegistroCheque = Convert.ToInt32(dr["idRegistroCheque"]),
                            NumeroSolicitud = Convert.ToInt32(dr["NumeroSolicitud"]),
                            Monto = Convert.ToDecimal(dr["Monto"]),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                            CuentaBanco = Convert.ToInt32(dr["CuentaBanco"]),
                            CuentaProveedor = Convert.ToInt32(dr["idRegistroCheque"]),
                            Estado = dr["Estado"].ToString()
                        }) ;
                    }
                }
            }

            return Lista;
        }

        // Para obtener los datos
        public RegistroChequeModel Obtener(int idRegistroCheque)
        {
            // instancia de la conexion a la DB

            var RegistroCheque = new RegistroChequeModel();

            var conexion = new Conexion();

            // creando la cadena de conexion a SQL
            using (var connection = new SqlConnection(conexion.getCadenaSQL()))

            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerRegistroCheque", connection);
                cmd.Parameters.AddWithValue("idRegistroCheque", idRegistroCheque);
                cmd.CommandType = CommandType.StoredProcedure;

                // leer el resultado del sp_Obtener (Procedimiento del CRUD en la DB)

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())

                    {
                        RegistroCheque.idRegistroCheque = Convert.ToInt32(dr["idRegistroCheque"]);
                        RegistroCheque.NumeroSolicitud = Convert.ToInt32(dr["NumeroSolicitud"]);
                        RegistroCheque.Monto = Convert.ToDecimal(dr["Monto"]);
                        RegistroCheque.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                        RegistroCheque.CuentaBanco = Convert.ToInt32(dr["CuentaBanco"]);
                        RegistroCheque.CuentaProveedor = Convert.ToInt32(dr["idRegistroCheque"]);
                        RegistroCheque.Estado = dr["Estado"].ToString();
                    }
                }
            }

            return RegistroCheque;
        }

        // Para el guardado de los datos 
        public bool Guardar(RegistroChequeModel RegistroCheque)
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
                    SqlCommand cmd = new SqlCommand("sp_GuardarRegistroCheque", connection);
                    //cmd.Parameters.AddWithValue("idConceptoPago", conceptoPago.idConceptoPago);
                    cmd.Parameters.AddWithValue("NumeroSolicitud", RegistroCheque.NumeroSolicitud);
                    cmd.Parameters.AddWithValue("Monto", RegistroCheque.Monto);
                    cmd.Parameters.AddWithValue("FechaRegistro", RegistroCheque.FechaRegistro);
                    cmd.Parameters.AddWithValue("CuentaBanco", RegistroCheque.CuentaBanco);
                    cmd.Parameters.AddWithValue("CuentaProveedor", RegistroCheque.CuentaProveedor);
                    cmd.Parameters.AddWithValue("Estado", RegistroCheque.Estado);
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
        public bool Editar(RegistroChequeModel RegistroCheque)

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
                    SqlCommand cmd = new SqlCommand("sp_EditarRegistroCheque", connection);
                    cmd.Parameters.AddWithValue("NumeroSolicitud", RegistroCheque.NumeroSolicitud);
                    cmd.Parameters.AddWithValue("Monto", RegistroCheque.Monto);
                    cmd.Parameters.AddWithValue("FechaRegistro", RegistroCheque.FechaRegistro);
                    cmd.Parameters.AddWithValue("CuentaBanco", RegistroCheque.CuentaBanco);
                    cmd.Parameters.AddWithValue("CuentaProveedor", RegistroCheque.CuentaProveedor);
                    cmd.Parameters.AddWithValue("Estado", RegistroCheque.Estado);
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
        public bool Eliminar(int idRegistroCheque)

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
                    SqlCommand cmd = new SqlCommand("sp_EliminarRegistroCheque", connection);
                    cmd.Parameters.AddWithValue("idRegistroCheque", idRegistroCheque);
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
