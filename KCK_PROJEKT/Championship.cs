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
        //numer meczu playoffowego
        int matchNumber = 0;
        bool playoffStarted = false;
        //ilość drużyn w playoffach atm
        int playoffStage = 0;
        public List<Team> teams = new List<Team>();
        public List<Team> teamsQualifiedAll = new List<Team>();
        public List<Team> teamsQualified = new List<Team>();
        public List<Team> teamsToDisqualify = new List<Team>();
        public List<Group> groups = new List<Group>();
        public List<Match> groupMatches = new List<Match>();
        public List<Match> playoffMatches = new List<Match>();

        public Championship(List<Team> teams)
        {
            this.teams = teams;
            this.numOfTeams = numOfTeams;
            this.numOfTeams = teams.Count;
            ClearTeams();
            CreateGroups();
        }


        //Losowanie grup
        public void GroupDraw()
        {
            List<int> tmp = new List<int>();
            foreach (var group in groups)
            {
                for (int i = 0; i < 4; i++)
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

                Match match = new Match(group.teams[0], group.teams[1], true);
                Match match1 = new Match(group.teams[0], group.teams[2], true);
                Match match2 = new Match(group.teams[0], group.teams[3], true);
                Match match3 = new Match(group.teams[1], group.teams[2], true);
                Match match4 = new Match(group.teams[1], group.teams[3], true);
                Match match5 = new Match(group.teams[2], group.teams[3], true);
                groupMatches.Add(match);
                groupMatches.Add(match1);
                groupMatches.Add(match2);
                groupMatches.Add(match3);
                groupMatches.Add(match4);
                groupMatches.Add(match5);
            }
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("MENU TURNIEJU");
            Console.WriteLine("Wybierz opcje:");
            Console.WriteLine("1. Zagraj mecz grupowy");
            Console.WriteLine("2. Pokaż grupy");
            Console.WriteLine("3. Wyjdz z mistrzostw");
            Console.WriteLine("4. Zasymuluj grupę");
            Console.WriteLine("5. Przejdź do fazy pucharowej");
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    PlayGroupMatch();
                    break;
                case ConsoleKey.D2:
                    ShowGroupsAndTables();
                    break;
                case ConsoleKey.D3:
                    break;
                case ConsoleKey.D4:
                    SimulateRestOfGroupMatches();
                    Console.Clear();
                    Console.WriteLine("Zasymulowano nierozegrane mecze");
                    Console.WriteLine("Wciśnij dowolny przycisk aby kontynuować");
                    Console.ReadKey();
                    Menu();
                    break;
                case ConsoleKey.D5:
                    if (playoffStarted == true)
                    {
                        initPlayoffStageMatches();
                        PlayoffMenu();
                    }
                    foreach (var match in groupMatches)
                    {
                        if (match.PlayedInGroup == false)
                        {
                            Console.WriteLine("Nie rozegrano jeszcze wszystkich meczy");
                            Console.WriteLine("Jeżeli chcesz przesymulować resztę meczy i zacząć fazę pucharową kliknij 1");
                            Console.WriteLine("Jeżeli nie chcesz przesymulować meczy i wrócić do menu kliknij 2");
                            var tmp = Console.ReadKey();
                            if (tmp.Key == ConsoleKey.D1)
                            {
                                SimulateRestOfGroupMatches();
                                GetGroupQualifiers();
                                //tworzy mecze do fazy pucharowej
                                for (int i = 0; i < (numOfTeams / 2) - 1; i++)
                                {
                                    Match playoffmatch = new Match();
                                    playoffMatches.Add(playoffmatch);
                                }
                                playoffStage = numOfTeams / 2;
                                playoffStarted = true;
                                initPlayoffStageMatches();
                                PlayoffMenu();

                            }
                            if (tmp.Key == ConsoleKey.D2)
                            {
                                Menu();
                            }
                        }
                    }
                    GetGroupQualifiers();
                    //tworzy mecze do fazy pucharowej
                    for (int i = 0; i < (numOfTeams / 2) - 1; i++)
                    {
                        Match playoffmatch = new Match();
                        playoffMatches.Add(playoffmatch);
                    }
                    playoffStage = numOfTeams / 2;
                    playoffStarted = true;
                    initPlayoffStageMatches();
                    PlayoffMenu();
                    break;
            }
            return;
        }

        public void PlayoffMenu()
        {
            Console.Clear();
            Console.WriteLine("PLAYOFFY");
            Console.WriteLine("Wybierz opcje:");
            Console.WriteLine("1. Zagraj mecz playoffowy");
            Console.WriteLine("2. Pokaż drabinke");
            Console.WriteLine("3. Wróć do menu mistrzostw");
            playoffStage = CalcPlayoffStage();
            Console.WriteLine("Stage "+ playoffStage + "   Mecze zag " +NumOfPlayoffMatchesPlayed());
            var key = Console.ReadKey();


            switch (key.Key)
            {
                case ConsoleKey.D1:
                    if(playoffStage == 16)
                    {
                        Play16Match();
                    }
                    if(playoffStage == 8)
                    {
                        Play16Match();
                    }
                    if(playoffStage == 4)
                    {
                        Play16Match();
                    }
                    if(playoffStage == 2)
                    {
                        Play16Match();
                    }
                    break;
            }
        }
        public void PlayGroupMatch()
        {
            string name = " ";
            Console.WriteLine("Podaj nazwę grupy:");
            name += Console.ReadLine().Trim().ToUpper();
            foreach(var group in groups)
            {
                if(group.name.Contains(name))
                {
                    Console.WriteLine("podaj drużyny które chcesz żeby zagrały mecz");
                    GiveTeams:
                    string teamA, teamB;
                    teamA = FirstToUpper(Console.ReadLine());
                    teamB = FirstToUpper(Console.ReadLine());
                    
                    int tmp = 0;
                    //Sprawdzenie czy wybrano dobre grupy
                    foreach(var team in group.teams)
                    {
                        if(team.Nationality == teamA)
                        {
                            tmp++;
                        }
                        if(team.Nationality == teamB)
                        {
                            tmp++;
                        }
                    }
                    if(tmp == 2)
                    {
                        foreach(var match in groupMatches)
                        {
                            if ((match.teamA.Nationality == teamA || match.teamA.Nationality == teamB) && (match.teamB.Nationality == teamA || match.teamB.Nationality == teamB))
                            {
                                if(match.PlayedInGroup == true)
                                {
                                    Console.WriteLine("Ten mecz został już zagrany");
                                    match.Sumarize();
                                }
                                else
                                {
                                    match.startMatch();
                                    match.Sumarize();
                                    match.PlayedInGroup = true;
                                }
                                
                            }
                        }
                    }
                    else {
                        Console.WriteLine("Podałeś złe drużyny, aby spróbować jeszcze raz kliknij 1, aby wrócić do menu kliknij 2");
                        var key = Console.ReadKey();
                        if(key.Key == ConsoleKey.D1)
                        {
                            goto GiveTeams;
                        }
                        else
                        {
                            Menu();
                        }

                    }
                }
            }
            Console.WriteLine("Nie ma takiej grupy");
            Console.WriteLine("Naciśnij dowolny guzik aby kontynuować");
            Console.ReadKey();
            Menu();
        }






        public void SimulateRestOfGroupMatches()
        {
            foreach(var match in groupMatches)
            {
                if(match.PlayedInGroup == false)
                {
                    match.startMatchFast();
                    match.PlayedInGroup = true;
                }
            }
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
                teamsQualifiedAll.Add(team1);
                teamsQualifiedAll.Add(team2);
                teamsQualified.Add(team1);
                teamsQualified.Add(team2);
            }
        }
        public void ShowGroupsAndTables()
        {
            Console.Clear();
            foreach (var group in groups)
            {
                Console.WriteLine("-------------------------------------");
                group.ShowGroup();
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Naciśnij guzik aby wrócić do menu mistrzostw");
            Console.ReadKey();
            Menu();
        }



        //init grup
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

        // Czyszczenie statystyk drużyn
        public void ClearTeams()
        {
            foreach (var team in teams)
            {
                team.wins = 0;
                team.draws = 0;
                team.loses = 0;
                team.points = 0;
                team.goalsLost = 0;
                team.goalsScored = 0;
            }
        }




        public void PlayQuarterFinal()
        {

        }
        public void PlaySemifinal()
        {

        }

        public void Play16Match()
        {
            foreach(var team in teamsQualified)
            {
                Console.Write(team.Nationality + " ");
            }

            GiveTeamsPlayoff:
            Console.WriteLine("podaj drużyny które chcesz żeby zagrały mecz");
            string teamA, teamB;
            teamA = FirstToUpper(Console.ReadLine());
            teamB = FirstToUpper(Console.ReadLine());

            int tmp = 0;
            //Sprawdzenie czy wybrano dobre kraje
            foreach (var team in teamsQualified)
            {
                if (team.Nationality == teamA)
                {
                    tmp++;
                }
                if (team.Nationality == teamB)
                {
                    tmp++;
                }
            }
            if (tmp == 2)
            {
                for(int i = 0; i < playoffStage / 2; i++)
                {
                    if ((playoffMatches[i+teamsQualifiedAll.Count-teamsQualified.Count].teamA.Nationality == teamA || playoffMatches[i+teamsQualifiedAll.Count - teamsQualified.Count].teamA.Nationality == teamB) && (playoffMatches[i+teamsQualifiedAll.Count - teamsQualified.Count].teamB.Nationality == teamA || playoffMatches[i+ teamsQualifiedAll.Count - teamsQualified.Count].teamB.Nationality == teamB))
                    {
                        if (playoffMatches[i+ teamsQualifiedAll.Count - teamsQualified.Count].PlayedInPlayoff == true)
                        {
                            Console.WriteLine("Ten mecz został już zagrany");
                            playoffMatches[i+ teamsQualifiedAll.Count - teamsQualified.Count].Sumarize();
                            PlayoffMenu();
                        }
                        else
                        {
                            playoffMatches[i+ teamsQualifiedAll.Count - teamsQualified.Count].startMatch();
                            if (playoffMatches[i+ teamsQualifiedAll.Count - teamsQualified.Count].winner == 1)
                            {
                                teamsToDisqualify.Add(playoffMatches[i+ teamsQualifiedAll.Count - teamsQualified.Count].teamB);
                            }
                            else
                            {
                                teamsToDisqualify.Add(playoffMatches[i+ teamsQualifiedAll.Count - teamsQualified.Count].teamA);
                            }
                            playoffMatches[i+ teamsQualifiedAll.Count - teamsQualified.Count].Sumarize();
                            playoffMatches[i+ teamsQualifiedAll.Count - teamsQualified.Count].PlayedInPlayoff = true;
                            initPlayoffStageMatches();
                            PlayoffMenu();
                        }
                    }
                }
                Console.WriteLine("Podałeś złe drużyny turniejowe, aby spróbować jeszcze raz kliknij 1, aby wrócić do menu kliknij 2");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    goto GiveTeamsPlayoff;
                }
                else
                {
                    PlayoffMenu();
                }
            }
            else
            {
                Console.WriteLine("Podałeś złe drużyny turniejowe, aby spróbować jeszcze raz kliknij 1, aby wrócić do menu kliknij 2");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    goto GiveTeamsPlayoff;
                }
                else
                {
                    PlayoffMenu();
                }
            }
        }


        public void initPlayoffStageMatches()
        {
            playoffStage = CalcPlayoffStage();
            if (numOfTeams == 32)
            {
                if(NumOfPlayoffMatchesPlayed() == 0 || NumOfPlayoffMatchesPlayed() == 8 || NumOfPlayoffMatchesPlayed() == 12 || NumOfPlayoffMatchesPlayed() == 14)
                {
                    initPlayoffStageMatchesSub(playoffStage);
                }
            }
            if(numOfTeams == 16)
            {
                if (NumOfPlayoffMatchesPlayed() == 0 || NumOfPlayoffMatchesPlayed() == 4 || NumOfPlayoffMatchesPlayed() == 6)
                {
                    initPlayoffStageMatchesSub(playoffStage);
                }
            }
            if (numOfTeams == 8)
            {
                if (NumOfPlayoffMatchesPlayed() == 0 || NumOfPlayoffMatchesPlayed() == 2)
                {
                    initPlayoffStageMatchesSub(playoffStage);
                }
            }

        }
        
        //Podfunkcja  ^^^
        public void initPlayoffStageMatchesSub(int stage)
        {
            foreach (var team in teamsToDisqualify)
            {
                if (teamsQualified.Contains(team))
                {
                    teamsQualified.Remove(team);
                }
            }
            Console.WriteLine("odkurwiam inita meczy");
            Thread.Sleep(1900);
            for (int i = 0; i < stage / 2; i++)
            {
                playoffMatches[matchNumber].teamA = teamsQualified[i];
                playoffMatches[matchNumber].teamB = teamsQualified[(stage - 1) - i];
                playoffMatches[matchNumber].formationA = playoffMatches[matchNumber].teamA.formation;
                playoffMatches[matchNumber].formationB = playoffMatches[matchNumber].teamB.formation;
                playoffMatches[matchNumber].group = false;
                matchNumber++;
            }
        }




        public int NumOfPlayoffMatchesPlayed()
        {
            int num = 0;
            foreach(var match in playoffMatches)
            {
                if(match.PlayedInPlayoff == true)
                {
                    num++;
                }
            }
            return num;
        }

        public int CalcPlayoffStage()
        {
            int num = 0;
            if (NumOfPlayoffMatchesPlayed() == 0)
            {
                num = numOfTeams / 2;
            }
            else if(NumOfPlayoffMatchesPlayed() < (numOfTeams / 4))
            {
                num = numOfTeams / 2;
            }
            else if(NumOfPlayoffMatchesPlayed()  < ((numOfTeams / 4) + (numOfTeams / 8)))
            {
                num = numOfTeams / 4;
            }
            else if (NumOfPlayoffMatchesPlayed() < ((numOfTeams / 4) + (numOfTeams / 8) + (numOfTeams / 16)))
            {
                num = numOfTeams / 8;
            }
            else if (NumOfPlayoffMatchesPlayed() < ((numOfTeams / 4) + (numOfTeams / 8) + (numOfTeams / 16) + (numOfTeams / 32)))
            {
                num = numOfTeams / 16;
            }
            return num;
        }



        public void PlayPlayOffMatchesFast()
        {
            List<Match> matches = new List<Match>();
            for (int i = 0; i < numOfTeams / 2; i++)
            {
                Match match = new Match();
                matches.Add(match);
            }
            int matchNumber = 0;
            for (int i = 0; i < numOfTeams / 4; i++)
            {
                matches[matchNumber].teamA = teamsQualified[i];
                matches[matchNumber].teamB = teamsQualified[(numOfTeams / 2 - 1) - i];
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
            for (int i = 0; i < numOfTeams / 2; i++)
            {
                teamsQualified.RemoveAt(0);
            }
            Console.WriteLine("  ");





            for (int i = 0; i < numOfTeams / 8; i++)
            {
                matches[matchNumber].teamA = teamsQualified[i];
                matches[matchNumber].teamB = teamsQualified[(numOfTeams / 4 - 1) - i];
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
                    teamsQualified.Add(teamsQualified[(numOfTeams / 4 - 1) - i]);
                }
                matchNumber++;
            }
            for (int i = 0; i < numOfTeams / 4; i++)
            {
                teamsQualified.RemoveAt(0);
            }
            Console.WriteLine("  ");
            if (numOfTeams == 8)
            {
                return;
            }


            for (int i = 0; i < numOfTeams / 16; i++)
            {
                matches[matchNumber].teamA = teamsQualified[i];
                matches[matchNumber].teamB = teamsQualified[(numOfTeams / 8 - 1) - i];
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
            if (numOfTeams == 16)
            {
                return;
            }
            for (int i = 0; i < numOfTeams / 8; i++)
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

        // stare metody z v1
        public void PlayGroupMatches()
        {
            foreach (var group in groups)
            {
                group.PlayGroupMatches();
            }
        }
        public void PlayGroupMatchesFast()
        {
            foreach (var group in groups)
            {
                group.PlayGroupMatchesFast();
            }
        }
        string FirstToUpper(string s)
        {
            string tmp = s;
            tmp = tmp.ToLower();
            string[] words = tmp.Split();
            List<string> newwords = new List<string>();
            if (s == null)
            {
                return null;
            }

            string returnWord = "";
            if (tmp.Length > 0)
            {
                foreach (string word in words)
                {
                    newwords.Add(char.ToUpper(word[0]) + word.Substring(1));
                }
                foreach (string word in newwords)
                {
                    returnWord += word;
                    returnWord += " ";
                }
                returnWord = returnWord.Trim();
            }
            return returnWord;
        }
    }
}
