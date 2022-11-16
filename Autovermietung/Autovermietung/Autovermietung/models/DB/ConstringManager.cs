using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung.models.DB
{
    public class ConstringManager
    {
        private string _server = "localhost";
        private string _database = "orm_autovermietung";
        private string user = "root";
        private string pw = "SHW_Destroyer02";

        public string Server { get => _server; set => _server = value; }
        public string Database { get => _database; set => _database = value; }
        public string User { get => user; set => user = value; }
        public string Pw { get => pw; set => pw = value; }
    }
}
