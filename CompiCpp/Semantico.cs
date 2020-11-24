using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CompiCpp
{
    public class ERROR
    {
        public int codigo;
        public int linea;
        public string mensaje;
        public ERROR(int Codigo, int Linea, string Mensaje)
        {
            this.codigo = Codigo;
            this.linea = Linea;
            this.mensaje = Mensaje;
        }
        public int Codigo()
        {
            return codigo;
        }

        public int Linea()
        {
            return linea; 
        }
        public string Mensaje ()
        {
            return mensaje; 
        }
      

    }
    public enum Alcance
    {
        Public,
        Private,
        Static,
        Protected,
        Sealed,
        Abstract
    }

    public enum TipoDato
    {
        Int,
        String,
        Bool,
        Char,
        Double,
        Float,
        Nada
    }

    public enum Regreso
    {
        Int,
        String,
        Bool,
        Char,
        Double,
        Float,
        Void
    }

    public enum TipoVariable
    {
        varLocal,
        parametro
    }

    public class NodoClase
    {

        private string lexema;
        private Alcance miAlcance;
        private string herencia;
        private int renglonDec;
        private int[] referencias;

        private Dictionary<string,NodoAtributo> tSA = new Dictionary<string, NodoAtributo>();
        private Dictionary<string, NodoMetodo> tSM = new Dictionary<string, NodoMetodo>();

        public string Lexema
        {
            get { return lexema; }
            set { lexema = value; }
        }
        public Alcance MiAlcance
        {
            get { return miAlcance; }
            set { miAlcance = value; }
        }
        public string Herencia
        {
            get { return herencia; }
            set { herencia = value; }
        }
        public int RenglonDec
        {
            get { return renglonDec; }
            set { renglonDec = value; }
        }
        public int[] Referencias
        {
            get { return referencias; }
            set { referencias = value; }
        }
        public Dictionary<string, NodoMetodo> TSM
        {
            get { return tSM; }
            set { tSM = value; }
        }

        public Dictionary<string, NodoAtributo> TSA
        {
            get { return tSA; }
            set { tSA = value; }
        }

    }
    public class NodoAtributo
    {
        private string lexema;
        private string miAlcance;
        private string miTipo;
    
        private string direccionMemoria;
        private int renglonDec;
        private List<int> referencias =  new List<int>();
        private List<int> valor = new List<int>();

        public List<int> Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public List<int> Referencias
        {
            get { return referencias; }
            set { referencias = value;}
        }
        public string Lexema
        {
            get { return lexema; }
            set { lexema = value; }
        }

        public string MiAlcance
        {
            get { return miAlcance; }
            set { miAlcance = value; }
        }
     

        public string DireccionMemoria
        {
            get { return direccionMemoria; }
            set { direccionMemoria = value; }
        }

        public int RenglonDec
        {
            get { return renglonDec; }
            set { renglonDec = value; }
        }

        public string MiTipo
        {
            get { return miTipo; }
            set { miTipo = value; }
        }
    }
    public class NodoMetodo
    {
        public string lexema;
        public int lineaDec;
        public string miAlcance;
        public string miRegreso;
     
        public Dictionary<string, NodoVariable> tSV = new Dictionary<string, NodoVariable>();
        public List<NodoSobrecarga> sobrecarga = new List<NodoSobrecarga>();


        public List<NodoSobrecarga> Sobrecarga
        {
            get { return sobrecarga; }
            set { sobrecarga = value; }
        }

        public string Lexema
        {
            get { return lexema; }
            set { lexema = value; }
        }

        public int LineaDec
        {
            get { return lineaDec; }
            set { lineaDec = value; }
        }
        public string MiAlcance
        {
            get { return miAlcance; }
            set { miAlcance = value; }
        }

        public string MiRegreso
        {
            get { return miRegreso; }
            set { miRegreso = value; }
        }



        public Dictionary<string, NodoVariable> TSV
        {
            get { return tSV; }
            set { tSV = value; }
        }


    }
    public class NodoSobrecarga
    {
        public string lexema;
        public int lineaDec;
        public string miAlcance;
        public string miRegreso;

        public Dictionary<string, NodoVariable> tSV = new Dictionary<string, NodoVariable>();

        public string Lexema
        {
            get { return lexema; }
            set { lexema = value; }
        }

        public int LineaDec
        {
            get { return lineaDec; }
            set { lineaDec = value; }
        }
        public string MiAlcance
        {
            get { return miAlcance; }
            set { miAlcance = value; }
        }

        public string MiRegreso
        {
            get { return miRegreso; }
            set { miRegreso = value; }
        }



        public Dictionary<string, NodoVariable> TSV
        {
            get { return tSV; }
            set { tSV = value; }
        }
    }
    public class NodoVariable
    {
        private bool esParametro;
        private string lexema;
        private string miAlcance;
        private string miTipo;
        private List<int> valor = new List<int>();
        private string direccionMemoria;
        private int renglonDec;
        private List<int> referencias =  new List<int>();


        public List<int> Referencias
        {
            get { return referencias; }
            set { referencias = value; }
        }
        public bool EsParametro
        {
            get { return esParametro; }
            set { esParametro = value; }
        }

        public string Lexema
        {
            get { return lexema; }
            set { lexema = value; }
        }

        public string MiAlcance
        {
            get { return miAlcance; }
            set { miAlcance = value; }
        }
        public List<int> Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public string DireccionMemoria
        {
            get { return direccionMemoria; }
            set { direccionMemoria = value; }
        }

        public int RenglonDec
        {
            get { return renglonDec; }
            set { renglonDec = value; }
        }

        public string MiTipo
        {
            get { return miTipo; }
            set { miTipo = value; }
        }
    }
     public class TablaSimbolos
    {
     
        static public List<string> clases = new List<string>();
        private static Dictionary<string, NodoClase> tSC = new Dictionary<string, NodoClase>();
        public static Dictionary<string, NodoClase> TSC
        {

            get { return tSC; }
            set { tSC = value; }
        }

        //------------------------------------------------------------------Metodos para clase---------------------------------------------------------------------------
        public static void LimpiarTabla()
        {

            int count = TSC.Count;
            for (int a = 0; a < count; a++)
            {
                string clase = clases.ElementAt(a);

                TSC.Remove(clase);
            }

        }
        public static void InsertarClase(NodoClase miNodoClase)
        {
           

            if (!TSC.ContainsKey(miNodoClase.Lexema))
            {

                TSC.Add(miNodoClase.Lexema, miNodoClase);
                clases.Add(miNodoClase.Lexema);
            }
            else
            {
            
                ERRORES.Mensaje("600 "+ miNodoClase.RenglonDec+ "  Ya esxiste una clase con ese identificador.");

            }
        }

        public static NodoClase ObtenerClase(string lexema)
        {
            
                return TSC.FirstOrDefault(x => x.Key == lexema).Value;
         
        }

        public static void BuscarHerencia(string lexema, NodoClase claseActual)
        {
            if (!TSC.ContainsKey(lexema))
            {
                //La linea que trae no es la correcta
               
                ERRORES.Mensaje("Codigo: 602 Linea:" + claseActual.RenglonDec + " Mensaje: La clase no existe en el contexto actual");
      

            }

        }

        public static void InsertarAtributoClase(NodoAtributo nuevoAtributo, NodoClase claseActual)
        {
            if (!claseActual.TSA.ContainsKey(nuevoAtributo.Lexema))
            {
                claseActual.TSA.Add(nuevoAtributo.Lexema, nuevoAtributo);
            }
            else
            {
                ERRORES.Mensaje("Codigo: 602 Linea:" + nuevoAtributo.RenglonDec + " El atributo ya existe en el contexto actual");

            }

        }


        public static NodoAtributo obtenerNodoAtributo(string lexema, NodoClase claseActual, int linea)
        {
            if (claseActual.TSA.ContainsKey(lexema))
            {
                NodoAtributo nodoBusqueda = new NodoAtributo();
                nodoBusqueda = claseActual.TSA.FirstOrDefault(x => x.Key == lexema).Value;
                if (nodoBusqueda.Valor.Count == 0)
                {
                    ERRORES.Mensaje("Codigo: 602 Linea:" + linea + " El atributo no ha sido inicializado.");
                    return null;
                }
                else
                {
                    return nodoBusqueda;
                }
            }
            else
            {
                ERRORES.Mensaje("Codigo: 602 Linea:" + linea + " El atributo no existe en el contexto actual.");
        
                return null;
            }
        }

   

        public static string obtenerTipoAtributoClase(string lexema, NodoClase claseActual)
        {

            if (claseActual.TSA.ContainsKey(lexema))
            {
                return (claseActual.TSA.FirstOrDefault(x => x.Key == lexema).Value).MiTipo;
            }
            else
            {
                ERRORES.Mensaje("Codigo: 602 Linea:" + 0 + " El atributo no existe en el contexto actual");

                return "Nada";
            }
        }


        public static void AtributoNoReferenciado()
        {
          
          
            NodoClase clase = new NodoClase();
           
            NodoAtributo atributo = new NodoAtributo();

            for (int contador =  0;contador < TSC.Count; contador++)
            {
                
                clase = TSC.Values.ElementAt(contador);
                for(int contAtributo = 0; contAtributo < clase.TSA.Count; contAtributo++)
                {
                    atributo = clase.TSA.Values.ElementAt(contAtributo);
                    if (atributo.Referencias.Count == 0)
                    {
                        ERRORES.Mensaje("Codigo: 602 Linea:" + atributo.RenglonDec + " El atributo nunca es utilizado.");
                    }

                }
                


            }
        }

        //------------------------------------------------------Metodos para metodos----------------------------------------------------------------------------------------

        #region Metodos
        public static void InsertarMetodo(NodoMetodo nuevoMetodo, NodoClase claseActual, List<NodoVariable> Parametros)
        {
            List<NodoAtributo> listaExistente = new List<NodoAtributo>();
            List<NodoAtributo> listaNuevo = new List<NodoAtributo>();
            bool IngresarNodo = true;
            #region Metodo sin sobrecarga
            if (claseActual.Lexema != nuevoMetodo.Lexema)
            {
                if (!claseActual.TSM.ContainsKey(nuevoMetodo.Lexema))
                {

                    foreach (var item in Parametros)
                    {

                        InsertarParametroMetodo(item, nuevoMetodo);
                    }


                    claseActual.TSM.Add(nuevoMetodo.Lexema, nuevoMetodo);
                }
                #endregion
            #region Sobrecarga de metodos
                else
                {

                    int enteros = 0;
                    int strings = 0;
                    int booleanos = 0;
                    int decimales = 0;

                    int enteros2 = 0;
                    int strings2 = 0;
                    int booleanos2 = 0;
                    int decimales2 = 0;

                    int enteros3 = 0;
                    int strings3 = 0;
                    int booleanos3 = 0;
                    int decimales3 = 0;


                    NodoMetodo metodoExistente = ObtenerMetodo(nuevoMetodo.Lexema, claseActual.Lexema);
                    NodoSobrecarga metodoSobrecarga = new NodoSobrecarga();
                    bool nodosEnLista = metodoExistente.Sobrecarga.Any();
                    if (nodosEnLista)
                    {

                        int contador = metodoExistente.sobrecarga.Count;
                        for (int a = 0; a < metodoExistente.TSV.Count; a++)
                        {
                            NodoVariable parExistente = metodoExistente.TSV.ElementAt(a).Value;
                            switch (parExistente.MiTipo)
                            {
                                case "int":
                                    enteros++;
                                    break;
                                case "string":
                                    strings++;
                                    break;
                                case "double":
                                    decimales++;
                                    break;
                            }

                        }
                        for (int a = 0; a < Parametros.Count; a++)
                        {
                            NodoVariable parNuevo = Parametros.ElementAt(a);
                            switch (parNuevo.MiTipo)
                            {
                                case "int":
                                    enteros2++;
                                    break;
                                case "string":
                                    strings2++;
                                    break;
                                case "double":
                                    decimales2++;
                                    break;
                            }

                        }


                        for (int g = 0; g < contador; g++)
                        {
                            NodoVariable parExistente = new NodoVariable();
                            NodoSobrecarga nuevoSobrecarga = metodoExistente.sobrecarga.ElementAt(g);
                            enteros3 = 0;
                            strings3 = 0;
                            booleanos3 = 0;
                            decimales3 = 0;
                            for (int h = 0; h < nuevoSobrecarga.TSV.Count; h++)
                            {

                                parExistente = nuevoSobrecarga.TSV.ElementAt(h).Value;
                                switch (parExistente.MiTipo)
                                {
                                    case "int":
                                        enteros3++;
                                        break;
                                    case "string":
                                        strings3++;
                                        break;
                                    case "double":
                                        decimales3++;
                                        break;
                                }




                            }//

                           
                               
                                   if (enteros == enteros2 && enteros > 0 && Parametros.Count == metodoExistente.TSV.Count || enteros == enteros2 && enteros2 > 0 && Parametros.Count == metodoExistente.TSV.Count || strings == strings2 && strings > 0 && Parametros.Count == metodoExistente.TSV.Count || strings == strings2 && strings2 > 0 && Parametros.Count == metodoExistente.TSV.Count || decimales == decimales2 && decimales > 0 && Parametros.Count == metodoExistente.TSV.Count || decimales == decimales2 && decimales2 > 0 && Parametros.Count == metodoExistente.TSV.Count)
                                   {
                                        IngresarNodo = false;
                                        ERRORES.Mensaje("Codigo: 602 Linea:" + metodoExistente.LineaDec + " El metodo ya existe en el contexto actual");
                  

                                        enteros = 0;
                                        strings = 0;
                                        booleanos = 0;
                                        decimales = 0;

                                        enteros2 = 0;
                                        strings2 = 0;
                                        booleanos2 = 0;
                                        decimales2 = 0;

                                        enteros3 = 0;
                                        strings3 = 0;
                                        booleanos3 = 0;
                                        decimales3 = 0;
                                    }if  (enteros == enteros3 && enteros > 0 && Parametros.Count == metodoExistente.TSV.Count || enteros == enteros3 && enteros3 > 0 && Parametros.Count == metodoExistente.TSV.Count || strings == strings3 && strings > 0 && Parametros.Count == metodoExistente.TSV.Count || strings == strings3 && strings3 > 0 && Parametros.Count == metodoExistente.TSV.Count || decimales == decimales3 && decimales > 0 && Parametros.Count == metodoExistente.TSV.Count || decimales == decimales3 && decimales3 > 0 && Parametros.Count == metodoExistente.TSV.Count)
                                    {
                                        IngresarNodo = false;
                                        ERRORES.Mensaje("Codigo: 602 Linea:" + metodoExistente.LineaDec + " El metodo ya existe en el contexto actual");
                                  
                                        enteros = 0;
                                        strings = 0;
                                        booleanos = 0;
                                        decimales = 0;

                                        enteros2 = 0;
                                        strings2 = 0;
                                        booleanos2 = 0;
                                        decimales2 = 0;


                                        enteros3 = 0;
                                        strings3 = 0;
                                        booleanos3 = 0;
                                        decimales3 = 0;

                                    }
                               
                                    if(Parametros.Count == nuevoSobrecarga.TSV.Count && enteros3 ==enteros2 && strings3 == strings2 && decimales3 ==decimales2)
                                    {
                                        ERRORES.Mensaje("Codigo: 602 Linea:" + metodoExistente.LineaDec + " El metodo ya existe en el contexto actual");
                                        IngresarNodo = false;
    
                                        enteros = 0;
                                        strings = 0;
                                        booleanos = 0;
                                        decimales = 0;

                                        enteros2 = 0;
                                        strings2 = 0;
                                        booleanos2 = 0;
                                        decimales2 = 0;


                                        enteros3 = 0;
                                        strings3 = 0;
                                        booleanos3 = 0;
                                        decimales3 = 0;
                                    }
                                   
                               
                           

                            

                            
                          
                                
                            

                     


                        }
                        #endregion
            #region IngresarNodo es true
                        if (IngresarNodo)
                        {
                            
                         
                                NodoSobrecarga metodoCarga = LlenarMetodoSobrecarga(nuevoMetodo);
                                foreach (var item in Parametros)
                                {

                                InsertarParametroSobrecarga(item, metodoCarga);

                                }
                                metodoExistente.Sobrecarga.Add(metodoCarga);
                                enteros = 0;
                                strings = 0;
                                booleanos = 0;
                                decimales = 0;

                                enteros2 = 0;
                                strings2 = 0;
                                booleanos2 = 0;
                                decimales2 = 0;


                                enteros3 = 0;
                                strings3 = 0;
                                booleanos3 = 0;
                                decimales3 = 0;
                            
                        }
                        #endregion
            #region Comparar solo dos metodos, el actual y el entrante sin sobrecarga


                    }
                    else if (metodoExistente.TSV.Count == 0 && Parametros.Count == 0)
                    {

                        ERRORES.Mensaje("Codigo: 602 Linea:" + 0 + " El metodo ya existe en el contexto actual");
  
                    }
                    else if (metodoExistente.TSV.Count == Parametros.Count)
                    {

                        for (int a = 0; a < metodoExistente.TSV.Count; a++)
                        {
                            NodoVariable parExistente = metodoExistente.TSV.ElementAt(a).Value;
                            switch (parExistente.MiTipo)
                            {
                                case "int":
                                    enteros++;
                                    break;
                                case "string":
                                    strings++;
                                    break;
                                case "double":
                                    decimales++;
                                    break;
                            }

                        }

                        for (int a = 0; a < Parametros.Count; a++)
                        {
                            NodoVariable parNuevo = Parametros.ElementAt(a);
                            switch (parNuevo.MiTipo)
                            {
                                case "int":
                                    enteros2++;
                                    break;
                                case "string":
                                    strings2++;
                                    break;
                                case "double":
                                    decimales2++;
                                    break;
                            }

                        }


                        if (enteros == enteros2 && enteros > 0 && Parametros.Count == metodoExistente.TSV.Count || enteros == enteros2 && enteros2 > 0 && Parametros.Count == metodoExistente.TSV.Count || strings == strings2 && strings > 0 && Parametros.Count == metodoExistente.TSV.Count || strings == strings2 && strings2 > 0 && Parametros.Count == metodoExistente.TSV.Count || decimales == decimales2 && decimales > 0 && Parametros.Count == metodoExistente.TSV.Count || decimales == decimales2 && decimales2 > 0 && Parametros.Count == metodoExistente.TSV.Count)
                        {
                            ERRORES.Mensaje("Codigo: 602 Linea:" + 0 + " El metodo ya existe en el contexto actual");
                            MessageBox.Show("El metodo ya existe en el contexto actual");
                            enteros = 0;
                            strings = 0;
                            booleanos = 0;
                            decimales = 0;

                            enteros2 = 0;
                            strings2 = 0;
                            booleanos2 = 0;
                            decimales2 = 0;
                        }
                        else
                        {
                            NodoSobrecarga metodoCarga = LlenarMetodoSobrecarga(nuevoMetodo);
                            foreach (var item in Parametros)
                            {

                                InsertarParametroSobrecarga(item, metodoCarga);

                            }
                            metodoExistente.Sobrecarga.Add(metodoCarga);
                            enteros = 0;
                            strings = 0;
                            booleanos = 0;
                            decimales = 0;

                            enteros2 = 0;
                            strings2 = 0;
                            booleanos2 = 0;
                            decimales2 = 0;
                        }



                    }
                    else
                    {
                        NodoSobrecarga metodoCarga = LlenarMetodoSobrecarga(nuevoMetodo);
                        foreach (var item in Parametros)
                        {

                            InsertarParametroSobrecarga(item, metodoCarga);

                        }
                        metodoExistente.Sobrecarga.Add(metodoCarga);
       
                    }


                }
            }
            else
            {
                ERRORES.Mensaje("Codigo: 602 Linea:" + 0 + " El metodo no puede llamarse igual que la clase.");

            }
            #endregion

        }


        public static NodoSobrecarga LlenarMetodoSobrecarga(NodoMetodo metodoActual)
        {
            NodoSobrecarga nuevoNodo = new NodoSobrecarga();
            nuevoNodo.LineaDec = metodoActual.LineaDec;
            nuevoNodo.Lexema = metodoActual.Lexema;
            nuevoNodo.MiRegreso = metodoActual.MiRegreso;
            nuevoNodo.MiAlcance = metodoActual.MiAlcance;

            return nuevoNodo;

        }

    
        public static void InsertarParametroMetodo(NodoVariable parametro, NodoMetodo metodoActual)
        {
            if (!metodoActual.TSV.ContainsKey(parametro.Lexema))
            {
                metodoActual.TSV.Add(parametro.Lexema, parametro);
            }
            else
            {
                ERRORES.Mensaje("Codigo: 602 Linea:" + parametro.RenglonDec + " El parametro ya existe en el contexto actual");
     
            }

        }
   
      
        public static void InsertarParametroSobrecarga(NodoVariable nuevaVariable, NodoSobrecarga metodoActual)
        {
            if (!metodoActual.TSV.ContainsKey(nuevaVariable.Lexema))
            {
                metodoActual.TSV.Add(nuevaVariable.Lexema, nuevaVariable);
            }
            else
            {
                ERRORES.Mensaje("Codigo: 602 Linea:" + nuevaVariable.RenglonDec + " El parametro ya existe en el contexto actual");

            }

        }
        public static NodoMetodo ObtenerMetodo(string metodo, string claseActual)
        {
                NodoClase miClase = ObtenerClase(claseActual);
                return miClase.TSM.FirstOrDefault(x => x.Key == metodo).Value;
               
        }

        public static void InsertarVariableMetodo(NodoClase claseActual, NodoMetodo metodoActual, NodoVariable nuevaVariable)
        {

            if (claseActual.TSM.ContainsKey(metodoActual.Lexema))
            {
      
                if (!metodoActual.TSV.ContainsKey(nuevaVariable.Lexema))
                {
                    metodoActual.TSV.Add(nuevaVariable.Lexema, nuevaVariable);
                }
                else
                {
                    ERRORES.Mensaje("Codigo: 602 Linea:" + nuevaVariable.RenglonDec + " La variable ya existe en el metodo actual.");
              
                }
            }
        }

        public static NodoVariable ObtenerVariableSobrecarga(string variable,string metodo, NodoClase claseActual, int linea)
        {
            int cont = 0;

            
                NodoMetodo nodoBusqueda = new NodoMetodo();
                NodoSobrecarga metodoEnSobrecarga = new NodoSobrecarga();
                NodoVariable variableBuscada = new NodoVariable();
                nodoBusqueda = ObtenerMetodo(metodo,claseActual.Lexema);
                cont = nodoBusqueda.Sobrecarga.Count();
                metodoEnSobrecarga = nodoBusqueda.Sobrecarga.ElementAt(cont-1);
                variableBuscada = metodoEnSobrecarga.TSV.FirstOrDefault(x => x.Key == variable).Value;
                if (variableBuscada== null)
                {
                    ERRORES.Mensaje("Codigo: 602 Linea:" + linea + " La variable no existe en el contexto actual.");
                    return null;
                }
                else
                {
                    if (variableBuscada.Valor.Count == 0)
                    {
                        ERRORES.Mensaje("Codigo: 602 Linea:" + linea + " La variable no ha sido inicializada.");
                        return null;
                    }
                    else 
                    {
                        return variableBuscada;
                    }
                    
                }
                
            
            
           
        }

        public static NodoVariable ObtenerVariableMetodo(string variable, string metodo, NodoClase claseActual, int linea)
        {

            NodoMetodo nodoBusqueda = new NodoMetodo();
            NodoVariable variableBuscada = new NodoVariable();
            nodoBusqueda = ObtenerMetodo(metodo, claseActual.Lexema);
            if (nodoBusqueda.TSV.ContainsKey(variable))
            {
                
                variableBuscada = nodoBusqueda.TSV.FirstOrDefault(x => x.Key == variable).Value;
                if (variableBuscada.Valor.Count == 0)
                {
                    ERRORES.Mensaje("Codigo: 602 Linea:" + linea + " La variable no ha sido inicializada.");
                    return null;
                }
                else
                {
                    return variableBuscada;
                }


            }
            else
            {
                ERRORES.Mensaje("Codigo: 602 Linea:" + linea + " La variable no existe en el contexto actual.");

                
                return null;
            }
        }
        public static void InsertarVariableSobrecarga(NodoClase claseActual, string metodo, NodoVariable nuevaVariable)
        {
            int contador = 0;
            NodoSobrecarga sobrecarga = new NodoSobrecarga();
            if (claseActual.TSM.ContainsKey(metodo))
            {
                NodoMetodo metodoActual = ObtenerMetodo(metodo, claseActual.Lexema);
                contador = metodoActual.Sobrecarga.Count();
                sobrecarga = metodoActual.Sobrecarga.ElementAt(contador-1);
                if (!sobrecarga.TSV.ContainsKey(nuevaVariable.Lexema)) 
                {
                    sobrecarga.TSV.Add(nuevaVariable.Lexema, nuevaVariable);
                }
                else
                {
                    ERRORES.Mensaje("Codigo: 602 Linea:" + nuevaVariable.RenglonDec + " La variable ya existe en el contexto actual.");
                }
                
            }
        }

        public static void VariableNoReferenciada() 
        {
            NodoClase clase = new NodoClase();
            NodoMetodo metodo = new NodoMetodo();
            NodoSobrecarga sobrecarga = new NodoSobrecarga();
            NodoVariable variable = new NodoVariable();
            bool conSobrecarga = false;
            for(int contClase = 0; contClase < TSC.Count; contClase++)
            {
                clase = TSC.Values.ElementAt(contClase);
                for (int contMetodo = 0; contMetodo < clase.TSM.Count; contMetodo++)
                {
                    metodo = clase.TSM.Values.ElementAt(contMetodo);
                    conSobrecarga = metodo.Sobrecarga.Any();
                    for (int contVar = 0; contVar < metodo.TSV.Count; contVar++)
                    {
                        variable = metodo.TSV.Values.ElementAt(contVar);

                        if (variable.Referencias.Count == 0 && variable.EsParametro == false)
                        {
                            ERRORES.Mensaje("Codigo: 602 Linea:" + variable.RenglonDec + " La variable nunca es utilizada.");
                        }
                       

                    }

                    if (conSobrecarga)
                    {
                        for (int contSob = 0; contSob < metodo.Sobrecarga.Count; contSob++)
                        {
                            sobrecarga = metodo.Sobrecarga.ElementAt(contSob);
                            for (int varSob = 0; varSob < sobrecarga.TSV.Count; varSob++)
                            {
                                variable = sobrecarga.TSV.Values.ElementAt(varSob);
                                if (variable.Referencias.Count == 0 && variable.EsParametro ==  false) { ERRORES.Mensaje("Codigo: 602 Linea:" + variable.RenglonDec + " La variable nunca es utilizada."); }
                            }
                        }
                    }
                }
            }

         


        }
        #endregion

    }

}




