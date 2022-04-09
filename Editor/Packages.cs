#if UNITY_EDITOR

using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace ZangdorGames.Setup
{
    public static class Packages
    {
        public async static void LoadNewManifestFromGist(string id)
        {
            string url = GetGistUrl(id);
            string contents = await GetContent(url);
            ReplacePackageFile(contents);
        }

        private static string GetGistUrl(string id, string user = "Suzakton") =>
            $"https://gist.githubusercontent.com/{user}/{id}/raw";

        private static async Task<string> GetContent(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }
        
        private static void ReplacePackageFile(string contents)
        {
            string existingPakageFile = Path.Combine(Application.dataPath, "../Packages/manifest.json");
            File.WriteAllText(existingPakageFile, contents);
            UnityEditor.PackageManager.Client.Resolve();
        }

        public static void InstallUnityPackage(string packageName)
        {
            UnityEditor.PackageManager.Client.Add($"com.unity.{packageName}");
        }
    }
}

#endif