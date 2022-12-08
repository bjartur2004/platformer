using UnityEngine;


class OnAppStart
{
    //private GameObject sceneManagerPrefab;



    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnAfterSceneLoadRuntimeMethod()
    {
        //sceneManagerPrefab = GameObject.Find("sceneManager");


    }
}
