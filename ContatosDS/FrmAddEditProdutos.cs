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
    public partial class FrmAddEditProdutos : Form
    {
        Almoxarifado _Almoxarifado = null;
        /// <summary>
        /// Inicia a interface e muda o titulo
        /// </summary>
        public FrmAddEditProdutos()
        {
            InitializeComponent();
            label1.Text = "Add Produto";
        }

        /// <summary>
        /// Alterações no botão de salvar/editar e conecção com o banco de dados
        /// </summary>
        /// <param name="almoxarifado"></param>
        public FrmAddEditProdutos(Almoxarifado almoxarifado)
        {
            InitializeComponent();
            button1.Text = "Salvar";
            button2.Visible = true;
            _Almoxarifado = almoxarifado;
            label1.Text = "Editar Produto";
            //Validação
            _Almoxarifado.onValidationError += Almoxarifado_onValidationError;
            textBox1.Text = _Almoxarifado.Produto;
            textBox2.Text = _Almoxarifado.Quantidade;
            
        }
        /// <summary>
        /// Para mostrar o erro e tempo que aconteceu
        /// </summary>
        /// <param name="Text"></param>
        void ShowError(string Text)
        {
            label7.Text = Text;
            panel2.Visible = true;
            timer1.Start();
        }

        /// <summary>
        /// Caso ocorra um erro ele para o timer e fecha a interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrError_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            panel2.Visible = false;
        }


        private void FrmAddEditProdutos_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Criando e atualizando o banco de dados usando TooSharp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (_Almoxarifado == null)
            {
                //new contact
                Almoxarifado almoxarifado = new Almoxarifado()
                {
                    Produto = textBox1.Text,
                    Quantidade = textBox2.Text
                };

                //Validation
                almoxarifado.onValidationError += Almoxarifado_onValidationError;

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Preencher o campo Produto");
                    return;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Preencher o campo Quantidade");
                    return;
                }
                



                //save
                if (almoxarifado.Save() > 0) MessageBox.Show("Produto Salvo");
                {
                    
                    this.Close();
                }
            }
            else
            {
                //update contact
                _Almoxarifado.Produto = textBox1.Text;
                _Almoxarifado.Quantidade = textBox2.Text;
                
                //save
                if (_Almoxarifado.Save() > 0) MessageBox.Show("Produto Atualizado");
                {
                    MessageBox.Show("Produto Atualizado");
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Validação do banco de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Almoxarifado_onValidationError(object sender, TooSharp.Core.TsExeptionArgs e)
        {
            ShowError(e.exception.Message);
        }

        /// <summary>
        /// Limitando o usuario a apenas colocar letras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        /// <summary>
        /// Limitando o usuario a apenas colocar numero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
