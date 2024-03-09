using SistemaCheques.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaCheques.Models.Datos
{
	public class ConceptoPagoDatos
	{
		// Para mostrar los datos
		public List<ConceptoPagoModel> Listar() {

			var Lista = new List<ConceptoPagoModel>();

			var conexion = new Conexion();

			// creando la cadena de conexion a SQL
			using (var connection = new SqlConnection(conexion.getCadenaSQL()))

			{
				connection.Open();
				SqlCommand cmd = new SqlCommand("sp_ListarConceptoPago", connection);

				cmd.CommandType = CommandType.StoredProcedure;

				// leer el resultado del sp_Listar (Procedimiento del CRUD en la DB)

				using (var dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						Lista.Add(new ConceptoPagoModel()
						{
							idConceptoPago = Convert.ToInt32(dr["idConceptoPago"]),
							Descripcion = dr["Descripcion"].ToString(),
							Estado = dr["Estado"].ToString()
						});
					}
				}
			}

			return Lista;
		}

		// Para obtener los datos
		public ConceptoPagoModel Obtener (int idConceptoPago)
		{
			// instancia de la conexion a la DB

			var ConceptoPago = new ConceptoPagoModel();

			var conexion = new Conexion();

			// creando la cadena de conexion a SQL
			using (var connection = new SqlConnection(conexion.getCadenaSQL()))

			{
				connection.Open();
				SqlCommand cmd = new SqlCommand("sp_ObtenerConceptoPago", connection);
				cmd.Parameters.AddWithValue("idConceptoPago", idConceptoPago);
				cmd.CommandType = CommandType.StoredProcedure;

				// leer el resultado del sp_Obtener (Procedimiento del CRUD en la DB)

				using (var dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						ConceptoPago.idConceptoPago = Convert.ToInt32(dr["idConceptoPago"]);
						ConceptoPago.Descripcion = dr["Descripcion"].ToString();
						ConceptoPago.Estado = dr["Estado"].ToString();
					}
				}
			}

			return ConceptoPago;
		}

		// Para el guardado de los datos 
		public bool Guardar(ConceptoPagoModel conceptoPago)
		{
			// Se crea coo=mo boolean para la validacion segun la DB

			bool respuesta;

			try
			{
				// intancia de la conexion a la DB

				var conexion = new Conexion();

				using (var connection = new SqlConnection(conexion.getCadenaSQL()))

				{
					connection.Open();
					// leer el resultado del sp_Guardar (Procedimiento del CRUD en la DB)
					SqlCommand cmd = new SqlCommand("sp_GuardarConceptoPago", connection);
                  //cmd.Parameters.AddWithValue("idConceptoPago", conceptoPago.idConceptoPago);
                    cmd.Parameters.AddWithValue("Descripcion",conceptoPago.Descripcion);
					cmd.Parameters.AddWithValue("Estado", conceptoPago.Estado);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.ExecuteNonQuery();
				}

				// En caso de que la validacion se realice correctamente

				respuesta = true;
			} 
			// En caso de haber algun error 
			catch(Exception ex)

			{
				String error = ex.Message; // Mensaje de error
				respuesta = false;
			}

			return respuesta;
		}

		// Actualizar los datos
		public bool Editar(ConceptoPagoModel conceptoPago)

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
					SqlCommand cmd = new SqlCommand("sp_EditarConceptoPago", connection);
					cmd.Parameters.AddWithValue("idConceptoPago", conceptoPago.idConceptoPago);
					cmd.Parameters.AddWithValue("Descripcion", conceptoPago.Descripcion);
					cmd.Parameters.AddWithValue("Estado", conceptoPago.Estado);
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
		public bool Eliminar(int idConceptoPago)

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
					cmd.Parameters.AddWithValue("idConceptoPago", idConceptoPago);
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
