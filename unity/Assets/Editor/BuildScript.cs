using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class BuildScript
{
    public static void PerformBuild()
    {
        PlayerSettings.WebGL.template = "PROJECT:VirusMania";
        PlayerSettings.SetGraphicsAPIs(BuildTarget.WebGL, new[] { GraphicsDeviceType.OpenGLES3 });
        
        string buildPath = "Build/WebGL";
        string[] scenes = new string[] {
            "Assets/Scenes/World.unity"
        };

        BuildPipeline.BuildPlayer(scenes, buildPath, BuildTarget.WebGL, BuildOptions.None);
        Debug.Log("Build WebGL terminé dans " + buildPath);
    }
}