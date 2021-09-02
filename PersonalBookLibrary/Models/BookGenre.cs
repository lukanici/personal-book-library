using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PersonalBookLibrary.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BookGenre
    {
        [EnumMember(Value = "HORROR")]
        Horror,

        [EnumMember(Value = "ROMANCE")]
        Romance,

        [EnumMember(Value = "SCI-FI")]
        SciFi,

        [EnumMember(Value = "BIOGRAPHY")]
        Biography,

        [EnumMember(Value = "COOKBOOK")]
        Cookbook
    }
}
