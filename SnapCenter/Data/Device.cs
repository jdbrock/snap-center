// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using SnapCenter.Device;
//
//    var welcome = Welcome.FromJson(jsonString);

namespace SnapCenter.Device
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DeviceConfig
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("tier")]
        public long? Tier { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("osName")]
        public string OsName { get; set; }

        [JsonProperty("os")]
        public string Os { get; set; }

        [JsonProperty("marketShare")]
        public long? MarketShare { get; set; }

        [JsonProperty("model")]
        public Model Model { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("full")]
        public string Full { get; set; }

        [JsonProperty("thumb")]
        public string Thumb { get; set; }
    }

    public partial class Model
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("model")]
        public string ModelModel { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("dimensions")]
        public Dimensions Dimensions { get; set; }

        [JsonProperty("resolution")]
        public Resolution Resolution { get; set; }

        [JsonProperty("cpu")]
        public Cpu Cpu { get; set; }

        [JsonProperty("memory")]
        public Memory Memory { get; set; }

        [JsonProperty("screenRotation")]
        public long? ScreenRotation { get; set; }

        [JsonProperty("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonProperty("formFactor")]
        public string FormFactor { get; set; }

        [JsonProperty("screenSize")]
        public ScreenSize ScreenSize { get; set; }

        [JsonProperty("availabilityCount")]
        public long? AvailabilityCount { get; set; }

        [JsonProperty("deviceFrame")]
        public DeviceFrame DeviceFrame { get; set; }
    }

    public partial class Cpu
    {
        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        [JsonProperty("core")]
        public object Core { get; set; }
    }

    public partial class DeviceFrame
    {
        [JsonProperty("grid")]
        public Full Grid { get; set; }

        [JsonProperty("full")]
        public Full Full { get; set; }
    }

    public partial class Full
    {
        [JsonProperty("frameUrl")]
        public string FrameUrl { get; set; }

        [JsonProperty("width")]
        public long? Width { get; set; }

        [JsonProperty("height")]
        public long? Height { get; set; }

        [JsonProperty("screen")]
        public long[] Screen { get; set; }
    }

    public partial class Dimensions
    {
        [JsonProperty("height")]
        public Depth Height { get; set; }

        [JsonProperty("width")]
        public Depth Width { get; set; }

        [JsonProperty("depth")]
        public Depth Depth { get; set; }
    }

    public partial class Depth
    {
        [JsonProperty("mm")]
        public string Mm { get; set; }

        [JsonProperty("in")]
        public string In { get; set; }
    }

    public partial class Memory
    {
        [JsonProperty("formattedSize")]
        public string FormattedSize { get; set; }
    }

    public partial class Resolution
    {
        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("ppi")]
        public string Ppi { get; set; }
    }

    public partial class ScreenSize
    {
        [JsonProperty("in")]
        public string In { get; set; }

        [JsonProperty("cm")]
        public string Cm { get; set; }
    }

    public partial class DeviceConfig
    {
        public static DeviceConfig[] FromJson(string json) => JsonConvert.DeserializeObject<DeviceConfig[]>(json, SnapCenter.Device.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this DeviceConfig[] self) => JsonConvert.SerializeObject(self, SnapCenter.Device.Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter()
                {
                    DateTimeStyles = DateTimeStyles.AssumeUniversal,
                },
            },
        };
    }
}
