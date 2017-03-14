using UnityEngine;
using UnityEditor;

public class CreateAssetBundle : Editor {

	[MenuItem("Assets/Build AssetBundles")]
	static void BuildAllAssetBundle()
	{
		Object[] SelectedAsset = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);
		BuildPipeline.BuildAssetBundles ("Assetbundles",BuildAssetBundleOptions.None,BuildTarget.iOS);
	}


}
