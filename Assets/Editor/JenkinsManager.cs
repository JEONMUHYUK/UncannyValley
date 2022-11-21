using UnityEditor;

public class BuidlScript
{
    [UnityEditor.MenuItem("MyMenu/Build/Builded",false,1)]
    static void MyPerforBuild()
    {
        string[] scene = { "Assets/Scene/SampleScene.unity" };
        BuildPipeline.BuildPlayer(scene,"mygame.exe",BuildTarget.StandaloneWindows64,BuildOptions.None);
    }
}
