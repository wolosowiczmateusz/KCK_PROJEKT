using System.Text.Json;
using System.Text.Json.Serialization;
using KCK_PROJEKT;


string fileName = "fifka_new.json";
string jsonString = File.ReadAllText(fileName);
List<Player> players = JsonSerializer.Deserialize<List<Player>>(jsonString)!;
foreach(var player in players)
{
    player.setLineAndSplit();
}
List<Formation> formations = new List<Formation>();
FormationCreator creator = new FormationCreator();
formations = creator.getFormations();
List<Team> teams = new List<Team>();
Helper helper = new Helper();




ShowMenu();







void AddTeam()
{
    Console.Clear();
    string nationalitySelect;
    int formationSelect;

    Console.WriteLine("Jaki kraj chciałbyś stworzyć?");
    Console.Write("Podaj kraj: ");
    nationalitySelect = FirstToUpper(Console.ReadLine());
    Console.Clear();
    Console.WriteLine("Jaką formacje użyć?");
    Console.WriteLine("Lista możliwych formacji:");
    Console.WriteLine("1. 4-3-3 \n2. 4-3-3 defensywna \n3. 4-3-3 ofensywna \n4. 4-1-2-1-2 \n5. 4-2-2-2");
    Console.WriteLine("6. 4-4-2 \n7. 4-5-1 \n8. 3-5-2 \n9. 3-4-1-2 \n10. 5-3-2 \n11. 5-4-1\n");
    Console.Write("Wybierz numerek formacji:");
    formationSelect = Convert.ToInt32(Console.ReadLine());
    nationalitySelect.Trim();
    Team team = new Team(creator.getFormation(helper.getFormationFromNumber(formationSelect)), nationalitySelect);
    teams.Add(team);
    ShowMenu();
}

void RemoveTeam()
{
    Console.Clear();
    string nationalitySelect;
    int formationSelect;

    Console.WriteLine("Jaki kraj chciałbyś usunąć?");
    Console.Write("Podaj kraj: ");
    nationalitySelect = FirstToUpper(Console.ReadLine());
    Team teamToDelete = new Team();
    foreach(var team in teams)
    {
        if(team.Nationality == nationalitySelect)
        {
            teamToDelete = team;
        }
    }
    teams.Remove(teamToDelete);
    Console.ReadKey();
    ShowMenu();
}

void ShowTeams()
{
    Console.Clear();
    foreach (var team in teams)
    {
        if (team.PlayerList.Count == 11)
        {
            Console.Write("Ma już team  ");
        }
        Console.WriteLine("Drużyna: " + team.Nationality);
        Console.WriteLine("Formacja: " + team.formation.Name + "\n");

    }
    if (teams.Count == 0)
    {
        Console.WriteLine("Nie ma żadnej drużyny!\n");
    }
    Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
    string back = FirstToUpper(Console.ReadLine());
    ShowMenu();
}

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("Co chcesz zrobic?");
    Console.WriteLine("1. Dodaj drużynę");
    Console.WriteLine("2. Zobacz drużyny");
    Console.WriteLine("3. Edytuj drużynę");
    Console.WriteLine("4. Zapisz drużyny");
    Console.WriteLine("5. Wczytaj drużyny");
    Console.WriteLine("6. Zrób mecz");
    Console.WriteLine("7. Mistrzostwa");
    Console.WriteLine("8. Usuń drużynę");
    Console.WriteLine("9. Zrób mecz turniejowy");
    var read = Console.ReadKey();
    switch (read.Key)
    {
        case ConsoleKey.D1:
            AddTeam();
            break;
        case ConsoleKey.D2:
            ShowTeams();
            break;
        case ConsoleKey.D3:
            ManageTeam();
            break;
        case ConsoleKey.D4:
            SaveTeams();
            break;
        case ConsoleKey.D5:
            LoadTeams();
            break;
        case ConsoleKey.D6:
            PlayMatch();
            break;
        case ConsoleKey.D7:
            PlayChampionship();
            break;
        case ConsoleKey.D8:
            RemoveTeam();
            break;
        case ConsoleKey.D9:
            PlayTournamentMatch();
            break;
    }
}

void ShowChampionshipMenu(Championship championship)
{

}

void PlayMatch()
{
    Console.WriteLine("Podaj pierwszą drużynę:");
    string teamAname = Console.ReadLine();

    Console.WriteLine("Podaj drugą drużynę:");
    string teamBname = Console.ReadLine();
    teamAname = FirstToUpper(teamAname);
    teamBname = FirstToUpper(teamBname);
    Team teamA = new Team();
    Team teamB = new Team();

    foreach(var team in teams)
    {
        if (team.Nationality == teamAname)
        {
            teamA = team;
        }
        if(team.Nationality == teamBname)
        {
            teamB = team;
        }
    }

    Match match = new Match(teamA, teamB, true);
    match.startMatch();

    Console.WriteLine(match.get_OVR());
    Console.WriteLine(match.get_GK_OVR());
    Console.WriteLine(match.get_DEF_OVR());
    Console.WriteLine(match.get_MID_OVR());
    Console.WriteLine(match.get_ST_OVR());
    Console.WriteLine("Punkty A: " + teamA.points + "Punkty B: " + teamB.points);

    Console.ReadKey();
    ShowMenu();
}

void PlayTournamentMatch()
{
    Console.WriteLine("Podaj pierwszą drużynę:");
    string teamAname = Console.ReadLine();

    Console.WriteLine("Podaj drugą drużynę:");
    string teamBname = Console.ReadLine();
    teamAname = FirstToUpper(teamAname);
    teamBname = FirstToUpper(teamBname);
    Team teamA = new Team();
    Team teamB = new Team();

    foreach (var team in teams)
    {
        if (team.Nationality == teamAname)
        {
            teamA = team;
        }
        if (team.Nationality == teamBname)
        {
            teamB = team;
        }
    }

    Match match = new Match(teamA, teamB, false);
    match.startMatchFast();

    Console.ReadKey();
    ShowMenu();
}

/// <summary>
/// DEGUG VERSION
/// </summary>
void PlayChampionship()
{
    string nationality;
    Console.WriteLine("Wybierz rozmiar turnieju:");
    Console.WriteLine("1. 32");
    Console.WriteLine("2. 16");
    Console.WriteLine("3. 8");
    var size = Console.ReadKey();
    List<Team> teamsToTournament = new List<Team>();
    switch (size.Key)
    {
        case ConsoleKey.D1:
            Console.WriteLine("1. Chcę podać drużyny samemu");
            Console.WriteLine("2. Chcę wybrać losowe drużyny");
            size = Console.ReadKey();
            if(size.Key == ConsoleKey.D1)
            {
                for (int i = 0; i < 32; i++)
                {
                    Console.Write("Teamy które biorą udział w turnieju:");
                    foreach (var team in teamsToTournament)
                    {
                        Console.Write(team.Nationality + " ");
                    }
                    Console.WriteLine("\nPodaj drużynę");
                    nationality = FirstToUpper(Console.ReadLine());
                    foreach (Team team in teams)
                    {
                        if (team.Nationality == nationality)
                        {
                            teamsToTournament.Add(team);
                        }
                    }
                }
            }
            if(size.Key == ConsoleKey.D2)
            {
                List<int> tmp = new List<int>();
                for (int i = 0; i < 32; i++)
                {
                    var random = new Random();
                    int index = random.Next(teams.Count);
                    while (tmp.Contains(index))
                    {
                        index = random.Next(teams.Count);
                    }
                    teamsToTournament.Add(teams[index]);
                    tmp.Add(index);
                }
            }
            break;

        case ConsoleKey.D2:
            Console.WriteLine("1. Chcę podać drużyny samemu");
            Console.WriteLine("2. Chcę wybrać losowe drużyny");
            size = Console.ReadKey();
            if (size.Key == ConsoleKey.D1)
            {
                for (int i = 0; i < 16; i++)
                {
                    Console.Write("Teamy które biorą udział w turnieju:");
                    foreach (var team in teamsToTournament)
                    {
                        Console.Write(team.Nationality + " ");
                    }
                    Console.WriteLine("\nPodaj drużynę");
                    nationality = FirstToUpper(Console.ReadLine());
                    foreach (Team team in teams)
                    {
                        if (team.Nationality == nationality)
                        {
                            teamsToTournament.Add(team);
                        }
                    }
                }
            }
            if (size.Key == ConsoleKey.D2)
            {
                List<int> tmp = new List<int>();
                for (int i = 0; i < 16; i++)
                {
                    var random = new Random();
                    int index = random.Next(teams.Count);
                    while (tmp.Contains(index))
                    {
                        index = random.Next(teams.Count);
                    }
                    teamsToTournament.Add(teams[index]);
                    tmp.Add(index);
                }
            }
            break;
        case ConsoleKey.D3:
            Console.WriteLine("1. Chcę podać drużyny samemu");
            Console.WriteLine("2. Chcę wybrać losowe drużyny");
            size = Console.ReadKey();
            if (size.Key == ConsoleKey.D1)
            {
                for (int i = 0; i < 8; i++)
                {
                    Console.Write("Teamy które biorą udział w turnieju:");
                    foreach (var team in teamsToTournament)
                    {
                        Console.Write(team.Nationality + " ");
                    }
                    Console.WriteLine("\nPodaj drużynę");
                    nationality = FirstToUpper(Console.ReadLine());
                    foreach (Team team in teams)
                    {
                        if (team.Nationality == nationality)
                        {
                            teamsToTournament.Add(team);
                        }
                    }
                }
            }
            if (size.Key == ConsoleKey.D2)
            {
                List<int> tmp = new List<int>();
                for (int i = 0; i < 8; i++)
                {
                    var random = new Random();
                    int index = random.Next(teams.Count);
                    while (tmp.Contains(index))
                    {
                        index = random.Next(teams.Count);
                    }
                    teamsToTournament.Add(teams[index]);
                    tmp.Add(index);
                }
            }
            break;
    }

    Console.WriteLine("Drużyny które wybrałeś to:");
    foreach(var team in teamsToTournament)
    {
        Console.WriteLine(team.Nationality + ", ");
    }



    Championship championship = new Championship(teamsToTournament);
    championship.GroupDraw();
    championship.PlayGroupMatchesFast();
    championship.ShowGroupsAndTables();
    championship.GetGroupQualifiers();
    championship.PlayPlayOffMatchesFast();
    Console.ReadKey();
    ShowMenu();
}


void SaveTeams()
{
    Console.Clear();
    Console.WriteLine("Podaj pod jaką nazwą chcesz zapisać plik");
    string fileName = Console.ReadLine();
    StreamWriter writer = new StreamWriter(fileName);
    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(List<Team>));
    x.Serialize(writer, teams);
    writer.Dispose();
    ShowMenu();
}

void LoadTeams()
{
    Console.Clear();
    Console.WriteLine("Podaj nazwę pliku do załadowania");
    string fileName = Console.ReadLine();
    System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(typeof(List<Team>));

    using (Stream reader = new FileStream(fileName, FileMode.Open))
    {
        teams = (List<Team>)xml.Deserialize(reader);
    }
    foreach(var team in teams)
    {
        foreach(var player in team.PlayerList)
        {
            player.setLineAndSplit();
        }
    }

    ShowMenu();
}

void ManageTeam()
{
    Console.Clear();
    int choice;
    string nationality;
    Console.WriteLine("Jaki team chciałbyś edytować?");
    Console.WriteLine("Podaj nazwę klubu: ");
    nationality = FirstToUpper(Console.ReadLine());

    Team team = new Team();
    foreach (var _team in teams)
    {
        if (_team.Nationality == nationality)
        {
            team = _team;
        }
    }

    if (team.Nationality == null)
    {
        Console.WriteLine("Nie ma takiego klubu \nWciśnij 1 aby spróbować ponownie\nWciśnij dowolny przycisk aby wrócić do menu");
        choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
            ManageTeam();
        }
        else
        {
            ShowMenu();
        }
    }

    Formation formation = team.formation;
    goto WhatToDoNext;
    WhatToDoNext:
    Console.Clear();
    Console.WriteLine("Co chciałbyś zrobić?: ");
    Console.WriteLine("1. Dodać zawodnika do drużyny");
    Console.WriteLine("2. Wyświetlić drużynę");
    Console.WriteLine("3. Wyświetlić drużynę (DEBUG MODE)");
    Console.WriteLine("4. Wróć do menu");
    choice = Convert.ToInt32(Console.ReadLine());
    
    if (choice == 1)
    {
        Player tmp = new Player();
        tmp = SearchPlayer(nationality,formation,team,tmp);
        Player player = new Player();
        player = tmp;

        int id = player.ID;
        int posNr = player.PosNr;
        Player playerRemoved = new Player();
        foreach(var _player in team.PlayerList.ToList())
        {
            if(_player.ID == id)
            {
                team.removePlayer(_player);
            }
        }
        foreach(var _player in team.PlayerList.ToList())
        {
            if(_player.PosNr == posNr)
            {
                team.removePlayer(_player);
            }
        }
        team.addPlayer(player);
        goto WhatToDoNext;
    }
    if (choice == 2)
    {
        ShowTeamWithPos(team);
        string tmp = Console.ReadLine();
        goto WhatToDoNext;
    }
    if (choice == 3)
    {
        foreach(var _player in team.PlayerList)
        {
            Console.WriteLine(_player.FullName + " " + _player.PosNr);
        }
        string tmp = Console.ReadLine();
        goto WhatToDoNext;
    }
    if(choice == 4)
    {
        ShowMenu();
    }

}


Player SearchPlayer(string nationality, Formation formation, Team team, Player pl)
{
    Console.WriteLine("Na jaką pozycję chciałbyś dodać zawodnika?");
    int tmp = 1;

    ShowTeamWithPos(team);
    
    int pos = Convert.ToInt32(Console.ReadLine());
    Console.Clear();
    Console.WriteLine("Wpisz nazwisko zawodnika:");
    string playerName = Console.ReadLine();
    string playerName2 = FirstToUpper(playerName);
    List<Player> playersSearch = new List<Player>();
    foreach (var p in players)
    {
        if (p.Nationality == nationality)
        {
            if (p.FullName.Contains(playerName) || p.FullName.Contains(playerName2))
            {
                playersSearch.Add(p);
            }
        }
    }

    if (playersSearch.Count == 0)
    {
        Console.Write("Nie znaleziono żadnego piłkarza. Wciśnij 1 aby spróbować ponownie\nWciśnij dowolny przycisk aby wrócić");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
            pl = SearchPlayer(nationality,formation,team, pl);
            return pl;
        }
        else
        {
            ManageTeam();
            return pl;
        }
    }
    else
    {
        tmp = 1;
        foreach (var p in playersSearch)
        {
            Console.WriteLine(tmp + " " + p.FullName + ", Wiek: " + p.Age);
            tmp++;
        }
        Console.WriteLine("Wybierz piłkarza:");
        Player player = new Player();
        int chosenPlayer = Convert.ToInt32(Console.ReadLine());
        player = playersSearch[chosenPlayer - 1];
        player.PosNr = pos;
        Console.WriteLine(player.PosNr);
        Console.WriteLine("Wybrany piłkarz to: " + player.FullName + ". Będzie grał na pozycji: " + team.formation.Positions[pos - 1]);
        Thread.Sleep(600);
        return player;
    }
}


void ShowTeamWithPos(Team team)
{
    Formation formation = team.formation;
    bool playerExist = false;
    Player player = new Player();
    //i = 1 żeby wyświetlać odpowiednie pozycje
    for(int i = 1; i < 12; i++)
    {
        foreach(var p in team.PlayerList)
        {
            if (p.PosNr == i) {
                playerExist = true;
                player = p;
            }
        }
        if (playerExist)
        {
            Console.WriteLine(i + ". " + formation.Positions[i - 1] + " " + player.FullName);
        }
        else
        {
            Console.WriteLine(i + ". " + formation.Positions[i - 1]);
        }
        playerExist = false;
    }
}


// Funkcja zamienia wszystkie stringi na zaczynające się z wielkiej litery
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
        foreach(string word in words)
        {
            newwords.Add(char.ToUpper(word[0]) + word.Substring(1));  
        }
        foreach(string word in newwords)
        {
            returnWord += word;
            returnWord += " ";
        }
        returnWord = returnWord.Trim();
    }
    return returnWord;
}







