using OperationsWF;
using OperationsWF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Positions.UI.Panels
{
    public class PanelConfigs : Panel
    {
        TextBox textboxSaldo = new TextBox();

        public PanelConfigs()
        {
            DrawPanel();
        }

        private void DrawPanel()
        {
            // 
            // pictureBox2
            // 
            PictureBox pictureBox = new PictureBox();
            pictureBox.BackgroundImage = global::Positions.Properties.Resources._309020_24;
            pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox.Location = new System.Drawing.Point(25, 45);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(32, 32);
            pictureBox.TabIndex = 5;
            pictureBox.TabStop = false;
            // 
            // labelTipoTrade
            // 
            Label labelCarteira = new Label();
            labelCarteira.AutoSize = true;
            labelCarteira.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelCarteira.ForeColor = System.Drawing.Color.Coral;
            labelCarteira.Location = new System.Drawing.Point(60, 53);
            labelCarteira.Name = "labelCarteira";
            labelCarteira.Size = new System.Drawing.Size(98, 17);
            labelCarteira.TabIndex = 8;
            labelCarteira.Text = "Carteira";
            // 
            // label6
            // 
            Label label = new Label();
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(62, 80);
            label.Name = "label";
            label.Size = new System.Drawing.Size(74, 13);
            label.TabIndex = 3;
            label.Text = "Saldo atual (BTC):";
            // 
            // textboxSaldo
            // 
            textboxSaldo.AutoSize = true;
            textboxSaldo.Location = new System.Drawing.Point(170, label.Location.Y - 3);
            textboxSaldo.Name = "textboxSaldo";
            textboxSaldo.Size = new System.Drawing.Size(80, 13);
            textboxSaldo.TabIndex = 28;
            textboxSaldo.Text = Program.myHistory.saldo;
            // 
            // buttonVer
            // 
            Button buttonSalvar = new Button();
            buttonSalvar.BackColor = System.Drawing.SystemColors.Control;
            buttonSalvar.BackgroundImage = global::Positions.Properties.Resources.if_floppy_285657;
            buttonSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            buttonSalvar.ForeColor = System.Drawing.SystemColors.ControlLight;
            buttonSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonSalvar.Location = new System.Drawing.Point(textboxSaldo.Location.X + textboxSaldo.Width + 10, textboxSaldo.Location.Y);
            buttonSalvar.Name = "buttonSalvar";
            buttonSalvar.Size = new System.Drawing.Size(40, 28);
            buttonSalvar.TabIndex = 12;
            buttonSalvar.UseVisualStyleBackColor = false;
            buttonSalvar.Click += ButtonSalvar_Click;
            // 
            // MyConfigsPanel
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(223, 0);
            this.Name = "MyConfigsPanel";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(739, 537);
            this.TabIndex = 1;
            this.Visible = false;
            this.Controls.Add(pictureBox);
            this.Controls.Add(labelCarteira);
            this.Controls.Add(label);
            this.Controls.Add(textboxSaldo);
            this.Controls.Add(buttonSalvar);
        }

        private void ButtonSalvar_Click(object sender, EventArgs e)
        {
            Program.myHistory.saldo = textboxSaldo.Text;

            XmlSerializer serializer = new XmlSerializer(typeof(History));
            string fileName = System.IO.Path.Combine(Application.CommonAppDataPath, "positions.xml");
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, Program.myHistory);
            }
        }
    }
}
