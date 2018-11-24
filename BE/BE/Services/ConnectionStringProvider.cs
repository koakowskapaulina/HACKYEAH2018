using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Services
{   
    public class ConnectionStringProvider
    {
        private string _key;

        public ConnectionStringProvider(string key)
        {
            _key = key;
        }

        public string GetConnectionString()
        {
            return _key;
        }
    }
}
