﻿using Newtonsoft.Json;

namespace SolutionExtensions
{
    public class ExtensionModel : IExtensionModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonIgnore]
        public string Category { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
