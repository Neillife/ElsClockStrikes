using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElsClockStrikes.Core
{
    public static class UpdateChecker
    {
        private const string owner = "neillife";
        private const string repo = "ElsClockStrikes";
        private static string GitHubAPI = $"https://api.github.com/repos/{owner}/{repo}/releases/latest";

        public static async Task CheckNewVersion(bool isAutoCheckUpdate)
        {
            if (!isAutoCheckUpdate)
                return;

            try
            {
                string currentVersion = GetCurrentVersion();
                var (releaseTagName, releaseUrl) = await GetLatestReleaseAsync();

                if (releaseTagName == null)
                    return;

                if (!currentVersion.Equals(releaseTagName))
                {
                    var result = MessageBox.Show(
                        $"發現新版本：{releaseTagName}\n有新的版本更新可用是否前往下載？",
                        "發現更新",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );

                    if (result == DialogResult.Yes)
                    {
                        Process.Start(releaseUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                // API request failure is ignored and not processed...
            }
        }

        private static string GetCurrentVersion()
        {
            string verStr = Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", "-");
            verStr = verStr.Remove(verStr.Length - 2);
            return $"20{verStr}";
        }

        private static async Task<(string releaseTagName, string releaseUrl)> GetLatestReleaseAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(3); // no response with 3 sec do nothing.
                client.DefaultRequestHeaders.UserAgent.ParseAdd("request");

                string json = await client.GetStringAsync(GitHubAPI);

                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    string releaseTagName = doc.RootElement.GetProperty("tag_name").GetString();
                    string releaseUrl = doc.RootElement.GetProperty("html_url").GetString();
                    return (releaseTagName, releaseUrl);
                }
            }
        }
    }
}
