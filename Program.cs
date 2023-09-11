namespace Match_Details_Management_System
{
    internal class Program
    {
        static void Main()
        {
            MatchManagement matchManagement = new MatchManagement();

            // Add at least 6 MatchDetails objects
            matchManagement.AddMatch(new MatchDetails { MatchId = 1, Sport = "Soccer", MatchDateTime = DateTime.Parse("2023-09-07 14:00"), Location = "Stadium A", HomeTeam = "Team A", AwayTeam = "Team B", HomeTeamScore = 0, AwayTeamScore = 0 });
            // Add more matches here...

            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("\n------------------------ MENU ---------------------");

                Console.WriteLine("");

                Console.WriteLine(" 1 -> To Display All Matches which is Stored");
                Console.WriteLine(" 2 -> To Display Match Details");
                Console.WriteLine(" 3 -> To Update Match Score");
                Console.WriteLine(" 4 -> To Remove Match");
                Console.WriteLine(" 5 -> To Sort Matches");
                Console.WriteLine(" 6 -> To Filter Matches");
                Console.WriteLine(" 7 -> To Calculate Statistics");
                Console.WriteLine(" 8 -> To Search Matches");
                Console.WriteLine(" 0 -> To Exit");

                Console.WriteLine("");
                // Console.WriteLin(\n);

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            matchManagement.DisplayAllMatches();
                            break;
                        case 2:
                            Console.Write("Enter Match ID to Display:- ");
                            int matchId = int.Parse(Console.ReadLine());
                            matchManagement.DisplayMatchDetails(matchId);
                            break;
                        case 3:
                            Console.Write("Enter Match ID:- ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Home Team Score:- ");
                            int homeScore = int.Parse(Console.ReadLine());
                            Console.Write("Enter Away Team Score:- ");
                            int awayScore = int.Parse(Console.ReadLine());
                            matchManagement.UpdateMatchScore(id, homeScore, awayScore);
                            break;
                        case 4:
                            Console.Write("Enter Match ID:- ");
                            int removeId = int.Parse(Console.ReadLine());
                            matchManagement.RemoveMatch(removeId);
                            break;
                        case 5:
                            Console.WriteLine("Sort By -> [ Date / Sport / Location] ");
                            string criteria = Console.ReadLine();
                            Console.WriteLine("Ascending? [ True / False ] ");
                            bool ascending = bool.Parse(Console.ReadLine());
                            matchManagement.SortMatches(criteria, ascending);
                            matchManagement.DisplayAllMatches();
                            break;
                        case 6:
                            Console.WriteLine("Filter By -> [ Sport / Location / Date Range] ");
                            string filterCriteria = Console.ReadLine();
                            Console.WriteLine("Enter value: ");
                            string value = Console.ReadLine();
                            List<MatchDetails> filteredMatches = matchManagement.FilterMatches(filterCriteria, value);
                            Console.WriteLine("\nFiltered Matches:");
                            foreach (var match in filteredMatches)
                            {
                                Console.WriteLine($"\nMatch ID:- {match.MatchId}, \nSport:- {match.Sport}, \nDate:- {match.MatchDateTime}, \nLocation:- {match.Location}, \nTeams:- {match.HomeTeam} V/S {match.AwayTeam}, \nScores:- {match.HomeTeamScore} - {match.AwayTeamScore}");
                            }
                            break;
                        case 7:
                            Console.WriteLine("Calculate statistics for: [ Average Score / Highest Score / Lowest Score]");
                            string statisticsCriteria = Console.ReadLine();
                            matchManagement.CalculateStatistics(statisticsCriteria);
                            break;
                        case 8:
                            Console.WriteLine("Search for: ");
                            string keyword = Console.ReadLine();
                            List<MatchDetails> searchedMatches = matchManagement.SearchMatches(keyword);
                            Console.WriteLine("\nSearched Matches:");
                            foreach (var match in searchedMatches)
                            {
                                Console.WriteLine($"\nMatch ID:- {match.MatchId}, \nSport:- {match.Sport}, \nDate:- {match.MatchDateTime}, \nLocation:- {match.Location}, \nTeams:- {match.HomeTeam} V/S {match.AwayTeam}, \nScores:- {match.HomeTeamScore} - {match.AwayTeamScore}");
                            }
                            break;
                        case 0:
                            continueRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}