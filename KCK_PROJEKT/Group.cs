using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_PROJEKT
{
    public class Group
    {
        public List<Team> teams = new List<Team>();
        public string name;

        public Group(string name)
        {
            this.name = name;
        }

        public bool Add(Team team)
        {
            if (teams.Count < 4 && !teams.Contains(team))
            {
                teams.Add(team);
                return true;
            }
            return false;
        }
        public bool Remove(Team team)
        {
            if(teams.Count > 0)
            {
                teams.Remove(team);
                return true;
            }
            return false;
        }


        public void PlayGroupMatches()
        {
            Match match1 = new Match(teams[0], teams[1], true);
            Match match2 = new Match(teams[0], teams[2], true);
            Match match3 = new Match(teams[0], teams[3], true);
            Match match4 = new Match(teams[1], teams[2], true);
            Match match5 = new Match(teams[1], teams[3], true);
            Match match6 = new Match(teams[2], teams[3], true);
            match1.startMatch();
            match2.startMatch();
            match3.startMatch();
            match4.startMatch();
            match5.startMatch();
            match6.startMatch();
            sortTable();
        }

        public void PlayGroupMatchesFast()
        {
            Match match1 = new Match(teams[0], teams[1], true);
            Match match2 = new Match(teams[0], teams[2], true);
            Match match3 = new Match(teams[0], teams[3], true);
            Match match4 = new Match(teams[1], teams[2], true);
            Match match5 = new Match(teams[1], teams[3], true);
            Match match6 = new Match(teams[2], teams[3], true);
            match1.startMatchFast();
            match2.startMatchFast();
            match3.startMatchFast();
            match4.startMatchFast();
            match5.startMatchFast();
            match6.startMatchFast();
            sortTable();
        }

        public void ShowGroup()
        {
            sortTable();
            string values = name;
            values +="          W R P  GZ GS  RG   P\n";
            Console.WriteLine(values);
           
            foreach (Team team in teams)
            {
                int teamScored = team.goalsScored.ToString().Length;
                int teamLost = team.goalsLost.ToString().Length;
                int teamDifference = (team.goalsScored - team.goalsLost).ToString().Length;
                int teamPoints = team.points.ToString().Length;


                int length = team.Nationality.Length;
                string teamStats = "";
                teamStats += team.Nationality;
                for (int i = 0; i < (17-length); i++)
                {
                    teamStats += " ";
                }

                teamStats += team.wins + " ";
                teamStats += team.draws + " ";
                teamStats += team.loses + "  ";
                if(teamScored == 1)
                {
                    teamStats += " ";
                }
                teamStats += team.goalsScored + " ";
                if(teamLost == 1)
                {
                    teamStats += " ";
                }
                teamStats += team.goalsLost + " ";
                if (teamDifference == 1)
                {
                    teamStats += "  ";
                }
                if(teamDifference == 2)
                {
                    teamStats += " ";
                }
                teamStats += (team.goalsScored - team.goalsLost) + "  ";
                if(teamPoints == 1)
                {
                    teamStats += " ";
                }
                teamStats += team.points;
                Console.WriteLine(teamStats);
            }
        }

        public void sortTable()
        {
            int maxPoints = 0;
            foreach(var team in teams)
            {
                if(team.points > maxPoints)
                {
                    maxPoints = team.points;
                }
            }
            teams = teams.OrderByDescending(t => t.points)
                         .ThenByDescending(t => t.goalsScored-t.goalsLost)
                         .ThenByDescending(t => t.goalsScored).ToList();

        }
        public List<Team> GetQualifiers()
        {
            List<Team> teamsQuali = new List<Team>();
            teamsQuali.Add(teams[0]);
            teamsQuali.Add(teams[1]);
            return teamsQuali;
        }
    }
}
