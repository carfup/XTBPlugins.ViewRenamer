using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carfup.XTBPlugins.AppCode
{
    internal class Language
    {
        public Language(int lcid, string name)
        {
            Lcid = lcid;
            Name = name;
        }

        public int Lcid { get; }
        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
