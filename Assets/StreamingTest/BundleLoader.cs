using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using AssetBundles;

public class BundleLoader : MonoBehaviour
{

//  public string assetBundleName;
//  public string assetName;

  // Use this for initialization
  IEnumerator Start()
  {
    yield return StartCoroutine(Initialize());

    //yield return StartCoroutine(InstantiateGameObjectAsync(assetBundleName, assetName));

  }

  protected IEnumerator Initialize()
  {
    DontDestroyOnLoad(gameObject);
#if DEVELOPMENT_BUILD || UNITY_EDITOR
    AssetBundleManager.SetDevelopmentAssetBundleServer();
#else
    // Use the following code if AssetBundles are embedded in the project for example via StreamingAssets folder etc:
		AssetBundleManager.SetSourceAssetBundleURL(Application.streamingAssetsPath + "/");
		// Or customize the URL based on your deployment or configuration
		//AssetBundleManager.SetSourceAssetBundleURL("http://www.MyWebsite/MyAssetBundles");
#endif

    var request = AssetBundleManager.Initialize();
    if (request != null)
      yield return StartCoroutine(request);

  }

  protected IEnumerator InstantiateGameObjectAsync(string assetbundleName, string assetName)
  {

    AssetBundleLoadAssetOperation request = AssetBundleManager.LoadAssetAsync(assetbundleName, assetName, typeof(GameObject));
    if (request == null)
      Debug.Log("null request object detected");
      yield break;
    yield return StartCoroutine(request);


    GameObject prefab = request.GetAsset<GameObject>();

    if (prefab != null)
      GameObject.Instantiate(prefab);
  }

  //enter asset bundle and name in one string delimited by a ':' ie cube_bundle:cube_mat
  //I'll figure something better out in production
  public void Load(string assetbundle)
  {
    Debug.Log("loading " + assetbundle);
    string[] parsed = assetbundle.Split(':');
    string bundle = parsed[0];
    string asset = parsed[1];
    Debug.Log("bundle: " + bundle + " asset: " + asset);
    //    StartCoroutine(InstantiateGameObjectAsync(bundle, asset));
    StartCoroutine(DownloadAssetBundle(bundle, asset));
  }

  IEnumerator DownloadAssetBundle(string bundle, string asset)
  {
    UnityWebRequest www = UnityWebRequest.GetAssetBundle(Application.streamingAssetsPath + '/' + bundle);
    yield return www.Send();

    if (www.isError)
    {
      Debug.Log(www.error);
    }
    else
    {
      AssetBundle b = ((DownloadHandlerAssetBundle)www.downloadHandler).assetBundle;
      GameObject prefab = b.LoadAsset(asset, typeof(GameObject)) as GameObject;

      if (prefab != null)
        GameObject.Instantiate(prefab);


    }
  }
}
