using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Data.SQLite;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace castleFlex_alfa
{
    class card
    {
        public int id { get; set; }
        public byte[] pic { get; set; }
        public int cost { get; set; }
        public string type { get; set; }
        public string name { get; set; }
    }

}
