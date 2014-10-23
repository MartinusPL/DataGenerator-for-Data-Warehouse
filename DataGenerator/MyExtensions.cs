using System;
using System.Collections.Generic;
using System.IO;
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

        public static HashSet<string[]> FromCsv<T>(IEnumerable<T> objectlist, string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                HashSet<string[]> ret = new HashSet<string[]>();
                while ((line = sr.ReadLine()) != null)
                {
                    var exp = line.Split(CSV.separator.ToCharArray());
                    ret.Add(exp);
                }
                return ret;
            }
        }
    }
}
