using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class ConnectionFactory
    {
        public  string GetConnectionString()
        {
            return "Server=DESKTOP-4CRA0BU\\GHORBANI;Database=newSite;User ID=sa;Password=3686535;Trusted_Connection=True";
        }
    }
}
