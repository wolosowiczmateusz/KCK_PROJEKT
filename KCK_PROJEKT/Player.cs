using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_PROJEKT
{
    public class Player
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public int Overall { get; set; }
        public List<string> Positions { get; set; }

        public List<string> PositionsSplit { get; set; }
        public string BestPosition { get; set; }
        public string line { get; set; }


        //jako faktyczna liczba a nie index
        public int PosNr { get; set; }

        public Player(string FN, int Age, string Nat, int OV, List<string> POS, string BP)
        {
            this.FullName = FN;
            this.Age = Age;
            this.Nationality = Nat;
            this.Positions = POS;
            this.BestPosition = BP;
            this.Overall = OV;
            if(BP =="CB" || BP =="RB" || BP == "LB")
            {
                line = "Defender";
            }
            if(BP == "CM" || BP == "CDM" || BP == "CAM" || BP == "RM" || BP == "LM")
            {
                line = "Midfielder";
            }
            if(BP== "ST")
            {
                line = "Striker";
            }
            if(BP == "GK")
            {
                line = "Goalkeeper";
            }

        }

        public Player() { }
        public void setLineAndSplit() {
            if (BestPosition == "CB" || BestPosition == "RB" || BestPosition == "LB")
            {
                line = "Defender";
            }
            if (BestPosition == "CM" || BestPosition == "CDM" || BestPosition == "CAM" || BestPosition == "RM" || BestPosition == "LM")
            {
                line = "Midfielder";
            }
            if (BestPosition == "ST")
            {
                line = "Striker";
            }
            if (BestPosition == "GK")
            {
                line = "Goalkeeper";
            }

            List<string> tmp = new List<string>(Positions[0].Split(","));
            PositionsSplit = tmp;
        }


        public string GetInfo()
        {
            string positions = "";
            foreach (string pos in Positions)
            {
                positions += pos;
            }
            string info = "";
            info += "Imie i nazwisko: "+FullName+"\n";
            info += "Wiek: " + Age + "\n";
            info += "Kraj: " + Nationality + "\n";
            info += "OV: " + Overall + "\n";
            info += "Pozycje: " + positions + "\n";
            info += "Najlepsza pozycja: " + BestPosition + "\n";
            return info;
        }
    }
}
