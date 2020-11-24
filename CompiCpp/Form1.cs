using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CompiCpp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       public List<NodoLexema> NodoLexemen = new List<NodoLexema>();
        FileStream fs;
        public String Entrada = "";
        StreamReader lector;
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtCodigo.Text = openFileDialog1.FileName;

                fs = new FileStream(txtCodigo.Text, FileMode.Open, FileAccess.Read);
                lector = new StreamReader(fs, Encoding.Default);
                txtCodigo.Text = lector.ReadToEnd();
                lector.Close();
                fs.Close();
            }
        }

        private void compilarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compilarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dgvTokens.Rows.Clear();
            string Entrada = txtCodigo.Text +" ";
            Lexico lexico = new Lexico();
            //List<ERRORES> error = new List<ERRORES>();
            List<Tokens> tokens = lexico.Detecta(Entrada);
            foreach (var item in tokens)
            {
                NodoLexemen.Add(crearNodo(item.getTipoToken().ToString(), item.getValor().ToString(), Convert.ToInt32(item.getRenglon()), Convert.ToInt32(item.getnumeroToken())));
                
            }
            foreach (NodoLexema lexema in NodoLexemen)
            {
                if (lexema.Linea >= 400)
                {
                    dgvErrores.Rows.Add(lexema.TextoLexema, lexema.Descripcion, lexema.Token, lexema.Linea);
                } else
                   dgvTokens.Rows.Add(lexema.TextoLexema, lexema.Descripcion, lexema.Token, lexema.Linea);

            }
     
            Sintactico sintactico = new Sintactico(NodoLexemen);
            MessageBox.Show(sintactico.Termino);
            listBox1.Items.Add(ERRORES.Display());
         
            NodoLexemen.Clear();

            
        }
        //Crear Nodo
        private NodoLexema crearNodo(string lexema, string descripcion, int token, int linea)
        {
            NodoLexema l = new NodoLexema();
            l.TextoLexema = lexema;
            l.Descripcion = descripcion;
            l.Token = token;
            l.Linea = linea;
            return l;
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
