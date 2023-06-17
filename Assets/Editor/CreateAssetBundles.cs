using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateAssetBundles
{
    [MenuItem ("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles ()
    {
        BuildPipeline.BuildAssetBundles ("Assets/Bundles", BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}
