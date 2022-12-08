using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEditor;

public class sceneManager : MonoBehaviour
{
    public GameObject player; //temporary, a game manager will replace this functionality



    [SerializeField] private Animator fadeAnimator;

    private string goingToAdress;
    private string goingToPassageName;


    [SerializeField] private passageLink[] passageLinks;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // TEMP //
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        player.transform.position = getPassageByName(goingToPassageName).gameObject.transform.GetChild(0).transform.position;
    }

    passageLink getPassageLinkByName(string name)
    {
        foreach (passageLink passlink in passageLinks)
        {
            if (passlink.PassageName == name)
            {
                return passlink;
            }
        }
        return null;
    }

    Passage getPassageByName(string name)
    {
        GameObject[] passages = GameObject.FindGameObjectsWithTag("Passage");
        foreach (GameObject pass in passages)
        {            

            if(pass.GetComponent<Passage>().PassageName == name)
            {
                // TEMP //
                pass.GetComponent<Passage>().SM = this;

                return pass.GetComponent<Passage>();
            }
        }
        return null;
    }

    public void GoThroughPassage(string passageName)
    {
        passageLink passlink = getPassageLinkByName(passageName);
        goingToPassageName = passlink.ToPassageLink.PassageName;
        FadeOutScene(passlink.ToPassageLink.mySceneLinker.scene);
    }

    private void FadeOutScene(string gotoAddress)
    {
        fadeAnimator.SetTrigger("fadeout");
        goingToAdress = gotoAddress;
    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(goingToAdress);
        fadeAnimator.SetTrigger("fadein");
    }

}
