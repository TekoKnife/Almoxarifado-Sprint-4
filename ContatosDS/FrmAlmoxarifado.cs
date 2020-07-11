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

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmAddEditProdutos().ShowDialog();
            ReloadData();
        }

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

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ReloadData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void FrmAlmoxarifado_Shown(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            ReloadData();
        }

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
