using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdStrapped.Models
{
    public class Command
    {
        public int CommandId { get; set; }
        public string Hook { get; set; }
        public Action<String> Method { get; set; }
        public string Description { get; set; }
    }
}
