using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_script : MonoBehaviour {

    public GameObject[] nonMobiles;

    void Start()
    {

    if (nonMobiles == null)
    {

            nonMobiles = GameObject.FindGameObjectsWithTag("NonMobile");

    }



    #if (UNITY_IOS || UNITY_ANDROID)
        
        foreach (GameObject nonMobile in nonMobiles({

            nonMobile.SetActive(false);

        }

    #endif

    }

    public void LoadByIndex(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex);

    }
    
    public void QuitGame(int flags)
    {

    #if !UNITY_IOS && !UNITY_ANDROID
        Application.Quit();
    #endif

    }

}
