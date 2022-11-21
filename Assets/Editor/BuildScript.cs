
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
        string[] scenesActive = UnityEditor.EditorBuildSettingsScene.GetActiveSceneList(UnityEditor.EditorBuildSettings.scenes); // �� �� Ȱ��ȭ�� ���� �����´�.
        BuildPipeline.BuildPlayer(scene, path + "./test.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
    }
}