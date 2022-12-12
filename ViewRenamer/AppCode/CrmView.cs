using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carfup.XTBPlugins.AppCode
{
    public class CrmView
    {
        public string Entity { get; set; }
        public Guid Id { get; set; }
        public Dictionary<int, string> Names { get; set; }
        public int Type { get; set; }
        public bool Modified { get; set; } = false;
    }
}
