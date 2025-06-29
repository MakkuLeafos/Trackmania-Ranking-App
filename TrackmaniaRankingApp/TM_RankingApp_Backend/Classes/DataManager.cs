using TM_RankingApp_Backend.Models;
using System.Linq;
using System.Text.Json;

namespace TM_RankingApp_Backend.Classes
{
    public class DataManager
    {
        private string eventDataJSONFilePath = Path.Combine(Environment.CurrentDirectory, @"Data\EventData.json");
        private List<TMEvent>? eventList;

        public List<TMEvent> GetEventList()
        {
            eventList = JsonSerializer.Deserialize<List<TMEvent>>(GetJSONData(eventDataJSONFilePath));
            if (eventList != null)
            {
                return eventList;
            }
            else
            {
                return [];
            }
        }

        public List<TMLeaderboardEntry> GetLeaderboard()
        {
            var leaderboard = new Dictionary<string, int>();

            foreach (var ev in GetEventList())
            {
                foreach (var result in ev.RankingList)
                {
                    if (leaderboard.ContainsKey(result.Name))
                    {
                        leaderboard[result.Name] += result.Points;
                    }
                    else
                    {
                        leaderboard.Add(result.Name, result.Points);
                    }
                }
            }

            var sortedLeaderboard = leaderboard.Select(entry => new TMLeaderboardEntry { Name = entry.Key, TotalPoints = entry.Value })
                                               .OrderByDescending(e => e.TotalPoints)
                                               .ToList();

            for (int i = 0; i < sortedLeaderboard.Count; i++)
            {
                sortedLeaderboard[i].Rank = i + 1;
            }

            return sortedLeaderboard;
        }

        public void SaveJSONData()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string JSONString = JsonSerializer.Serialize(eventList, options);

            File.WriteAllText(eventDataJSONFilePath,JSONString);
        }

        public string GetJSONData(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            return jsonData;
        }
    }
}
