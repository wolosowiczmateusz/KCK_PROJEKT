using System.Text.Json;
using System.Text.Json.Serialization;
using KCK_PROJEKT;


string fileName = "fifadb.json";
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

List<Match> matches = new List<Match>();
Match match = new Match();

ShowMenu();




void AddTeam()
{
    Console.Clear();
    string nationalitySelect;
    int formationSelect;

    Console.WriteLine("Jaki kraj chciałbyś stworzyć?");
    Console.Write("Podaj kraj: ");
    nationalitySelect = FirstToUpper(Console.ReadLine());
    foreach(var t in teams)
    {
        if(t.Nationality == nationalitySelect)
        {
            Console.Clear();
            Console.WriteLine("Taki kraj jest juz dodany");
            Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
            Console.ReadKey();
            ShowMenu();
        }
    }
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

    Console.Write("Podaj nazwę kraju drużyny, którą chciałbyś usunąć: ");
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
    Console.WriteLine("Usunięto drużynę");
    Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
    Console.ReadKey();
    ShowMenu();
}

void ShowTeams()
{
    Console.Clear();
    foreach (var team in teams)
    {
        Console.WriteLine("Drużyna: " + team.Nationality);
        Console.WriteLine("Formacja: " + team.formation.Name + "\n");
    }
    if (teams.Count == 0)
    {
        Console.WriteLine("Nie ma żadnej drużyny!\n");
    }
    Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
    Console.ReadKey();
    ShowMenu();
}

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("|  Symulator meczy piłkarskich  |");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("|  Wybierz akcję:               |");
    Console.WriteLine("|  1. Wyświetl listę drużyn     |");
    Console.WriteLine("|  2. Dodaj drużynę             |");
    Console.WriteLine("|  3. Edytuj drużynę            |");
    Console.WriteLine("|  4. Usuń drużynę              |");
    Console.WriteLine("|                               |");
    Console.WriteLine("|  5. Zapisz drużyny            |");
    Console.WriteLine("|  6. Wczytaj drużyny           |");
    Console.WriteLine("|                               |");
    Console.WriteLine("|  7. Zagraj mecz zwykły        |");
    Console.WriteLine("|  8. Zagraj mecz turniejowy    |");
    Console.WriteLine("|  9. Mistrzostwa               |");
    Console.WriteLine("| ESC. Zakończ program          |");
    Console.WriteLine("---------------------------------");
    var read = Console.ReadKey();
    switch (read.Key)
    {
        case ConsoleKey.D1:
            ShowTeams();
            break;
        case ConsoleKey.D2:
            AddTeam();
            break;
        case ConsoleKey.D3:
            ManageTeam();
            break;
        case ConsoleKey.D4:
            RemoveTeam();
            break;
        case ConsoleKey.D5:
            SaveTeams();
            break;
        case ConsoleKey.D6:
            LoadTeams();
            break;
        case ConsoleKey.D7:
            PlayMatch();
            break;
        case ConsoleKey.D8:
            PlayTournamentMatch();
            break;
        case ConsoleKey.D9:
            PlayChampionship();
            break;
        case ConsoleKey.Escape:
            break;
            return;
        default:
            ShowMenu();
            break;
    }
}


void PlayMatch()
{
    Console.Clear();
    Console.WriteLine("Podaj nazwę pierwszej drużyny:");
    string teamAname = Console.ReadLine();

    Console.WriteLine("Podaj nazwę drugiej drużyny:");
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
    Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
    Console.ReadKey();
    ShowMenu();
}

void PlayTournamentMatch()
{
    Console.Clear();
    Console.WriteLine("Mecz turniejowy");
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
    match.startMatch();
    ShowMenu();
}

/// <summary>
/// DEGUG VERSION
/// </summary>
void PlayChampionship()
{
    Console.Clear();
    string nationality;
    Console.WriteLine("Wybierz rozmiar turnieju:");
    Console.WriteLine("1. 32 drużyny");
    Console.WriteLine("2. 16 drużyn");
    Console.WriteLine("3. 8 drużyn");
    var size = Console.ReadKey();
    List<Team> teamsToTournament = new List<Team>();
    switch (size.Key)
    {
        case ConsoleKey.D1:
            Console.Clear();
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
                    bool chosen = false;
                    foreach (Team team in teams)
                    {
                        if (team.Nationality == nationality)
                        {
                            if (teamsToTournament.Contains(team))
                            {
                                Console.WriteLine("Dodałeś już taką drużynę");
                                Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
                                Console.ReadKey();
                                i--;
                                chosen = true;
                            }
                            else
                            {
                                teamsToTournament.Add(team);
                                chosen = true;
                            }
                        }
                    }
                    if (chosen == false)
                    {
                        Console.WriteLine("Nie ma takiej drużyny");
                        Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
                        Console.ReadKey();
                        i--;
                    }
                }
                Console.WriteLine("Drużyny które wybrałeś to:");
                foreach (var team in teamsToTournament)
                {
                    Console.Write(team.Nationality + ", ");
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
                Console.WriteLine("Drużyny wylosowane to:");
                foreach (var team in teamsToTournament)
                {
                    Console.Write(team.Nationality + ", ");
                }
            }
            break;

        case ConsoleKey.D2:
            Console.Clear();
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
                    bool chosen = false;
                    foreach (Team team in teams)
                    {
                        if (team.Nationality == nationality)
                        {
                            if (teamsToTournament.Contains(team))
                            {
                                Console.WriteLine("Dodałeś już taką drużynę");
                                Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
                                Console.ReadKey();
                                i--;
                                chosen = true;
                            }
                            else
                            {
                                teamsToTournament.Add(team);
                                chosen = true;
                            }
                        }
                    }
                    if (chosen == false)
                    {
                        Console.WriteLine("Nie ma takiej drużyny");
                        Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
                        Console.ReadKey();
                        i--;
                    }
                }
                Console.WriteLine("Drużyny które wybrałeś to:");
                foreach (var team in teamsToTournament)
                {
                    Console.Write(team.Nationality + ", ");
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
                Console.WriteLine("Drużyny wylosowane to:");
                foreach (var team in teamsToTournament)
                {
                    Console.Write(team.Nationality + ", ");
                }
            }
            break;
        case ConsoleKey.D3:
            Console.Clear();
            Console.WriteLine("1. Chcę podać drużyny samemu");
            Console.WriteLine("2. Chcę wybrać losowe drużyny");
            size = Console.ReadKey();
            if (size.Key == ConsoleKey.D1)
            {
                for (int i = 0; i < 8; i++)
                {
                    Console.Clear();
                    Console.Write("Teamy które biorą udział w turnieju:");
                    foreach (var team in teamsToTournament)
                    {
                        Console.Write(team.Nationality + " ");
                    }
                    Console.WriteLine("\nPodaj drużynę");
                    nationality = FirstToUpper(Console.ReadLine());
                    bool chosen = false;
                    foreach (Team team in teams)
                    {
                        if (team.Nationality == nationality)
                        {
                            if (teamsToTournament.Contains(team))
                            {
                                Console.WriteLine("Dodałeś już taką drużynę");
                                Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
                                Console.ReadKey();
                                i--;
                                chosen = true;
                            }
                            else
                            {
                                teamsToTournament.Add(team);
                                chosen = true;
                            }
                        }
                    }
                    if(chosen==false)
                    {
                        Console.WriteLine("Nie ma takiej drużyny");
                        Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
                        Console.ReadKey();
                        i--;
                    }
                }
                Console.WriteLine("Drużyny które wybrałeś to:");
                foreach (var team in teamsToTournament)
                {
                    Console.Write(team.Nationality + ", ");
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
                Console.WriteLine("Drużyny wylosowane to:");
                foreach (var team in teamsToTournament)
                {
                    Console.Write(team.Nationality + ", ");
                }
            }
            break;
    }

    Championship championship = new Championship(teamsToTournament);

    championship.Menu();
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
    try
    {
        using (Stream reader = new FileStream(fileName, FileMode.Open))
        {
            teams = (List<Team>)xml.Deserialize(reader);
        }
    }
    catch(FileNotFoundException e)
    {
        Console.WriteLine("Nie znaleziono takiego pliku");
        Console.WriteLine("Wciśnij dowolny przycisk aby kontynuować");
        Console.ReadKey();
        ShowMenu();
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
    string nationality;
    Console.WriteLine("Podaj nazwę drużyny, którą chcesz edytować: ");
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
        var key = Console.ReadKey(); 
        if (key.Key == ConsoleKey.D1)
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
    Console.WriteLine("3. Wróć do menu");
    var key2 = Console.ReadKey();
    
    if (key2.Key == ConsoleKey.D1)
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
    if (key2.Key == ConsoleKey.D2)
    {
        ShowTeamWithPos(team);
        Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować");
        Console.ReadKey();
        goto WhatToDoNext;
    }
    else
    {
        ShowMenu();
    }

}


Player SearchPlayer(string nationality, Formation formation, Team team, Player pl)
{
    Console.Clear();
    int tmp = 1;

    ShowTeamWithPos(team);
    Console.WriteLine("\nNa jaką pozycję chciałbyś dodać/zamienić zawodnika?");
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
        var key = Console.ReadKey();
        if (key.Key == ConsoleKey.D1)
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
        chooseplayer:
        Console.Clear();
        tmp = 1;
        foreach (var p in playersSearch)
        {
            Console.WriteLine(tmp + " " + p.FullName + ", Wiek: " + p.Age);
            tmp++;
        }

        Console.WriteLine("Wybierz piłkarza:");
        Player player = new Player();
        int chosenPlayer = Convert.ToInt32(Console.ReadLine());
        if(chosenPlayer > tmp-1 || chosenPlayer<=0)
        {
            Console.WriteLine("Wybrałeś osobę spoza kategorii");
            Console.WriteLine("Wciśnij 1 aby spróbować jeszcze raz, lub naciśnij dowolny przycisk aby wrócić do edytowanie drużyny");
            var key = Console.ReadKey();
            if(key.Key == ConsoleKey.D1)
            {
                goto chooseplayer;
            }
            else
            {
                ManageTeam();
                return pl;
            }
        }
        else
        {
            player = playersSearch[chosenPlayer - 1];
            player.PosNr = pos;
            return player;
        }
    }
}


void ShowTeamWithPos(Team team)
{
    Console.Clear();
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







