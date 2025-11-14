using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class HeroesContext
    {
        private readonly string _connectionString;

        public HeroesContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnexionDapper");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
