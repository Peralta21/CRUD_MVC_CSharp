using System.Data.SqlClient;

namespace CRUD.Datos
{
    public class Connection
    {
        private string cadenaSQL = String.Empty;

        public Connection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }
        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
