namespace TM_RankingApp_Backend.Models
{
    public class TMEvent
    {
        public class EventResult
        {
            public string Name { get; set; } = string.Empty;
            public int Rank { get; set; }
            public int Points
            {
                //Sets the points according to the rank
                get
                {
                    int points;
                    switch (Rank)
                    {
                        case 1:
                            {
                                points = 25;
                                break;
                            }
                        case 2:
                            {
                                points = 18;
                                break;
                            }
                        case 3:
                            {
                                points = 15;
                                break;
                            }
                        case 4:
                            {
                                points = 12;
                                break;
                            }
                        case 5:
                            {
                                points = 10;
                                break;
                            }
                        case 6:
                            {
                                points = 8;
                                break;
                            }
                        case 7:
                            {
                                points = 6;
                                break;
                            }
                        case 8:
                            {
                                points = 4;
                                break;
                            }
                        case 9:
                            {
                                points = 2;
                                break;
                            }
                        case 10:
                            {
                                points = 1;
                                break;
                            }
                        default:
                            {
                                points = 0;
                                break;
                            }
                    }

                    return points;
                }
            }
        }

        public int EventID { get; set; } = 0;
        public string EventName { get; set; } = string.Empty;
        public List<EventResult> RankingList { get; set; } = [];
    }
}
