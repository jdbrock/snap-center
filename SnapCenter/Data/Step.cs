// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using SnapCenter.Step;
//
//    var welcome = Welcome.FromJson(jsonString);

namespace SnapCenter.Step
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class StepReport
    {
        [JsonProperty("finishedSnapshots")]
        public string[] FinishedSnapshots { get; set; }

        [JsonProperty("deviceScreenshots")]
        public DeviceScreenshot[] DeviceScreenshots { get; set; }
    }

    public partial class DeviceScreenshot
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("device_snapshot_id")]
        public string DeviceSnapshotId { get; set; }

        [JsonProperty("log_file")]
        public string LogFile { get; set; }

        [JsonProperty("stacktrace")]
        public object Stacktrace { get; set; }

        [JsonProperty("crash_data")]
        public object[] CrashData { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("screenshot")]
        public Screenshot Screenshot { get; set; }
    }

    public partial class Screenshot
    {
        [JsonProperty("urls")]
        public Urls Urls { get; set; }

        [JsonProperty("rotation")]
        public long? Rotation { get; set; }

        [JsonProperty("landscape")]
        public bool? Landscape { get; set; }
    }

    public partial class Urls
    {
        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }
    }

    public partial class StepReport
    {
        public static StepReport FromJson(string json) => JsonConvert.DeserializeObject<StepReport>(json, SnapCenter.Step.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this StepReport self) => JsonConvert.SerializeObject(self, SnapCenter.Step.Converter.Settings);
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
