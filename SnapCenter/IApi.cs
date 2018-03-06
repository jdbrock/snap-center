using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SnapCenter
{
    public interface IApi
    {
        [Get("/apps/{user}/{app}/test_runs/{runId}/report")]
        Task<TestRun.TestRunReport> GetTestRunReport([Header("X-API-Token")] string apiKey, string user, string app, string runId);

        [Get("/apps/{user}/{app}/device_configurations")]
        Task<Device.DeviceConfig[]> GetDeviceConfig([Header("X-API-Token")] string apiKey, string user, string app, string app_upload_id);
    }
}
