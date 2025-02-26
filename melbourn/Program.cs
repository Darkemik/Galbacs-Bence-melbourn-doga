using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Pilot
{
    public string Name;
    public string Nationality;
    public string Team;
    public int StartPosition;
    public string Time; 
    public int Points;

    public Pilot(string line)
    {
        string[] data = line.Split(';'); 
        string name = data[0];
        string nationality = data[1];
        string team = data[2];
        int startPosition = int.Parse(data[3]);
        string time = data[4]; 
        int points = int.Parse(data[5]);

        
        Name = name;
        Nationality = nationality;
        Team = team;
        StartPosition = startPosition;
        Time = time;
        Points = points;    
    }
}

class Program
{
    static void Main()
    {
        string path = "C:\\Users\\ny20BBusaiD\\Desktop\\melbourn\\melbourn\\melbourn\\melbourne2009.txt";
        List<Pilot> pilots = new List<Pilot>();

        foreach (var line in File.ReadLines(path).Skip(1))
        {
            pilots.Add(new Pilot(line));
        }

        Console.WriteLine("1 feladat:");
        Console.WriteLine();
        Console.WriteLine($"Célba ért pilóták száma: {pilots.Count}");
        Console.WriteLine();
        Console.WriteLine("2 feladat");
        Console.WriteLine();
        int totalPoints = pilots.Sum(p => p.Points);
        Console.WriteLine($"Összes kiosztott világbajnoki pont: {totalPoints}");
        Console.WriteLine();
        Console.WriteLine("3 feladat");
        Console.WriteLine();
        int germanDrivers = pilots.Count(p => p.Nationality.ToLower() == "germany");
        Console.WriteLine($"Német nemzetiségű versenyzők száma: {germanDrivers}");
        Console.WriteLine();
        Console.WriteLine("4 feladat");
        Console.WriteLine();
        List<string> teamsWithPoints = new List<string>();

        foreach (var pilot in pilots)
        {
            if (pilot.Points > 0 && !teamsWithPoints.Contains(pilot.Team))
            {
                teamsWithPoints.Add(pilot.Team);
            }
        }

        Console.WriteLine("Csapatok, amelyek pilótái pontot szereztek:");
        foreach (var team in teamsWithPoints)
        {
            Console.WriteLine($" ====>>>>>>>>>>> {team}");
        }
        Console.WriteLine();
        Console.WriteLine("5 feladat");
        Console.WriteLine();

   

        
        var winner = pilots
            .OrderBy(p => p.Time) 
            .First();
        Console.WriteLine($"A verseny győztese: {winner.Name}");
        Console.WriteLine();
        Console.WriteLine($"A {winner.Name} nevű embernek volt a legjobb ideje, ami {winner.Time}s.");
    }

}
