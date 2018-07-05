using OperationsWF;
using OperationsWF.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Positions.UI.Panels
{
    public class PanelOperacoes : Panel
    {
        Label SaldoParentUI;
        TabControl tabControlOperacoes = new TabControl();

        public String resultadoDialogs = "";
        ArrayList labelsDuracao = new ArrayList();
        System.Windows.Forms.Timer timerAtualizarDuracaoLabels = new System.Windows.Forms.Timer();

        public PanelOperacoes(Label SaldoParentUI)
        {
            this.SaldoParentUI = SaldoParentUI;
            DrawPanel();
            CarregarPosicoes();
        }

        private void CarregarPosicoes()
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

            foreach (Position position in Program.myHistory.positions)
            {
                position.calculaValores();
                DesenhaPosicao(position);
            }

            timerAtualizarDuracaoLabels.Interval = 60 * 1000;
            timerAtualizarDuracaoLabels.Tick += TimerAtualizarDuracaoLabels_Tick;
            timerAtualizarDuracaoLabels.Start();
            AtualizarDuracaoLabels();
        }

        private void TimerAtualizarDuracaoLabels_Tick(object sender, EventArgs e)
        {
            AtualizarDuracaoLabels();
        }

        private void DrawPanel()
        {
            // 
            // OperarPage
            // 
            TabPage OperarPage = new TabPage();
            OperarPage.Dock = System.Windows.Forms.DockStyle.Fill;
            OperarPage.Location = new System.Drawing.Point(210, 48);
            OperarPage.Name = "OperarPage";
            OperarPage.Size = new System.Drawing.Size(729, 489);
            OperarPage.TabIndex = 2;
            // 
            // tabPageAbertas
            // 
            TabPage tabPageAbertas = new TabPage();
            tabPageAbertas.AutoScroll = true;
            tabPageAbertas.Location = new System.Drawing.Point(4, 22);
            tabPageAbertas.Name = "tabPageAbertas";
            tabPageAbertas.Size = new System.Drawing.Size(701, 371);
            tabPageAbertas.TabIndex = 0;
            tabPageAbertas.Text = "Abertas";
            tabPageAbertas.UseVisualStyleBackColor = true;
            // 
            // tabPageFechadas
            // 
            TabPage tabPageFechadas = new TabPage();
            tabPageFechadas.AutoScroll = true;
            tabPageFechadas.Location = new System.Drawing.Point(4, 22);
            tabPageFechadas.Name = "tabPageFechadas";
            tabPageFechadas.Size = new System.Drawing.Size(701, 371);
            tabPageFechadas.TabIndex = 0;
            tabPageFechadas.Text = "Fechadas";
            tabPageFechadas.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControlOperacoes.Controls.Add(tabPageAbertas);
            tabControlOperacoes.Controls.Add(tabPageFechadas);
            tabControlOperacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlOperacoes.Location = new System.Drawing.Point(5, 5);
            tabControlOperacoes.Name = "tabControlOperacoes";
            tabControlOperacoes.SelectedIndex = 0;
            tabControlOperacoes.Size = new System.Drawing.Size(709, 397);
            tabControlOperacoes.TabIndex = 0;
            // 
            // panel4
            // 
            Panel panelMainContainer = new Panel();
            panelMainContainer.AutoScroll = true;
            panelMainContainer.Controls.Add(tabControlOperacoes);
            panelMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMainContainer.Location = new System.Drawing.Point(10, 120);
            panelMainContainer.Name = "panelMainContainer";
            panelMainContainer.Size = new System.Drawing.Size(719, 407);
            panelMainContainer.TabIndex = 3;

            // 
            // buttonNovaPosicao
            // 
            Button buttonNovaPosicao = new Button();
            buttonNovaPosicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonNovaPosicao.Image = global::Positions.Properties.Resources.if_plus_1282963__1_;
            buttonNovaPosicao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonNovaPosicao.Name = "buttonNovaPosicao";
            buttonNovaPosicao.Size = new System.Drawing.Size(137, 38);
            buttonNovaPosicao.TabIndex = 0;
            buttonNovaPosicao.Text = "       Nova posição";
            buttonNovaPosicao.UseVisualStyleBackColor = true;
            buttonNovaPosicao.Click += new System.EventHandler(this.buttonNovaPosicao_Click);
            // 
            // pnlBotoes
            // 
            Panel pnlBotoes = new Panel();
            pnlBotoes.Controls.Add(buttonNovaPosicao);
            pnlBotoes.Dock = System.Windows.Forms.DockStyle.Top;
            pnlBotoes.Name = "pnlBotoes";
            pnlBotoes.Size = new System.Drawing.Size(719, 50);
            pnlBotoes.TabIndex = 2;

            // 
            // MyPositionsPanel
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(panelMainContainer);
            this.Controls.Add(pnlBotoes);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(223, 0);
            this.Name = "MyPositionsPanel";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(739, 537);
            this.TabIndex = 0;
        }

        private void buttonNovaPosicao_Click(object sender, EventArgs e)
        {
            AddPositionForm dialogAddPosicao = new AddPositionForm();
            dialogAddPosicao.ShowDialog();

            RecarregaPainel();
        }

        private void RecarregaPainel()
        {
            UpdateSaldoGUI();

            tabControlOperacoes.TabPages[0].Controls.Clear();
            tabControlOperacoes.TabPages[1].Controls.Clear();
            foreach (Position position in Program.myHistory.positions)
            {
                position.calculaValores();
                DesenhaPosicao(position);
            }
        }

        private void UpdateSaldoGUI()
        {
            SaldoParentUI.Text = Program.myHistory.saldo;
        }

        private void DesenhaPosicao(Position position)
        {

            // 
            // labelPosicao
            // 
            Label labelPosicao = new Label();
            labelPosicao.AutoSize = true;
            labelPosicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPosicao.ForeColor = position.Status == "Posição Aberta" ? System.Drawing.Color.Green : System.Drawing.Color.DarkRed;
            labelPosicao.Location = new System.Drawing.Point(9, 9);
            labelPosicao.Name = "label6";
            labelPosicao.Size = new System.Drawing.Size(115, 20);
            labelPosicao.Text = position.Status;
            // 
            // label7
            // 
            Label label7 = new Label();
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(61, 45);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(63, 13);
            label7.TabIndex = 6;
            label7.Text = position.Par1 + "/" + position.Par2;
            // 
            // label8
            // 
            Label label8 = new Label();
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(29, 45);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(26, 13);
            label8.TabIndex = 7;
            label8.Text = "Par:";
            // 
            // label9
            // 
            Label label9 = new Label();
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(29, 68);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(31, 13);
            label9.TabIndex = 8;
            label9.Text = "Tipo:";
            // 
            // label10
            // 
            Label label10 = new Label();
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(61, 68);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(35, 13);
            label10.TabIndex = 9;
            label10.Text = position.TipoPosicao;
            // 
            // labelTecnica
            // 
            Label labelTecnica = new Label();
            labelTecnica.AutoSize = true;
            labelTecnica.Location = new System.Drawing.Point(208, 22);
            labelTecnica.Name = "labelTecnica";
            labelTecnica.Size = new System.Drawing.Size(80, 13);
            labelTecnica.Text = "Técnica:";
            // 
            // labelTecnicaVal
            // 
            Label labelTecnicaVal = new Label();
            labelTecnicaVal.AutoSize = true;
            labelTecnicaVal.Location = new System.Drawing.Point(260, 22);
            labelTecnicaVal.Name = "labelTecnicaVal";
            labelTecnicaVal.Size = new System.Drawing.Size(27, 13);
            labelTecnicaVal.Text = position.Tecnica;
            if (position.Status == "Posição Aberta")
            {
                labelTecnica.Location = new System.Drawing.Point(208, 68);
                labelTecnicaVal.Location = new System.Drawing.Point(260, 68);
            }
            // 
            // label12
            // 
            Label label12 = new Label();
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(208, 45);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(80, 13);
            label12.TabIndex = 10;
            label12.Text = "Risco/Ganho:";
            // 
            // label13
            // 
            Label label13 = new Label();
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.Location = new System.Drawing.Point(280, 45);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(27, 13);
            label13.TabIndex = 11;
            label13.Text = position.RelacaoRiscoGanho;
            // 
            // labelResultado
            // 
            Label labelResultado = new Label();
            labelResultado.AutoSize = true;
            labelResultado.Location = new System.Drawing.Point(208, 68);
            labelResultado.Name = "labelResultado";
            labelResultado.Size = new System.Drawing.Size(100, 13);
            labelResultado.TabIndex = 10;
            labelResultado.Text = "Resultado operação:";
            if (position.Status == "Posição Aberta")
                labelResultado.Visible = false;
            // 
            // labelResultadoVal
            // 
            Label labelResultadoVal = new Label();
            labelResultadoVal.AutoSize = true;
            labelResultadoVal.Location = new System.Drawing.Point(320, 68);
            labelResultadoVal.Name = "labelResultadoVal";
            labelResultadoVal.ForeColor = !position.Resultado.Contains("Stop") ? System.Drawing.Color.Green : System.Drawing.Color.DarkRed;
            labelResultadoVal.Size = new System.Drawing.Size(100, 13);
            labelResultadoVal.TabIndex = 10;
            labelResultadoVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelResultadoVal.Text = position.Resultado;
            if (position.Status == "Posição Aberta")
                labelResultadoVal.Visible = false;

            // 
            // label14
            // 
            Label label14 = new Label();
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(555, 14);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(65, 13);
            label14.TabIndex = 6;
            label14.Text = position.TipoTrade;
            label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label14.ForeColor = System.Drawing.Color.DarkRed;
            // 
            // labelDuracao
            // 
            Label labelDuracao = new Label();
            labelDuracao.AutoSize = true;
            labelDuracao.Location = new System.Drawing.Point(500, 35);
            labelDuracao.Name = "labelDuracao";
            labelDuracao.Size = new System.Drawing.Size(110, 13);
            labelDuracao.Tag = position;
            if (position.Status == "Posição fechada")
            {
                TimeSpan duracao = position.Duracao;
                labelDuracao.Text = String.Format("Duração: {0} Dias - {1} Horas - {2} Min.", duracao.Days, duracao.Hours, duracao.Minutes);
            }
            else
            {
                TimeSpan duracao = position.Duracao;
                labelDuracao.Text = String.Format("Duração: {0} Dias - {1} Horas - {2} Min.", duracao.Days, duracao.Hours, duracao.Minutes);
                labelsDuracao.Add(labelDuracao);
            }
            // 
            // buttonVer
            // 
            Button buttonVer = new Button();
            buttonVer.BackColor = System.Drawing.SystemColors.Control;
            buttonVer.BackgroundImage = global::Positions.Properties.Resources.if_system_search_118797__1_;
            buttonVer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            buttonVer.ForeColor = System.Drawing.SystemColors.ControlLight;
            buttonVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            if (position.Status == "Posição fechada")
                buttonVer.Location = new System.Drawing.Point(570, 60);
            else
                buttonVer.Location = new System.Drawing.Point(520, 60);
            buttonVer.Name = "buttonVer";
            buttonVer.Size = new System.Drawing.Size(40, 28);
            buttonVer.TabIndex = 12;
            buttonVer.UseVisualStyleBackColor = false;
            buttonVer.Tag = position;
            buttonVer.Click += ButtonVer_Click;
            // 
            // buttonFecharPosicao
            // 
            Button buttonFecharPosicao = new Button();
            buttonFecharPosicao.BackColor = System.Drawing.SystemColors.Control;
            buttonFecharPosicao.BackgroundImage = global::Positions.Properties.Resources.if_Artboard_9svg_1579798__1_;
            buttonFecharPosicao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            buttonFecharPosicao.ForeColor = System.Drawing.SystemColors.ControlLight;
            buttonFecharPosicao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonFecharPosicao.Location = new System.Drawing.Point(570, 60);
            buttonFecharPosicao.Name = "buttonFecharPosicao";
            buttonFecharPosicao.Size = new System.Drawing.Size(40, 28);
            buttonFecharPosicao.TabIndex = 12;
            buttonFecharPosicao.UseVisualStyleBackColor = false;
            buttonFecharPosicao.Tag = position;
            buttonFecharPosicao.Click += ButtonFecharPosicao_Click;
            if (position.Status == "Posição fechada")
                buttonFecharPosicao.Visible = false;
            // 
            // buttonExcluir
            // 
            Button buttonExcluir = new Button();
            buttonExcluir.BackColor = System.Drawing.SystemColors.Control;
            buttonExcluir.BackgroundImage = global::Positions.Properties.Resources.if_trash_100984__1_;
            buttonExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            buttonExcluir.ForeColor = System.Drawing.SystemColors.ControlLight;
            buttonExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonExcluir.Location = new System.Drawing.Point(620, 60);
            buttonExcluir.Name = "buttonExcluir";
            buttonExcluir.Size = new System.Drawing.Size(40, 28);
            buttonExcluir.TabIndex = 12;
            buttonExcluir.UseVisualStyleBackColor = false;
            buttonExcluir.Tag = position;
            buttonExcluir.Click += ButtonExcluir_Click; ;
            // 
            // labelDivider1
            // 
            Label labelDivider1 = new Label();
            labelDivider1.AutoSize = true;
            labelDivider1.Location = new System.Drawing.Point(6, 85);
            labelDivider1.Name = "labelDivider1";
            labelDivider1.Size = new System.Drawing.Size(613, 13);
            labelDivider1.Text = "_________________________________________________________________________________" +
    "____________________________";
            // 
            // panelPositionOverview
            // 
            Panel panelPositionOverview = new Panel();
            panelPositionOverview.Controls.Add(label14);
            panelPositionOverview.Controls.Add(label13);
            panelPositionOverview.Controls.Add(label12);
            panelPositionOverview.Controls.Add(labelDuracao);
            panelPositionOverview.Controls.Add(label10);
            panelPositionOverview.Controls.Add(label9);
            panelPositionOverview.Controls.Add(label8);
            panelPositionOverview.Controls.Add(label7);
            panelPositionOverview.Controls.Add(labelPosicao);
            panelPositionOverview.Controls.Add(labelResultado);
            panelPositionOverview.Controls.Add(buttonVer);
            panelPositionOverview.Controls.Add(buttonFecharPosicao);
            panelPositionOverview.Controls.Add(buttonExcluir);
            panelPositionOverview.Controls.Add(labelDivider1);
            panelPositionOverview.Controls.Add(labelResultadoVal);
            panelPositionOverview.Controls.Add(labelTecnica);
            panelPositionOverview.Controls.Add(labelTecnicaVal);
            panelPositionOverview.Dock = DockStyle.Top;
            panelPositionOverview.Name = "panel1";
            panelPositionOverview.Size = new System.Drawing.Size(505, 100);

            if (position.Status == "Posição Aberta")
                tabControlOperacoes.TabPages[0].Controls.Add(panelPositionOverview);
            else
                tabControlOperacoes.TabPages[1].Controls.Add(panelPositionOverview);


        }

        private void ButtonFecharPosicao_Click(object sender, EventArgs e)
        {
            ClosePositionForm close = new ClosePositionForm(this);
            close.ShowDialog();

            if (!resultadoDialogs.Equals(""))
            {
                Position position = (Position)((Button)sender).Tag;
                position.DataFechamento = DateTime.Now.ToString("dd/MM/yyyy");
                position.HoraFechamento = DateTime.Now.ToString("HH:mm");
                DateTime datetimeAbertura = DateTime.Parse(position.DataAbertura + " " + position.HoraAbertura);
                TimeSpan duracao = DateTime.Now - datetimeAbertura;
                position.Status = String.Format("Posição fechada");
                position.Resultado = resultadoDialogs;
                position.Historico.Add(DateTime.Now.ToString("dd/MM/yyyy - HH:mm -> ") + "Posição fechada com resultado: " + resultadoDialogs + String.Format(". Duração: {0} horas e {1} minutos.", duracao.Hours, duracao.Minutes));


                AtualizaSaldo(position);
                Program.myHistory.AtualizarPosicaoXml(position);
                RecarregaPainel();
            }
        }

        /// <summary>
        /// TODO implementar atualiacao parcial e ENUMs
        /// </summary>
        /// <param name="position"></param>
        private void AtualizaSaldo(Position position)
        {
            float ganhoPerdaValor = 0;
            float ganhoValor = 0;
            float perdaValor = 0;
            float saldoAtual = float.Parse(Program.myHistory.saldo, CultureInfo.InvariantCulture.NumberFormat);
            /*
            if (position.Resultado == DynamicDB.resultados[0])
            { //alvo
                ganhoValor = float.Parse(position.GanhoValor.ToString("0.00000000", CultureInfo.InvariantCulture.NumberFormat), CultureInfo.InvariantCulture.NumberFormat);
                saldoAtual = saldoAtual + perdaValor;
            }
            else //stop
            {
                perdaValor = float.Parse(position.RiscoValor.ToString("0.00000000", CultureInfo.InvariantCulture.NumberFormat), CultureInfo.InvariantCulture.NumberFormat);
                saldoAtual = saldoAtual - perdaValor;
            }*/

            //o ganho ou perda ja tem que chegar com o sinal aqui, se nao chegar vai dar problema, arrumar
            if (position.Resultado == DynamicDB.resultados[0])//alvo
                ganhoPerdaValor = float.Parse(position.GanhoValor.ToString("0.00000000", CultureInfo.InvariantCulture.NumberFormat), CultureInfo.InvariantCulture.NumberFormat);
            else //stop
                ganhoPerdaValor = float.Parse(position.RiscoValor.ToString("0.00000000", CultureInfo.InvariantCulture.NumberFormat), CultureInfo.InvariantCulture.NumberFormat);

            saldoAtual = saldoAtual + ganhoPerdaValor;

            Program.myHistory.saldo = saldoAtual.ToString("0.00000000", CultureInfo.InvariantCulture.NumberFormat);
        }

        private void SalvarXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(History));
            string fileName = System.IO.Path.Combine(Application.CommonAppDataPath, "positions.xml");
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, Program.myHistory);
            }
        }

        private void ButtonExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja mesmo excluir a posição do seu histórico?", "Deletar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) { }
            Position position = (Position)((Button)sender).Tag;
            Program.myHistory.positions.Remove(position);
            SalvarXml();
            RecarregaPainel();
        }

        private void ButtonVer_Click(object sender, EventArgs e)
        {
            Position position = (Position)((Button)sender).Tag;
            ViewPositionForm view = new ViewPositionForm(position);
            DialogResult res = view.ShowDialog();
        }

        private void AtualizarDuracaoLabels()
        {
            foreach (Label labelDuracao in labelsDuracao)
            {
                Position position = (Position)((Label)labelDuracao).Tag;
                DateTime datetimeAbertura = DateTime.Parse(position.DataAbertura + " " + position.HoraAbertura);
                TimeSpan duracao = DateTime.Now - datetimeAbertura;
                labelDuracao.Text = String.Format("Duração: {0} Dias - {1} Horas - {2} Min.", duracao.Days, duracao.Hours, duracao.Minutes);
            }
        }
    }
}
