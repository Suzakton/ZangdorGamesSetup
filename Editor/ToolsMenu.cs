#if UNITY_EDITOR

using UnityEditor;
using static ZangdorGames.Setup.Folders;
using static ZangdorGames.Setup.Packages;

namespace ZangdorGames.Setup
{
    public static class ToolsMenu
    {
        [MenuItem("ZangdorGames/Setup New Project", false, -1000)]
        public static void SetupProject()
        {
            //Clear project from already existing folders and files
            CleanAllProject();
            // Create base project dirs
            CreateDirectories("_Project", "2DAssets", "3DAssets", "Prefabs", "Scenes", "Scripts", "Scriptables");
            // Change base namespace
            EditorSettings.projectGenerationRootNamespace = "ZangdorGames";
            // Change serialization mode
            EditorSettings.serializationMode = UnityEditor.SerializationMode.ForceText;
            // Download all packages
            LoadNewManifestFromGist("9fa7a11b017c69968dadd11d734e1141");
        }

        [MenuItem("ZangdorGames/Packages/Cinemachine")]
        public static void AddCinemachine() => InstallUnityPackage("cinemachine");
        
        [MenuItem("ZangdorGames/Packages/New Input System")]
        public static void AddNewInputSystem() => InstallUnityPackage("inputsystem");
        
        [MenuItem("ZangdorGames/Packages/Adressables")]
        public static void AddAddressables() => InstallUnityPackage("addressables");
        
        [MenuItem("ZangdorGames/Packages/URP")]
        public static void AddURP() => InstallUnityPackage("render-pipelines.universal");

        [MenuItem("ZangdorGames/Packages/Timeline")]
        public static void AddTimeline() => InstallUnityPackage("timeline");

        [MenuItem("ZangdorGames/Packages/PostProcessing")]
        public static void AddPostProcessing() => InstallUnityPackage("postprocessing");
    }
}

#endif