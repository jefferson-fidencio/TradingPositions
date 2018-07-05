using OperationsWF;
using Positions.UI.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Positions.UI
{
    public partial class ClosePositionForm : Form
    {
        private PanelOperacoes pnlOperacoes;

        public ClosePositionForm()
        {
            InitializeComponent();
        }

        public ClosePositionForm(PanelOperacoes form1)
        {
            InitializeComponent();
            this.pnlOperacoes = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlOperacoes.resultadoDialogs = DynamicDB.resultados[0];
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlOperacoes.resultadoDialogs = DynamicDB.resultados[2];
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            pnlOperacoes.resultadoDialogs = DynamicDB.resultados[1];
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlOperacoes.resultadoDialogs = DynamicDB.resultados[3];
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnlOperacoes.resultadoDialogs = DynamicDB.resultados[4];
            this.Close();

        }
    }
}
