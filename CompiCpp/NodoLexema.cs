using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiCpp
{


    public class NodoLexema
    {
        private string textoLexema;
        private string descripcion;
        private int token;
        private int linea;
        


        public string TextoLexema// 
        {
            get { return this.textoLexema; }
            set { this.textoLexema = value; }
        }

        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        public int Token
        {
            get { return this.token; }
            set { this.token = value; }
        }

        public int Linea
        {
            get { return this.linea; }
            set { this.linea = value; }
        }
    }
}
