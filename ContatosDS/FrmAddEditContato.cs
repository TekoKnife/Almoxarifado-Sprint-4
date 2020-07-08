using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TooSharp.Models;
using System.Text.RegularExpressions;

namespace ContatosDS
{
    public partial class FrmAddEditContato : Form
    {
        Contato _Contrato = null;
        public FrmAddEditContato()
        {
            InitializeComponent();
            label1.Text = "Add Contato";
        }

        /// <summary>
        /// Conecção com o Banco de Dados
        /// </summary>
        /// <param name="contrato"></param>
        public FrmAddEditContato(Contato contrato)
        {
            InitializeComponent();
            button1.Text = "Salvar";
            button2.Visible = true;
            _Contrato = contrato;
            label1.Text = "Editar Contato";
            //Validação
            _Contrato.onValidationError += Contato_onValidationError;
            textBox1.Text = _Contrato.Nome;
            textBox2.Text = _Contrato.Sobrenome;
            textBox3.Text = _Contrato.Email;
            textBox4.Text = _Contrato.Celular;
            textBox5.Text = _Contrato.CNPJ;
        }
        
        /// <summary>
        /// Para mostrar o erro e tempo que aconteceu
        /// </summary>
        /// <param name="Error"></param>
        void ShowError(string Text)
        {
            label7.Text = Text;
            panel3.Visible = true;
            timer1.Start();
        }

        private void tmrError_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            panel3.Visible = false;
        }

        

        // criando e atualizando usando toosharp
        private void button2_Click(object sender, EventArgs e)
        {
            if (_Contrato == null)
            {
                //new contact
                Contato contact = new Contato()
                {
                    Nome = textBox1.Text,
                    Sobrenome = textBox2.Text,
                    Email = textBox3.Text,
                    Celular = textBox4.Text,
                    CNPJ = textBox5.Text
                };

                //Validation
                contact.onValidationError += Contato_onValidationError;

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Preencher o campo Nome");
                    return;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Preencher o campo Sobrenome");
                    return;
                }
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Preencher o campo Email");
                    return;
                }
                if (textBox4.Text == "")
                {
                    MessageBox.Show("Preencher o campo Celular");
                    return;
                }
                if (textBox5.Text == "")
                {
                    MessageBox.Show("Preencher o campo CNPJ");
                    return;
                }
                
                    

                //save
                if (contact.Save() > 0) MessageBox.Show("Contato Salvo");
                {
                    MessageBox.Show("Contato Salvo");
                    this.Close();
                }
            }
            else
            {
                //update contact
                _Contrato.Nome = textBox1.Text;
                _Contrato.Sobrenome = textBox2.Text;
                _Contrato.Email = textBox3.Text;
                _Contrato.Celular = textBox4.Text;
                _Contrato.CNPJ = textBox5.Text;
                //save
                if (_Contrato.Save() > 0) MessageBox.Show("Contato Atualizado");
                {
                    MessageBox.Show("Contato Atualizado");
                    this.Close();   
                }
            }
        }

        

        private void Contato_onValidationError(object sender, TooSharp.Core.TsExeptionArgs e)
        {
            ShowError(e.exception.Message);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void FrmAddEditContato_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {            
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {                
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox3_Validated(object sender, EventArgs e)
        {
            string text = textBox3.Text;

            bool valor = text.Contains("@") && text.Contains(".com");

            if (valor == true)
            {
                MessageBox.Show("Email valido");
            }
            else
            {
                MessageBox.Show("Email invalido");
            }
        }
    }
}
