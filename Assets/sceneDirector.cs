using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class sceneDirector : MonoBehaviour
{
    public string _RemoteBundleURL;     // https://drive.google.com/uc?id=1WuactX0T18zWR5Lh2mcj0Enh4Jxf1Bv1&export=download
    public string _AssetName;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void OnBtnResourceLoad()
    {
        StartCoroutine(coLoadResourceObject());
    }
    public void OnBtnDownloadAssetBundle()
    {
        StartCoroutine(coDownloadAssetBundle());
    }

    IEnumerator coLoadResourceObject()
    {
        ResourceRequest req = Resources.LoadAsync<GameObject>("ColorCandyPNG");
        yield return req;

        GameObject.Instantiate(req.asset);
    }

    IEnumerator coDownloadAssetBundle()
    {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(_RemoteBundleURL);
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            if(bundle != null)
            {
                GameObject prefab = bundle.LoadAsset<GameObject>(_AssetName);
                if(prefab != null)
                    Instantiate( prefab );
                else 
                    Debug.Log("Prefab is NULL!");

                // Unload the AssetBundles compressed contents to conserve memory
                bundle.Unload(false);
            }
            else 
                Debug.Log("Bundle is NULL!");
             
        }
    }
}
