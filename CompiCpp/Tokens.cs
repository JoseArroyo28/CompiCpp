using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiCpp
{
    public class Tokens
    {
        Lexico lx = new Lexico();
        public int numeroToken;
        String[] palabrasReservadas = new string[] { "asm", "else", "new", "this", "auto", "enum", "operator", "throw", "bool", "explicit", "private", "true", "break", "export", "protected", "try", "case", "extern", "public", "typedef", "catch", "false", "register", "typeid", "char", "float", "reinterpret_cast", "typename", "class", "for", "return", "union", "const", "friend", "short", "unsigned", "const_cast", "goto", "signed", "using", "continue", "if", "sizeof", "virtual", "default", "inline", "static", "void", "delete", "int", "static_cast", "volatile", "do", "long", "struct", "wchar_t", "double", "mutable", "switch", "while", "dynamic_cast", "namespace", "template", "#include", "string", "std", "cout", "cin" };
        public String[] Errorres = new string[] { "Numero No Valido", "Salto de Linea Inesperado", "Se Esperar Cerrar Las comillas", "Caracter No Valido", "Falta Apostrofe", "Falto Cerrar Comentario" };
        public enum Token
        {
            Id,
            NumeroE,
            NumeroD,
            Cadena,
            Caracter,
            Coma,
            Punto,
            DosPuntos,
            PuntoComa,
            //***************
            SignoMas,
            MasMas,
            MasIgual,
            SignoMenos,
            MenosMenos,
            MenosIgual,
            //******************
            //*********************
            Asterisco,
            AsteriscoIgual,
            /// <summary>
            /// 
            /// </summary>
            DiagonalDiv,
            DiagonalIgual,
            Comentario,
            /// <summary>
            /// 
            /// </summary>
            Porcentaje,
            PorcentajeIgual,
            //**********************
            Igual,
            IgualIgual,
            //*********************
            MayorQue,
            MayorigualQue,
            MayorQue2,
            //********************
            MenorQue,
            MenorQue2,
            MenorIgualQue,
            //***********************
            Admiracion,
            Diferente,
           ///...............
            And,
            DobleAnd,
            //.......
            Barra,
            Or, 
            //...........
            Hat,
            CorcheteIzq,
            CorcheteDer,
            LlaveIzq,
            LlaveDer,
            ParentesisIzq,
            ParentesisDer,
            Tilde,
            Noexiste,
            ErrorNum,
            SaltoLinea,
            FaltaApostrofe,
            ComentarioError
        }
        Token tipoToken;
        String valorToken;
        int Renglon;
        public Tokens(Token tipoDeToken, String valorToken, int Renglon, int numeroToken)
        {
            this.tipoToken = tipoDeToken;
            this.valorToken = valorToken;
            this.Renglon = Renglon;
        }
        public string getValor()
        {
            return valorToken;
        }
        public int getRenglon()
        {
            return Renglon;
        }
        public int getnumeroToken()
        {
            return numeroToken;
        }
        public string getTipoToken()
        {
            switch (tipoToken)
            {
                case Token.Id:

                    int i = 0;
                    while (i < palabrasReservadas.Length)
                    {
                        if (valorToken == palabrasReservadas[i])
                        {
                            numeroToken = -100 - i;
                            return "Palabra Reservada";
                        }
                        i++;
                    }
                    numeroToken = -1;
                    return "Identificador";
                case Token.NumeroE:
                    numeroToken = -2;
                    return "Numero Entero";
                case Token.NumeroD:
                    numeroToken = -3;
                    return "Numero Decimal";
                case Token.SignoMas:
                    numeroToken = -4;
                    return "Signo Más";
                case Token.SignoMenos:
                    numeroToken = -5;
                    return "Signo Menos";
                case Token.Asterisco:
                    numeroToken = -6;
                    return "Asterisco";
                case Token.DiagonalDiv:
                    numeroToken = -7;
                    return "Diagonal";
                case Token.Porcentaje:
                    numeroToken = -8;
                    return "Modulo";
                case Token.MasMas:
                    numeroToken = -9;
                    return "Incremento";
                case Token.MenosMenos:
                    numeroToken = -10;
                    return "Decremento";
                case Token.IgualIgual:
                    numeroToken = -11;
                    return "Igual Comparacion";
                case Token.Diferente:
                    numeroToken = -12;
                    return "Diferente a ";
                case Token.MayorQue:
                    numeroToken = -13;
                    return "Mayor que";
                case Token.MenorQue:
                    numeroToken = -14;
                    return "Menor Que";
                
                case Token.MayorigualQue:
                    numeroToken = -15;
                    return " Mayor Igual A";
                case Token.MenorIgualQue:
                    numeroToken = -16;
                    return "Manoy Igual A";

                case Token.DobleAnd:
                    numeroToken = -17;
                    return "Doble & (&&)";
                case Token.Or:
                    numeroToken = -18;
                    return "Doble Barra (||)";
                case Token.Admiracion:
                    numeroToken = -19;
                    return "Signo Admiracion";
                case Token.MenorQue2:
                    numeroToken = -20;
                    return "Operador De Cambio Izquierdo";
                case Token.MayorQue2:
                    numeroToken = -21;
                    return "Operador De Cambio Derecho";
                case Token.Tilde:
                    numeroToken = -22;
                    return "Tilde";
                case Token.And:
                    numeroToken = -23;
                    return "& Sencillo";
                case Token.Hat:
                    numeroToken = -24;
                    return "acento circunflejo";
               
                case Token.Barra:
                    numeroToken = -25;
                    return "Barra Sencilla";
               
                case Token.Igual:
                    numeroToken = -26;
                    return "Asignacion =";
                case Token.MasIgual:
                    numeroToken = -27;
                    return "Mas Igual";
                case Token.MenosIgual:
                    numeroToken = -28;
                    return "Menos Igual";
                case Token.AsteriscoIgual:
                    numeroToken = -29;
                    return "Asterisco Igual";
                case Token.DiagonalIgual:
                    numeroToken = -30;
                    return "Diagonal Igual";
                case Token.PorcentajeIgual:
                    numeroToken = -31;
                    return "Modulo Igual";

                case Token.Coma:
                    numeroToken = -32;
                    return "Coma";
                case Token.Punto:
                    numeroToken = -33;
                    return "Punto";
                case Token.Cadena:
                    numeroToken = -34;
                    return "Cadena";
                case Token.Caracter:
                    numeroToken = -35;
                    return "Caracter";
                case Token.DosPuntos:
                    numeroToken = -36;
                    return "Dos Puntos";
                case Token.PuntoComa:
                    numeroToken = -37;
                    return "Punto y Coma";
                case Token.ParentesisIzq:
                    numeroToken = -38;
                    return "Parentesis Izquierdo";
                case Token.ParentesisDer:
                    numeroToken = -39;
                    return "Parentesis Derecho";
                case Token.CorcheteIzq:
                    numeroToken = -40;
                    return "Corchete Izquierdo";
                case Token.CorcheteDer:
                    numeroToken = -41;
                    return "Corchete Derecho";
                case Token.LlaveIzq:
                    numeroToken = -42;
                    return "Llave Izquierda";
                case Token.LlaveDer:
                    numeroToken = -43;
                    return "Llave Derecha";
                case Token.Comentario:
                    return "Comentario";
                case Token.Noexiste:
                    numeroToken = 404;
                    return Errorres[3];
                case Token.ErrorNum:
                    numeroToken = 400;
                    return Errorres[0];
                case Token.SaltoLinea:
                    numeroToken = 402;
                    return Errorres[1];
                case Token.FaltaApostrofe:
                    numeroToken = 403;
                    return Errorres[4];
                case Token.ComentarioError:
                    numeroToken = 404;
                    return Errorres[5];
                default:
                    numeroToken = 504;
                    return "Caracter No Valido";
            }
        }
    }
}
