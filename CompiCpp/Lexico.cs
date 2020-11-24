using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiCpp
{
    public class Lexico
    {
       List<Tokens> Salida;
        int estado;
        String Lexema;
        public int Renglon = 1, numeroToken;

        public List<Tokens> Detecta(String Entrada)
        {
            Salida = new List<Tokens>();

            estado = 0;
            Lexema = "";
            Char c;
            for (int i = 0; i < Entrada.Length; i++)
            {
                c = Entrada.ElementAt(i);
                switch (estado)
                {
                    case 0:
                        if (c.CompareTo(',') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.Coma);
                        }
                        else if (c.CompareTo('.') == 0)
                        {
                            estado = 3;
                            Lexema += c;
                        }
                        else if (c.CompareTo(':') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.DosPuntos);
                        }
                        else if (c.CompareTo('#')==0)
                        {
                            Lexema += c;
                            estado = 23;
                        }
                        else if (c.CompareTo(';') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.PuntoComa);
                        }
                        else if (c.CompareTo('^') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.Hat);
                        }
                        else if (c.CompareTo('[') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.CorcheteIzq);
                        }
                        else if (c.CompareTo(']') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.CorcheteDer);
                        }
                        else if (c.CompareTo('{') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.LlaveIzq);
                        }
                        else if (c.CompareTo('}') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.LlaveDer);
                        }
                        else if (c.CompareTo('(') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.ParentesisIzq);
                        }
                        else if (c.CompareTo(')') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.ParentesisDer);
                        }
                        else if (c.CompareTo('~') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.Tilde);
                        }
                        else if (char.IsLetter(c) || c.CompareTo('_') == 0)
                        {
                            estado = 1;
                            Lexema += c;
                        }
                        else if (Entrada.ElementAt(i) == '\t')
                        {
                            estado = 0;
                        }
                        else if (char.IsNumber(c))
                        {
                            estado = 2;
                            Lexema += c;
                        }
                        else if (c.CompareTo('"') == 0)
                        {
                            estado = 5;
                            Lexema += c;
                        }
                        // Apostrofe
                        else if (Entrada.ElementAt(i) == 39)
                        {
                            estado = 6;
                            Lexema += c;
                        }
                        else if (c.CompareTo('+') == 0)
                        {
                            Lexema += c;
                            estado = 7;
                        }
                        else if (c.CompareTo('-') == 0)
                        {
                            Lexema += c;
                            estado = 8;
                        }
                        else if (c.CompareTo('*') == 0)
                        {
                            Lexema += c;
                            estado = 9;
                        }
                        else if (c.CompareTo('/') == 0)
                        {
                            Lexema += c;
                            estado = 10;
                        }
                        else if (c.CompareTo('%') == 0)
                        {
                            estado = 14;
                            Lexema += c;
                        }
                        else if (c.CompareTo('=') == 0)
                        {
                            estado = 15;
                            Lexema += c;
                        }
                        else if (c.CompareTo('>') == 0)
                        {
                            estado = 16;
                            Lexema += c;
                        }
                        else if (c.CompareTo('<') == 0)
                        {
                            estado = 17;
                            Lexema += c;
                        }
                        else if (c.CompareTo('!') == 0)
                        {
                            estado = 18;
                            Lexema += c;
                        }
                        else if (c.CompareTo('&') == 0)
                        {
                            estado = 19;
                            Lexema += c;
                        }
                        else if (c.CompareTo('|') == 0)
                        {
                            estado = 20;
                            Lexema += c;
                        }
                        //Salto d elinea Conteo de renglon
                        else if (Entrada.ElementAt(i) == 10)
                            Renglon++;
                        else if (Entrada.ElementAt(i) == 32)
                            estado = 0;
                        else
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.Noexiste);
                        }
                        break;
                    case 1:
                        if (char.IsLetter(c) || c.CompareTo('_') == 0 || char.IsNumber(c))
                        {
                            estado = 1;
                            Lexema += c;
                        }
                        else
                        {
                            i--;
                            agregarToken(Tokens.Token.Id);
                        }                        break;
                    case 2:
                        if (char.IsNumber(c))
                        {
                            estado = 2;
                            Lexema += c;
                        }
                        else if (c.CompareTo('.') == 0)
                        {
                            estado = 3;
                            Lexema += c;
                        }
                        else
                        {
                            i--;
                            agregarToken(Tokens.Token.NumeroE);
                        }
                        break;
                    case 3:
                        if (char.IsNumber(c))
                        {
                            Lexema += c;
                            estado = 4;
                        }
                        else if (Char.IsNumber((Entrada.ElementAt(i - 2))))
                        {
                            i--;
                            Lexema += c;
                            estado = 22;
                        }
                        else
                        {
                            agregarToken(Tokens.Token.Punto);
                            i--;
                        }
                        break;
                    case 4:
                        if (char.IsNumber(c))
                        {
                            Lexema += c;
                        }
                        else if (c.CompareTo('.')==0)
                        {
                            Lexema += c;
                            estado = 22 ;
                        }
                        else
                        {
                            agregarToken(Tokens.Token.NumeroD);
                            i--;
                        }
                        break;
                    case 5:
                        if (c.CompareTo('"')==0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.Cadena);
                        }
                        //Salto de Linea
                        else if (Entrada.ElementAt(i)==10)
                        {
                            agregarToken(Tokens.Token.SaltoLinea);
                        }
                        else
                        {
                            Lexema += c;
                        }
                        break;
                    case 6:
                        if (char.IsControl(c)||Char.IsLetterOrDigit(c)||Char.IsSymbol(c))
                        {
                            Lexema += c;
                            estado =21;
                        }
                        break;
                    case 7:
                        if (c.CompareTo('+') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.MasMas);
                        }
                        else if (c.CompareTo('=') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.MasIgual);
                        }
                        else
                        {
                            i--;
                            agregarToken(Tokens.Token.SignoMas);
                        }
                        break;
                    case 8:
                        if (c.CompareTo('-') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.MenosMenos);
                        }
                        else if (c.CompareTo('=') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.MenosIgual);
                        }
                        else
                        {
                            i--;
                            agregarToken(Tokens.Token.SignoMenos);
                        } 
                        break;
                    case 9:
                        if (c.CompareTo('=') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.AsteriscoIgual);
                        }
                        else
                        {
                            i--;
                            agregarToken(Tokens.Token.Asterisco);
                        }
                        break;
                    case 10:
                        if (c.CompareTo('=') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.DiagonalIgual);
                        }
                        else if (c.CompareTo('/') == 0)
                        {
                            estado = 11;
                            Lexema += c;
                        }
                        else if (c.CompareTo('*') == 0)
                        {
                            estado = 12;
                            Lexema += c;
                        }
                        else
                        {
                            i--;
                            agregarToken(Tokens.Token.DiagonalDiv);
                        }
                        break;
                    case 11:
                        //Salto de Linea
                        if (Entrada.ElementAt(i) == 10)
                        {
                            Lexema = "";
                            estado = 0;
                        }
                        else
                            Lexema += c;
                        break;
                    case 12:
                        if (c.CompareTo('*') == 0)
                        {
                            estado = 13;
                            Lexema += c;
                        }
                        else if (i==Entrada.Length-1)
                        {
                            agregarToken(Tokens.Token.ComentarioError);
                        }
                        else
                            Lexema += c;
                        break;
                    case 13:
                        if (c.CompareTo('/') == 0 )
                        {
                            Lexema = "";
                            estado = 0;
                        }
                        else if (i == Entrada.Length - 1)
                        {
                            agregarToken(Tokens.Token.ComentarioError);
                        }
                        else
                        {
                            estado = 12;
                            Lexema += c;
                        }
                        break;
                    case 14:
                        if (c.CompareTo('=') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.PorcentajeIgual);
                        }
                        else
                        {
                            i--;
                            agregarToken(Tokens.Token.Porcentaje);
                        }
                        break;
                    case 15:
                        if (c.CompareTo('=') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.IgualIgual);
                        }
                        else
                        {
                            i--;
                            agregarToken(Tokens.Token.Igual);
                        }
                        break;
                    case 16:
                        if (c.CompareTo('=') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.MayorigualQue);
                        }
                        else if (c.CompareTo('>') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.MayorQue2);
                        }
                        else
                        {
                            i--;
                            agregarToken(Tokens.Token.MayorQue);
                        }
                        break;
                    case 17:
                        if (c.CompareTo('=') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.MenorIgualQue);
                        }
                        else if (c.CompareTo('<') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.MenorQue2);
                        }
                        else
                        {
                            i--;
                            agregarToken(Tokens.Token.MenorQue);
                        }  
                        break;
                    case 18:
                        if (c.CompareTo('=') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.Diferente);
                        }
                        else
                        {
                            i--;
                            agregarToken(Tokens.Token.Admiracion);
                        }
                        break;
                    case 19:
                        if (c.CompareTo('&') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.DobleAnd);
                        }
                        else
                        {
                            i--;
                            agregarToken(Tokens.Token.And);
                        }
                           break;
                    case 20:
                        if (c.CompareTo('|') == 0)
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.Or);
                        }
                        else
                        {
                            i--;
                            agregarToken(Tokens.Token.Barra);
                        }
                           
                        break;
                    case 21:
                        if ((Entrada.ElementAt(i) == 39))
                        {
                            Lexema += c;
                            agregarToken(Tokens.Token.Caracter);
                        }
                        else
                        {
                            i--;    
                            agregarToken(Tokens.Token.FaltaApostrofe);
                        }
                        break;
                    case 22:
                        if ((Entrada.ElementAt(i) == '.')||Char.IsLetter(c) || Char.IsNumber(c))
                        {
                            Lexema += c;
                        }
                        else
                        {
                            i--;
                            agregarToken(Tokens.Token.ErrorNum);
                        }
                        break;
                    case 23:
                        if (Char.IsLetter(c))
                        {
                            Lexema += c;
                        }
                        else if (Lexema == "#include")
                        {
                            agregarToken(Tokens.Token.Id);
                            i--;
                        }
                        else
                        {
                            agregarToken(Tokens.Token.Noexiste);
                        }
                        break;
                }
            }
            return Salida;
        }
        public void agregarToken(Tokens.Token tipo)
        {
            Salida.Add(new Tokens(tipo, Lexema, Renglon, numeroToken));
            Lexema = "";
            estado = 0;
        }
    }
}
