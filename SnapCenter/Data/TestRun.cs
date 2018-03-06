// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using SnapCenter.Data;
//
//    var welcome = Welcome.FromJson(jsonString);

namespace SnapCenter.TestRun
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TestRunReport
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("date")]
        public System.DateTimeOffset? Date { get; set; }

        [JsonProperty("date_finished")]
        public System.DateTimeOffset? DateFinished { get; set; }

        [JsonProperty("revision")]
        public long? Revision { get; set; }

        [JsonProperty("testType")]
        public string TestType { get; set; }

        [JsonProperty("features")]
        public Feature[] Features { get; set; }

        [JsonProperty("finished_device_snapshots")]
        public string[] FinishedDeviceSnapshots { get; set; }

        [JsonProperty("errorMessage")]
        public object ErrorMessage { get; set; }

        [JsonProperty("device_logs")]
        public DeviceLog[] DeviceLogs { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }
    }

    public partial class DeviceLog
    {
        [JsonProperty("device_snapshot_id")]
        public string DeviceSnapshotId { get; set; }

        [JsonProperty("device_log")]
        public string DeviceLogDeviceLog { get; set; }

        [JsonProperty("test_log")]
        public string TestLog { get; set; }
    }

    public partial class Feature
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tests")]
        public Test[] Tests { get; set; }

        [JsonProperty("failed")]
        public long? Failed { get; set; }

        [JsonProperty("skipped")]
        public long? Skipped { get; set; }

        [JsonProperty("peakMemory")]
        public long? PeakMemory { get; set; }

        [JsonProperty("peakDuration")]
        public double? PeakDuration { get; set; }
    }

    public partial class Test
    {
        [JsonProperty("testName")]
        public string TestName { get; set; }

        [JsonProperty("unique_name")]
        public string UniqueName { get; set; }

        [JsonProperty("conflict")]
        public bool? Conflict { get; set; }

        [JsonProperty("runs")]
        public Run[] Runs { get; set; }

        [JsonProperty("peakMemory")]
        public long? PeakMemory { get; set; }

        [JsonProperty("peakDuration")]
        public double? PeakDuration { get; set; }
    }

    public partial class Run
    {
        [JsonProperty("steps")]
        public Step[] Steps { get; set; }

        [JsonProperty("report_url")]
        public string ReportUrl { get; set; }

        [JsonProperty("failed")]
        public long? Failed { get; set; }

        [JsonProperty("skipped")]
        public long? Skipped { get; set; }

        [JsonProperty("number")]
        public long? Number { get; set; }
    }

    public partial class Step
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("stepName")]
        public string StepName { get; set; }

        [JsonProperty("stepExecutions")]
        public StepExecution[] StepExecutions { get; set; }

        [JsonProperty("failed")]
        public long? Failed { get; set; }

        [JsonProperty("skipped")]
        public long? Skipped { get; set; }

        [JsonProperty("conflict")]
        public bool? Conflict { get; set; }

        [JsonProperty("step_report_url")]
        public string StepReportUrl { get; set; }
    }

    public partial class StepExecution
    {
        [JsonProperty("device_snapshot_id")]
        public string DeviceSnapshotId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class Stats
    {
        [JsonProperty("os")]
        public long? Os { get; set; }

        [JsonProperty("devices")]
        public long? Devices { get; set; }

        [JsonProperty("devices_finished")]
        public long? DevicesFinished { get; set; }

        [JsonProperty("devices_not_runned")]
        public long? DevicesNotRunned { get; set; }

        [JsonProperty("devices_failed")]
        public long? DevicesFailed { get; set; }

        [JsonProperty("totalDeviceMinutes")]
        public double? TotalDeviceMinutes { get; set; }

        [JsonProperty("passed")]
        public long? Passed { get; set; }

        [JsonProperty("failed")]
        public long? Failed { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonProperty("step_count")]
        public long? StepCount { get; set; }

        [JsonProperty("skipped")]
        public long? Skipped { get; set; }

        [JsonProperty("filesize")]
        public long? Filesize { get; set; }

        [JsonProperty("peakmem")]
        public Peakmem Peakmem { get; set; }

        [JsonProperty("peakmemDetails")]
        public Peakmem[] PeakmemDetails { get; set; }

        [JsonProperty("peakduration")]
        public Peakduration Peakduration { get; set; }

        [JsonProperty("peakdurationDetails")]
        public Peakduration[] PeakdurationDetails { get; set; }

        [JsonProperty("artifacts")]
        public Artifacts Artifacts { get; set; }
    }

    public partial class Artifacts
    {
        [JsonProperty("nunit_xml_zip")]
        public string NunitXmlZip { get; set; }
    }

    public partial class Peakduration
    {
        [JsonProperty("device_snapshot_id")]
        public string DeviceSnapshotId { get; set; }

        [JsonProperty("step_id")]
        public string StepId { get; set; }

        [JsonProperty("peak_duration")]
        public double? PeakDuration { get; set; }
    }

    public partial class Peakmem
    {
        [JsonProperty("device_snapshot_id")]
        public string DeviceSnapshotId { get; set; }

        [JsonProperty("step_id")]
        public string StepId { get; set; }

        [JsonProperty("peak_memory")]
        public long? PeakMemory { get; set; }
    }

    public partial class TestRunReport
    {
        public static TestRunReport FromJson(string json) => JsonConvert.DeserializeObject<TestRunReport>(json);
    }

    public static class Serialize
    {
        public static string ToJson(this TestRunReport self) => JsonConvert.SerializeObject(self);
    }
}
