﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TooSharp.Models;
namespace ContatosDS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Abrir o painel para cadastrar o cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            new FrmAddEditContato().ShowDialog();
            ReloadData();
        }

        /// <summary>
        /// Função para procurar os dados cadastrados
        /// </summary>
        void ReloadData()
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                //procurar data
                PopulateData(Contatos.Records()
                    .Where(Contatos.COLUMNS.Nome, "LIKE", "%" + textBox1.Text + "%")
                    .Get());
            }
            else
            {
                //fetch all data
                PopulateData(Contatos.Records().Get());
            }
        }

        /// <summary>
        /// Puxando os categorias da tabela e criando uma ligação com banco de dados
        /// </summary>
        /// <param name="Contrato"></param>
        void PopulateData(IEnumerable<Contato> Contrato)
        {
            table.Rows.Clear();
            foreach (var c in Contrato)
            {
                table.Rows.Add(new object[]{
                    c.ID,
                    c.Nome,
                    c.Sobrenome,
                    c.Email,
                    c.Celular,
                    c.CNPJ,
                    "Edit",
                    "Delete"
                });
                table.Rows[table.RowCount - 1].Tag = c;
            }
        }

        /// <summary>
        /// Regarrega automatico para a aparição dos dados na tabela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ReloadData();
        }

        /// <summary>
        /// Botão de busca do contato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        { 
            ReloadData();
        }

        /// <summary>
        /// Regarrega automatico para a aparição dos dados na tabela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            ReloadData();
        }

        /// <summary>
        /// Recarregar o painel caso não tenha aparecido o contato novo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            ReloadData();
        }

        /// <summary>
        /// Função dos 2 botões que tem na tabela Editar/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6) //edit
            {
                new FrmAddEditContato((Contato)table.CurrentRow.Tag).ShowDialog();
                ReloadData();
            }
            if (e.ColumnIndex == 7) //delete
            {
                Contato contatos = (Contato)table.CurrentRow.Tag;
                if (MessageBox.Show("Delete " + contatos.Nome + "?", "CONFIRM", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    contatos.Delete();
                    ReloadData();
                }
            }
        }

        /// <summary>
        /// Abrir o painel do Almoxarifado 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            new FrmAlmoxarifado().ShowDialog();
        }
    }
}
