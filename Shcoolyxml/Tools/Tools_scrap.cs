using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;

namespace Schooly.Tools
{
    class Tools_scrap
    {

        public static async Task DownloadCompatibleEdgeDriverAsync()
        {
            string edgeVersion = GetEdgeBrowserVersion();
            if (string.IsNullOrEmpty(edgeVersion))
            {
                Console.WriteLine("Edge browser not found.");
                return;
            }

            string edgeDriverVersion = await GetEdgeDriverVersionAsync(edgeVersion);
            if (string.IsNullOrEmpty(edgeDriverVersion))
            {
                Console.WriteLine("EdgeDriver version not found.");
                return;
            }

            await DownloadEdgeDriverAsync(edgeDriverVersion);

        }

    public static async Task<string> GetEdgeDriverVersionAsync(string edgeVersion)
        {
            string edgeDriverReleasesApi = "https://msedgedriver.azureedge.net/LATEST_RELEASE_" + edgeVersion.Split('.')[0];

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    return await httpClient.GetStringAsync(edgeDriverReleasesApi);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching EdgeDriver version: " + ex.Message);
                    return null;
                }
            }
        }

        public static async Task DownloadEdgeDriverAsync(string edgeDriverVersion)
        {
            string edgeDriverDownloadUrl;
            string edgeDriverZipFile;

            //if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            //{
                edgeDriverDownloadUrl = $"https://msedgedriver.azureedge.net/{edgeDriverVersion}/edgedriver_win64.zip";
                edgeDriverZipFile = "edgedriver_win64.zip";
            //}
            //else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            //{
            //    edgeDriverDownloadUrl = $"https://msedgedriver.azureedge.net/{edgeDriverVersion}/edgedriver_mac64.zip";
            //    edgeDriverZipFile = "edgedriver_mac64.zip";
            //}
            //else
            //{
            //    Console.WriteLine("Unsupported platform.");
            //    return;
            //}

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    byte[] edgeDriverData = await httpClient.GetByteArrayAsync(edgeDriverDownloadUrl);
                    File.WriteAllBytes(edgeDriverZipFile, edgeDriverData);

                    // Extract the downloaded zip file
                    ZipFile.ExtractToDirectory(edgeDriverZipFile, ".");
                    Console.WriteLine($"EdgeDriver version {edgeDriverVersion} downloaded and extracted.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error downloading EdgeDriver: " + ex.Message);
                }
            }
        }

        public static string GetEdgeBrowserVersion()
        {
            string edgeExePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

            if (System.IO.File.Exists(edgeExePath))
            {
                FileVersionInfo edgeVersionInfo = FileVersionInfo.GetVersionInfo(edgeExePath);
                return edgeVersionInfo.FileVersion;
            }

            return null;
        }
    }
}
