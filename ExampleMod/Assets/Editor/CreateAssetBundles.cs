using UnityEditor;
using System.IO;
using NUnit.Framework.Constraints;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        var path = System.IO.Directory.GetCurrentDirectory();
        var assetBundleDirectory = path + @"\..\ExampleModOutput\";
        
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
    }
}