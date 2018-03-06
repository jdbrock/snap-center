// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using SnapCenter.AppTestRun;
//
//    var welcome = Welcome.FromJson(jsonString);

namespace SnapCenter.AppTestRun
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class AppTestRun
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("date")]
        public System.DateTimeOffset? Date { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("runStatus")]
        public string RunStatus { get; set; }

        [JsonProperty("resultStatus")]
        public string ResultStatus { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("testSeries")]
        public string TestSeries { get; set; }

        [JsonProperty("testType")]
        public string TestType { get; set; }

        [JsonProperty("uploadedBy")]
        public string UploadedBy { get; set; }
    }

    public partial class Stats
    {
        [JsonProperty("devices")]
        public long? Devices { get; set; }

        [JsonProperty("devicesFinished")]
        public long? DevicesFinished { get; set; }

        [JsonProperty("devicesFailed")]
        public long? DevicesFailed { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonProperty("passed")]
        public long? Passed { get; set; }

        [JsonProperty("failed")]
        public long? Failed { get; set; }

        [JsonProperty("skipped")]
        public long? Skipped { get; set; }

        [JsonProperty("peakMemory")]
        public long? PeakMemory { get; set; }

        [JsonProperty("totalDeviceMinutes")]
        public long? TotalDeviceMinutes { get; set; }
    }

    public partial class AppTestRun
    {
        public static AppTestRun[] FromJson(string json) => JsonConvert.DeserializeObject<AppTestRun[]>(json);
    }

    public static class Serialize
    {
        public static string ToJson(this AppTestRun[] self) => JsonConvert.SerializeObject(self);
    }
}
