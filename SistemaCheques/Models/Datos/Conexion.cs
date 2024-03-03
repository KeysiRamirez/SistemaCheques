using System.Data.SqlClient;

namespace SistemaCheques.Models.Datos
{
	public class Conexion
	{
		private string CadenaSQL = string.Empty;	

		// constructor 
		public Conexion() {

			// cadena de conexion con el archivo appsettings.json ya que ahi se definio la conexion con la DB

			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

			// definir el acceso al archivo en donde se define la conexion

			CadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
		
		}	

		public string getCadenaSQL()
		{
			return CadenaSQL;
		}
	}
}
