using Newtonsoft.Json;
using SortDownloads.Helpers;
using SortDownloads.Settings;

internal class Program
{
    private static void Main(string[] args)
    {
        using (StreamReader reader = new StreamReader(File.Open($"{Directory.GetCurrentDirectory()}\\appsettings.json", FileMode.Open)))
        {
            string json = reader.ReadToEnd();
            var settings = JsonConvert.DeserializeObject<ScriptSettings>(json);

            DirectoryInfo info = new DirectoryInfo(settings.SortingDir);
            FileInfo[] allFiles = info.GetFiles();
            var extensions = new List<string>();

            //Get all extensions from folder
            foreach (var file in allFiles)
            {
                if (!file.Extension.Contains('.'))
                {

                    continue;
                }

                //Filter excluded extensions
                extensions.Add(file.Extension.Remove(0, 1));

            }


            extensions = extensions.Where(x => !settings.ExtensionsToIgnore.Contains(x.ToLower())).ToList();

            DownloadsFileHelper.MoveFiles(extensions, settings.SortingDir);
            DownloadsFileHelper.MoveFilesWithoutExtension(settings.SortingDir);

        }
    }
}