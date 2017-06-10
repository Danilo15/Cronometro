using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaCusto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            dgvLista.Rows.Add(txtNome.Text,txtValor.Text);

            txtNome.Text = string.Empty;
            txtValor.Text = string.Empty;

            txtNome.Focus();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            txtValor.Text = Dinheiro(txtValor.Text);
            txtValor.SelectionStart = txtValor.Text.Length;
            txtValor.SelectionLength = txtValor.Text.Length;
        }

        public string Dinheiro(string entrada)
        {
            entrada = PermiteChar(entrada, "0123456789");
            while (entrada.IndexOf("0") == 0) entrada = entrada.Substring(1, entrada.Length - 1);
            while (entrada.Length < 3) entrada = "0" + entrada;
            entrada = entrada.Substring(0, entrada.Length - 2) + "," + entrada.Substring(entrada.Length - 2, 2);

            return entrada;
        }

        public string PermiteChar(string Entrada, string Caracteres)
        {
            string Retorno = "";

            for (int i = 0; i < Entrada.Length; i++)
                if (Caracteres.IndexOf(Entrada[i]) >= 0)
                    Retorno += Entrada[i];

            return Retorno;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            var rows = dgvLista.SelectedRows;

            foreach (DataGridViewRow item in rows)
            {
                dgvLista.Rows.Remove(item);
            }
        }
    }
}
