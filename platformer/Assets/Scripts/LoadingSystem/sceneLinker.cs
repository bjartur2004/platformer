using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneReferance;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "NewSceneLinker", menuName = "ScriptableObject/SceneLinker")]
public class sceneLinker : ScriptableObject
{
    public SceneReference scene;

    public List<passageLink> passageLinks = new List<passageLink>();



#if UNITY_EDITOR

    [ContextMenu("Add PassageLink")]
    private void addPassageLink()
    {
        passageLink passageLink = ScriptableObject.CreateInstance<passageLink>();

        passageLink.name = "NewSceneLinker";

        passageLink.Instantiate(this);
        passageLinks.Add(passageLink);

        AssetDatabase.AddObjectToAsset(passageLink, this);
        AssetDatabase.SaveAssets();

        EditorUtility.SetDirty(this);
        EditorUtility.SetDirty(passageLink);
    }

#endif

}
