
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildScript : MonoBehaviour
{

    [UnityEditor.MenuItem("MyMenu/MyBuild", false, 1)]
    static void PerformBuild()
    {
        string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");

        string[] scene = { "Assets/Scenes/StartScene.unity" };
        string[] scenesActive = UnityEditor.EditorBuildSettingsScene.GetActiveSceneList(UnityEditor.EditorBuildSettings.scenes); // 씬 중 활성화된 씬만 가져온다.
        BuildPipeline.BuildPlayer(scene, path + "./test.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
    }
}