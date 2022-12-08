using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class passageLink : ScriptableObject
{
    public string PassageName;

    [SerializeField] public sceneLinker mySceneLinker;

    [SerializeField] public passageLink ToPassageLink;



#if UNITY_EDITOR

    public void Instantiate(sceneLinker sceneLinker)
    {
        mySceneLinker = sceneLinker;
    }
#endif

}
