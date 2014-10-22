using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class CSV
    {
        public const string separator = "|";

        public static string ToCsv<T>(IEnumerable<T> objectlist)
        {
            var csvdata = new StringBuilder();

            foreach (var o in objectlist)
            {
                csvdata.AppendLine(o.ToString());
            }

            return csvdata.ToString();
        }
    }
}
