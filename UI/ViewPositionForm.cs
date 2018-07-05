using OperationsWF;
using OperationsWF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Positions.UI
{
    public partial class ViewPositionForm : Form
    {
        Position position;

        Label labelEntrada = new Label();
        Label labelCapital = new Label();
        Label labelAlvo = new Label();
        TextBox textBoxAlvo = new TextBox();
        Label labelStop = new Label();
        TextBox textBoxStop = new TextBox();
        Label labelParcial = new Label();
        TextBox textBoxParcial = new TextBox();
        Panel pnlHistory = new Panel();
        Label labelRelacaoRiscoGanho = new Label();
        Label labelGanhoPercent = new Label();
        Label labelGanhoValor = new Label();
        Label labelRiscoPercent = new Label();
        Label labelRiscoValor = new Label();
        Label labelGanhoParcialPercent = new Label();
        Label labelGanhoParcialValor = new Label();
        Label labelTipoPosicao = new Label();

        public ViewPositionForm(Position position)
        {
            this.position = position;
            DrawForm();
        }

        private void DrawForm()
        {
            #region header

            // 
            // buttonEditar
            // 
            Button buttonEditar = new Button();
            buttonEditar.BackgroundImage = global::Positions.Properties.Resources.if_edit_43786;
            buttonEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            buttonEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonEditar.Location = new System.Drawing.Point(580, 25);
            buttonEditar.Name = "buttonEditar";
            buttonEditar.Size = new System.Drawing.Size(40, 28);
            buttonEditar.Click += ButtonEditar_Click; ;
            // 
            // labelTipoTrade
            // 
            Label labelTipoTrade = new Label();
            labelTipoTrade.AutoSize = true;
            labelTipoTrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelTipoTrade.ForeColor = System.Drawing.Color.Coral;
            labelTipoTrade.Location = new System.Drawing.Point(552, 25);
            labelTipoTrade.Name = "labelTipoTrade";
            labelTipoTrade.Size = new System.Drawing.Size(98, 17);
            labelTipoTrade.TabIndex = 8;
            labelTipoTrade.Text = position.TipoTrade;
            // 
            // label6
            // 
            Label label6 = new Label();
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(6, 51);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(74, 13);
            label6.TabIndex = 3;
            label6.Text = "Ferramenta:";
            // 
            // labelFerramenta
            // 
            Label labelFerramenta = new Label();
            labelFerramenta.AutoSize = true;
            labelFerramenta.Location = new System.Drawing.Point(90, label6.Location.Y);
            labelFerramenta.Name = "labelFerramenta";
            labelFerramenta.Size = new System.Drawing.Size(34, 13);
            labelFerramenta.TabIndex = 28;
            labelFerramenta.Text = position.Ferramenta;
            // 
            // label5
            // 
            Label label5 = new Label();
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(6, 29);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(67, 13);
            label5.TabIndex = 2;
            label5.Text = "Exchange:";
            // 
            // labelExchange
            // 
            Label labelExchange = new Label();
            labelExchange.AutoSize = true;
            labelExchange.Location = new System.Drawing.Point(90, label5.Location.Y);
            labelExchange.Name = "labelExchange";
            labelExchange.Size = new System.Drawing.Size(34, 13);
            labelExchange.TabIndex = 28;
            labelExchange.Text = position.Exchange;
            // 
            // label4
            // 
            Label label4 = new Label();
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(296, 51);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(89, 13);
            label4.TabIndex = 1;
            label4.Text = "Horário entrada:";
            // 
            // labelHorario
            // 
            Label labelHorario = new Label();
            labelHorario.AutoSize = true;
            labelHorario.Location = new System.Drawing.Point(405, label4.Location.Y);
            labelHorario.Name = "labelHorario";
            labelHorario.Size = new System.Drawing.Size(34, 13);
            labelHorario.TabIndex = 28;
            labelHorario.Text = position.HoraAbertura;
            // 
            // label2
            // 
            Label label2 = new Label();
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(296, 29);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 13);
            label2.TabIndex = 0;
            label2.Text = "Data inicial:";
            // 
            // labelData
            // 
            Label labelData = new Label();
            labelData.AutoSize = true;
            labelData.Location = new System.Drawing.Point(405, label2.Location.Y);
            labelData.Name = "labelData";
            labelData.Size = new System.Drawing.Size(34, 13);
            labelData.TabIndex = 28;
            labelData.Text = position.DataAbertura;
            // 
            // labelDivider1
            // 
            Label labelDivider1 = new Label();
            labelDivider1.AutoSize = true;
            labelDivider1.Location = new System.Drawing.Point(6, 174);
            labelDivider1.Name = "labelDivider1";
            labelDivider1.Size = new System.Drawing.Size(613, 13);
            labelDivider1.TabIndex = 16;
            labelDivider1.Text = "_________________________________________________________________________________" +
    "_________________________";

            #endregion

            #region indicadores

            Panel pnlIndicadores = new Panel();
            pnlIndicadores.Location = new System.Drawing.Point(428, 101);
            pnlIndicadores.Size = new Size(200,80);
            pnlIndicadores.AutoScroll = true;

            int cont = 0;
            foreach (string indicador in position.Indicadores)
            {
                // 
                // pictureBoxIndicador
                // 
                PictureBox pictureBoxIndicador = new PictureBox();
                pictureBoxIndicador.BackgroundImage = global::Positions.Properties.Resources.if_tick_12514__1_;
                pictureBoxIndicador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                pictureBoxIndicador.Location = new System.Drawing.Point(5, cont * 25);
                pictureBoxIndicador.Name = "pictureBoxIndicador";
                pictureBoxIndicador.Size = new System.Drawing.Size(19, 20);
                pictureBoxIndicador.TabStop = false;
                // 
                // labelIndicador
                // 
                Label labelIndicador = new Label();
                labelIndicador.AutoSize = true;
                labelIndicador.Location = new System.Drawing.Point(pictureBoxIndicador.Location.X + 25, pictureBoxIndicador.Location.Y);
                labelIndicador.Name = "label15";
                labelIndicador.Size = new System.Drawing.Size(25, 13);
                labelIndicador.Text = indicador;

                pnlIndicadores.Controls.Add(pictureBoxIndicador);
                pnlIndicadores.Controls.Add(labelIndicador);
                cont = cont+1;
            }

            // 
            // label12
            // 
            Label label12 = new Label();
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.Location = new System.Drawing.Point(6, 158);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(102, 13);
            label12.TabIndex = 10;
            label12.Text = "Capital aplicado:";
            // 
            // labelCapital
            // 
            labelCapital.AutoSize = true;
            labelCapital.Location = new System.Drawing.Point(122, label12.Location.Y);
            labelCapital.Name = "labelCapital";
            labelCapital.Size = new System.Drawing.Size(34, 13);
            labelCapital.TabIndex = 28;
            labelCapital.Text = position.Capital;
            // 
            // label11
            // 
            Label label11 = new Label();
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.Location = new System.Drawing.Point(296, 101);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(121, 13);
            label11.TabIndex = 9;
            label11.Text = "Indicadores à favor:";
            // 
            // label10
            // 
            Label label10 = new Label();
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(3, 129);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(109, 13);
            label10.TabIndex = 7;
            label10.Text = "Técnica aplicada:";
            // 
            // labelTecnica
            // 
            Label labelTecnica = new Label();
            labelTecnica.AutoSize = true;
            labelTecnica.Location = new System.Drawing.Point(122, label10.Location.Y);
            labelTecnica.Name = "labelTecnica";
            labelTecnica.Size = new System.Drawing.Size(34, 13);
            labelTecnica.TabIndex = 28;
            labelTecnica.Text = position.Tecnica;
            // 
            // label9
            // 
            Label label9 = new Label();
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(3, 101);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(102, 13);
            label9.TabIndex = 6;
            label9.Text = "Tipo de posição:";
            // 
            // labelTipoPosicao
            // 
            labelTipoPosicao.AutoSize = true;
            labelTipoPosicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelTipoPosicao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            labelTipoPosicao.Location = new System.Drawing.Point(122, 99);
            labelTipoPosicao.Name = "label18";
            labelTipoPosicao.Size = new System.Drawing.Size(44, 17);
            labelTipoPosicao.TabIndex = 18;
            labelTipoPosicao.Text = position.TipoPosicao;
            // 
            // labelDivider2
            // 
            Label labelDivider2 = new Label();
            labelDivider2.AutoSize = true;
            labelDivider2.Location = new System.Drawing.Point(6, 75);
            labelDivider2.Name = "labelDivider2";
            labelDivider2.Size = new System.Drawing.Size(613, 13);
            labelDivider2.TabIndex = 5;
            labelDivider2.Text = "_________________________________________________________________________________" +
    "_________________________";

            #endregion

            #region calculados

            // 
            // label32
            // 
            labelGanhoParcialPercent.AutoSize = true;
            labelGanhoParcialPercent.ForeColor = System.Drawing.Color.Green;
            labelGanhoParcialPercent.Location = new System.Drawing.Point(80, 49);
            labelGanhoParcialPercent.Name = "label32";
            labelGanhoParcialPercent.Size = new System.Drawing.Size(30, 13);
            labelGanhoParcialPercent.TabIndex = 29;
            labelGanhoParcialPercent.Text = position.ParcialPercent.ToString("0.00") + "%";
            // 
            // label33
            // 
            labelGanhoParcialValor.AutoSize = true;
            labelGanhoParcialValor.ForeColor = System.Drawing.Color.Green;
            labelGanhoParcialValor.Location = new System.Drawing.Point(47, 26);
            labelGanhoParcialValor.Name = "label33";
            labelGanhoParcialValor.Size = new System.Drawing.Size(34, 13);
            labelGanhoParcialValor.TabIndex = 28;
            labelGanhoParcialValor.Text = position.ParcialValor.ToString("0.00000000");
            // 
            // label34
            // 
            Label label34 = new Label();
            label34.AutoSize = true;
            label34.Location = new System.Drawing.Point(7, 49);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(25, 13);
            label34.TabIndex = 2;
            label34.Text = "Porcentagem:";
            // 
            // label35
            // 
            Label label35 = new Label();
            label35.AutoSize = true;
            label35.Location = new System.Drawing.Point(7, 26);
            label35.Name = "label35";
            label35.Size = new System.Drawing.Size(34, 13);
            label35.TabIndex = 1;
            label35.Text = "Valor:";// 
                                    // groupBox3
                                    // 
            GroupBox groupBoxGanhoParcial = new GroupBox();
            groupBoxGanhoParcial.Controls.Add(labelGanhoParcialPercent);
            groupBoxGanhoParcial.Controls.Add(labelGanhoParcialValor);
            groupBoxGanhoParcial.Controls.Add(label34);
            groupBoxGanhoParcial.Controls.Add(label35);
            groupBoxGanhoParcial.Location = new System.Drawing.Point(487, 235);
            groupBoxGanhoParcial.Name = "groupBox3";
            groupBoxGanhoParcial.Size = new System.Drawing.Size(120, 75);
            groupBoxGanhoParcial.TabIndex = 31;
            groupBoxGanhoParcial.TabStop = false;
            groupBoxGanhoParcial.Text = "Ganho Parcial";
            // 
            // label29
            // 
            labelRelacaoRiscoGanho.AutoSize = true;
            labelRelacaoRiscoGanho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            labelRelacaoRiscoGanho.Location = new System.Drawing.Point(379, 204);
            labelRelacaoRiscoGanho.Name = "label29";
            labelRelacaoRiscoGanho.Size = new System.Drawing.Size(34, 13);
            labelRelacaoRiscoGanho.TabIndex = 30;
            labelRelacaoRiscoGanho.Text = position.RelacaoRiscoGanho;
            // 
            // label28
            // 
            Label label28 = new Label();
            label28.AutoSize = true;
            label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label28.Location = new System.Drawing.Point(236, 204);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(137, 13);
            label28.TabIndex = 31;
            label28.Text = "Relação Risco/Ganho:";

            // 
            // label24
            // 
            labelGanhoPercent.AutoSize = true;
            labelGanhoPercent.ForeColor = System.Drawing.Color.Green;
            labelGanhoPercent.Location = new System.Drawing.Point(80, 49);
            labelGanhoPercent.Name = "label24";
            labelGanhoPercent.Size = new System.Drawing.Size(30, 13);
            labelGanhoPercent.TabIndex = 29;
            labelGanhoPercent.Text = position.GanhoPercent.ToString("0.00") + "%";
            // 
            // label25
            // 
            labelGanhoValor.AutoSize = true;
            labelGanhoValor.ForeColor = System.Drawing.Color.Green;
            labelGanhoValor.Location = new System.Drawing.Point(47, 26);
            labelGanhoValor.Name = "label25";
            labelGanhoValor.Size = new System.Drawing.Size(34, 13);
            labelGanhoValor.TabIndex = 28;
            labelGanhoValor.Text = position.GanhoValor.ToString("0.00000000");
            // 
            // label26
            // 
            Label label26 = new Label();
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(7, 49);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(18, 13);
            label26.TabIndex = 2;
            label26.Text = "Porcentagem:";
            // 
            // label27
            // 
            Label label27 = new Label();
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(7, 26);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(34, 13);
            label27.TabIndex = 1;
            label27.Text = "Valor:";
            // 
            // groupBox2
            // 
            GroupBox groupBoxGanho = new GroupBox();
            groupBoxGanho.Controls.Add(labelGanhoPercent);
            groupBoxGanho.Controls.Add(labelGanhoValor);
            groupBoxGanho.Controls.Add(label26);
            groupBoxGanho.Controls.Add(label27);
            groupBoxGanho.ForeColor = System.Drawing.Color.Green;
            groupBoxGanho.Location = new System.Drawing.Point(360, 235);
            groupBoxGanho.Name = "groupBox2";
            groupBoxGanho.Size = new System.Drawing.Size(120, 75);
            groupBoxGanho.TabIndex = 30;
            groupBoxGanho.TabStop = false;
            groupBoxGanho.Text = "Ganho";
            // 
            // labelRiscoPercent
            // 
            labelRiscoPercent.AutoSize = true;
            labelRiscoPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            labelRiscoPercent.Location = new System.Drawing.Point(80, 49);
            labelRiscoPercent.Name = "labelRiscoPercent";
            labelRiscoPercent.Size = new System.Drawing.Size(30, 13);
            labelRiscoPercent.TabIndex = 29;
            labelRiscoPercent.Text = position.RiscoPercent.ToString("0.00") + "%";
            // 
            // labelRiscoValor
            // 
            labelRiscoValor.AutoSize = true;
            labelRiscoValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            labelRiscoValor.Location = new System.Drawing.Point(47, 26);
            labelRiscoValor.Name = "labelRiscoValor";
            labelRiscoValor.Size = new System.Drawing.Size(34, 13);
            labelRiscoValor.TabIndex = 28;
            labelRiscoValor.Text = position.RiscoValor.ToString("0.00000000");
            // 
            // label22
            // 
            Label label22 = new Label();
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(7, 49);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(18, 13);
            label22.TabIndex = 2;
            label22.Text = "Porcentagem:";
            // 
            // label23
            // 
            Label label23 = new Label();
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(7, 26);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(34, 13);
            label23.TabIndex = 1;
            label23.Text = "Valor:";// 
                                    // groupBox12
                                    // 
            GroupBox groupBoxRisco = new GroupBox();
            groupBoxRisco.Controls.Add(labelRiscoPercent);
            groupBoxRisco.Controls.Add(labelRiscoValor);
            groupBoxRisco.Controls.Add(label22);
            groupBoxRisco.Controls.Add(label23);
            groupBoxRisco.ForeColor = System.Drawing.Color.Maroon;
            groupBoxRisco.Location = new System.Drawing.Point(234, 235);
            groupBoxRisco.Name = "groupBox12";
            groupBoxRisco.Size = new System.Drawing.Size(120, 75);
            groupBoxRisco.TabIndex = 25;
            groupBoxRisco.TabStop = false;
            groupBoxRisco.Text = "Risco";
            // 
            // label19
            // 
            Label label19 = new Label();
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label19.Location = new System.Drawing.Point(6, 230);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(55, 13);
            label19.TabIndex = 19;
            label19.Text = "Entrada:";
            // 
            // labelEntrada
            // 
            labelEntrada.AutoSize = true;
            labelEntrada.Location = new System.Drawing.Point(80, 230);
            labelEntrada.Name = "labelEntrada";
            labelEntrada.Size = new System.Drawing.Size(43, 13);
            labelEntrada.TabIndex = 22;
            labelEntrada.Text = position.Entrada;
            // 
            // label20
            // 
            Label label20 = new Label();
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label20.Location = new System.Drawing.Point(6, 253);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(36, 13);
            label20.TabIndex = 20;
            label20.Text = "Alvo:";
            // 
            // labelAlvo
            // 
            labelAlvo.AutoSize = true;
            labelAlvo.ForeColor = System.Drawing.Color.Green;
            labelAlvo.Location = new System.Drawing.Point(80, 253);
            labelAlvo.Name = "labelAlvo";
            labelAlvo.Size = new System.Drawing.Size(43, 13);
            labelAlvo.TabIndex = 23;
            labelAlvo.Text = position.Alvo;
            // 
            // textBoxAlvo
            // 
            textBoxAlvo.AutoSize = true;
            textBoxAlvo.ForeColor = System.Drawing.Color.Green;
            textBoxAlvo.Location = new System.Drawing.Point(80, 253);
            textBoxAlvo.Name = "textBoxAlvo";
            textBoxAlvo.Size = new System.Drawing.Size(65, 13);
            textBoxAlvo.TabIndex = 23;
            textBoxAlvo.Text = position.Alvo;
            textBoxAlvo.Visible = false;
            textBoxAlvo.TextChanged += AtualizarAlvo;
            // 
            // buttonEditarAlvo
            // 
            Button buttonEditarAlvo = new Button();
            buttonEditarAlvo.BackgroundImage = global::Positions.Properties.Resources.if_edit_173002;
            buttonEditarAlvo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            buttonEditarAlvo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonEditarAlvo.Location = new System.Drawing.Point(155, 250);
            buttonEditarAlvo.Name = "buttonEditarAlvo";
            buttonEditarAlvo.Size = new System.Drawing.Size(30, 23);
            buttonEditarAlvo.Click += ButtonEditarAlvo_Click;
            buttonEditarAlvo.Visible = position.Status=="Posição fechada" ? false: true; 
            // 
            // label21
            // 
            Label label21 = new Label();
            label21.AutoSize = true;
            label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label21.Location = new System.Drawing.Point(6, 275);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(37, 13);
            label21.TabIndex = 21;
            label21.Text = "Stop:";
            // 
            // labelStop
            // 
            labelStop.AutoSize = true;
            labelStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            labelStop.Location = new System.Drawing.Point(80, 275);
            labelStop.Name = "labelStop";
            labelStop.Size = new System.Drawing.Size(32, 13);
            labelStop.TabIndex = 24;
            labelStop.Text = position.Stop;
            // 
            // textBoxStop
            // 
            textBoxStop.AutoSize = true;
            textBoxStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            textBoxStop.Location = new System.Drawing.Point(80, 275);
            textBoxStop.Name = "textBoxStop";
            textBoxStop.Size = new System.Drawing.Size(65, 13);
            textBoxStop.TabIndex = 23;
            textBoxStop.Text = position.Stop;
            textBoxStop.Visible = false;
            textBoxStop.TextChanged += AtualizarStop;
            // 
            // buttonEditarStop
            // 
            Button buttonEditarStop = new Button();
            buttonEditarStop.BackgroundImage = global::Positions.Properties.Resources.if_edit_173002;
            buttonEditarStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            buttonEditarStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonEditarStop.Location = new System.Drawing.Point(155, 272);
            buttonEditarStop.Name = "buttonEditarStop";
            buttonEditarStop.Size = new System.Drawing.Size(30, 23);
            buttonEditarStop.Click += ButtonEditarStop_Click;
            buttonEditarStop.Visible = position.Status == "Posição fechada" ? false : true;
            // 
            // label30
            // 
            labelParcial.AutoSize = true;
            labelParcial.ForeColor = System.Drawing.Color.Green;
            labelParcial.Location = new System.Drawing.Point(80, 297);
            labelParcial.Name = "label30";
            labelParcial.Size = new System.Drawing.Size(32, 13);
            labelParcial.TabIndex = 33;
            labelParcial.Text = position.Parcial;
            // 
            // textBoxParcial
            // 
            textBoxParcial.AutoSize = true;
            textBoxParcial.ForeColor = System.Drawing.Color.Green;
            textBoxParcial.Location = new System.Drawing.Point(80, 297);
            textBoxParcial.Name = "textBoxParcial";
            textBoxParcial.Size = new System.Drawing.Size(65, 13);
            textBoxParcial.TabIndex = 23;
            textBoxParcial.Text = position.Parcial;
            textBoxParcial.Visible = false;
            textBoxParcial.TextChanged += AtualizarParcial;
            // 
            // buttonEditarParcial
            // 
            Button buttonEditarParcial = new Button();
            buttonEditarParcial.BackgroundImage = global::Positions.Properties.Resources.if_edit_173002;
            buttonEditarParcial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            buttonEditarParcial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonEditarParcial.Location = new System.Drawing.Point(155, 295);
            buttonEditarParcial.Name = "buttonEditarParcial";
            buttonEditarParcial.Size = new System.Drawing.Size(30, 23);
            buttonEditarParcial.Click += ButtonEditarParcial_Click;
            buttonEditarParcial.Visible = position.Status == "Posição fechada" ? false : true;
            // 
            // label31
            // 
            Label label31 = new Label();
            label31.AutoSize = true;
            label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label31.Location = new System.Drawing.Point(6, 297);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(50, 13);
            label31.TabIndex = 32;
            label31.Text = "Parcial:";
            // 
            // label17
            // 
            Label labelPar = new Label();
            labelPar.AutoSize = true;
            labelPar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPar.ForeColor = System.Drawing.Color.Black;
            labelPar.Location = new System.Drawing.Point(6, 200);
            labelPar.Name = "label17";
            labelPar.Size = new System.Drawing.Size(76, 17);
            labelPar.TabIndex = 17;
            labelPar.Text = position.Par1 + " / " + position.Par2;
            // 
            // labelDivider3
            // 
            Label labelDivider3 = new Label();
            labelDivider3.AutoSize = true;
            labelDivider3.Location = new System.Drawing.Point(6, 317);
            labelDivider3.Name = "labelDivider3";
            labelDivider3.Size = new System.Drawing.Size(613, 13);
            labelDivider3.TabIndex = 34;
            labelDivider3.Text = "_________________________________________________________________________________" +
    "_________________________";
            #endregion

            #region history

            // 
            // label37
            // 
            Label labelHistory = new Label();
            labelHistory.AutoSize = true;
            labelHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelHistory.Location = new System.Drawing.Point(6, 340);
            labelHistory.Name = "label37";
            labelHistory.Size = new System.Drawing.Size(61, 13);
            labelHistory.TabIndex = 35;
            labelHistory.Text = "Histórico:";
            // 
            // pnlHistory
            // 
            pnlHistory.Location = new System.Drawing.Point(5, 360);
            pnlHistory.Size = new Size(650, 110);
            pnlHistory.AutoScroll = true;

            foreach (string history in position.Historico)
            {
                Label labelHistory1 = new Label();
                labelHistory1.AutoSize = true;
                labelHistory1.Dock = DockStyle.Top;
                labelHistory1.Text = history;

                Label labelDividerHistory = new Label();
                labelDividerHistory.AutoSize = true;
                labelDividerHistory.Dock = DockStyle.Top;
                labelDividerHistory.Name = "labelDividerHistory";
                labelDividerHistory.Height = 13;

                pnlHistory.Controls.Add(labelHistory1);
                pnlHistory.Controls.Add(labelDividerHistory);
            }

            #endregion

            GroupBox groupBoxPosition = new GroupBox();
            groupBoxPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBoxPosition.Location = new System.Drawing.Point(5, 5);
            groupBoxPosition.Name = "groupBoxPosition";
            groupBoxPosition.TabIndex = 0;
            groupBoxPosition.TabStop = false;
            groupBoxPosition.Text = "Posição 1";
            groupBoxPosition.Controls.Add(pnlHistory);
            groupBoxPosition.Controls.Add(labelHistory);
            groupBoxPosition.Controls.Add(labelDivider1);
            groupBoxPosition.Controls.Add(groupBoxGanhoParcial);
            groupBoxPosition.Controls.Add(labelParcial);
            groupBoxPosition.Controls.Add(label31);
            groupBoxPosition.Controls.Add(labelRelacaoRiscoGanho);
            groupBoxPosition.Controls.Add(label28);
            groupBoxPosition.Controls.Add(groupBoxGanho);
            groupBoxPosition.Controls.Add(groupBoxRisco);
            groupBoxPosition.Controls.Add(labelStop);
            groupBoxPosition.Controls.Add(labelAlvo);
            groupBoxPosition.Controls.Add(labelEntrada);
            groupBoxPosition.Controls.Add(label21);
            groupBoxPosition.Controls.Add(label20);
            groupBoxPosition.Controls.Add(label19);
            groupBoxPosition.Controls.Add(labelTipoPosicao);
            groupBoxPosition.Controls.Add(labelPar);
            groupBoxPosition.Controls.Add(labelDivider2);
            groupBoxPosition.Controls.Add(pnlIndicadores);
            groupBoxPosition.Controls.Add(label12);
            groupBoxPosition.Controls.Add(labelCapital);
            groupBoxPosition.Controls.Add(label11);
            groupBoxPosition.Controls.Add(labelTipoTrade);
            groupBoxPosition.Controls.Add(label10);
            groupBoxPosition.Controls.Add(label9);
            groupBoxPosition.Controls.Add(labelDivider3);
            groupBoxPosition.Controls.Add(label6);
            groupBoxPosition.Controls.Add(label5);
            groupBoxPosition.Controls.Add(label4);
            groupBoxPosition.Controls.Add(label2);
            groupBoxPosition.Controls.Add(labelData);
            groupBoxPosition.Controls.Add(labelHorario);
            groupBoxPosition.Controls.Add(labelExchange);
            groupBoxPosition.Controls.Add(labelFerramenta);
            groupBoxPosition.Controls.Add(labelTecnica);
            groupBoxPosition.Controls.Add(labelPar);
            //groupBoxPosition.Controls.Add(buttonEditar);
            groupBoxPosition.Controls.Add(buttonEditarAlvo);
            groupBoxPosition.Controls.Add(textBoxAlvo);
            groupBoxPosition.Controls.Add(textBoxStop);
            groupBoxPosition.Controls.Add(textBoxParcial);
            groupBoxPosition.Controls.Add(buttonEditarParcial);
            groupBoxPosition.Controls.Add(buttonEditarStop);

            Controls.Add(groupBoxPosition);

            this.ClientSize = new System.Drawing.Size(685, 500);
            this.Padding = new Padding(10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = Positions.Properties.Resources.if_Hunting1_2315994;
            this.Text = "Visualizar posição";
        }

        private void ButtonEditarParcial_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja realmente alterar sua estratégia?", "Alterar estratégia", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                labelParcial.Visible = false;
                textBoxParcial.Visible = true;
                ((Button)sender).BackgroundImage = Positions.Properties.Resources.if_floppy_285657;
                ((Button)sender).Click -= ButtonEditarParcial_Click;
                ((Button)sender).Click += SaveNewParcialClick;
            }
        }

        private void SaveNewParcialClick(object sender, EventArgs e)
        {
            position.Parcial = textBoxParcial.Text;
            position.Historico.Add(DateTime.Now.ToString("dd/MM/yyyy - HH:mm -> ") + "Parcial alterada para " + position.Parcial + ".");
            SalvarXml(position);

            labelParcial.Text = textBoxParcial.Text;
            labelParcial.Visible = true;
            textBoxParcial.Visible = false;
            ((Button)sender).BackgroundImage = Positions.Properties.Resources.if_edit_173002;
            ((Button)sender).Click -= SaveNewParcialClick;
            ((Button)sender).Click += ButtonEditarParcial_Click;

            RecarregarHistorico();
        }

        private void RecarregarHistorico()
        {
            pnlHistory.Controls.Clear();
            foreach (string history in position.Historico)
            {
                Label labelHistory1 = new Label();
                labelHistory1.AutoSize = true;
                labelHistory1.Dock = DockStyle.Top;
                labelHistory1.Text = history;

                Label labelDividerHistory = new Label();
                labelDividerHistory.AutoSize = true;
                labelDividerHistory.Dock = DockStyle.Top;
                labelDividerHistory.Name = "labelDividerHistory";
                labelDividerHistory.Height = 13;

                pnlHistory.Controls.Add(labelHistory1);
                pnlHistory.Controls.Add(labelDividerHistory);
            }
        }

        private void ButtonEditarAlvo_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja realmente alterar sua estratégia?", "Alterar estratégia", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                labelAlvo.Visible = false;
                textBoxAlvo.Visible = true;
                ((Button)sender).BackgroundImage = Positions.Properties.Resources.if_floppy_285657;
                ((Button)sender).Click -= ButtonEditarAlvo_Click;
                ((Button)sender).Click += SaveNewAlvoClick;
            }
        }

        private void SaveNewAlvoClick(object sender, EventArgs e)
        {
            position.Alvo = textBoxAlvo.Text;
            position.Historico.Add(DateTime.Now.ToString("dd/MM/yyyy - HH:mm -> ") + "Alvo alterado para " + position.Alvo + ".");
            SalvarXml(position);

            labelAlvo.Text = textBoxAlvo.Text;
            labelAlvo.Visible = true;
            textBoxAlvo.Visible = false;
            ((Button)sender).BackgroundImage = Positions.Properties.Resources.if_edit_173002;
            ((Button)sender).Click -= SaveNewAlvoClick;
            ((Button)sender).Click += ButtonEditarAlvo_Click;

            RecarregarHistorico();
        }

        private void ButtonEditarStop_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja realmente alterar sua estratégia?", "Alterar estratégia", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                labelStop.Visible = false;
                textBoxStop.Visible = true;
                ((Button)sender).BackgroundImage = Positions.Properties.Resources.if_floppy_285657;
                ((Button)sender).Click -= ButtonEditarStop_Click;
                ((Button)sender).Click += SaveNewStopClick;
            }
        }

        private void SaveNewStopClick(object sender, EventArgs e)
        {
            position.Stop = textBoxStop.Text;
            position.Historico.Add(DateTime.Now.ToString("dd/MM/yyyy - HH:mm -> ") + "Stop alterado para " + position.Stop + ".");
            SalvarXml(position);

            labelStop.Text = textBoxStop.Text;
            labelStop.Visible = true;
            textBoxStop.Visible = false;
            ((Button)sender).BackgroundImage = Positions.Properties.Resources.if_edit_173002;
            ((Button)sender).Click -= SaveNewStopClick;
            ((Button)sender).Click += ButtonEditarStop_Click;

            RecarregarHistorico();
        }

        private void SalvarXml(Position positionUpdate)
        {
            //nao sei pq nao ta funcionando a referencia da posicao no vetor entao..
            foreach (Position position in Program.myHistory.positions)
            {
                if (position.IdPosition == positionUpdate.IdPosition)
                {
                    Program.myHistory.positions.Remove(position);
                    Program.myHistory.positions.Add(positionUpdate);
                    break;
                }
            }

            XmlSerializer serializer = new XmlSerializer(typeof(History));
            string fileName = System.IO.Path.Combine(Application.CommonAppDataPath, "positions.xml");
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, Program.myHistory);
            }
        }

        private void ButtonEditar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deseja realmente alterar sua estratégia?", "Alterar estratégia", MessageBoxButtons.YesNo);
        }


        private void AtualizarParcial(object sender, EventArgs e)
        {
            position.Parcial = textBoxParcial.Text;
            AtualizarCalculados(null, null);
        }

        private void AtualizarStop(object sender, EventArgs e)
        {
            position.Stop = textBoxStop.Text;
            AtualizarCalculados(null, null);
        }

        private void AtualizarAlvo(object sender, EventArgs e)
        {
            position.Alvo = textBoxAlvo.Text;
            AtualizarCalculados(null, null);
        }

        private void AtualizarCalculados(object sender, EventArgs e)
        {
            //RecalcularPorcentagemCapital();

            try
            {
                labelRiscoPercent.Text = position.RiscoPercent.ToString("0.00");
            }
            catch (Exception)
            {
                labelRiscoPercent.Text = "N/A";
            }
            try
            {
                labelRiscoValor.Text = position.RiscoValor.ToString("0.00000000");
            }
            catch (Exception)
            {
                labelRiscoValor.Text = "N/A";
            }
            try
            {
                labelGanhoPercent.Text = position.GanhoPercent.ToString("0.00");
            }
            catch (Exception)
            {
                labelGanhoPercent.Text = "N/A";
            }
            try
            {
                labelGanhoValor.Text = position.GanhoValor.ToString("0.00000000");
            }
            catch (Exception)
            {
                labelGanhoValor.Text = "N/A";
            }
            try
            {
                //if (!checkBoxParcial.Checked) throw new Exception();
                labelGanhoParcialPercent.Text = position.ParcialPercent.ToString("0.00");
            }
            catch (Exception)
            {
                labelGanhoParcialPercent.Text = "N/A";
            }
            try
            {
                //if (!checkBoxParcial.Checked) throw new Exception();
                labelGanhoParcialValor.Text = position.ParcialValor.ToString("0.00000000");
            }
            catch (Exception)
            {
                labelGanhoParcialValor.Text = "N/A";
            }
            try
            {
                labelRelacaoRiscoGanho.Text = position.RelacaoRiscoGanho;
            }
            catch (Exception)
            {
                labelRelacaoRiscoGanho.Text = "N/A";
            }
        }
    }
}
