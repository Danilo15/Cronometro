using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConversorGastoHoras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal valorHora = txtValorPorHora.Value;
            decimal valorProduto = txtValorProduto.Value;
            decimal valorObtido = 0;
            int horas = 0;

            while(valorObtido < valorProduto)
            {
                valorObtido += valorHora;
                horas++;
            }

            string resultado = string.Format("Para você obter o produto de valor: R${0}, você precisará\ntrabalhar {1} hora(s), obtendo o total de R${2}", valorProduto.ToString("N2"), horas, valorObtido.ToString("N2"));
            lblResultado.Text = resultado;
        }
    }
}
