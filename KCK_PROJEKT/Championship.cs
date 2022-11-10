using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_PROJEKT
{
    public class Championship
    {
        int numOfTeams;

        public List<Team> teams = new List<Team>();
        public List<Team> teamsQualified = new List<Team>();

        public List<Group> groups = new List<Group>();



        public Championship(List<Team> teams)
        {
            this.teams = teams;
            this.numOfTeams = numOfTeams;
            this.numOfTeams = teams.Count;
            ClearTeams();
            CreateGroups();
        }

        public void ClearTeams()
        {
            foreach(var team in teams)
            {
                team.wins = 0;
                team.draws = 0;
                team.loses = 0;
                team.points = 0;
                team.goalsLost = 0;
                team.goalsScored = 0;
            }
        }
        public void CreateGroups()
        {
            if (numOfTeams == 8)
            {
                Group groupA = new Group("Grupa A");
                Group groupB = new Group("Grupa B");
                groups.Add(groupA);
                groups.Add(groupB);
            }
            else if (numOfTeams == 16)
            {
                Group groupA = new Group("Grupa A");
                Group groupB = new Group("Grupa B");
                Group groupC = new Group("Grupa C");
                Group groupD = new Group("Grupa D");
                groups.Add(groupA);
                groups.Add(groupB);
                groups.Add(groupC);
                groups.Add(groupD);
            }
            else if (numOfTeams == 32)
            {
                Group groupA = new Group("Grupa A");
                Group groupB = new Group("Grupa B");
                Group groupC = new Group("Grupa C");
                Group groupD = new Group("Grupa D");
                Group groupE = new Group("Grupa E");
                Group groupF = new Group("Grupa F");
                Group groupG = new Group("Grupa G");
                Group groupH = new Group("Grupa H");
                groups.Add(groupA);
                groups.Add(groupB);
                groups.Add(groupC);
                groups.Add(groupD);
                groups.Add(groupE);
                groups.Add(groupF);
                groups.Add(groupG);
                groups.Add(groupH);
            }
        }


        public void GroupDraw()
        {
            List<int> tmp = new List<int>();
            foreach(var group in groups)
            {
                for(int i = 0; i < 4; i++)
                {
                    var random = new Random();
                    int index = random.Next(teams.Count);
                    while (tmp.Contains(index))
                    {
                        index = random.Next(teams.Count);
                    }
                    group.Add(teams[index]);
                    tmp.Add(index);
                }
            }
        }

        public void PlayGroupMatches()
        {
            foreach(var group in groups)
            {
                group.PlayGroupMatches();
            }
        }

        public void PlayGroupMatchesFast()
        {
            foreach(var group in groups)
            {
                group.PlayGroupMatchesFast();
            }
        }

        public void PlayPlayOffMatchesFast()
        {
            List<Match> matches = new List<Match>();
            for(int i = 0; i < numOfTeams/2; i++)
            {
                Match match = new Match();
                matches.Add(match);
            }
            int matchNumber = 0;
            for(int i = 0; i < numOfTeams/4; i++)
            {
                matches[matchNumber].teamA = teamsQualified[i];
                matches[matchNumber].teamB = teamsQualified[(numOfTeams/2-1)-i];
                matches[matchNumber].formationA = matches[matchNumber].teamA.formation;
                matches[matchNumber].formationB = matches[matchNumber].teamB.formation;
                matches[matchNumber].group = false;
                matches[matchNumber].startMatchFast();
                if (matches[matchNumber].winner == 1)
                {
                    teamsQualified.Add(teamsQualified[i]);
                }
                else
                {
                    teamsQualified.Add(teamsQualified[(numOfTeams / 2 - 1) - i]);
                }
                matchNumber++;
            }
            for(int i = 0; i < numOfTeams/2; i++)
            {
                teamsQualified.RemoveAt(0);
            }
            Console.WriteLine("  ");


            for (int i = 0; i < numOfTeams/8; i++)
            {
                matches[matchNumber].teamA = teamsQualified[i];
                matches[matchNumber].teamB = teamsQualified[(numOfTeams/4-1) - i];
                matches[matchNumber].formationA = matches[matchNumber].teamA.formation;
                matches[matchNumber].formationB = matches[matchNumber].teamB.formation;
                matches[matchNumber].group = false;
                matches[matchNumber].startMatchFast();
                if (matches[matchNumber].winner == 1)
                {
                    teamsQualified.Add(teamsQualified[i]);
                }
                else
                {
                    teamsQualified.Add(teamsQualified[(numOfTeams/4-1) - i]);
                }
                matchNumber++;
            }
            for (int i = 0; i < numOfTeams/4; i++)
            {
                teamsQualified.RemoveAt(0);
            }
            Console.WriteLine("  ");
            if(numOfTeams == 8) {
                return;
            }


            for (int i = 0; i < numOfTeams/16; i++)
            {
                matches[matchNumber].teamA = teamsQualified[i];
                matches[matchNumber].teamB = teamsQualified[(numOfTeams/8-1) - i];
                matches[matchNumber].formationA = matches[i].teamA.formation;
                matches[matchNumber].formationB = matches[i].teamB.formation;
                matches[matchNumber].group = false;
                matches[matchNumber].startMatchFast();
                if (matches[matchNumber].winner == 1)
                {
                    teamsQualified.Add(teamsQualified[i]);
                }
                else
                {
                    teamsQualified.Add(teamsQualified[(numOfTeams / 8 - 1) - i]);
                }
                matchNumber++;
            }
            if(numOfTeams == 16)
            {
                return;
            }
            for (int i = 0; i < numOfTeams/8; i++)
            {
                teamsQualified.RemoveAt(0);
            }
            Console.WriteLine("  ");
            matches[15].teamA = teamsQualified[0];
            matches[15].teamB = teamsQualified[1];
            matches[15].formationA = matches[0].teamA.formation;
            matches[15].formationB = matches[0].teamB.formation;
            matches[15].group = false;
            matches[15].startMatchFast();


        }




        public void GetGroupQualifiers()
        {
            foreach(var group in groups)
            {
                Team team1 = new Team();
                Team team2 = new Team();
                List<Team> teamsQuali = new List<Team>();
                teamsQuali = group.GetQualifiers();
                team1 = teamsQuali[0];
                team2 = teamsQuali[1];
                teamsQualified.Add(team1);
                teamsQualified.Add(team2);
            }
        }



        public void ShowGroupsAndTables()
        {
            foreach (var group in groups)
            {
                Console.WriteLine("-------------------------------------");
                group.ShowGroup();
            }
            Console.WriteLine("-------------------------------------");
        }

        



    }
}
