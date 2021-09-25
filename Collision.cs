
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1.5f;
     void OnCollisionEnter(UnityEngine.Collision other)

     {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                    break;
            case "Finish":
                StartSucessSequence();
                break;
            case "Fuel":
                Debug.Log("Fuel has been added");
                break;
            default:
                StartCrashSequence();
                break;
        }
     }

    private void StartSucessSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        // todo add SFX upon crash
        //todo add partice effect for crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);

    }


    void LoadNextLevel()
    {
        int currectSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currectSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex );
    }

    void ReloadLevel()
    {
        int currectSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currectSceneIndex);
    }
}
