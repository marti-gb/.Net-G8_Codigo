using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DataContext
{
    public class DapperConnectionHelper : IDapperConnectionHelper
    {
        private readonly IConfiguration _configuration;
        private string ConnectionString { get; set; }

        //Define el proveedor de nuestra base de datos(para nuestro caso System.Data.SqlClient para SqlServer)
        private string ProviderName { get; set; }

        public DapperConnectionHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            ProviderName = "System.Data.SqlClient";
        }

        public IDbConnection GetDapperContextHelper()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
