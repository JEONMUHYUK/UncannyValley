using UnityEngine;
using UnityEditor;
using System.IO;


public class BuidlScript : MonoBehaviour
{
    [UnityEditor.MenuItem("MyMenu/Build/Builded", false, 1)]
    static void MyPerforBuild()
    {
        string curDir = Directory.GetCurrentDirectory() + "\\Builde\\";
        //  string[] scene = UnityEditor.EditorBuildSettingsScene.GetActiveSceneList(EditorBuildSettingsScene );
        //  string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
        string[] scenes = { "Assets/Scenes/GameScene.unity" };
        //  string[] scenes = UnityEditor.EditorBuildSettingsScene.GetActiveSceneList(EditorBuildSettings.scenes);
        //  BuildPipeline.BuildPlayer(scenes,"./Build/mygame.exe" , BuildTarget.StandaloneWindows64, BuildOptions.None);
        BuildPipeline.BuildPlayer(scenes, curDir + "mygame.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
        //  BuildPipeline.BuildPlayer(scene, path + "./test.exx" "mygame.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
    }
}
