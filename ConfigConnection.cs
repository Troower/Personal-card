using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCard
{
    public class ConfigConnection
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Password { get; set; }
        public string Uid {  get; set; }
    }
    public class ConfigReader
    {
        static public ConfigConnection ReadConfig()
        {

            var str = File.ReadAllLines(@"..\..\..\config.ini");
            return new ConfigConnection
            {
                Server = str[0],
                Database = str[1],
                Uid = str[2],
                Password = str[2]
            };

        }

    }
}
