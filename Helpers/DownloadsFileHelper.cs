namespace SortDownloads.Helpers
{
    public static class DownloadsFileHelper
    {
        public static void MoveFiles(List<string> extensions, string sortingDir)
        {
            DirectoryInfo info = new DirectoryInfo(sortingDir);
            foreach (var extension in extensions)
            {
                var directoryToCreate = $"{sortingDir}/{extension}";

                bool directoryExists = Directory.Exists(directoryToCreate);

                //Create directory if it does not exist
                if (!directoryExists)
                {
                    Directory.CreateDirectory(directoryToCreate);
                }

                FileInfo[] files = info.GetFiles($"*.{extension}");
                foreach (var file in files)
                {
                    Directory.Move(file.FullName.Replace("\\", "/"), $"{directoryToCreate}/{file.Name}");
                }

            }
        }

        public static void MoveFilesWithoutExtension(string sortingDir)
        {

            DirectoryInfo info = new DirectoryInfo(sortingDir);
            var directoryToCreate = $"{sortingDir}/no_extension";

            bool directoryExists = Directory.Exists(directoryToCreate);

            //Create directory if it does not exist
            if (!directoryExists)
            {
                Directory.CreateDirectory(directoryToCreate);
            }

            FileInfo[] files = info.GetFiles($"*.");
            foreach (var file in files)
            {
                Directory.Move(file.FullName.Replace("\\", "/"), $"{directoryToCreate}/{file.Name}");
            }
        }
        
    }
}