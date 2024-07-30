using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW2
{
    public class DbProviderFactory
    {
        /*public static IDbProvider CreateProvider(string providerType, string connectionString)
        {
            if (providerType == "SQL")
            {
                return new SqlDbProvider(connectionString);
            }
            else
            {
                throw new ArgumentException("Invalid provider type");
            }
        }*/

        public static IDbProvider CreateProvider()
        {
            return new SqlDbProvider();
        }
    }
}