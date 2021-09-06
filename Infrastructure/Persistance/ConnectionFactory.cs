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
            return "Server=DESKTOP-L35V6LG;Database=newSite;User ID=Mina;Password=Dapa123456;Trusted_Connection=True";
        }
    }
}
