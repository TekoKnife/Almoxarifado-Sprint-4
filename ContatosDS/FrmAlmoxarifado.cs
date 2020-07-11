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

namespace ContatosDS
{
    public partial class FrmAlmoxarifado : Form
    {
        public FrmAlmoxarifado()
        {
            InitializeComponent();
        }

        private void FrmAlmoxarifado_Load(object sender, EventArgs e)
        {

        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Abrir o painel para cadastrar o produto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            new FrmAddEditProdutos().ShowDialog();
            ReloadData();
        }

        /// <summary>
        /// Função para procurar os dados cadastrados
        /// </summary>
        void ReloadData()
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                //serch data
                PopulateData(Almoxarifados.Records()
                    .Where(Almoxarifados.COLUMNS.Produto, "LIKE", "%" + textBox1.Text + "%")
                    .Get());
            }
            else
            {
                //fetch all data
                PopulateData(Almoxarifados.Records().Get());
            }
        }

        /// <summary>
        /// Puxando os categorias da tabela e criando uma ligação com banco de dados
        /// </summary>
        /// <param name="Almoxarifado"></param>
        void PopulateData(IEnumerable<Almoxarifado> Almoxarifado)
        {
            table.Rows.Clear();
            foreach (var c in Almoxarifado)
            {
                table.Rows.Add(new object[]{
                    c.Codigo,
                    c.Produto,
                    c.Quantidade,
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
        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
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
        private void FrmAlmoxarifado_Shown(object sender, EventArgs e)
        {
            ReloadData();
        }

        /// <summary>
        /// Recarregar o painel caso não tenha aparecido o produto novo
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
        private void table_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) //edit
            {
                new FrmAddEditProdutos((Almoxarifado)table.CurrentRow.Tag).ShowDialog();
                ReloadData();
            }
            if (e.ColumnIndex == 4) //delete
            {
                Almoxarifado almoxarifados = (Almoxarifado)table.CurrentRow.Tag;
                if (MessageBox.Show("Delete " + almoxarifados.Produto + "?", "CONFIRM", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    almoxarifados.Delete();
                    ReloadData();
                }
            }
        }
    }
}
