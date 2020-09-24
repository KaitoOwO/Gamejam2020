using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public float transitionTime = 1f;
    public Animator transition;
    public static LevelManager instance;
    public bool onTransition = false;

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
        if (!onTransition)
        {
            StartCoroutine(LoadLevel(index));

        }
    }

    public void loadLevelAsyncWithIndex(int index)
    {

        if (!onTransition)
        {
            StartCoroutine(LoadLevel(index));

        }
    }

    public void loadLevelSelectionScreen()
    {
        if (!onTransition)
        {
            StartCoroutine(LoadAsyncMainMenu(0));
        }

    }
    IEnumerator LoadLevel(int levelIndex)
    {
        onTransition = true;
        transition.ResetTrigger("end");
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        onTransition = false;
        transition.SetTrigger("end");
        transition.ResetTrigger("start");

    }


    IEnumerator LoadAsync(int sceneIndex)
    {
        onTransition = true;
        transition.ResetTrigger("end");
        transition.SetTrigger("start");

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        yield return new WaitForSeconds(transitionTime);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            yield return null;
        }

        onTransition = false;

        transition.SetTrigger("end");
        transition.ResetTrigger("start");
    }


    IEnumerator LoadAsyncMainMenu(int sceneIndex)
    {
        onTransition = true;
        transition.SetTrigger("end");
        transition.SetTrigger("start");
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        yield return new WaitForSeconds(transitionTime);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            yield return null;
        }

        onTransition = false;

        MenuManager[] menuManager = FindObjectsOfType<MenuManager>();
        menuManager[0].canvas1.enabled = false;
        menuManager[0].canvas2.enabled = true;
        transition.ResetTrigger("end");
        transition.ResetTrigger("start");
    }
}
