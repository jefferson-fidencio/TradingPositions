using Positions.UI.Panels;
using System.Drawing;
using System.Windows.Forms;

namespace OperationsWF
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenuLateral = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuConfiguracoes = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuGanhos = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuMinhasOperacoes = new System.Windows.Forms.Label();
            this.pictureBoxMenuMinhasOperacoes = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogoPositions = new System.Windows.Forms.PictureBox();
            this.labelLogoPositions = new System.Windows.Forms.Label();
            this.panelHistory = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OperarPage = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panelSobre = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSaldo = new Label();

            #region panelSobre (desativado)

            // 
            // panelSobre
            // 
            this.panelSobre.BackColor = System.Drawing.Color.White;
            this.panelSobre.Controls.Add(this.label6);
            this.panelSobre.Controls.Add(this.pictureBox3);
            this.panelSobre.Controls.Add(this.label5);
            this.panelSobre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSobre.Location = new System.Drawing.Point(223, 0);
            this.panelSobre.Name = "panelSobre";
            this.panelSobre.Size = new System.Drawing.Size(739, 537);
            this.panelSobre.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Leelawadee UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(202, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(243, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Feito pra galera do cadê meu bitcoin ;)";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BackgroundImage = global::Positions.Properties.Resources.if_statistics_383213;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(170, 158);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(76, 63);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Leelawadee UI", 30F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(252, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 54);
            this.label5.TabIndex = 7;
            this.label5.Text = "Positions";

            #endregion

            #region Menu

            // 
            // pictureBox1
            // 
            pictureBoxLogoPositions.BackgroundImage = global::Positions.Properties.Resources._383213_64;
            pictureBoxLogoPositions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBoxLogoPositions.Location = new System.Drawing.Point(23, 30);
            pictureBoxLogoPositions.Name = "pictureBox1";
            pictureBoxLogoPositions.Size = new System.Drawing.Size(44, 44);
            pictureBoxLogoPositions.TabIndex = 3;
            pictureBoxLogoPositions.TabStop = false;
            // 
            // Positions
            // 
            labelLogoPositions.AutoSize = true;
            labelLogoPositions.Font = new System.Drawing.Font("Leelawadee UI", 20F);
            labelLogoPositions.ForeColor = System.Drawing.Color.White;
            labelLogoPositions.Location = new System.Drawing.Point(73, 48);
            labelLogoPositions.Name = "Positions";
            labelLogoPositions.Size = new System.Drawing.Size(124, 37);
            labelLogoPositions.TabIndex = 2;
            labelLogoPositions.Text = "Positions";
            // 
            // panelMenuLateral
            // 
            this.panelMenuLateral.BackColor = System.Drawing.Color.Firebrick;
            this.panelMenuLateral.Controls.Add(this.panel3);
            this.panelMenuLateral.Controls.Add(this.panel1);
            this.panelMenuLateral.Controls.Add(this.label4);
            this.panelMenuLateral.Controls.Add(this.panel2);
            this.panelMenuLateral.Controls.Add(this.pictureBoxLogoPositions);
            this.panelMenuLateral.Controls.Add(this.labelLogoPositions);
            this.panelMenuLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuLateral.Location = new System.Drawing.Point(0, 0);
            this.panelMenuLateral.Name = "panelMenuLateral";
            this.panelMenuLateral.Size = new System.Drawing.Size(223, 537);
            this.panelMenuLateral.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkRed;
            this.panel3.Controls.Add(this.menuConfiguracoes);
            this.panel3.Controls.Add(this.pictureBox6);
            this.panel3.Location = new System.Drawing.Point(0, 335);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(223, 59);
            this.panel3.TabIndex = 7;
            // 
            // menuConfiguracoes
            // 
            this.menuConfiguracoes.AutoSize = true;
            this.menuConfiguracoes.Font = new System.Drawing.Font("Leelawadee UI", 14F);
            this.menuConfiguracoes.ForeColor = System.Drawing.Color.White;
            this.menuConfiguracoes.Location = new System.Drawing.Point(53, 17);
            this.menuConfiguracoes.Name = "menuConfiguracoes";
            this.menuConfiguracoes.Size = new System.Drawing.Size(134, 25);
            this.menuConfiguracoes.TabIndex = 5;
            this.menuConfiguracoes.Text = "Configurações";
            this.menuConfiguracoes.Click += new System.EventHandler(this.menuConfiguracoesClick);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::Positions.Properties.Resources._430115_32;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(17, 19);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(24, 24);
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.menuGanhos);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Location = new System.Drawing.Point(0, 270);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 59);
            this.panel1.TabIndex = 6;
            // 
            // menuMinhasOperacoes
            // 
            menuMinhasOperacoes.AutoSize = true;
            menuMinhasOperacoes.Font = new System.Drawing.Font("Leelawadee UI", 14F);
            menuMinhasOperacoes.ForeColor = System.Drawing.Color.White;
            menuMinhasOperacoes.Location = new System.Drawing.Point(53, 17);
            menuMinhasOperacoes.Name = "menuMinhasOperacoes";
            menuMinhasOperacoes.Size = new System.Drawing.Size(152, 25);
            menuMinhasOperacoes.TabIndex = 5;
            menuMinhasOperacoes.Text = "Minhas Posições";
            menuMinhasOperacoes.Click += new System.EventHandler(this.menuMinhasOperacoesClick);
            // 
            // pictureBoxMenuMinhasOperacoes
            // 
            pictureBoxMenuMinhasOperacoes.BackgroundImage = global::Positions.Properties.Resources._1530077_32;
            pictureBoxMenuMinhasOperacoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBoxMenuMinhasOperacoes.Location = new System.Drawing.Point(12, 14);
            pictureBoxMenuMinhasOperacoes.Name = "pictureBoxMenuMinhasOperacoes";
            pictureBoxMenuMinhasOperacoes.Size = new System.Drawing.Size(32, 32);
            pictureBoxMenuMinhasOperacoes.TabIndex = 5;
            pictureBoxMenuMinhasOperacoes.TabStop = false;
            // 
            // label8
            // 
            this.menuGanhos.AutoSize = true;
            this.menuGanhos.Font = new System.Drawing.Font("Leelawadee UI", 14F);
            this.menuGanhos.ForeColor = System.Drawing.Color.White;
            this.menuGanhos.Location = new System.Drawing.Point(53, 17);
            this.menuGanhos.Name = "label8";
            this.menuGanhos.Size = new System.Drawing.Size(127, 25);
            this.menuGanhos.TabIndex = 5;
            this.menuGanhos.Text = "Meus Ganhos";
            menuGanhos.Click += new System.EventHandler(this.menuGanhosClick);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::Positions.Properties.Resources._309025_32;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(18, 21);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.TabIndex = 5;
            this.pictureBox5.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Leelawadee UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(63, 509);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Versão 1.0.0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkRed;
            this.panel2.Controls.Add(this.menuMinhasOperacoes);
            this.panel2.Controls.Add(this.pictureBoxMenuMinhasOperacoes);
            this.panel2.Location = new System.Drawing.Point(0, 205);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 59);
            this.panel2.TabIndex = 4;

            #endregion

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 537);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Positions";

            #region Header

            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Leelawadee UI", 14F, System.Drawing.FontStyle.Bold);
            label7.ForeColor = System.Drawing.Color.White;
            label7.Location = new System.Drawing.Point(75, 16);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(157, 25);
            label7.TabIndex = 6;
            label7.Text = "Minhas Posições";
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = global::Positions.Properties.Resources._1530077_32;
            pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox4.Location = new System.Drawing.Point(20, 11);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(32, 32);
            pictureBox4.TabIndex = 7;
            pictureBox4.TabStop = false;
            // 
            // pictureBoxWallet
            // 
            PictureBox pictureBoxWallet = new PictureBox();
            pictureBoxWallet.BackgroundImage = global::Positions.Properties.Resources._309020_24__1_;
            pictureBoxWallet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBoxWallet.Location = new System.Drawing.Point(500, 15);
            pictureBoxWallet.Name = "pictureBoxWallet";
            pictureBoxWallet.Size = new System.Drawing.Size(32, 32);
            pictureBoxWallet.TabIndex = 5;
            pictureBoxWallet.TabStop = false;
            // 
            // labelWallet
            // 
            Label labelWallet = new Label();
            labelWallet.AutoSize = true;
            labelWallet.ForeColor = Color.White;
            labelWallet.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            labelWallet.Location = new System.Drawing.Point(pictureBoxWallet.Location.X + pictureBoxWallet.Width + 10, 15);
            labelWallet.Name = "labelWallet";
            labelWallet.Size = new System.Drawing.Size(74, 0);
            labelWallet.TabIndex = 3;
            labelWallet.Text = "Saldo atual (BTC):";
            // 
            // labelSaldo
            // 
            labelSaldo.AutoSize = true;
            labelSaldo.ForeColor = Color.White;
            labelSaldo.Location = new System.Drawing.Point(labelWallet.Location.X, labelWallet.Location.Y + 20);
            labelSaldo.Name = "labelSaldo";
            labelSaldo.Size = new System.Drawing.Size(80, 13);
            labelSaldo.TabIndex = 28;            
            // 
            // pnlBackground
            // 
            Panel pnlBackground = new Panel();
            pnlBackground.BackColor = System.Drawing.Color.Firebrick;
            pnlBackground.Controls.Add(label7);
            pnlBackground.Controls.Add(pictureBox4);
            pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlBackground.Margin = new Padding(10);
            pnlBackground.Location = new System.Drawing.Point(10, 10);
            pnlBackground.Name = "pnlBackground";
            pnlBackground.Size = new System.Drawing.Size(719, 60);
            pnlBackground.Controls.Add(pictureBox4);
            pnlBackground.Controls.Add(label7);
            pnlBackground.Controls.Add(pictureBoxWallet);
            pnlBackground.Controls.Add(labelWallet);
            pnlBackground.Controls.Add(labelSaldo);
            // 
            // panelHeader
            // 
            panelHeader.Padding = new Padding(10,0,10,0);
            panelHeader.BackColor = System.Drawing.Color.White;
            panelHeader.Controls.Add(pnlBackground);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(10, 10);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(719, 60);
            panelHeader.TabIndex = 1;

            #endregion
        }

        #endregion

        private System.Windows.Forms.Panel panelMenuLateral;
        private System.Windows.Forms.Panel panelHistory;
        private System.Windows.Forms.Panel OperarPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxLogoPositions;
        private System.Windows.Forms.Label labelLogoPositions;
        private Panel panel2;
        private Label menuMinhasOperacoes;
        private PictureBox pictureBoxMenuMinhasOperacoes;
        private Label label4;
        private Panel panelSobre;
        private PictureBox pictureBox3;
        private Label label5;
        private Label label6;
        private Panel panelHeader;
        private Label label7;
        private PictureBox pictureBox4;
        private Panel panel3;
        private Label menuConfiguracoes;
        private PictureBox pictureBox6;
        private Panel panel1;
        private Label menuGanhos;
        private PictureBox pictureBox5;
        private Label labelSaldo;
    }
}

