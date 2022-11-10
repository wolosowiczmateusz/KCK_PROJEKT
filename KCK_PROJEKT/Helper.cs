using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_PROJEKT
{
    public class Helper
    {
        public string getFormationFromNumber(int number)
        {
            string formation = "";

            if(number == 1)
            {
                formation = "4-3-3";
            }
            if (number == 2)
            {
                formation = "4-3-3 defensywna";
            }
            if (number == 3)
            {
                formation = "4-3-3 ofensywna";
            }
            if (number == 4)
            {
                formation = "4-2-1-2";
            }
            if (number == 5)
            {
                formation = "4-2-2-2";
            }
            if (number == 6)
            {
                formation = "4-4-2";
            }
            if (number == 7)
            {
                formation = "4-5-1";
            }
            if (number == 8)
            {
                formation = "3-5-2";
            }
            if (number == 9)
            {
                formation = "3-4-1-2";
            }
            if (number == 10)
            {
                formation = "5-3-2";
            }
            if (number == 11)
            {
                formation = "5-4-1";
            }
            return formation;

        }
    
        public FormationInfo getFormInfo(Formation form)
        {
            FormationInfo formInfo = new FormationInfo();
            
            if(form.Name == "4-3-3")
            {
                formInfo.positionsAsString[0] = "GK";
                formInfo.positionsAsString[1] = "LB";
                formInfo.positionsAsString[2] = "CB";
                formInfo.positionsAsString[3] = "CB";
                formInfo.positionsAsString[4] = "RB";
                formInfo.positionsAsString[5] = "CM";
                formInfo.positionsAsString[6] = "CM";
                formInfo.positionsAsString[7] = "CM";
                formInfo.positionsAsString[8] = "ST";
                formInfo.positionsAsString[9] = "ST";
                formInfo.positionsAsString[10] = "ST";
            }
            if (form.Name == "4-3-3 defensywna")
            {
                formInfo.positionsAsString[0] = "GK";
                formInfo.positionsAsString[1] = "LB";
                formInfo.positionsAsString[2] = "CB";
                formInfo.positionsAsString[3] = "CB";
                formInfo.positionsAsString[4] = "RB";
                formInfo.positionsAsString[5] = "CDM";
                formInfo.positionsAsString[6] = "CDM";
                formInfo.positionsAsString[7] = "CM";
                formInfo.positionsAsString[8] = "ST";
                formInfo.positionsAsString[9] = "ST";
                formInfo.positionsAsString[10] = "ST";
            }
            if (form.Name == "4-3-3 ofensywna")
            {
                formInfo.positionsAsString[0] = "GK";
                formInfo.positionsAsString[1] = "LB";
                formInfo.positionsAsString[2] = "CB";
                formInfo.positionsAsString[3] = "CB";
                formInfo.positionsAsString[4] = "RB";
                formInfo.positionsAsString[5] = "CM";
                formInfo.positionsAsString[6] = "CM";
                formInfo.positionsAsString[7] = "CAM";
                formInfo.positionsAsString[8] = "ST";
                formInfo.positionsAsString[9] = "ST";
                formInfo.positionsAsString[10] = "ST";
            }
            if (form.Name == "4-2-2-2")
            {
                formInfo.positionsAsString[0] = "GK";
                formInfo.positionsAsString[1] = "LB";
                formInfo.positionsAsString[2] = "CB";
                formInfo.positionsAsString[3] = "CB";
                formInfo.positionsAsString[4] = "RB";
                formInfo.positionsAsString[5] = "CDM";
                formInfo.positionsAsString[6] = "CDM";
                formInfo.positionsAsString[7] = "CAM";
                formInfo.positionsAsString[8] = "CAM";
                formInfo.positionsAsString[9] = "ST";
                formInfo.positionsAsString[10] = "ST";
            }
            if (form.Name == "4-1-2-1-2")
            {
                formInfo.positionsAsString[0] = "GK";
                formInfo.positionsAsString[1] = "LB";
                formInfo.positionsAsString[2] = "CB";
                formInfo.positionsAsString[3] = "CB";
                formInfo.positionsAsString[4] = "RB";
                formInfo.positionsAsString[5] = "LM";
                formInfo.positionsAsString[6] = "CDM";
                formInfo.positionsAsString[7] = "CAM";
                formInfo.positionsAsString[8] = "RM";
                formInfo.positionsAsString[9] = "ST";
                formInfo.positionsAsString[10] = "ST";
            }
            if (form.Name == "4-4-2")
            {
                formInfo.positionsAsString[0] = "GK";
                formInfo.positionsAsString[1] = "LB";
                formInfo.positionsAsString[2] = "CB";
                formInfo.positionsAsString[3] = "CB";
                formInfo.positionsAsString[4] = "RB";
                formInfo.positionsAsString[5] = "LM";
                formInfo.positionsAsString[6] = "CM";
                formInfo.positionsAsString[7] = "CM";
                formInfo.positionsAsString[8] = "RM";
                formInfo.positionsAsString[9] = "ST";
                formInfo.positionsAsString[10] = "ST";
            }
            if (form.Name == "4-5-1")
            {
                formInfo.positionsAsString[0] = "GK";
                formInfo.positionsAsString[1] = "LB";
                formInfo.positionsAsString[2] = "CB";
                formInfo.positionsAsString[3] = "CB";
                formInfo.positionsAsString[4] = "RB";
                formInfo.positionsAsString[5] = "LM";
                formInfo.positionsAsString[6] = "CM";
                formInfo.positionsAsString[7] = "CM";
                formInfo.positionsAsString[8] = "CM";
                formInfo.positionsAsString[9] = "RM";
                formInfo.positionsAsString[10] = "ST";
            }
            if (form.Name == "3-5-2")
            {
                formInfo.positionsAsString[0] = "GK";
                formInfo.positionsAsString[1] = "CB";
                formInfo.positionsAsString[2] = "CB";
                formInfo.positionsAsString[3] = "CB";
                formInfo.positionsAsString[4] = "LM";
                formInfo.positionsAsString[5] = "CDM";
                formInfo.positionsAsString[6] = "CDM";
                formInfo.positionsAsString[7] = "CAM";
                formInfo.positionsAsString[8] = "RM";
                formInfo.positionsAsString[9] = "ST";
                formInfo.positionsAsString[10] = "ST";
            }
            if (form.Name == "3-4-1-2")
            {
                formInfo.positionsAsString[0] = "GK";
                formInfo.positionsAsString[1] = "CB";
                formInfo.positionsAsString[2] = "CB";
                formInfo.positionsAsString[3] = "CB";
                formInfo.positionsAsString[4] = "LM";
                formInfo.positionsAsString[5] = "CM";
                formInfo.positionsAsString[6] = "CM";
                formInfo.positionsAsString[7] = "CAM";
                formInfo.positionsAsString[8] = "RM";
                formInfo.positionsAsString[9] = "ST";
                formInfo.positionsAsString[10] = "ST";
            }
            if (form.Name == "5-3-2")
            {
                formInfo.positionsAsString[0] = "GK";
                formInfo.positionsAsString[1] = "LB";
                formInfo.positionsAsString[2] = "CB";
                formInfo.positionsAsString[3] = "CB";
                formInfo.positionsAsString[4] = "CB";
                formInfo.positionsAsString[5] = "RB";
                formInfo.positionsAsString[6] = "CM";
                formInfo.positionsAsString[7] = "CM";
                formInfo.positionsAsString[8] = "CM";
                formInfo.positionsAsString[9] = "ST";
                formInfo.positionsAsString[10] = "ST";
            }
            if (form.Name == "5-4-1")
            {
                formInfo.positionsAsString[0] = "GK";
                formInfo.positionsAsString[1] = "LB";
                formInfo.positionsAsString[2] = "CB";
                formInfo.positionsAsString[3] = "CB";
                formInfo.positionsAsString[4] = "CB";
                formInfo.positionsAsString[5] = "RB";
                formInfo.positionsAsString[6] = "LM";
                formInfo.positionsAsString[7] = "CM";
                formInfo.positionsAsString[8] = "CM";
                formInfo.positionsAsString[9] = "RM";
                formInfo.positionsAsString[10] = "ST";
            }
            return formInfo;

        }
    }
}
