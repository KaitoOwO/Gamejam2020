using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public float transitionTime = 1f;
    public Animator transition;
    public static LevelManager instance;


    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


    }
    public void RestartScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        loadLevelWithIndex(0);
    }


    public void loadLevelWithIndex(int index)
    {
        StartCoroutine(LoadLevel(index));
    }

    public void loadLevelAsyncWithIndex(int index)
    {
        StartCoroutine(LoadLevel(index));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.ResetTrigger("end");
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
        transition.SetTrigger("end");
        transition.ResetTrigger("start");


    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        transition.SetTrigger("end");
        transition.SetTrigger("start");

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);

            yield return null;
        }
        transition.ResetTrigger("end");
        transition.ResetTrigger("start");
    }
}
