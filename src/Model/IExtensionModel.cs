﻿using Newtonsoft.Json;

namespace SolutionExtensions
{
    public interface IExtensionModel
    {
        [JsonProperty("name")]
        string Name { get; }

        [JsonProperty("description")]
        string Description { get; }

        [JsonProperty("productId")]
        string ProductId { get; }

        [JsonProperty("link")]
        string Link { get; }

        [JsonIgnore()]
        string Category { get; set; }
    }
}
