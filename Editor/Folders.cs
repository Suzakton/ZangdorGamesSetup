#if UNITY_EDITOR

using System.Net.Mime;
using System.IO;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

namespace ZangdorGames.Setup
{
    public static class Folders
    {
        public static void CreateDirectories(string root, params string[] directories)
        {
            string fullPath = Combine(dataPath, root);
            foreach (string newDir in directories)
                CreateDirectory(Combine(fullPath, newDir));
            Refresh();
        }

        public static void CleanAllProject()
        {
            DirectoryInfo directoryInfos = new DirectoryInfo(dataPath);
            foreach (FileInfo file in directoryInfos.GetFiles())
                file.Delete(); 
            foreach (DirectoryInfo dir in directoryInfos.GetDirectories())
                dir.Delete(true); 
        }
    }
}

#endif