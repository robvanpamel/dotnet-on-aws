using System.Collections.Generic;

namespace LookingOverTheHedge.Api.Data
{
    public class Speaker
    {
        public Speaker()
        {
            ScheduledTalks = new List<Talk>();
        }

        public int SpeakerId { get; set; }

        public string Name { get; set; }

        public List<Talk> ScheduledTalks { get; set; }
    }
}