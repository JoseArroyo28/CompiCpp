using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiCpp
{
    public enum TipoNodoArbol
    {
        Expresion, Sentencia, Condicional
    }
    public enum TipoSentencia
    {
        IF,
        FOR,
        ASIGNACION,
        LEER,
        ESCRIBIR,
        NADA
    }
    public enum tipoExpresion
    {
        Operador,
        Constante,
        Identificador,
        NADA
    }
    public enum tipoOperador
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        NADA
    }
    public enum OperacionCondicional
    {
        IgualIgual,
        MenorQue,
        MayorQue,
        MenorIgualQue,
        MayorIgualQue,
        Diferente,
        NADA
    }
    public class NodoArbol
    {                                      //    IF             EXP             ASIG       for
        public NodoArbol hijoIzquierdo;  //  condicional      operando izq    arbol exp   sentencias
        public NodoArbol hijoDerecho;     // if false          operando der                condicional
        public NodoArbol hijoCentro;      // if true 
        public NodoArbol hermano;     // apunta a la siguiente instruccion (arbol)

        public TipoNodoArbol soyDeTipoNodo;
        public TipoSentencia soySentenciaDeTipo;

        public tipoExpresion SoyDeTipoExpresion;
        public tipoOperador soyDeTipoOperacion;
        // semantico ... gramatica con atributo
        public OperacionCondicional soyOperacionCondicionaDeTipo;

        public string lexema;

        //reglas semanticas // atributos
        //comprobacion de tipos y generacion de codigo intermedio
        public TipoDato SoyDeTipoDato;
        public TipoDato tipoValorNodoHijoIzquierdo; // valores sintetizados
        public TipoDato tipoValorNodoHijoDerecho;   // valores sintetizados

        public string memoriaAsignada; // conocer la memoria asignada
        public string valor;   //para hacer calculos codigo intermedio
        public string pCode;  // generar el codigo intermedio
        public string pCode1;  // generar el codigo intermedio
        public string pCode2;  // generar el codigo intermedio
        public string pCode3;  // generar el codigo intermedio
        public int linea;
    }
    public class Arbol
    {
        public NodoClase nombreClaseActiva;
        public string nombreMetodoActivo;

        public int puntero;
        public List<NodoLexema> miListaTokenTemporal;

        public Arbol(List<NodoLexema> miListaTokenLexico)
        {
            puntero = 0;
            miListaTokenTemporal = miListaTokenLexico;
        }

        public NodoArbol CrearArbolSintacticoAbstracto()
        {
            NodoArbol nodoraiz = new NodoArbol();
            nodoraiz = ObtenerSiguienteArbol();
            puntero++;
            if (miListaTokenTemporal[puntero].TextoLexema != "$")
            {
                nodoraiz.hermano = NodoHermano();
            }
            return nodoraiz;
        }


        private NodoArbol NodoHermano()
        {
            NodoArbol t = ObtenerSiguienteArbol();
            puntero++;
            if (miListaTokenTemporal[puntero].TextoLexema != "$")
            {
                t.hermano = NodoHermano();
            }
            return t;
        }

        private NodoArbol ObtenerSiguienteArbol()
        {
            switch (miListaTokenTemporal[puntero].Token)
            {
                case -64: //if
                    return CrearArbolIF();
                case -1: //asignacion
                    return CrearArbolAsignacion();
                case -63: //for
                    return CrearArbolFor();
                case -73: // escritura
                    return CrearNodoEscritura();
                case -74: // lectura
                    return CrearNodoLectura();
                default:
                    return null;
            }
        }


        #region Crear ARBOL Expresion
        public NodoArbol CrearArbolExpresion()
        {
            NodoArbol nodoRaiz = Termino();
            while (miListaTokenTemporal[puntero].Linea.Equals("+")
                || miListaTokenTemporal[puntero].Linea.Equals("-"))
            {
                NodoArbol nodoTemp = NuevoNodoExpresion(tipoExpresion.Operador);
                nodoTemp.hijoIzquierdo = nodoRaiz;
                nodoTemp.soyDeTipoOperacion =
                    miListaTokenTemporal[puntero].Linea.Equals("+")
                    ? tipoOperador.Suma
                    : tipoOperador.Resta;
                if (miListaTokenTemporal[puntero].Linea.Equals("+"))
                {
                    nodoTemp.pCode = "adi;";
                }
                else
                {
                    nodoTemp.pCode = "sbi;";
                }
                nodoTemp.lexema = miListaTokenTemporal[puntero].TextoLexema;
                nodoRaiz = nodoTemp;
                puntero++;
                nodoRaiz.hijoDerecho = Termino();
            }

            return nodoRaiz;
        }

        private NodoArbol Termino()
        {
            NodoArbol t = Factor();
            while (miListaTokenTemporal[puntero].Linea.Equals("*")  // cambiar por su token
                 || miListaTokenTemporal[puntero].Linea.Equals("/"))
            {
                NodoArbol p = NuevoNodoExpresion(tipoExpresion.Operador);
                p.hijoIzquierdo = t;
                p.soyDeTipoOperacion = miListaTokenTemporal[puntero].Linea.Equals("*")
                    ? tipoOperador.Multiplicacion
                    : tipoOperador.Division;
                if (miListaTokenTemporal[puntero].Linea.Equals("*"))
                {
                    t.pCode = "mpi;";
                }
                else
                {
                    t.pCode = "div;";
                }

                t.lexema = miListaTokenTemporal[puntero].TextoLexema;
                t = p;
                puntero++;
                t.hijoDerecho = Factor();
            }
            return t;
        }

        public NodoArbol Factor()
        {
            NodoArbol t = new NodoArbol();

            if (miListaTokenTemporal[puntero].Linea == -2) //ENTERO
            {
                t = NuevoNodoExpresion(tipoExpresion.Constante);
                t.pCode = " ldc " + miListaTokenTemporal[puntero].Linea + ";";
               t.SoyDeTipoDato = TipoDato.Int;
                t.lexema = miListaTokenTemporal[puntero].TextoLexema;
                puntero++;
            }
            if (miListaTokenTemporal[puntero].Linea == -3)  //decimal
            {
                t = NuevoNodoExpresion(tipoExpresion.Constante);
                t.pCode = " ldc " + miListaTokenTemporal[puntero].TextoLexema + ";";
                t.lexema = miListaTokenTemporal[puntero].TextoLexema;
               t.SoyDeTipoDato = TipoDato.Double;
                puntero++;
            }

            else if (miListaTokenTemporal[puntero].Linea == -1) // identificador
            {
                t = NuevoNodoExpresion(tipoExpresion.Identificador);
                t.lexema = miListaTokenTemporal[puntero].TextoLexema;

                t.pCode = " lod " + miListaTokenTemporal[puntero].TextoLexema + ";"; // gramatica con atributos
              //  t.SoyDeTipoDato =
                // TablaSimbolos.ObtenerTipoDato(
                //  miListaTokenTemporal[puntero].TextoLexema,
                //   nombreClaseActiva, nombreMetodoActivo); // gramatica con atributos

                puntero++;
            }
            else if (miListaTokenTemporal[puntero].Linea.Equals("("))
            {
                puntero++;
                t = CrearArbolExpresion();
                puntero++;
            }
            return t;
        }

        #endregion      
        #region Crear ARBOL Asignacion
        public NodoArbol CrearArbolAsignacion()
        {
            var sentenciaAsignacion = NuevoNodoSentencia(TipoSentencia.ASIGNACION);
            sentenciaAsignacion.lexema = miListaTokenTemporal[puntero].TextoLexema;
            sentenciaAsignacion.pCode = "lda " + miListaTokenTemporal[puntero].TextoLexema + ";";
            sentenciaAsignacion.pCode1 = "sto;";
            puntero += 2;
            //sentenciaAsignacion.SoyDeTipoDato = TablaSimbolos.ObtenerTipoDato(sentenciaAsignacion.lexema, nombreClaseActiva, nombreMetodoActivo);
            sentenciaAsignacion.hijoIzquierdo = CrearArbolExpresion();

            return sentenciaAsignacion;

        }


        #endregion       
        #region Crear Arbol If
        public NodoArbol CrearArbolIF()
        {
            var nodoArbolIF = NuevoNodoSentencia(TipoSentencia.IF);
            puntero += 2;
            nodoArbolIF.hijoIzquierdo = CrearArbolCondicional();
            puntero += 2;

            //error cuando no hay comandos cuando la condicional es verdadera
            // validar que exista codigo en el TRUE
            nodoArbolIF.hijoCentro = ObtenerSiguienteArbol();
            puntero += 2;
            //codigo cuando sea falso


            if (miListaTokenTemporal[puntero].Linea.Equals("else"))  // cambiar por el numero de token
            {
                puntero++;
                if (miListaTokenTemporal[puntero].Linea.Equals("if")) // cambiar por el numero de token
                {
                    CrearArbolIF();
                }
                else
                {
                    puntero++;
                    nodoArbolIF.hijoDerecho = ObtenerSiguienteArbol();
                }
            }

            return nodoArbolIF;
        }


        #endregion
        #region Crear Arbol Condicional 
        public NodoArbol CrearArbolCondicional()
        {
            NodoArbol nodoRaiz = CrearArbolExpresion();
            if (miListaTokenTemporal[puntero].Linea.Equals("==")
                || miListaTokenTemporal[puntero].Linea.Equals("<=")
                || miListaTokenTemporal[puntero].Linea.Equals(">=")
                || miListaTokenTemporal[puntero].Linea.Equals(">")
                || miListaTokenTemporal[puntero].Linea.Equals("<"))
            {
                NodoArbol nodoTemp = NuevoNodoCondicional();

                switch (miListaTokenTemporal[puntero].TextoLexema)
                {
                    case "==":
                        nodoTemp.soyOperacionCondicionaDeTipo = OperacionCondicional.IgualIgual;
                        break;
                    case "<=":
                        nodoTemp.soyOperacionCondicionaDeTipo = OperacionCondicional.MenorIgualQue;
                        break;
                    case ">=":
                        nodoTemp.soyOperacionCondicionaDeTipo = OperacionCondicional.MayorIgualQue;
                        break;
                    case ">":
                        nodoTemp.soyOperacionCondicionaDeTipo = OperacionCondicional.MayorQue;
                        break;
                    case "<":
                        nodoTemp.soyOperacionCondicionaDeTipo = OperacionCondicional.MenorQue;
                        break;
                    default:
                        break;
                }
                nodoTemp.hijoIzquierdo = nodoRaiz;
                nodoRaiz = nodoTemp;
                puntero++;
                nodoRaiz.hijoDerecho = CrearArbolExpresion();
            }

            return nodoRaiz;
        }
        #endregion        
        #region Crear Arbol For

        private NodoArbol CrearArbolFor()
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Crear Arbol de Escritura
        private NodoArbol CrearNodoEscritura()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Crear Arbol Lectura
        private NodoArbol CrearNodoLectura()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Crear diferentes tipos de NodoArbol
        public NodoArbol NuevoNodoExpresion(tipoExpresion tipoExpresion)
        {
            NodoArbol nodo = new NodoArbol();

            nodo.soyDeTipoNodo = TipoNodoArbol.Expresion;

            nodo.SoyDeTipoExpresion = tipoExpresion;
            nodo.soyDeTipoOperacion = tipoOperador.NADA;
            nodo.SoyDeTipoDato = TipoDato.Nada;

            nodo.soySentenciaDeTipo = TipoSentencia.NADA;
            nodo.soyOperacionCondicionaDeTipo = OperacionCondicional.NADA;
            nodo.tipoValorNodoHijoDerecho = TipoDato.Nada;
            nodo.soyOperacionCondicionaDeTipo = OperacionCondicional.NADA;
            nodo.tipoValorNodoHijoIzquierdo = TipoDato.Nada;
            return nodo;
        }
        public NodoArbol NuevoNodoSentencia(TipoSentencia tipoSentencia)
        {
            NodoArbol nodo = new NodoArbol();
            nodo.soyDeTipoNodo = TipoNodoArbol.Sentencia;
            nodo.soySentenciaDeTipo = tipoSentencia;

            nodo.SoyDeTipoExpresion = tipoExpresion.NADA;
            nodo.soyDeTipoOperacion = tipoOperador.NADA;
            nodo.SoyDeTipoDato = TipoDato.Nada;


            nodo.soyOperacionCondicionaDeTipo = OperacionCondicional.NADA;
            nodo.tipoValorNodoHijoDerecho = TipoDato.Nada;
            nodo.soyOperacionCondicionaDeTipo = OperacionCondicional.NADA;
            nodo.tipoValorNodoHijoIzquierdo = TipoDato.Nada;
            return nodo;

        }
        public NodoArbol NuevoNodoCondicional()
        {
            NodoArbol nodo = new NodoArbol();
            nodo.soyDeTipoNodo = TipoNodoArbol.Condicional;

            nodo.SoyDeTipoExpresion = tipoExpresion.NADA;
            nodo.soyDeTipoOperacion = tipoOperador.NADA;
            nodo.SoyDeTipoDato = TipoDato.Nada;

            nodo.soySentenciaDeTipo = TipoSentencia.NADA;
            nodo.soyOperacionCondicionaDeTipo = OperacionCondicional.NADA;
            nodo.soyOperacionCondicionaDeTipo = OperacionCondicional.NADA;
            nodo.tipoValorNodoHijoDerecho = TipoDato.Nada;
            nodo.tipoValorNodoHijoIzquierdo = TipoDato.Nada;
            return nodo;

        }

        #endregion


    }
}
