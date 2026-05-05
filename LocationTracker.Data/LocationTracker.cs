using Dapper;
using LocationTracker.Core;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;

namespace LocationTracker.Data
{
    public class LocationRepository : ILocationTracker 
    {
        IDbConnection dbConnection;

        public LocationRepository(string connectionstring)
        {
            dbConnection = new SqlConnection(connectionstring);
        }

        public string LogLocation(string latitude, string longitude)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Latitude", latitude);
            parameters.Add("@Longitude", longitude);
            parameters.Add("@Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

            dbConnection.Execute("sp_InsertLocationLogger", parameters, commandType: CommandType.StoredProcedure);

            return parameters.Get<string>("@Message");
        }
    }
}