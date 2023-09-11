using System;
using System.Collections.Generic;
using System.Linq;

public class MatchManagement
{
    private List<MatchDetails> matches;

    public MatchManagement()
    {
        matches = new List<MatchDetails>();
    }

    // Add Match Validation Method
    private bool ValidateMatchDetails(MatchDetails match)
    {
        return true;
    }

    public void AddMatch(MatchDetails match)
    {
        if (ValidateMatchDetails(match))
        {
            matches.Add(match);
        }
        else
        {
            Console.WriteLine("Invalid Match Details Because Match is Not Added");
        }
    }

    // Implement Sorting Matches based on criteria and order
    public void SortMatches(string criteria, bool ascending)
    {
        switch (criteria.ToLower())
        {
            case "date":
                matches = ascending ? matches.OrderBy(m => m.MatchDateTime).ToList() : matches.OrderByDescending(m => m.MatchDateTime).ToList();
                break;
            case "sport":
                matches = ascending ? matches.OrderBy(m => m.Sport).ToList() : matches.OrderByDescending(m => m.Sport).ToList();
                break;
            case "location":
                matches = ascending ? matches.OrderBy(m => m.Location).ToList() : matches.OrderByDescending(m => m.Location).ToList();
                break;
            default:
                Console.WriteLine("Invalid Sorting");
                break;
        }
    }

    // Implement Filtering Matches based on criteria
    public List<MatchDetails> FilterMatches(string criteria, string value)
    {
        switch (criteria.ToLower())
        {
            case "sport":
                return matches.Where(m => m.Sport.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList();
            case "location":
                return matches.Where(m => m.Location.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList();
            case "date range":
                DateTime startDate;
                DateTime endDate;
                if (DateTime.TryParse(value.Split('-')[0], out startDate) && DateTime.TryParse(value.Split('-')[1], out endDate))
                {
                    return matches.Where(m => m.MatchDateTime >= startDate && m.MatchDateTime <= endDate).ToList();
                }
                else
                {
                    Console.WriteLine("Invalid Use Format 'yyyy-mm-dd - yyyy-mm-dd'");
                }
                break;
            default:
                Console.WriteLine("Invalid Filtering Criteria");
                break;
        }

        return new List<MatchDetails>();
    }

    // Implement Statistics Calculation based on match scores
    public void CalculateStatistics(string criteria)
    {
        switch (criteria.ToLower())
        {
            case "average score":
                double homeAvg = matches.Average(m => m.HomeTeamScore);
                double awayAvg = matches.Average(m => m.AwayTeamScore);
                Console.WriteLine($"Average Score - Home: {homeAvg}, Away: {awayAvg}");
                break;
            case "highest score":
                int highestHomeScore = matches.Max(m => m.HomeTeamScore);
                int highestAwayScore = matches.Max(m => m.AwayTeamScore);
                Console.WriteLine($"Highest Score - Home: {highestHomeScore}, Away: {highestAwayScore}");
                break;
            case "lowest score":
                int lowestHomeScore = matches.Min(m => m.HomeTeamScore);
                int lowestAwayScore = matches.Min(m => m.AwayTeamScore);
                Console.WriteLine($"Lowest Score - Home: {lowestHomeScore}, Away: {lowestAwayScore}");
                break;
            default:
                Console.WriteLine("Invalid");
                break;
        }
    }

    // Implement Search Matches based on keywords
    public List<MatchDetails> SearchMatches(string keyword)
    {
        return matches.Where(m =>
            m.Sport.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            m.HomeTeam.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            m.AwayTeam.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            m.Location.Contains(keyword, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }

    public void DisplayAllMatches()
    {
        foreach (var match in matches)
        {
            Console.WriteLine($"\nMatch ID:- {match.MatchId}, \nSport:- {match.Sport}, \nDate:- {match.MatchDateTime}, \nLocation:- {match.Location}, \nTeams:- {match.HomeTeam} V/S {match.AwayTeam}, \nScores:- {match.HomeTeamScore} - {match.AwayTeamScore}");
        }
    }

    public void DisplayMatchDetails(int matchId)
    {
        var match = matches.Find(m => m.MatchId == matchId);
        if (match != null)
        {
            Console.WriteLine($"\nMatch ID:- {match.MatchId}, \nSport:- {match.Sport}, \nDate:- {match.MatchDateTime}, \nLocation:- {match.Location}, \nTeams:- {match.HomeTeam} V/S {match.AwayTeam}, \nScores:- {match.HomeTeamScore} - {match.AwayTeamScore}");
        }
        else
        {
            Console.WriteLine("Match Not Found");
        }
    }

    public void UpdateMatchScore(int matchId, int homeScore, int awayScore)
    {
        var match = matches.Find(m => m.MatchId == matchId);
        if (match != null)
        {
            match.HomeTeamScore = homeScore;
            match.AwayTeamScore = awayScore;
            Console.WriteLine("Scores Updated Successfully");
        }
        else
        {
            Console.WriteLine("Match Not Found");
        }
    }

    public void RemoveMatch(int matchId)
    {
        var match = matches.Find(m => m.MatchId == matchId);
        if (match != null)
        {
            matches.Remove(match);
            Console.WriteLine("Match Removed Successfully");
        }
        else
        {
            Console.WriteLine("Match Not Found");
        }
    }
}

