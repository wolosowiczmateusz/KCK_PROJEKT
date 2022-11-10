using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_PROJEKT
{
    public class FormationCreator
    {
        public List<Formation> formations = new List<Formation>();

        public FormationCreator(){
            Formation _433 = new Formation("4-3-3");
            _433.DEFCount = 4;
            _433.MIDCount = 3;
            _433.STCount = 3;
            _433.Positions.Add("GK");
            _433.Positions.Add("LB");
            _433.Positions.Add("CB");
            _433.Positions.Add("CB");
            _433.Positions.Add("RB");
            _433.Positions.Add("CM");
            _433.Positions.Add("CM");
            _433.Positions.Add("CM");
            _433.Positions.Add("ST");
            _433.Positions.Add("ST");
            _433.Positions.Add("ST");
            formations.Add(_433);

            Formation _433def = new Formation("4-3-3 defensywna");
            _433def.DEFCount = 4;
            _433def.MIDCount = 3;
            _433def.STCount = 3;
            _433def.Positions.Add("GK");
            _433def.Positions.Add("LB");
            _433def.Positions.Add("CB");
            _433def.Positions.Add("CB");
            _433def.Positions.Add("RB");
            _433def.Positions.Add("CDM");
            _433def.Positions.Add("CDM");
            _433def.Positions.Add("CM");
            _433def.Positions.Add("ST");
            _433def.Positions.Add("ST");
            _433def.Positions.Add("ST");
            formations.Add(_433def);

            Formation _433at = new Formation("4-3-3 ofensywna");
            _433at.DEFCount = 4;
            _433at.MIDCount = 3;
            _433at.STCount = 3;
            _433at.Positions.Add("GK");
            _433at.Positions.Add("LB");
            _433at.Positions.Add("CB");
            _433at.Positions.Add("CB");
            _433at.Positions.Add("RB");
            _433at.Positions.Add("CM");
            _433at.Positions.Add("CM");
            _433at.Positions.Add("CAM");
            _433at.Positions.Add("ST");
            _433at.Positions.Add("ST");
            _433at.Positions.Add("ST");
            formations.Add(_433at);

            Formation _4222 = new Formation("4-2-2-2");
            _4222.DEFCount = 4;
            _4222.MIDCount = 4;
            _4222.STCount = 2;
            _4222.Positions.Add("GK");
            _4222.Positions.Add("LB");
            _4222.Positions.Add("CB");
            _4222.Positions.Add("CB");
            _4222.Positions.Add("RB");
            _4222.Positions.Add("CDM");
            _4222.Positions.Add("CDM");
            _4222.Positions.Add("CAM");
            _4222.Positions.Add("CAM");
            _4222.Positions.Add("ST");
            _4222.Positions.Add("ST");
            formations.Add(_4222);

            Formation _41212 = new Formation("4-1-2-1-2");
            _41212.DEFCount = 4;
            _41212.MIDCount = 4;
            _41212.STCount = 2;
            _41212.Positions.Add("GK");
            _41212.Positions.Add("LB");
            _41212.Positions.Add("CB");
            _41212.Positions.Add("CB");
            _41212.Positions.Add("RB");
            _41212.Positions.Add("LM");
            _41212.Positions.Add("CDM");
            _41212.Positions.Add("CAM");
            _41212.Positions.Add("RM");
            _41212.Positions.Add("ST");
            _41212.Positions.Add("ST");
            formations.Add(_41212);

            Formation _442 = new Formation("4-4-2");
            _442.DEFCount = 4;
            _442.MIDCount = 4;
            _442.STCount = 2;
            _442.Positions.Add("GK");
            _442.Positions.Add("LB");
            _442.Positions.Add("CB");
            _442.Positions.Add("CB");
            _442.Positions.Add("RB");
            _442.Positions.Add("LM");
            _442.Positions.Add("CM");
            _442.Positions.Add("CM");
            _442.Positions.Add("RM");
            _442.Positions.Add("ST");
            _442.Positions.Add("ST");
            formations.Add(_442);

            Formation _451 = new Formation("4-5-1");
            _451.DEFCount = 4;
            _451.MIDCount = 5;
            _451.STCount = 1;
            _451.Positions.Add("GK");
            _451.Positions.Add("LB");
            _451.Positions.Add("CB");
            _451.Positions.Add("CB");
            _451.Positions.Add("RB");
            _451.Positions.Add("LM");
            _451.Positions.Add("CM");
            _451.Positions.Add("CM");
            _451.Positions.Add("CM");
            _451.Positions.Add("RM");
            _451.Positions.Add("ST");
            formations.Add(_451);

            Formation _352 = new Formation("3-5-2");
            _352.DEFCount = 3;
            _352.MIDCount = 5;
            _352.STCount = 2;
            _352.Positions.Add("GK");
            _352.Positions.Add("CB");
            _352.Positions.Add("CB");
            _352.Positions.Add("CB");
            _352.Positions.Add("LM");
            _352.Positions.Add("CDM");
            _352.Positions.Add("CDM");
            _352.Positions.Add("CAM");
            _352.Positions.Add("RM");
            _352.Positions.Add("ST");
            _352.Positions.Add("ST");
            formations.Add(_352);

            Formation _3412 = new Formation("3-4-1-2");
            _3412.DEFCount = 3;
            _3412.MIDCount = 5;
            _3412.STCount = 2;
            _3412.Positions.Add("GK");
            _3412.Positions.Add("CB");
            _3412.Positions.Add("CB");
            _3412.Positions.Add("CB");
            _3412.Positions.Add("LM");
            _3412.Positions.Add("CM");
            _3412.Positions.Add("CM");
            _3412.Positions.Add("CAM");
            _3412.Positions.Add("RM");
            _3412.Positions.Add("ST");
            _3412.Positions.Add("ST");
            formations.Add(_3412);

            Formation _532 = new Formation("5-3-2");
            _532.DEFCount = 5;
            _532.MIDCount = 3;
            _532.STCount = 2;
            _532.Positions.Add("GK");
            _532.Positions.Add("LB");
            _532.Positions.Add("CB");
            _532.Positions.Add("CB");
            _532.Positions.Add("CB");
            _532.Positions.Add("RB");
            _532.Positions.Add("CM");
            _532.Positions.Add("CM");
            _532.Positions.Add("CM");
            _532.Positions.Add("ST");
            _532.Positions.Add("ST");
            formations.Add(_532);

            Formation _541 = new Formation("5-4-1");
            _541.DEFCount = 5;
            _541.MIDCount = 4;
            _541.STCount = 1;
            _541.Positions.Add("GK");
            _541.Positions.Add("LB");
            _541.Positions.Add("CB");
            _541.Positions.Add("CB");
            _541.Positions.Add("CB");
            _541.Positions.Add("RB");
            _541.Positions.Add("LM");
            _541.Positions.Add("CM");
            _541.Positions.Add("CM");
            _541.Positions.Add("RM");
            _541.Positions.Add("ST");
            formations.Add(_541);
        }
        public List<Formation> getFormations()
        {
            return formations;
        }

        public Formation getFormation(string Name)
        {
            Formation forma = new Formation();
            foreach(Formation formation in formations)
            {
                if(formation.Name == Name)
                {
                    forma = formation;
                }
            }
            return forma;
        }

    }
}
