using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator transition;

    public float transitionTime = 1f;
    public Canvas canvas1;
    public Canvas canvas2;

    public void GoToLevel(int sceneIndex)
    {
        LevelManager.instance.loadLevelAsyncWithIndex(sceneIndex);
    }
    public void GoToMenu(int canvas)
    {
        StartCoroutine(LoadOtherCanvas(canvas));
    }
    IEnumerator LoadOtherCanvas(int canvas)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("end");

        if (canvas == 1)
        {
            canvas1.enabled = true;
            canvas2.enabled = false;

        }
        else
        {
            canvas1.enabled = false;
            canvas2.enabled = true;
        }

    }


}
