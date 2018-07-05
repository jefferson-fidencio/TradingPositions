using OperationsWF;
using OperationsWF.Model;
using Positions.Model;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Positions.UI.Panels
{
    public class PanelGanhos : Panel
    {
        Panel panelMainContainer;

        int totalPosicoes = 0;
        int totalAlvos = 0;
        int totalStops = 0;
        double taxaAcerto = 0;

        public PanelGanhos()
        {

            //carrega totais
            totalPosicoes = Program.myHistory.positions.Count;
            foreach (Position position in Program.myHistory.positions)
            {
                if (position.Resultado == "Alvo")
                    totalAlvos = totalAlvos + 1;
                else
                    totalStops = totalStops + 1;
            }
            taxaAcerto = totalAlvos * 100 / totalPosicoes;

            DrawPanel();
            LoadMonthlySummary();
        }

        private void LoadMonthlySummary()
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

            ArrayList meses = new ArrayList();
            foreach (Position position in Program.myHistory.positions)
            {
                //descobre mes da posicao
                int mes = DateTime.Parse(position.DataAbertura).Month;

                bool existe = false;
                foreach (MonthSummary month in meses)
                {
                    if (month.Mes == mes)
                    {
                        month.Posicoes.Add(position);
                        existe = true;
                        break; //ja tem o mes criado
                    }
                }

                //cria novo mes
                if (!existe)
                {
                    MonthSummary novoMes = new MonthSummary(mes);
                    novoMes.Posicoes.Add(position);
                    meses.Add(novoMes);
                }
            }

            drawMonthSummary(meses);
        }

        private void drawMonthSummary(ArrayList meses)
        {
            foreach (MonthSummary mes in meses)
            {
                DrawPanelMonth(mes);
            }
        }

        private void DrawPanelMonth(MonthSummary mes)
        {
            // 
            // lblMes
            // 
            Label lblMes = new Label();
            lblMes.AutoSize = true;
            lblMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblMes.ForeColor = System.Drawing.SystemColors.Highlight;
            lblMes.Location = new System.Drawing.Point(10, 11);
            lblMes.Name = "lblMes";
            lblMes.Size = new System.Drawing.Size(55, 24);
            lblMes.TabIndex = 0;
            lblMes.Text = mes.MesNome;

            // 
            // pctAcerto
            // 
            PictureBox pctAcerto = new PictureBox();
            pctAcerto.BackgroundImage = global::Positions.Properties.Resources.if_piechart_1055011__1_;
            pctAcerto.Location = new System.Drawing.Point(30, lblMes.Location.Y + lblMes.Height + 15);
            pctAcerto.Name = "pctAcerto";
            pctAcerto.SizeMode = PictureBoxSizeMode.AutoSize;
            pctAcerto.Size = new System.Drawing.Size(20, 20);
            pctAcerto.TabIndex = 9;
            pctAcerto.TabStop = false;
            // 
            // lblTxAcerto
            // 
            Label lblTxAcerto = new Label();
            lblTxAcerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTxAcerto.Name = "lblTxAcerto";
            lblTxAcerto.Location = new System.Drawing.Point(pctAcerto.Location.X + pctAcerto.Width + 5, pctAcerto.Location.Y);
            lblTxAcerto.Size = new System.Drawing.Size(140, 20);
            lblTxAcerto.Text = "Taxa de acerto:";
            // 
            // lblTxAcertoVal
            // 
            Label lblTxAcertoVal = new Label();
            lblTxAcertoVal.Name = "lblTxAcertoVal";
            lblTxAcertoVal.Location = new System.Drawing.Point(lblTxAcerto.Location.X + lblTxAcerto.Width + 5, lblTxAcerto.Location.Y);
            lblTxAcertoVal.AutoSize = true;
            lblTxAcertoVal.Text = mes.TaxaAcerto.ToString("0.00") + "%";
            /*
            // 
            // pctWallet
            // 
            PictureBox pctWallet = new PictureBox();
            pctWallet.BackgroundImage = global::Positions.Properties.Resources._309020_24;
            pctWallet.Location = new System.Drawing.Point(36, 49);
            pctWallet.Name = "pctWallet";
            pctWallet.Size = new System.Drawing.Size(25, 25);
            pctWallet.TabIndex = 9;
            pctWallet.TabStop = false;
            // 
            // lblLucro
            // 
            Label lblLucro = new Label();
            lblLucro.AutoSize = true;
            lblLucro.Location = new System.Drawing.Point(67, 49);
            lblLucro.Name = "lblLucro";
            lblLucro.Size = new System.Drawing.Size(73, 13);
            lblLucro.TabIndex = 1;
            lblLucro.Text = "Lucro mensal:";
            // 
            // lblLucroValue
            // 
            Label lblLucroValue = new Label();
            lblLucroValue.AutoSize = true;
            lblLucroValue.ForeColor = System.Drawing.Color.Green;
            lblLucroValue.Location = new System.Drawing.Point(146, 49);
            lblLucroValue.Name = "lblLucroValue";
            lblLucroValue.Size = new System.Drawing.Size(88, 13);
            lblLucroValue.TabIndex = 2;
            lblLucroValue.Text = "0.00347893 BTC";
            // 
            // lblPercentCapital
            // 
            Label lblPercentCapital = new Label();
            lblPercentCapital.AutoSize = true;
            lblPercentCapital.ForeColor = System.Drawing.Color.Green;
            lblPercentCapital.Location = new System.Drawing.Point(146, 73);
            lblPercentCapital.Name = "lblPercentCapital";
            lblPercentCapital.Size = new System.Drawing.Size(145, 13);
            lblPercentCapital.TabIndex = 3;
            lblPercentCapital.Text = "23% do capital inicial de maio";
            // 
            // pctOperacoes
            // 
            PictureBox pctOperacoes = new PictureBox();
            pctOperacoes.BackgroundImage = global::Positions.Properties.Resources.if_statistics_383213;
            pctOperacoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pctOperacoes.Location = new System.Drawing.Point(380, 49);
            pctOperacoes.Name = "pctOperacoes";
            pctOperacoes.Size = new System.Drawing.Size(25, 25);
            pctOperacoes.TabIndex = 10;
            pctOperacoes.TabStop = false;
            */
            // 
            // lblOperacoes
            // 
            Label lblOperacoes = new Label();
            lblOperacoes.AutoSize = true;
            lblOperacoes.Location = new System.Drawing.Point(320, lblTxAcerto.Location.Y);
            lblOperacoes.Name = "lblOperacoes";
            lblOperacoes.Size = new System.Drawing.Size(112, 13);
            lblOperacoes.TabIndex = 4;
            lblOperacoes.Text = "Operações realizadas:";
            // 
            // lblOperacoesValue
            // 
            Label lblOperacoesValue = new Label();
            lblOperacoesValue.AutoSize = true;
            lblOperacoesValue.Location = new System.Drawing.Point(lblOperacoes.Location.X + lblOperacoes.Width + 5, lblOperacoes.Location.Y);
            lblOperacoesValue.Name = "lblOperacoesValue";
            lblOperacoesValue.Size = new System.Drawing.Size(19, 13);
            lblOperacoesValue.TabIndex = 5;
            lblOperacoesValue.Text = mes.Posicoes.Count.ToString();
            // 
            // lblDuracao
            // 
            Label lblDuracao = new Label();
            lblDuracao.AutoSize = true;
            lblDuracao.Location = new System.Drawing.Point(lblOperacoes.Location.X, lblOperacoes.Location.Y + 20);
            lblDuracao.Name = "lblDuracao";
            lblDuracao.Size = new System.Drawing.Size(82, 13);
            lblDuracao.TabIndex = 6;
            lblDuracao.Text = "Duração média:";
            // 
            // lblDuracaoValue
            // 
            Label lblDuracaoValue = new Label();
            lblDuracaoValue.AutoSize = true;
            lblDuracaoValue.Location = new System.Drawing.Point(lblDuracao.Location.X + lblDuracao.Width + 5, lblDuracao.Location.Y);
            lblDuracaoValue.Name = "lblDuracaoValue";
            lblDuracaoValue.Size = new System.Drawing.Size(99, 13);
            lblDuracaoValue.TabIndex = 7;
            lblDuracaoValue.Text = mes.DuracaoMedia;
            // 
            // btnDetalhes
            // 
            Button btnDetalhes = new Button();
            btnDetalhes.Location = new System.Drawing.Point(619, 14);
            btnDetalhes.Name = "btnDetalhes";
            btnDetalhes.Size = new System.Drawing.Size(75, 23);
            btnDetalhes.TabIndex = 8;
            btnDetalhes.Text = "Detalhes";
            btnDetalhes.UseVisualStyleBackColor = true;
            // 
            // lblDiv
            // 
            Label lblDiv = new Label();
            lblDiv.AutoSize = true;
            lblDiv.Location = new System.Drawing.Point(7, 94);
            lblDiv.Name = "lblDiv";
            lblDiv.Size = new System.Drawing.Size(697, 13);
            lblDiv.TabIndex = 11;
            lblDiv.Text = "_________________________________________________________________________________" +
    "__________________________________";

            // 
            // pnlMonthSummary
            // 
            Panel pnlMonthSummary = new Panel();
            pnlMonthSummary.BackColor = System.Drawing.Color.White;
            pnlMonthSummary.Location = new System.Drawing.Point(0, 0);
            pnlMonthSummary.Name = "pnlMonthSummary";
            pnlMonthSummary.Dock = DockStyle.Top;
            pnlMonthSummary.Size = new System.Drawing.Size(0, 115);
            pnlMonthSummary.Controls.AddRange(new Control[] { lblMes, pctAcerto, lblTxAcerto, lblTxAcertoVal, /*pctWallet, lblLucro, lblLucroValue, lblPercentCapital, pctOperacoes,*/ lblOperacoes, lblOperacoesValue, lblDuracao, lblDuracaoValue, btnDetalhes, lblDiv });

            panelMainContainer.Controls.Add(pnlMonthSummary);
        }

        private void DrawPanel()
        {
            // 
            // lblResumo
            // 
            Label lblResumo = new Label();
            lblResumo.AutoSize = true;
            lblResumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblResumo.ForeColor = System.Drawing.Color.DarkRed;
            lblResumo.Location = new System.Drawing.Point(10, 0);
            lblResumo.Name = "lblResumo";
            lblResumo.Size = new System.Drawing.Size(55, 24);
            lblResumo.TabIndex = 0;
            lblResumo.Text = "Resumo:";
            // 
            // pctOperacoes
            // 
            PictureBox pctOperacoes = new PictureBox();
            pctOperacoes.BackgroundImage = global::Positions.Properties.Resources.if_flag_173015;
            pctOperacoes.SizeMode = PictureBoxSizeMode.AutoSize;
            pctOperacoes.Location = new System.Drawing.Point(20, lblResumo.Location.Y + lblResumo.Height + 10);
            pctOperacoes.Name = "pctOperacoes";
            pctOperacoes.Size = new System.Drawing.Size(20, 20);
            pctOperacoes.TabIndex = 9;
            pctOperacoes.TabStop = false;
            // 
            // lblTotalOperacoes
            // 
            Label lblTotalOperacoes = new Label();
            lblTotalOperacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTotalOperacoes.Name = "lblTotalOperacoes";
            lblTotalOperacoes.Location = new System.Drawing.Point(pctOperacoes.Location.X + pctOperacoes.Width + 5, pctOperacoes.Location.Y);
            lblTotalOperacoes.Size = new System.Drawing.Size(140,20);
            lblTotalOperacoes.Text = "Total de operações:";
            // 
            // lblTotalOperacoesVal
            // 
            Label lblTotalOperacoesVal = new Label();
            lblTotalOperacoesVal.Name = "lblTotalOperacoesVal";
            lblTotalOperacoesVal.Location = new System.Drawing.Point(lblTotalOperacoes.Location.X + lblTotalOperacoes.Width + 5, lblTotalOperacoes.Location.Y);
            lblTotalOperacoesVal.AutoSize = true;
            lblTotalOperacoesVal.Text = totalPosicoes.ToString();
            // 
            // pctAlvo
            // 
            PictureBox pctAlvo = new PictureBox();
            pctAlvo.BackgroundImage = global::Positions.Properties.Resources.if_target_20;
            pctAlvo.SizeMode = PictureBoxSizeMode.AutoSize;
            pctAlvo.Location = new System.Drawing.Point(pctOperacoes.Location.X, pctOperacoes.Location.Y + pctOperacoes.Height + 5);
            pctAlvo.Name = "pctAlvo";
            pctAlvo.Size = new System.Drawing.Size(20, 20);
            pctAlvo.TabIndex = 9;
            pctAlvo.TabStop = false;
            // 
            // lblOpAlvo
            // 
            Label lblOpAlvo = new Label();
            lblOpAlvo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblOpAlvo.Name = "lblOpAlvo";
            lblOpAlvo.Location = new System.Drawing.Point(pctAlvo.Location.X + pctAlvo.Width + 5, pctAlvo.Location.Y);
            lblOpAlvo.Size = new System.Drawing.Size(140, 20);
            lblOpAlvo.Text = "Total de alvos:";
            // 
            // lblOpAlvoVal
            // 
            Label lblOpAlvoVal = new Label();
            lblOpAlvoVal.Name = "lblOpAlvoVal";
            lblOpAlvoVal.Location = new System.Drawing.Point(lblOpAlvo.Location.X + lblOpAlvo.Width + 5, lblOpAlvo.Location.Y);
            lblOpAlvoVal.AutoSize = true;
            lblOpAlvoVal.Text = totalAlvos.ToString();
            // 
            // pctStop
            // 
            PictureBox pctStop = new PictureBox();
            pctStop.BackgroundImage = global::Positions.Properties.Resources.if_3_330411;
            pctStop.Location = new System.Drawing.Point(pctAlvo.Location.X, pctAlvo.Location.Y + pctAlvo.Height + 5);
            pctStop.Name = "pctStop";
            pctStop.SizeMode = PictureBoxSizeMode.AutoSize;
            pctStop.Size = new System.Drawing.Size(20, 20);
            pctStop.TabIndex = 9;
            pctStop.TabStop = false;
            // 
            // lblOpStop
            // 
            Label lblOpStop = new Label();
            lblOpStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblOpStop.Name = "lblOpStop";
            lblOpStop.Location = new System.Drawing.Point(pctStop.Location.X + pctStop.Width + 5, pctStop.Location.Y);
            lblOpStop.Size = new System.Drawing.Size(140, 20);
            lblOpStop.Text = "Total de stops:";
            // 
            // lblOpStopVal
            // 
            Label lblOpStopVal = new Label();
            lblOpStopVal.Name = "lblOpStopVal";
            lblOpStopVal.Location = new System.Drawing.Point(lblOpStop.Location.X + lblOpStop.Width + 5, lblOpStop.Location.Y);
            lblOpStopVal.AutoSize = true;
            lblOpStopVal.Text = totalStops.ToString();
            // 
            // pctAcerto
            // 
            PictureBox pctAcerto = new PictureBox();
            pctAcerto.BackgroundImage = global::Positions.Properties.Resources.if_piechart_1055011__1_;
            pctAcerto.Location = new System.Drawing.Point(300, pctOperacoes.Location.Y);
            pctAcerto.Name = "pctAcerto";
            pctAcerto.SizeMode = PictureBoxSizeMode.AutoSize;
            pctAcerto.Size = new System.Drawing.Size(20, 20);
            pctAcerto.TabIndex = 9;
            pctAcerto.TabStop = false;
            // 
            // lblTxAcerto
            // 
            Label lblTxAcerto = new Label();
            lblTxAcerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTxAcerto.Name = "lblTxAcerto";
            lblTxAcerto.Location = new System.Drawing.Point(pctAcerto.Location.X + pctAcerto.Width + 5, pctAcerto.Location.Y);
            lblTxAcerto.Size = new System.Drawing.Size(140, 20);
            lblTxAcerto.Text = "Taxa de acerto:";
            // 
            // lblTxAcertoVal
            // 
            Label lblTxAcertoVal = new Label();
            lblTxAcertoVal.Name = "lblTxAcertoVal";
            lblTxAcertoVal.Location = new System.Drawing.Point(lblTxAcerto.Location.X + lblTxAcerto.Width + 5, lblTxAcerto.Location.Y);
            lblTxAcertoVal.AutoSize = true;
            lblTxAcertoVal.Text = taxaAcerto.ToString("0.00") + "%";
            // 
            // lblDiv
            // 
            Label lblDiv = new Label();
            lblDiv.AutoSize = true;
            lblDiv.Location = new System.Drawing.Point(5, lblOpStopVal.Location.Y + 20);
            lblDiv.Name = "lblDiv";
            lblDiv.Size = new System.Drawing.Size(697, 13);
            lblDiv.TabIndex = 11;
            lblDiv.Text = "_________________________________________________________________________________" +
    "__________________________________";

            // 
            // pnlBotoes
            // 
            Panel pnlSummary = new Panel();
            pnlSummary.Controls.Add(lblResumo);
            pnlSummary.Controls.Add(pctOperacoes);
            pnlSummary.Controls.Add(lblTotalOperacoes);
            pnlSummary.Controls.Add(lblTotalOperacoesVal);
            pnlSummary.Controls.Add(pctAlvo);
            pnlSummary.Controls.Add(lblOpAlvo);
            pnlSummary.Controls.Add(lblOpAlvoVal);
            pnlSummary.Controls.Add(pctStop);
            pnlSummary.Controls.Add(lblOpStop);
            pnlSummary.Controls.Add(lblOpStopVal);
            pnlSummary.Controls.Add(pctAcerto);
            pnlSummary.Controls.Add(lblTxAcerto);
            pnlSummary.Controls.Add(lblTxAcertoVal);
            pnlSummary.Controls.Add(lblDiv);
            pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            pnlSummary.Name = "pnlBotoes";
            pnlSummary.Size = new System.Drawing.Size(719, 120);
            // 
            // panelMainContainer
            // 
            panelMainContainer = new Panel();
            panelMainContainer.AutoScroll = true;
            panelMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMainContainer.Location = new System.Drawing.Point(10, 120);
            panelMainContainer.Name = "panelMainContainer";
            panelMainContainer.Size = new System.Drawing.Size(719, 407);
            panelMainContainer.TabIndex = 3;
            // 
            // MyPositionsPanel
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(panelMainContainer);
            this.Controls.Add(pnlSummary);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(223, 0);
            this.Name = "MyPositionsPanel";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(739, 537);
            this.TabIndex = 0;
        }

        private void RecarregaPainel()
        {
        }

    }
}
