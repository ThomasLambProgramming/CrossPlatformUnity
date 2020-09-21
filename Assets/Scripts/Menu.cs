using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoader : MonoBehaviour
{
    
    public Animator transition;
    public float transitionTime = 1f;
    // Update is called once per frame
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        //wait
        
        SceneManager.LoadScene(levelIndex);

        //load scene
    }
    public void Quit()
    {
        Application.Quit();
    }
}
