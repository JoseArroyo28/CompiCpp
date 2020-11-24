using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiCpp
{
   public  class ERRORES
    {
        private static List<string> _list;
        public static List<string> _List
        {
            get { return _list; }
            set { _list = value; }
        }
         static ERRORES()
        {
            _list = new List<string>();
        }
        public static void Mensaje(string value)
        {
            _list.Add(value);
        }
        public static String Display()
        {
            //
            // Write out the results.
            //
            foreach (var value in _list)
            {
                return  value;
            }
            return " ";
        }
    }
}

