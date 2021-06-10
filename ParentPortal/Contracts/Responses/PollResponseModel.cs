using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParentPortal.Contracts.Responses
{
    public class PollResponseModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public List<PollData> PollDataCollection { get; set; }
    }
    public class PollData
    {
        public int id { get; set; }
        public string Question { get; set; }
        [JsonProperty("options")]
        public List<PollOption> Options { get; set; }
     

    }
    public class PollOption
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        public string optionIndex { get; set; }

    }
}
