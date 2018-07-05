using OperationsWF.Model;
using System;
using System.Collections;
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

namespace OperationsWF
{
    public partial class EditPositionForm : Form
    {
        ComboBox comboBoxExchange = new ComboBox();
        ComboBox comboBoxFerramenta = new ComboBox();
        TextBox textBoxData = new TextBox();
        TextBox textBoxHora = new TextBox();
        ComboBox comboBoxStatus = new ComboBox();
        ComboBox comboBoxTipoTrade = new ComboBox();
        ComboBox comboBoxTipoPosicao = new ComboBox();
        ComboBox comboBoxTecnica = new ComboBox();
        TextBox textBoxCapital = new TextBox();
        CheckedListBox checkedListBoxIndicadores = new CheckedListBox();
        ComboBox comboBoxPar2 = new ComboBox();
        ComboBox comboBoxPar1 = new ComboBox();
        TextBox textBoxEntrada = new TextBox();
        TextBox textBoxAlvo = new TextBox();
        TextBox textBoxStop = new TextBox();
        TextBox textBoxParcial = new TextBox();
        Label labelRelacaoRiscoGanho = new Label();
        Label labelGanhoPercent = new Label();
        Label labelGanhoValor = new Label();
        Label labelRiscoPercent = new Label();
        Label labelRiscoValor = new Label();
        Label labelGanhoParcialPercent = new Label();
        Label labelGanhoParcialValor = new Label();

        Position position;
        public EditPositionForm(Position position)
        {
            this.position = position;
            DrawForm();
            RecalcularRiscoGanho(null, null);
        }

        private void DrawForm()
        {
            #region header
                        
            // 
            // label5
            // 
            Label label5 = new Label();
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(6, 19);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(67, 13);
            label5.Text = "Exchange:";
            // 
            // comboBoxExchange
            // 
            comboBoxExchange.FormattingEnabled = true;
            comboBoxExchange.Location = new System.Drawing.Point(90, label5.Location.Y);
            comboBoxExchange.Name = "comboBoxExchange";
            comboBoxExchange.Size = new System.Drawing.Size(180, 13);
            comboBoxExchange.Items.AddRange(DynamicDB.exchanges);
            comboBoxExchange.SelectedText = position.exchange;
            comboBoxExchange.TabIndex = 1;
            // 
            // label6
            // 
            Label label6 = new Label();
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(6, 45);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(74, 13);
            label6.Text = "Ferramenta:";
            // 
            // comboBoxFerramenta
            // 
            comboBoxFerramenta.FormattingEnabled = true;
            comboBoxFerramenta.Location = new System.Drawing.Point(90, label6.Location.Y);
            comboBoxFerramenta.Name = "comboBoxFerramenta";
            comboBoxFerramenta.Size = new System.Drawing.Size(180, 13);
            comboBoxFerramenta.Items.AddRange(DynamicDB.ferramentas);
            comboBoxFerramenta.SelectedText = position.ferramenta;
            comboBoxFerramenta.TabIndex = 2;
            // 
            // label2
            // 
            Label label2 = new Label();
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(290, 19);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 13);
            label2.Text = "Data inicial:";
            // 
            // textBoxData
            // 
            textBoxData.Location = new System.Drawing.Point(395, label2.Location.Y);
            textBoxData.Name = "textBoxData";
            textBoxData.Size = new System.Drawing.Size(70, 13);
            textBoxData.Text = position.data_abertura;
            textBoxData.TabIndex = 3;
            // 
            // label4
            // 
            Label label4 = new Label();
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(290, 45);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(89, 13);
            label4.Text = "Horário entrada:";
            // 
            // textBoxHora
            // 
            textBoxHora.Location = new System.Drawing.Point(395, label4.Location.Y);
            textBoxHora.Name = "textBoxHora";
            textBoxHora.Size = new System.Drawing.Size(70, 13);
            textBoxHora.Text = position.hora_abertura;
            textBoxHora.TabIndex = 4;
            // 
            // labelStatus
            // 
            Label labelStatus = new Label();
            labelStatus.AutoSize = true;
            labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelStatus.Location = new System.Drawing.Point(480, 19);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new System.Drawing.Size(67, 13);
            labelStatus.Text = "Estado posição:";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new System.Drawing.Point(580, labelStatus.Location.Y);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new System.Drawing.Size(90, 13);
            comboBoxStatus.Items.AddRange(DynamicDB.estadosPosicao);
            comboBoxStatus.SelectedText = position.status;
            comboBoxStatus.TabIndex = 5;
            // 
            // labelTipoTrade
            // 
            Label labelTipoTrade = new Label();
            labelTipoTrade.AutoSize = true;
            labelTipoTrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelTipoTrade.Location = new System.Drawing.Point(480, 45);
            labelTipoTrade.Name = "labelTipoTrade";
            labelTipoTrade.Size = new System.Drawing.Size(67, 13);
            labelTipoTrade.Text = "Tipo Trade:";
            // 
            // comboBoxTipoTrade
            // 
            comboBoxTipoTrade.FormattingEnabled = true;
            comboBoxTipoTrade.Location = new System.Drawing.Point(580, labelTipoTrade.Location.Y);
            comboBoxTipoTrade.Name = "comboBoxTipoTrade";
            comboBoxTipoTrade.Size = new System.Drawing.Size(90, 13);
            comboBoxTipoTrade.Items.AddRange(DynamicDB.tiposTrade);
            comboBoxTipoTrade.SelectedText = position.tipoTrade;
            comboBoxTipoTrade.TabIndex = 6;
            // 
            // labelDivider1
            // 
            Label labelDivider1 = new Label();
            labelDivider1.AutoSize = true;
            labelDivider1.Location = new System.Drawing.Point(6, 75);
            labelDivider1.Name = "labelDivider1";
            labelDivider1.Size = new System.Drawing.Size(613, 13);
            labelDivider1.Text = "_________________________________________________________________________________" +
    "____________________________";

            #endregion

            #region indicadores

            //
            // label9
            // 
            Label label9 = new Label();
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(3, 101);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(102, 13);
            label9.Text = "Tipo de posição:";
            // 
            // comboBoxTipoPosicao
            // 
            comboBoxTipoPosicao.FormattingEnabled = true;
            comboBoxTipoPosicao.Location = new System.Drawing.Point(122, 99);
            comboBoxTipoPosicao.Name = "comboBoxTipoPosicao";
            comboBoxTipoPosicao.Size = new System.Drawing.Size(150, 17);
            comboBoxTipoPosicao.Items.AddRange(DynamicDB.tiposPosicao);
            comboBoxTipoPosicao.SelectedText = position.tipoPosicao;
            comboBoxTipoPosicao.TabIndex = 7;
            // 
            // label10
            // 
            Label label10 = new Label();
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(3, 129);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(109, 13);
            label10.Text = "Técnica aplicada:";
            // 
            // comboBoxTecnica
            // 
            comboBoxTecnica.FormattingEnabled = true;
            comboBoxTecnica.Location = new System.Drawing.Point(122, label10.Location.Y);
            comboBoxTecnica.Name = "comboBoxTecnica";
            comboBoxTecnica.Size = new System.Drawing.Size(150, 13);
            comboBoxTecnica.Items.AddRange(DynamicDB.tecnicas);
            comboBoxTecnica.SelectedIndex = 0;
            comboBoxTecnica.TabIndex = 8;
            // 
            // label12
            // 
            Label label12 = new Label();
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.Location = new System.Drawing.Point(6, 158);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(102, 13);
            label12.Text = "Capital aplicado:";
            // 
            // textBoxCapital
            // 
            textBoxCapital.Location = new System.Drawing.Point(122, label12.Location.Y);
            textBoxCapital.Name = "textBoxCapital";
            textBoxCapital.Size = new System.Drawing.Size(100, 13);
            textBoxCapital.Text = "0.02";
            textBoxCapital.TabIndex = 9;
            textBoxCapital.TextChanged += RecalcularRiscoGanho;
            // 
            // labelCapitalCurrency
            // 
            Label labelCapitalCurrency = new Label();
            labelCapitalCurrency.AutoSize = true;
            labelCapitalCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelCapitalCurrency.Location = new System.Drawing.Point(230, label12.Location.Y);
            labelCapitalCurrency.Name = "labelCapitalCurrency";
            labelCapitalCurrency.Size = new System.Drawing.Size(50, 13);
            // 
            // label11
            // 
            Label label11 = new Label();
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.Location = new System.Drawing.Point(296, 101);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(121, 13);
            label11.Text = "Indicadores à favor:";
            // 
            // checkedListBoxIndicadores
            // 
            checkedListBoxIndicadores.BackColor = System.Drawing.SystemColors.ControlLight;
            checkedListBoxIndicadores.FormattingEnabled = true;
            checkedListBoxIndicadores.Items.AddRange(DynamicDB.indicadores);
            checkedListBoxIndicadores.Location = new System.Drawing.Point(430, 101);
            checkedListBoxIndicadores.Name = "checkedListBoxIndicadores";
            checkedListBoxIndicadores.Size = new System.Drawing.Size(210, 90);
            checkedListBoxIndicadores.ScrollAlwaysVisible = true;
            checkedListBoxIndicadores.TabIndex = 10;
            // 
            // labelDivider2
            // 
            Label labelDivider2 = new Label();
            labelDivider2.AutoSize = true;
            labelDivider2.Location = new System.Drawing.Point(6, 178);
            labelDivider2.Name = "labelDivider2";
            labelDivider2.Size = new System.Drawing.Size(613, 8);
            labelDivider2.Text = "_________________________________________________________________________________" +
    "____________________________";

            #endregion

            #region calculados  

            // 
            // labelPar
            // 
            Label labelPar = new Label();
            labelPar.AutoSize = true;
            labelPar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPar.Location = new System.Drawing.Point(6, 210);
            labelPar.Name = "labelPar";
            labelPar.Size = new System.Drawing.Size(55, 13);
            labelPar.Text = "Par:";
            // 
            // comboBoxPar2
            // 
            comboBoxPar2.FormattingEnabled = true;
            comboBoxPar2.Location = new System.Drawing.Point(80, 210);
            comboBoxPar2.Name = "comboBoxPar2";
            comboBoxPar2.Size = new System.Drawing.Size(65, 21);
            comboBoxPar2.Items.AddRange(DynamicDB.moedas);
            comboBoxPar2.SelectedIndex = 0;
            comboBoxPar2.TabIndex = 11;
            // 
            // labelDivPar
            // 
            Label labelDivPar = new Label();
            labelDivPar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelDivPar.AutoSize = true;
            labelDivPar.Location = new System.Drawing.Point(150, 210);
            labelDivPar.Name = "labelDivPar";
            labelDivPar.Size = new System.Drawing.Size(10, 13);
            labelDivPar.Text = "/";
            // 
            // comboBoxPar1
            // 
            comboBoxPar1.FormattingEnabled = true;
            comboBoxPar1.Location = new System.Drawing.Point(165, 210);
            comboBoxPar1.Name = "comboBoxPar1";
            comboBoxPar1.Size = new System.Drawing.Size(65, 21);
            comboBoxPar1.Items.AddRange(DynamicDB.moedas);
            comboBoxPar1.SelectedIndex = 1;
            comboBoxPar1.TabIndex = 12;
            labelCapitalCurrency.Text = comboBoxPar1.Text;
            // 
            // label19
            // 
            Label label19 = new Label();
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label19.Location = new System.Drawing.Point(6, 235);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(55, 13);
            label19.Text = "Entrada:";
            // 
            // textBoxEntrada
            // 
            textBoxEntrada.Location = new System.Drawing.Point(80, 235);
            textBoxEntrada.Name = "textBoxEntrada";
            textBoxEntrada.Size = new System.Drawing.Size(150, 13);
            textBoxEntrada.TabIndex = 13;
            textBoxEntrada.Text = "0.00002222";
            textBoxEntrada.TextChanged += RecalcularRiscoGanho;
            // 
            // label20
            // 
            Label label20 = new Label();
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label20.Location = new System.Drawing.Point(6, 260);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(36, 13);
            label20.Text = "Alvo:";
            // 
            // textBoxAlvo
            // 
            textBoxAlvo.Location = new System.Drawing.Point(80, 260);
            textBoxAlvo.Name = "textBoxAlvo";
            textBoxAlvo.Size = new System.Drawing.Size(150, 13);
            textBoxAlvo.TabIndex = 14;
            textBoxAlvo.Text = "0.00004444";
            textBoxAlvo.TextChanged += RecalcularRiscoGanho;
            // 
            // label21
            // 
            Label label21 = new Label();
            label21.AutoSize = true;
            label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label21.Location = new System.Drawing.Point(6, 285);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(37, 13);
            label21.Text = "Stop:";
            // 
            // textBoxStop
            // 
            textBoxStop.Location = new System.Drawing.Point(80, 285);
            textBoxStop.Name = "textBoxStop";
            textBoxStop.Size = new System.Drawing.Size(150, 13);
            textBoxStop.TabIndex = 15;
            textBoxStop.Text = "0.00001111";
            textBoxStop.TextChanged += RecalcularRiscoGanho;
            // 
            // label31
            // 
            Label label31 = new Label();
            label31.AutoSize = true;
            label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label31.Location = new System.Drawing.Point(6, 310);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(50, 13);
            label31.Text = "Parcial:";
            // 
            // textBoxParcial
            // 
            textBoxParcial.Location = new System.Drawing.Point(80, 310);
            textBoxParcial.Name = "textBoxParcial";
            textBoxParcial.Size = new System.Drawing.Size(150, 13);
            textBoxParcial.TabIndex = 16;
            textBoxParcial.Text = "0.00003333";
            textBoxParcial.TextChanged += RecalcularRiscoGanho;
            
            // 
            // label28
            // 
            Label label28 = new Label();
            label28.AutoSize = true;
            label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label28.Location = new System.Drawing.Point(350, 210);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(137, 13);
            label28.Text = "Relação Risco/Ganho:";
            // 
            // labelRelacaoRiscoGanho
            // 
            labelRelacaoRiscoGanho.AutoSize = true;
            labelRelacaoRiscoGanho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            labelRelacaoRiscoGanho.Location = new System.Drawing.Point(500, 210);
            labelRelacaoRiscoGanho.Name = "label29";
            labelRelacaoRiscoGanho.Size = new System.Drawing.Size(34, 13);
            labelRelacaoRiscoGanho.Text = relacaoRiscoGanho;

            #region groupboxGanho

            // 
            // label24
            // 
            labelGanhoPercent.AutoSize = true;
            labelGanhoPercent.ForeColor = System.Drawing.Color.Green;
            labelGanhoPercent.Location = new System.Drawing.Point(80, 49);
            labelGanhoPercent.Name = "label24";
            labelGanhoPercent.Size = new System.Drawing.Size(30, 13);
            labelGanhoPercent.TabIndex = 29;
            labelGanhoPercent.Text = ganhoPercent.ToString("0.00") + "%";
            // 
            // label25
            // 
            labelGanhoValor.AutoSize = true;
            labelGanhoValor.ForeColor = System.Drawing.Color.Green;
            labelGanhoValor.Location = new System.Drawing.Point(47, 26);
            labelGanhoValor.Name = "label25";
            labelGanhoValor.Size = new System.Drawing.Size(34, 13);
            labelGanhoValor.TabIndex = 28;
            labelGanhoValor.Text = ganhoValor.ToString("0.00000000");
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
            groupBoxGanho.Location = new System.Drawing.Point(270, 240);
            groupBoxGanho.Name = "groupBox2";
            groupBoxGanho.Size = new System.Drawing.Size(120, 75);
            groupBoxGanho.TabIndex = 30;
            groupBoxGanho.TabStop = false;
            groupBoxGanho.Text = "Ganho";

            #endregion

            #region groupBoxRisco

            // 
            // labelRiscoPercent
            // 
            labelRiscoPercent.AutoSize = true;
            labelRiscoPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            labelRiscoPercent.Location = new System.Drawing.Point(80, 49);
            labelRiscoPercent.Name = "labelRiscoPercent";
            labelRiscoPercent.Size = new System.Drawing.Size(30, 13);
            labelRiscoPercent.TabIndex = 29;
            labelRiscoPercent.Text = riscoPercent.ToString("0.00") + "%";
            // 
            // labelRiscoValor
            // 
            labelRiscoValor.AutoSize = true;
            labelRiscoValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            labelRiscoValor.Location = new System.Drawing.Point(47, 26);
            labelRiscoValor.Name = "labelRiscoValor";
            labelRiscoValor.Size = new System.Drawing.Size(34, 13);
            labelRiscoValor.TabIndex = 28;
            labelRiscoValor.Text = riscoValor.ToString("0.00000000");
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
            groupBoxRisco.Location = new System.Drawing.Point(400, 240);
            groupBoxRisco.Name = "groupBox12";
            groupBoxRisco.Size = new System.Drawing.Size(120, 75);
            groupBoxRisco.TabIndex = 25;
            groupBoxRisco.TabStop = false;
            groupBoxRisco.Text = "Risco";

            #endregion

            #region groupBoxGanhoParcial

            // 
            // label32
            // 
            labelGanhoParcialPercent.AutoSize = true;
            labelGanhoParcialPercent.ForeColor = System.Drawing.Color.Green;
            labelGanhoParcialPercent.Location = new System.Drawing.Point(80, 49);
            labelGanhoParcialPercent.Name = "label32";
            labelGanhoParcialPercent.Size = new System.Drawing.Size(30, 13);
            labelGanhoParcialPercent.TabIndex = 29;
            labelGanhoParcialPercent.Text = parcialPercent.ToString("0.00") + "%";
            // 
            // label33
            // 
            labelGanhoParcialValor.AutoSize = true;
            labelGanhoParcialValor.ForeColor = System.Drawing.Color.Green;
            labelGanhoParcialValor.Location = new System.Drawing.Point(47, 26);
            labelGanhoParcialValor.Name = "label33";
            labelGanhoParcialValor.Size = new System.Drawing.Size(34, 13);
            labelGanhoParcialValor.TabIndex = 28;
            labelGanhoParcialValor.Text = parcialValor.ToString("0.00000000");
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
            groupBoxGanhoParcial.Location = new System.Drawing.Point(540, 240);
            groupBoxGanhoParcial.Name = "groupBox3";
            groupBoxGanhoParcial.Size = new System.Drawing.Size(120, 75);
            groupBoxGanhoParcial.TabIndex = 31;
            groupBoxGanhoParcial.TabStop = false;
            groupBoxGanhoParcial.Text = "Ganho Parcial";

            #endregion

            // 
            // buttonVer
            // 
            Button buttonSalvar = new Button();
            buttonSalvar.BackColor = System.Drawing.SystemColors.Control;
            buttonSalvar.BackgroundImage = global::Positions.Properties.Resources.if_floppy_285657;
            buttonSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            buttonSalvar.ForeColor = System.Drawing.SystemColors.ControlLight;
            buttonSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonSalvar.Location = new System.Drawing.Point(620, 200);
            buttonSalvar.Name = "buttonSalvar";
            buttonSalvar.Size = new System.Drawing.Size(40, 28);
            buttonSalvar.TabIndex = 12;
            buttonSalvar.UseVisualStyleBackColor = false;
            buttonSalvar.Click += ButtonSalvar_Click;

            #endregion

            this.ClientSize = new System.Drawing.Size(685, 350);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = Positions.Properties.Resources.if_Hunting1_2315994;
            this.Text = "Nova posição";
            Controls.Add(labelStatus);
            Controls.Add(labelDivider1);
            Controls.Add(groupBoxGanhoParcial);
            Controls.Add(textBoxParcial);
            Controls.Add(label31);
            Controls.Add(labelRelacaoRiscoGanho);
            Controls.Add(label28);
            Controls.Add(groupBoxGanho);
            Controls.Add(groupBoxRisco);
            Controls.Add(textBoxStop);
            Controls.Add(textBoxAlvo);
            Controls.Add(textBoxEntrada);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(comboBoxTipoPosicao);
            Controls.Add(checkedListBoxIndicadores);
            Controls.Add(labelDivider2);
            Controls.Add(label12);
            Controls.Add(textBoxCapital);
            Controls.Add(label11);
            Controls.Add(labelTipoTrade);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(textBoxData);
            Controls.Add(textBoxHora);
            Controls.Add(comboBoxExchange);
            Controls.Add(comboBoxFerramenta);
            Controls.Add(comboBoxTecnica);
            Controls.Add(labelPar);
            Controls.Add(labelDivPar);
            Controls.Add(comboBoxPar1);
            Controls.Add(comboBoxPar2);
            Controls.Add(labelStatus);
            Controls.Add(comboBoxStatus);
            Controls.Add(labelTipoTrade);
            Controls.Add(comboBoxTipoTrade);
            Controls.Add(buttonSalvar);

        }

        private void RecalcularRiscoGanho(object sender, EventArgs e)
        {
            this.riscoPercent = calculaRiscoPercent();
            labelRiscoPercent.Text = this.riscoPercent.ToString("0.00");
            this.riscoValor = calculaRiscoValor();
            labelRiscoValor.Text = this.riscoValor.ToString("0.0000");
            this.ganhoPercent = calculaGanhoPercent();
            labelGanhoPercent.Text = this.ganhoPercent.ToString("0.00");
            this.ganhoValor = calculaGanhoValor();
            labelGanhoValor.Text = this.ganhoValor.ToString("0.0000");
            this.parcialPercent = calculaGanhoParcialPercent();
            labelGanhoParcialPercent.Text = this.parcialPercent.ToString("0.00");
            this.parcialValor = calculaGanhoParcialValor();
            labelGanhoParcialValor.Text = this.parcialValor.ToString("0.0000");
            this.relacaoRiscoGanho = calculaRelacaoRiscoGanho();
            labelRelacaoRiscoGanho.Text = this.relacaoRiscoGanho;
        }

        private void ButtonSalvar_Click(object sender, EventArgs e)
        {
            ArrayList indicadores = new ArrayList ();
            foreach (var indicador in checkedListBoxIndicadores.CheckedItems)
            {
                indicadores.Add(indicador.ToString());
            }

            Position position = new Position(
                GetNewID(),
                comboBoxPar1.Text,
                comboBoxPar2.Text,
                comboBoxExchange.Text,
                comboBoxFerramenta.Text,
                comboBoxTecnica.Text,
                indicadores,
                comboBoxTipoTrade.Text,
                comboBoxTipoPosicao.Text,
                textBoxCapital.Text,
                textBoxEntrada.Text,
                textBoxAlvo.Text,
                textBoxStop.Text,
                textBoxParcial.Text,
                textBoxData.Text,
                textBoxHora.Text,
                new ArrayList {
                    String.Concat("Posição aberta no par {0} às {1} horas da data {2}, seguindo relação risco/ganho de {3}. Entrada: {4}, Alvo: {5}, Stop: {6}, Parcial: {7}. Capital aplicado de {8} utilizando técnica {9}.",
                     comboBoxPar1.Text+"/"+comboBoxPar2.Text,textBoxHora.Text,textBoxData.Text,relacaoRiscoGanho,
                     textBoxEntrada.Text,
                textBoxAlvo.Text,
                textBoxStop.Text,
                textBoxParcial.Text,textBoxCapital.Text,comboBoxTecnica.Text
                     )});

            Program.myHistory.positions.Add(position);

            XmlSerializer serializer = new XmlSerializer(typeof(History));
            string fileName = System.IO.Path.Combine(Application.CommonAppDataPath, "positions.xml");
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, Program.myHistory);
            }

            this.Close();
        }

        private int GetNewID()
        {
            int id = 0;
            foreach (Position position in Program.myHistory.positions)
            {
                if (position.idPosition >= id)
                    id = position.idPosition + 1;
            }
            return id;
        }

        private float riscoPercent;
        private float riscoValor;
        private float ganhoPercent;
        private float ganhoValor;
        private float parcialPercent;
        private float parcialValor;
        private string relacaoRiscoGanho;   

        private float calculaRiscoPercent()
        {
            float stop = float.Parse(textBoxStop.Text, CultureInfo.InvariantCulture.NumberFormat);
            float entrada = float.Parse(textBoxEntrada.Text, CultureInfo.InvariantCulture.NumberFormat);
            return ((stop - entrada) * 100 / entrada);
        }

        private float calculaRiscoValor()
        {
            float capital = float.Parse(textBoxCapital.Text, CultureInfo.InvariantCulture.NumberFormat);
            return capital * this.riscoPercent / 100;
        }

        private float calculaGanhoPercent()
        {
            float alvo = float.Parse(textBoxAlvo.Text, CultureInfo.InvariantCulture.NumberFormat);
            float entrada = float.Parse(textBoxEntrada.Text, CultureInfo.InvariantCulture.NumberFormat);
            return (alvo - entrada) * 100 / entrada;
        }

        private float calculaGanhoValor()
        {
            float capital = float.Parse(textBoxCapital.Text, CultureInfo.InvariantCulture.NumberFormat);
            return capital * this.ganhoPercent / 100;
        }

        /*private string calculaRelacaoRiscoGanho()
        {
            return Math.Abs(riscoPercent).ToString("0") + "/" + ganhoPercent.ToString("0");
        }*/

        private string calculaRelacaoRiscoGanho()
        {
            int numerador = Convert.ToInt32(Math.Abs(riscoPercent));
            int denominador = Convert.ToInt32(Math.Abs(ganhoPercent));
            int novoNumerador = 0;
            int novoDenominador = 0;

            if (numerador > denominador) // CASO O NUMERADOR SEJA MAIOR QUE O DENOMINADOR
            {
                for (int i = 2; 2 < denominador; i++)
                    if (numerador % i == 0 && denominador % i == 0)
                    {
                        novoNumerador = numerador / i;
                        novoDenominador = denominador / i;
                    }
            }
            else if (numerador < denominador)
            { // CASO O DENOMINADOR SEJA MAIOR QUE O NUMERADOR
                for (int i = 2; i <= numerador; i++)
                {
                    if (numerador % i == 0 && denominador % i == 0)
                    {
                        novoNumerador = numerador / i;
                        novoDenominador = denominador / i;
                    }
                }
            }
            else if (novoNumerador == novoDenominador)
            {//NUMEROS IGUAIS
                novoNumerador = novoDenominador = 1;
            }

            if (novoNumerador == 0 && novoDenominador == 0)
            {//numero muito diferentes - sem mdc
                novoNumerador = numerador;
                novoDenominador = denominador;
            }

            return novoNumerador + "/" + novoDenominador;
        }

        private float calculaGanhoParcialPercent()
        {
            float parcial = float.Parse(textBoxParcial.Text, CultureInfo.InvariantCulture.NumberFormat);
            float entrada = float.Parse(textBoxEntrada.Text, CultureInfo.InvariantCulture.NumberFormat);
            return (parcial - entrada) * 100 / entrada;
        }

        private float calculaGanhoParcialValor()
        {
            float capital = float.Parse(textBoxCapital.Text, CultureInfo.InvariantCulture.NumberFormat);
            return capital * this.parcialPercent / 100;
        }
    }
}
