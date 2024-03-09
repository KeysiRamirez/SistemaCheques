using SistemaCheques.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaCheques.Models.Datos
{
	public class ConceptoPagoDatos
	{
		// Para mostrar los datos
		public List<ConceptoPagoModel> Listar() {

			var lista = new List<ConceptoPagoModel>();

			var conexion = new Conexion();

			// creando la cadena de conexion a SQL
			using (var connection = new SqlConnection(conexion.getCadenaSQL()))
			
			{
				connection.Open();
				SqlCommand cmd = new SqlCommand("sp_Listar", connection);
				
				cmd.CommandType = CommandType.StoredProcedure;

				// leer el resultado del sp_Listar (Procedimiento del CRUD en la DB)

				using (var dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						lista.Add(new ConceptoPagoModel()
						{
							IdConceptoPago = Convert.ToInt32(dr["idConceptoPago"]),
							Descripcion = dr["Descripcion"].ToString(),
							Estado = dr["Estado"].ToString()
						});
					}
				}
			}

			return lista;
		}

		// Para obtener los datos
		public ConceptoPagoModel Obtener(int idConceptoPago)
		{

			var ConceptoPago = new ConceptoPagoModel();

			var conexion = new Conexion();

			// creando la cadena de conexion a SQL
			using (var connection = new SqlConnection(conexion.getCadenaSQL()))

			{
				connection.Open();
				SqlCommand cmd = new SqlCommand("sp_Obtener", connection);
				cmd.Parameters.AddWithValue("idConceptoPago", idConceptoPago);
				cmd.CommandType = CommandType.StoredProcedure;

				// leer el resultado del sp_Listar (Procedimiento del CRUD en la DB)

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

			return Obtener;
		}
	}
}
