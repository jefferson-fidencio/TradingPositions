using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OperationsWF.Model
{
    public class History
    {
        public List<Position> positions;
        public string saldo = "0.00000000";

        public History() {

            positions = new List<Position>();
        }

        public void AtualizarPosicaoXml(Position positionUpdate)
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
    }
}
