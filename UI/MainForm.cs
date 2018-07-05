using OperationsWF.Model;
using Positions.UI;
using Positions.UI.Panels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OperationsWF
{
    public partial class Form1 : Form
    {
        private PanelOperacoes MyPositionsPanel;
        private PanelConfigs MyConfigsPanel;
        private PanelGanhos MyGanhosPanel;

        public Form1()
        {
            CarregarXml();

            InitializeComponent();

            this.MyPositionsPanel = new PanelOperacoes(labelSaldo);
            this.MyConfigsPanel = new PanelConfigs();
            this.MyGanhosPanel = new PanelGanhos();

            this.Controls.Add(this.MyPositionsPanel);
            this.Controls.Add(this.MyConfigsPanel);
            this.Controls.Add(this.MyGanhosPanel);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelMenuLateral);

            try
            {
                labelSaldo.Text = Program.myHistory.saldo;
            }
            catch (System.Exception)
            {
                labelSaldo.Text = "0.00000000";
            }
        }

        private void CarregarXml()
        {
            try
            {

                XmlSerializer serializer = new XmlSerializer(typeof(History));
                string fileName = System.IO.Path.Combine(Application.CommonAppDataPath, "positions.xml");
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    Program.myHistory = (History)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                Program.myHistory = new History();
            }
        }

        private void menuMinhasOperacoesClick(object sender, EventArgs e)
        {
            MyPositionsPanel.Visible = true;
            MyConfigsPanel.Visible = false;

            ((Label)panelHeader.Controls[0].Controls[1]).Text = "Minhas Posições";
            ((PictureBox)panelHeader.Controls[0].Controls[0]).BackgroundImage = global::Positions.Properties.Resources._1530077_32;


        }

        private void menuConfiguracoesClick(object sender, EventArgs e)
        {
            MyPositionsPanel.Visible = false;
            MyConfigsPanel.Visible = true;

            ((Label)panelHeader.Controls[0].Controls[1]).Text = "Configurações";
            ((PictureBox)panelHeader.Controls[0].Controls[0]).BackgroundImage = global::Positions.Properties.Resources._430115_32;

        }

        private void menuGanhosClick(object sender, EventArgs e)
        {
            MyPositionsPanel.Visible = false;
            MyConfigsPanel.Visible = false;
            MyGanhosPanel.Visible = true;

            ((Label)panelHeader.Controls[0].Controls[1]).Text = "Meus Ganhos";
            ((PictureBox)panelHeader.Controls[0].Controls[0]).BackgroundImage = global::Positions.Properties.Resources._309025_32;

        }
    }
}
