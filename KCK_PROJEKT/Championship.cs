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
        public List<int> teamsAdded = new List<int>();
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

            foreach(var group in groups)
            {
                bool elseactivated = false;
                int groupCount = group.teams.Count();
                for (int i = 0; i < 4 - groupCount; i++)
                {
                    int antiblock = 0;
                    var random = new Random();
                    int index = random.Next(teams.Count);
                    while (teamsAdded.Contains(index))
                    {
                        antiblock++;
                        if(antiblock > numOfTeams*100000)
                        {
                            break;
                        }
                        index = random.Next(teams.Count);
                    }
                    group.Add(teams[index]);
                    teamsAdded.Add(index);
                }
                Match match0 = new Match(group.teams[0], group.teams[1], true);
                Match match1 = new Match(group.teams[0], group.teams[2], true);
                Match match2 = new Match(group.teams[0], group.teams[3], true);
                Match match3 = new Match(group.teams[1], group.teams[2], true);
                Match match4 = new Match(group.teams[1], group.teams[3], true);
                Match match5 = new Match(group.teams[2], group.teams[3], true);
                bool m0 = true;
                bool m1 = true;
                bool m2 = true;
                bool m3 = true;
                bool m4 = true;
                bool m5 = true;
                if (groupMatches.Count > 0)
                {
                    foreach (var match in groupMatches)
                    {
                        if(match.teamA.Nationality == group.teams[0].Nationality || match.teamA.Nationality == group.teams[1].Nationality)
                        {
                            if(match.teamB.Nationality == group.teams[0].Nationality || match.teamB.Nationality == group.teams[1].Nationality)
                            {
                                m0 = false;
                            }
                        }
                    }
                    foreach (var match in groupMatches)
                    {
                        if (match.teamA.Nationality == group.teams[0].Nationality || match.teamA.Nationality == group.teams[2].Nationality)
                        {
                            if (match.teamB.Nationality == group.teams[0].Nationality || match.teamB.Nationality == group.teams[2].Nationality)
                            {
                                m1 = false;
                            }
                        }
                    }
                    foreach (var match in groupMatches)
                    {
                        if (match.teamA.Nationality == group.teams[0].Nationality || match.teamA.Nationality == group.teams[3].Nationality)
                        {
                            if (match.teamB.Nationality == group.teams[0].Nationality || match.teamB.Nationality == group.teams[3].Nationality)
                            {
                                m2 = false;
                            }
                        }
                    }
                    foreach (var match in groupMatches)
                    {
                        if (match.teamA.Nationality == group.teams[1].Nationality || match.teamA.Nationality == group.teams[2].Nationality)
                        {
                            if (match.teamB.Nationality == group.teams[1].Nationality || match.teamB.Nationality == group.teams[2].Nationality)
                            {
                                m3 = false;
                            }
                        }
                    }
                    foreach (var match in groupMatches)
                    {
                        if (match.teamA.Nationality == group.teams[1].Nationality || match.teamA.Nationality == group.teams[3].Nationality)
                        {
                            if (match.teamB.Nationality == group.teams[1].Nationality || match.teamB.Nationality == group.teams[3].Nationality)
                            {
                                m4 = false;
                            }
                        }
                    }
                    foreach (var match in groupMatches)
                    {
                        if (match.teamA.Nationality == group.teams[2].Nationality || match.teamA.Nationality == group.teams[3].Nationality)
                        {
                            if (match.teamB.Nationality == group.teams[2].Nationality || match.teamB.Nationality == group.teams[3].Nationality)
                            {
                                m5 = false;
                            }
                        }
                    }
                }
                if(groupMatches.Count == 0)
                {
                    groupMatches.Add(match0);
                    groupMatches.Add(match1);
                    groupMatches.Add(match2);
                    groupMatches.Add(match3);
                    groupMatches.Add(match4);
                    groupMatches.Add(match5);
                    elseactivated = true;
                }

                if(elseactivated == false)
                {
                    if (m0)
                    {
                        groupMatches.Add(match0);
                    }
                    if (m1)
                    {
                        groupMatches.Add(match1);
                    }
                    if (m2)
                    {
                        groupMatches.Add(match2);
                    }
                    if (m3)
                    {
                        groupMatches.Add(match3);
                    }
                    if (m4)
                    {
                        groupMatches.Add(match4);
                    }
                    if (m5)
                    {
                        groupMatches.Add(match5);
                    }
                }
            }
        }


        //DEBUG METHOD
        public void ShowMatches()
        {
            foreach(var match in groupMatches)
            {
                Console.WriteLine(match.teamA.Nationality + "   " + match.teamB.Nationality);
            }
            Console.ReadKey();
            Menu();
        }


        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("| MENU TURNIEJU                   |");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("| 1. Zagraj mecz grupowy          |");
            Console.WriteLine("| 2. Pokaż grupy                  |");
            Console.WriteLine("| 3. Zasymuluj resztę meczy grupy |");
            Console.WriteLine("| 4. Edytuj grupy                 |");
            Console.WriteLine("| 5. Przejdź do fazy pucharowej   |");
            Console.WriteLine("| 6. Wyjdz z mistrzostw           |");
            Console.WriteLine("-----------------------------------");
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
                    if (groupMatches.Count != numOfTeams * 1.5)
                    {
                        Console.Clear();
                        Console.WriteLine("Grupy nie są pełne, nie można zasymulować meczy");
                        Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
                        Console.ReadKey();
                        Menu();
                        return;
                    }
                    SimulateRestOfGroupMatches();
                    Console.Clear();
                    Console.WriteLine("Zasymulowano nierozegrane mecze");
                    Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
                    Console.ReadKey();
                    Menu();
                    break;
                case ConsoleKey.D4:
                    EditGroups();
                    break;
                case ConsoleKey.D5:
                    if (playoffStarted == true)
                    {
                        initPlayoffStageMatches();
                        PlayoffMenu();
                        return;
                    }
                    foreach (var match in groupMatches)
                    {
                        if (match.PlayedInGroup == false)
                        {
                            Console.Clear();
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
                                return;

                            }
                            if (tmp.Key == ConsoleKey.D2)
                            {
                                Menu();
                            }
                        }
                    }
                    if(groupMatches.Count == 0)
                    {
                        Menu();
                        return;
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
                case ConsoleKey.D6:
                    return;
                    break;
            }
        }

        public void PlayoffMenu()
        {
            playoffStage = CalcPlayoffStage();
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("| MENU PLAYOFF'ÓW             |");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("| 1. Zagraj mecz playoffowy   |");
            Console.WriteLine("| 2. Pokaż drabinke           |");
            Console.WriteLine("| 3. Symuluj resztę meczy     |");

            if (playoffStage == 0)
            {
                Console.WriteLine("| 4. Wróć do menu mistrzostw  |");
                Console.WriteLine("-------------------------------");
            }
            else
            {
                Console.WriteLine("-------------------------------");
            }
            
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    if(playoffStage == 0)
                    {
                        Console.WriteLine("Zagrano wszystkie mecze! Koniec mistrzostw");
                        Console.ReadKey();
                        PlayoffMenu();
                    }
                    else
                    {
                        PlayPlayoffMatch();
                    }
                    break;
                case ConsoleKey.D2:
                    ShowPlayoffTable();
                    break;
                case ConsoleKey.D3:
                    SimulateRestOfPlayoffs();
                    break;
                case ConsoleKey.D4:
                    Menu();
                    break;
                default:
                    Menu();
                    break;
            }
        }
        public void PlayGroupMatch()
        {
            Console.Clear();
            string name = " ";
            Console.WriteLine("Podaj nazwę grupy:");
            name += Console.ReadLine().Trim().ToUpper();
            foreach(var group in groups)
            {
                if(group.name.Contains(name))
                {
                    GiveTeams:
                    Console.Clear();
                    string teamA, teamB;
                    Console.WriteLine("Podaj nazwę pierwszej drużyny");
                    teamA = FirstToUpper(Console.ReadLine());
                    Console.WriteLine("Podaj nazwę drugiej drużyny");
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
                                    Menu();
                                    return;
                                }
                                else
                                {
                                    match.startMatch();
                                    Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować");
                                    Console.ReadKey();
                                    match.PlayedInGroup = true;
                                    Menu();
                                    return;
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
                            return;
                        }
                        else
                        {
                            Menu();
                            return;
                        }

                    }
                }
            }
            Console.WriteLine("Nie ma takiej grupy");
            Console.WriteLine("Naciśnij dowolny guzik aby kontynuować");
            Console.ReadKey();
            Menu();
            return;
        }

        public void EditGroup()
        {
            Console.Clear();
            string name = " ";
            Console.WriteLine("Podaj nazwę grupy:");
            name += Console.ReadLine().Trim().ToUpper();
            foreach(var group in groups)
            {
                if (group.name.Contains(name))
                {
                    Console.Clear();
                    Console.WriteLine("Grupa"+name+ "\nCo chcesz zrobić:");
                    Console.WriteLine("1. Dodaj drużynę do grupy");
                    Console.WriteLine("2. Usuń drużynę z grupy");
                    var key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            Console.WriteLine("Dodawanie drużyny");
                            Console.WriteLine("Podaj nazwę drużyny:");
                            string teamName = FirstToUpper(Console.ReadLine());
                            bool exists = false;
                            foreach(var team in teams)
                            {
                                if(team.Nationality == teamName)
                                {
                                    if (group.Add(team) == false)
                                    {
                                        Console.WriteLine("Nie można dodać ponieważ grupa jest pełna, lub dana drużyna jest już dodana. wciśnij guzik aby kontynuować");
                                        Console.ReadKey();
                                        Menu();
                                        return;
                                    }
                                    else
                                    {
                                        foreach(var team2 in group.teams)
                                        {
                                            if(team2 != team)
                                            {
                                                Match match = new Match(team, team2, true);
                                                groupMatches.Add(match);
                                            }
                                        }
                                        int index = teams.IndexOf(team);
                                        teamsAdded.Add(index);
                                        exists = true;
                                    }
                                }
                            }
                            if(exists == false)
                            {
                                Console.WriteLine("Podałeś złą nazwę teamu, wciśnij dowolny guzik aby kontynuować");
                                Console.ReadKey();

                            }
                            else
                            {
                                Console.WriteLine("Dodano drużynę");
                            }
                            Menu();
                            return;
                            break;
                        case ConsoleKey.D2:
                            Console.Clear();
                            Console.WriteLine("Usuwanie drużyny");
                            Console.WriteLine("Podaj nazwę drużyny:");
                            string teamNameRem = FirstToUpper(Console.ReadLine());
                            bool existsRem = false;
                            foreach (var team in teams)
                            {
                                if (team.Nationality == teamNameRem)
                                {
                                    if (group.Remove(team) == false)
                                    {
                                        Console.WriteLine("Nie można usunąć ponieważ nie ma drużyn, wciśnij guzik aby kontynuować");
                                        Console.ReadKey();
                                        Menu();
                                        return;
                                        break;
                                    }
                                    // służy do usuwania meczy które miały drużynę którą teraz usuwam
                                    List<int> indexesToDelete = new List<int>();
                                    foreach(var match in groupMatches)
                                    {
                                        if(match.teamA.Nationality == team.Nationality || match.teamB.Nationality == team.Nationality)
                                        {
                                            indexesToDelete.Add(groupMatches.IndexOf(match));
                                        }
                                    }
                                    foreach(var i in indexesToDelete)
                                    {
                                        groupMatches.RemoveAt(i);
                                    }

                                    int index = teams.IndexOf(team);
                                    teamsAdded.Remove(index);
                                    existsRem = true;
                                }
                            }
                            if (existsRem == false)
                            {
                                Console.WriteLine("Podałeś złą nazwę teamu, wciśnij dowolny guzik aby kontynuować");
                                Console.ReadKey();
                                Menu();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Dodano drużynę");
                            }
                            Menu();
                            return;
                            break;
                    }

                }
            }
            Console.WriteLine("Nie ma takiej grupy");
            Console.WriteLine("Naciśnij dowolny guzik aby kontynuować");
            Console.ReadKey();
            Menu();
            return;
        }

        public void EditGroups()
        {
            Console.Clear();
            Console.WriteLine("Co chciałbyś zrobić:");
            Console.WriteLine("1. Wygeneruj losowe grupy");
            Console.WriteLine("2. Edytuj grupę");
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    GroupDraw();
                    Console.Clear();
                    Console.WriteLine("Grupy wygenerowane, naciśnij dowolny przycisk aby kontynuować");
                    Console.ReadKey();
                    Menu();
                    break;
                case ConsoleKey.D2:
                    EditGroup();
                    break;
            }

        }

        public void ShowPlayoffTable()
        {
            Console.Clear();
            if(numOfTeams == 32)
            {
                for (int i = 0; i < matchNumber; i++)
                {
                    if(i == 0)
                    {
                        Console.WriteLine("1/16 finału\n");
                    }
                    if(i == 8)
                    {
                        Console.WriteLine("Ćwierćfinał\n");
                    }
                    if(i == 12)
                    {
                        Console.WriteLine("Półfinał\n");
                    }
                    if(i == 14)
                    {
                        Console.WriteLine("Finał\n");
                    }
                    else { }
                    if(playoffMatches[i].scoreA == playoffMatches[i].scoreB)
                    {
                        if(playoffMatches[i].PlayedInPlayoff == false)
                        {
                            Console.WriteLine(playoffMatches[i].teamA.Nationality.Substring(0, 3) + " " + playoffMatches[i].scoreA + "  " + playoffMatches[i].scoreB + " " + playoffMatches[i].teamB.Nationality.Substring(0, 3));
                        }
                        else
                        {
                            Console.WriteLine(playoffMatches[i].teamA.Nationality.Substring(0, 3) + " " + (playoffMatches[i].scoreA + playoffMatches[i].scoreApen) + " (" + playoffMatches[i].scoreA + ")" + " " + "(" + playoffMatches[i].scoreB + ") " + (playoffMatches[i].scoreB + playoffMatches[i].scoreBpen) + " " + playoffMatches[i].teamB.Nationality.Substring(0, 3));
                        }
                    }
                    else
                    {
                        Console.WriteLine(playoffMatches[i].teamA.Nationality.Substring(0, 3) + " " + playoffMatches[i].scoreA + "  " + playoffMatches[i].scoreB + " " + playoffMatches[i].teamB.Nationality.Substring(0, 3));
                    }
                    if (i == 7 || i == 11 || i == 13)
                    {
                        Console.WriteLine("\n");
                    }
                }
            }
            if(numOfTeams == 16)
            {
                for (int i = 0; i < matchNumber; i++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("Ćwierćfinał\n");
                    }
                    if (i == 4)
                    {
                        Console.WriteLine("Półfinał\n");
                    }
                    if (i == 6)
                    {
                        Console.WriteLine("Finał\n");
                    }
                    else { }
                    if (playoffMatches[i].scoreA == playoffMatches[i].scoreB)
                    {
                        if (playoffMatches[i].PlayedInPlayoff == false)
                        {
                            Console.WriteLine(playoffMatches[i].teamA.Nationality.Substring(0, 3) + " " + playoffMatches[i].scoreA + "  " + playoffMatches[i].scoreB + " " + playoffMatches[i].teamB.Nationality.Substring(0, 3));
                        }
                        else
                        {
                            Console.WriteLine(playoffMatches[i].teamA.Nationality.Substring(0, 3) + " " + (playoffMatches[i].scoreA + playoffMatches[i].scoreApen) + " (" + playoffMatches[i].scoreA + ")" + " " + "(" + playoffMatches[i].scoreB + ") " + (playoffMatches[i].scoreB + playoffMatches[i].scoreBpen) + " " + playoffMatches[i].teamB.Nationality.Substring(0, 3));
                        }
                    }
                    else
                    {
                        Console.WriteLine(playoffMatches[i].teamA.Nationality.Substring(0, 3) + " " + playoffMatches[i].scoreA + "  " + playoffMatches[i].scoreB + " " + playoffMatches[i].teamB.Nationality.Substring(0, 3));
                    }
                    if (i == 3 || i == 5)
                    {
                        Console.WriteLine("\n");
                    }
                }
            }
            if (numOfTeams == 8)
            {
                for (int i = 0; i < matchNumber; i++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("Półfinał\n");
                    }
                    if (i == 2)
                    {
                        Console.WriteLine("Finał\n");
                    }
                    else { }
                    if (playoffMatches[i].scoreA == playoffMatches[i].scoreB)
                    {
                        if (playoffMatches[i].PlayedInPlayoff == false)
                        {
                            Console.WriteLine(playoffMatches[i].teamA.Nationality.Substring(0, 3) + " " + playoffMatches[i].scoreA + "  " + playoffMatches[i].scoreB + " " + playoffMatches[i].teamB.Nationality.Substring(0, 3));
                        }
                        else
                        {
                            Console.WriteLine(playoffMatches[i].teamA.Nationality.Substring(0, 3) + " " + (playoffMatches[i].scoreA + playoffMatches[i].scoreApen) + " (" + playoffMatches[i].scoreA + ")" + " " + "(" + playoffMatches[i].scoreB + ") " + (playoffMatches[i].scoreB + playoffMatches[i].scoreBpen) + " " + playoffMatches[i].teamB.Nationality.Substring(0, 3));
                        }
                    }
                    else
                    {
                        Console.WriteLine(playoffMatches[i].teamA.Nationality.Substring(0, 3) + " " + playoffMatches[i].scoreA + "  " + playoffMatches[i].scoreB + " " + playoffMatches[i].teamB.Nationality.Substring(0, 3));
                    }
                    if (i == 1)
                    {
                        Console.WriteLine("\n");
                    }
                }
            }

            Console.WriteLine("\nNaciśnij dowolny przycisk aby kontynuować");
            Console.ReadKey();
            PlayoffMenu();
            return;
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
        public void SimulateRestOfPlayoffs()
        {
            while(playoffStage != 0)
            {
                for (int i = 0; i < playoffStage / 2; i++)
                {
                    if (playoffMatches[i + teamsQualifiedAll.Count - teamsQualified.Count].PlayedInPlayoff == false)
                    {
                        playoffMatches[i + teamsQualifiedAll.Count - teamsQualified.Count].startMatchFast();
                        if (playoffMatches[i + teamsQualifiedAll.Count - teamsQualified.Count].winner == 1)
                        {
                            teamsToDisqualify.Add(playoffMatches[i + teamsQualifiedAll.Count - teamsQualified.Count].teamB);
                        }
                        else
                        {
                            teamsToDisqualify.Add(playoffMatches[i + teamsQualifiedAll.Count - teamsQualified.Count].teamA);
                        }
                        playoffMatches[i + teamsQualifiedAll.Count - teamsQualified.Count].PlayedInPlayoff = true;
                        initPlayoffStageMatches();
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Zasymulowano resztę meczy");
            Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
            Console.ReadKey();
            PlayoffMenu();
            return;
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

        public void PlayPlayoffMatch()
        {

            GiveTeamsPlayoff:
            Console.Clear();
            string teamA, teamB;
            Console.WriteLine("Podaj pierwszą drużynę");
            teamA = FirstToUpper(Console.ReadLine());
            Console.WriteLine("Podaj drugą drużynę");
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
                            Console.WriteLine("naciśnij dowolny klawisz aby kontynuować");
                            Console.ReadKey();
                            PlayoffMenu();
                            return;
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
                            playoffMatches[i+ teamsQualifiedAll.Count - teamsQualified.Count].PlayedInPlayoff = true;
                            initPlayoffStageMatches();
                            PlayoffMenu();
                            return;
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
                    return;
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
                    return;
                }
            }
        }


        public void initPlayoffStageMatches()
        {
            playoffStage = CalcPlayoffStage();
            if (numOfTeams == 32)
            {
                if(NumOfPlayoffMatchesPlayed() == 0 || NumOfPlayoffMatchesPlayed() == 8 || NumOfPlayoffMatchesPlayed() == 12 || NumOfPlayoffMatchesPlayed() == 14 || NumOfPlayoffMatchesPlayed() == 15)
                {
                    initPlayoffStageMatchesSub(playoffStage);
                }
            }
            if(numOfTeams == 16)
            {
                if (NumOfPlayoffMatchesPlayed() == 0 || NumOfPlayoffMatchesPlayed() == 4 || NumOfPlayoffMatchesPlayed() == 6 || NumOfPlayoffMatchesPlayed() == 7)
                {
                    initPlayoffStageMatchesSub(playoffStage);
                }
            }
            if (numOfTeams == 8)
            {
                if (NumOfPlayoffMatchesPlayed() == 0 || NumOfPlayoffMatchesPlayed() == 2 || NumOfPlayoffMatchesPlayed() == 3)
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

            if(NumOfPlayoffMatchesPlayed() < (numOfTeams / 4))
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
            else if (NumOfPlayoffMatchesPlayed() == 0)
            {
                num = numOfTeams / 2;
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
