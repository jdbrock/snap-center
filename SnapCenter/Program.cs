using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SnapCenter
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                JsonConvert.DefaultSettings = () => new JsonSerializerSettings
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

                var dir = args.Length >= 1 ? args[0] : Environment.GetEnvironmentVariable("SnapCenterOutput");
                var user = args.Length >= 2 ? args[1] : Environment.GetEnvironmentVariable("AppCenterUser");
                var app = args.Length >= 3 ? args[2] : Environment.GetEnvironmentVariable("AppCenterApp");
                var testRunId = args.Length >= 4 ? args[3] : Environment.GetEnvironmentVariable("TestRunId");
                var apiKey = args.Length >= 5 ? args[4] : Environment.GetEnvironmentVariable("AppCenterApiKey");

                await Console.Out.WriteLineAsync($"Output Dir: {dir}");
                await Console.Out.WriteLineAsync($"User: {user}");
                await Console.Out.WriteLineAsync($"App: {app}");
                await Console.Out.WriteLineAsync($"Test Run ID: {testRunId}");
                await Console.Out.WriteLineAsync($"API Key: {apiKey}");

                var api = Refit.RestService.For<IApi>("https://appcenter.ms/api/v0.1");

                await Console.Out.WriteLineAsync($"Requesting test run report {testRunId}...");
                var testRunReport = await api.GetTestRunReport(apiKey, user, app, testRunId);

                await Console.Out.WriteLineAsync($"Requesting device configuration for {testRunId}...");
                var deviceConfig = await api.GetDeviceConfig(apiKey, user, app, testRunId);

                var devicesById = deviceConfig
                    .ToDictionary(x => x.Id);

                var client = new HttpClient();

                await Console.Out.WriteLineAsync($"Fetching screenshots for {testRunId}...");

                foreach (var feature in testRunReport.Features)
                    foreach (var test in feature.Tests)
                    {
                        await Console.Out.WriteLineAsync($"Test: {test.TestName}");

                        foreach (var run in test.Runs)
                            foreach (var step in run.Steps)
                            {
                                await Console.Out.WriteLineAsync($"Step: {step.StepName}");

                                var stepReportJson = await client.GetStringAsync(step.StepReportUrl);
                                var stepReport = Step.StepReport.FromJson(stepReportJson);

                                foreach (var screenshot in stepReport.DeviceScreenshots)
                                {
                                    var device = devicesById[screenshot.DeviceSnapshotId];
                                    var screenshotUrl = screenshot.Screenshot.Urls.Original;
                                    var screenshotDir = Path.Combine(dir, test.TestName, device.Name);
                                    var screenshotPath = Path.Combine(screenshotDir, screenshot.Title + ".png");

                                    await Console.Out.WriteAsync($"Downloading to {screenshotPath}...");

                                    Directory.CreateDirectory(screenshotDir);

                                    using (var local = File.Create(screenshotPath))
                                    using (var remote = await client.GetStreamAsync(screenshotUrl))
                                    {
                                        await remote.CopyToAsync(local);
                                        await local.FlushAsync();
                                    }

                                    await Console.Out.WriteLineAsync("done.");
                                }
                            }
                    }

            }
            catch (Exception e)
            {
                await Console.Error.WriteLineAsync("ERROR: " + e.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
