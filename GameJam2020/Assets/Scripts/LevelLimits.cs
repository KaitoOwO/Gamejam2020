using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelLimits : MonoBehaviour
{
    // Start is called before the first frame updatein

    public int sceneIndex = 0;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            AudioManager.instance.Play("Dead");
            other.enabled = false;
            other.gameObject.GetComponent<Animator>().SetTrigger("Dead");
            LevelManager.instance.loadLevelAsyncWithIndex(sceneIndex);
        }
    }
}
